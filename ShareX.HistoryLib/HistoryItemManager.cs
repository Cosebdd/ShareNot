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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ShareNot.HelpersLib.Extensions;
using ShareNot.HelpersLib.Forms;
using ShareNot.HelpersLib.Helpers;
using ShareNot.HistoryLib.Forms;

namespace ShareNot.HistoryLib
{
    public partial class HistoryItemManager
    {
        public delegate HistoryItem[] GetHistoryItemsEventHandler();

        public event GetHistoryItemsEventHandler GetHistoryItems;

        public HistoryItem HistoryItem { get; private set; }

        public bool IsFilePathValid { get; private set; }
        public bool IsFileExist { get; private set; }
        public bool IsImageFile { get; private set; }
        public bool IsTextFile { get; private set; }

        private Action<string> editImage, pinToScreen;

        public HistoryItemManager(Action<string> editImage, Action<string> pinToScreen, bool hideShowMoreInfoButton = false)
        {
            this.editImage = editImage;
            this.pinToScreen = pinToScreen;

            InitializeComponent();

            tsmiOpen.HideImageMargin();
            tsmiCopy.HideImageMargin();
            tsmiEditImage.Visible = editImage != null;
            tsmiPinToScreen.Visible = pinToScreen != null;
            tsmiShowMoreInfo.Visible = !hideShowMoreInfoButton;
        }

        public HistoryItem UpdateSelectedHistoryItem()
        {
            HistoryItem[] historyItems = OnGetHistoryItems();

            if (historyItems != null && historyItems.Length > 0)
            {
                HistoryItem = historyItems[0];
            }
            else
            {
                HistoryItem = null;
            }

            if (HistoryItem != null)
            {
                IsFilePathValid = !string.IsNullOrEmpty(HistoryItem.FilePath) && Path.HasExtension(HistoryItem.FilePath);
                IsFileExist = IsFilePathValid && File.Exists(HistoryItem.FilePath);
                IsImageFile = IsFileExist && FileHelpers.IsImageFile(HistoryItem.FilePath);
                IsTextFile = IsFileExist && FileHelpers.IsTextFile(HistoryItem.FilePath);

                UpdateContextMenu(historyItems.Length);
            }
            else
            {
                cmsHistory.Enabled = false;
            }

            return HistoryItem;
        }

        public HistoryItem[] OnGetHistoryItems()
        {
            if (GetHistoryItems != null)
            {
                return GetHistoryItems();
            }

            return null;
        }

        public bool HandleKeyInput(KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                default:
                    return false;
                case Keys.Enter:
                    TryOpen();
                    break;
                case Keys.Control | Keys.Enter:
                    OpenFile();
                    break;
                case Keys.Shift | Keys.Enter:
                    OpenFolder();
                    break;
                case Keys.Shift | Keys.C:
                    CopyFile();
                    break;
                case Keys.Alt | Keys.C:
                    CopyImage();
                    break;
                case Keys.Control | Keys.Shift | Keys.C:
                    CopyFilePath();
                    break;
                case Keys.Control | Keys.E:
                    EditImage();
                    break;
                case Keys.Control | Keys.P:
                    PinToScreen();
                    break;
            }

            return true;
        }

        public void OpenFile()
        {
            if (HistoryItem != null && IsFileExist) FileHelpers.OpenFile(HistoryItem.FilePath);
        }

        public void OpenFolder()
        {
            if (HistoryItem != null && IsFileExist) FileHelpers.OpenFolderWithFile(HistoryItem.FilePath);
        }

        public void TryOpen()
        {
            if (HistoryItem != null)
            {
                if (IsFileExist)
                {
                    FileHelpers.OpenFile(HistoryItem.FilePath);
                }
            }
        }

