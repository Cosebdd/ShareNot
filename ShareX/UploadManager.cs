#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2024 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShareNot.Forms;
using ShareNot.HelpersLib;
using ShareNot.HelpersLib.Helpers;
using ShareNot.HelpersLib.Native;
using ShareNot.IndexerLib;
using ShareNot.Properties;

namespace ShareNot
{
    public static class UploadManager
    {
        public static void ProcessImageUpload(Bitmap bmp, TaskSettings taskSettings)
        {
            if (bmp != null)
            {
                RunImageTask(bmp, taskSettings);
            }
        }

        public static void ClipboardUpload(TaskSettings taskSettings = null)
        {
            if (taskSettings == null) taskSettings = TaskSettings.GetDefaultTaskSettings();

            try
            {
                if (Clipboard.ContainsImage())
                {
                    Bitmap image;

                    if (HelpersOptions.UseAlternativeClipboardGetImage)
                    {
                        image = ClipboardHelpers.GetImageAlternative2();
                    }
                    else
                    {
                        image = (Bitmap)Clipboard.GetImage();
                    }

                    ProcessImageUpload(image, taskSettings);
                }
            }
            catch (ExternalException e)
            {
                DebugHelper.WriteException(e);

                if (MessageBox.Show("\"" + e.Message + "\"\r\n\r\n" + Resources.WouldYouLikeToRetryClipboardUpload, "ShareNot - " + Resources.ClipboardUpload,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ClipboardUpload(taskSettings);
                }
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }
        }

        public static void ClipboardUploadWithContentViewer(TaskSettings taskSettings = null)
        {
            if (taskSettings == null) taskSettings = TaskSettings.GetDefaultTaskSettings();

            using (ClipboardUploadForm clipboardUploadForm = new ClipboardUploadForm(taskSettings))
            {
                clipboardUploadForm.ShowDialog();
            }
        }

        public static void ClipboardUploadMainWindow(TaskSettings taskSettings = null)
        {
            if (taskSettings == null) taskSettings = TaskSettings.GetDefaultTaskSettings();

            if (Program.Settings.ShowClipboardContentViewer)
            {
                using (ClipboardUploadForm clipboardUploadForm = new ClipboardUploadForm(taskSettings, true))
                {
                    clipboardUploadForm.ShowDialog();
                    Program.Settings.ShowClipboardContentViewer = !clipboardUploadForm.DontShowThisWindow;
                }
            }
            else
            {
                ClipboardUpload(taskSettings);
            }
        }

        public static void DragDropUpload(IDataObject data, TaskSettings taskSettings = null)
        {
            if (taskSettings == null) taskSettings = TaskSettings.GetDefaultTaskSettings();

            else if (data.GetDataPresent(DataFormats.Bitmap, false))
            {
                Bitmap bmp = data.GetData(DataFormats.Bitmap, false) as Bitmap;
                RunImageTask(bmp, taskSettings);
            }
        }

        public static void RunImageTask(Bitmap bmp, TaskSettings taskSettings, bool skipQuickTaskMenu = false, bool skipAfterCaptureWindow = false)
        {
            TaskMetadata metadata = new TaskMetadata(bmp);
            RunImageTask(metadata, taskSettings, skipQuickTaskMenu, skipAfterCaptureWindow);
        }

        public static void RunImageTask(TaskMetadata metadata, TaskSettings taskSettings, bool skipQuickTaskMenu = false, bool skipAfterCaptureWindow = false)
        {
            if (taskSettings == null) taskSettings = TaskSettings.GetDefaultTaskSettings();

            if (metadata != null && metadata.Image != null && taskSettings != null)
            {
                if (!skipQuickTaskMenu && taskSettings.AfterCaptureJob.HasFlag(AfterCaptureTasks.ShowQuickTaskMenu))
                {
                    QuickTaskMenu quickTaskMenu = new QuickTaskMenu();

                    quickTaskMenu.TaskInfoSelected += taskInfo =>
                    {
                        if (taskInfo == null)
                        {
                            RunImageTask(metadata, taskSettings, true);
                        }
                        else if (taskInfo.IsValid)
                        {
                            taskSettings.AfterCaptureJob = taskInfo.AfterCaptureTasks;
                            RunImageTask(metadata, taskSettings, true);
                        }
                    };

                    quickTaskMenu.ShowMenu();

                    return;
                }

                string customFileName = null;

                if (!skipAfterCaptureWindow && !TaskHelpers.ShowAfterCaptureForm(taskSettings, out customFileName, metadata))
                {
                    return;
                }

                WorkerTask task = WorkerTask.CreateImageUploaderTask(metadata, taskSettings, customFileName);
                TaskManager.Start(task);
            }
        }

        public static void UploadImage(Bitmap bmp, TaskSettings taskSettings = null)
        {
            if (bmp != null)
            {
                if (taskSettings == null)
                {
                    taskSettings = TaskSettings.GetDefaultTaskSettings();
                }

                if (taskSettings.IsSafeTaskSettings)
                {
                    taskSettings.UseDefaultAfterCaptureJob = false;
                }

                RunImageTask(bmp, taskSettings);
            }
        }

        public static void IndexFolder(TaskSettings taskSettings = null)
        {
            using (FolderSelectDialog dlg = new FolderSelectDialog())
            {
                if (dlg.ShowDialog())
                {
                    IndexFolder(dlg.FileName, taskSettings);
                }
            }
        }

        public static void IndexFolder(string folderPath, TaskSettings taskSettings = null)
        {
            if (!string.IsNullOrEmpty(folderPath) && Directory.Exists(folderPath))
            {
                if (taskSettings == null) taskSettings = TaskSettings.GetDefaultTaskSettings();

                taskSettings.ToolsSettings.IndexerSettings.BinaryUnits = Program.Settings.BinaryUnits;

                Task.Run(() =>
                {
                    Indexer.Index(folderPath, taskSettings.ToolsSettings.IndexerSettings);
                });
            }
        }
    }
}