        public void CopyFile()
        {
            HistoryItem[] historyItems = OnGetHistoryItems();
            if (historyItems != null)
            {
                string[] array = historyItems.Where(x => x != null && !string.IsNullOrEmpty(x.FilePath) && Path.HasExtension(x.FilePath) &&
                    File.Exists(x.FilePath)).Select(x => x.FilePath).ToArray();

                if (array != null && array.Length > 0)
                {
                    ClipboardHelpers.CopyFile(array);
                }
            }
        }

        public void CopyImage()
        {
            if (HistoryItem != null && IsImageFile) ClipboardHelpers.CopyImageFromFile(HistoryItem.FilePath);
        }

        public void CopyText()
        {
            if (HistoryItem != null && IsTextFile) ClipboardHelpers.CopyTextFromFile(HistoryItem.FilePath);
        }

        public void CopyFilePath()
        {
            HistoryItem[] historyItems = OnGetHistoryItems();
            if (historyItems != null)
            {
                string[] array = historyItems.Where(x => x != null && !string.IsNullOrEmpty(x.FilePath) && Path.HasExtension(x.FilePath) &&
                    File.Exists(x.FilePath)).Select(x => x.FilePath).ToArray();

                if (array != null && array.Length > 0)
                {
                    string filePaths = string.Join("\r\n", array);

                    if (!string.IsNullOrEmpty(filePaths))
                    {
                        ClipboardHelpers.CopyText(filePaths);
                    }
                }
            }
        }

        public void CopyFileName()
        {
            HistoryItem[] historyItems = OnGetHistoryItems();
            if (historyItems != null)
            {
                string[] array = historyItems.Where(x => x != null && !string.IsNullOrEmpty(x.FilePath) && Path.HasExtension(x.FilePath)).
                    Select(x => Path.GetFileNameWithoutExtension(x.FilePath)).ToArray();

                if (array != null && array.Length > 0)
                {
                    string fileNames = string.Join("\r\n", array);

                    if (!string.IsNullOrEmpty(fileNames))
                    {
                        ClipboardHelpers.CopyText(fileNames);
                    }
                }
            }
        }

        public void CopyFileNameWithExtension()
        {
            HistoryItem[] historyItems = OnGetHistoryItems();
            if (historyItems != null)
            {
                string[] array = historyItems.Where(x => x != null && !string.IsNullOrEmpty(x.FilePath) && Path.HasExtension(x.FilePath)).
                    Select(x => Path.GetFileName(x.FilePath)).ToArray();

                if (array != null && array.Length > 0)
                {
                    string fileNamesWithExtension = string.Join("\r\n", array);

                    if (!string.IsNullOrEmpty(fileNamesWithExtension))
                    {
                        ClipboardHelpers.CopyText(fileNamesWithExtension);
                    }
                }
            }
        }

        public void CopyFolder()
        {
            HistoryItem[] historyItems = OnGetHistoryItems();
            if (historyItems != null)
            {
                string[] array = historyItems.Where(x => x != null && !string.IsNullOrEmpty(x.FilePath) && Path.HasExtension(x.FilePath)).
                    Select(x => Path.GetDirectoryName(x.FilePath)).ToArray();

                if (array != null && array.Length > 0)
                {
                    string folderPaths = string.Join("\r\n", array);

                    if (!string.IsNullOrEmpty(folderPaths))
                    {
                        ClipboardHelpers.CopyText(folderPaths);
                    }
                }
            }
        }

        public void ShowImagePreview()
        {
            if (HistoryItem != null && IsImageFile) ImageViewer.ShowImage(HistoryItem.FilePath);
        }

        public void EditImage()
        {
            if (editImage != null && HistoryItem != null && IsImageFile) editImage(HistoryItem.FilePath);
        }

        public void PinToScreen()
        {
            if (pinToScreen != null && HistoryItem != null && IsImageFile) pinToScreen(HistoryItem.FilePath);
        }

        public void ShowMoreInfo()
        {
            new HistoryItemInfoForm(HistoryItem).Show();
        }
    }
}