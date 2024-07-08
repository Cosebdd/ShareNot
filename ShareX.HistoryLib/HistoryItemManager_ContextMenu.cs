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
using System.Windows.Forms;
using ShareNot.HistoryLib.Properties;

namespace ShareNot.HistoryLib
{
    public partial class HistoryItemManager
    {
        public ContextMenuStrip cmsHistory;

        private ToolStripMenuItem tsmiOpen;
        private ToolStripSeparator tssOpen1;
        private ToolStripMenuItem tsmiOpenFile;
        private ToolStripMenuItem tsmiOpenFolder;

        private ToolStripMenuItem tsmiCopy;
        private ToolStripMenuItem tsmiCopyFile;
        private ToolStripMenuItem tsmiCopyImage;
        private ToolStripMenuItem tsmiCopyText;
        private ToolStripSeparator tssCopy2;
        private ToolStripMenuItem tsmiCopyFilePath;
        private ToolStripMenuItem tsmiCopyFileName;
        private ToolStripMenuItem tsmiCopyFileNameWithExtension;
        private ToolStripMenuItem tsmiCopyFolder;

        private ToolStripMenuItem tsmiShowImagePreview;
        private ToolStripMenuItem tsmiEditImage;
        private ToolStripMenuItem tsmiPinToScreen;
        private ToolStripMenuItem tsmiShowMoreInfo;

        private void InitializeComponent()
        {
            cmsHistory = new ContextMenuStrip();

            tsmiOpen = new ToolStripMenuItem();
            tssOpen1 = new ToolStripSeparator();
            tsmiOpenFile = new ToolStripMenuItem();
            tsmiOpenFolder = new ToolStripMenuItem();

            tsmiCopy = new ToolStripMenuItem();
            tsmiCopyFile = new ToolStripMenuItem();
            tsmiCopyImage = new ToolStripMenuItem();
            tsmiCopyText = new ToolStripMenuItem();
            tssCopy2 = new ToolStripSeparator();
            tsmiCopyFilePath = new ToolStripMenuItem();
            tsmiCopyFileName = new ToolStripMenuItem();
            tsmiCopyFileNameWithExtension = new ToolStripMenuItem();
            tsmiCopyFolder = new ToolStripMenuItem();

            tsmiShowImagePreview = new ToolStripMenuItem();
            tsmiEditImage = new ToolStripMenuItem();
            tsmiPinToScreen = new ToolStripMenuItem();
            tsmiShowMoreInfo = new ToolStripMenuItem();

            cmsHistory.SuspendLayout();

            //
            // cmsHistory
            //
            cmsHistory.Items.AddRange(new ToolStripItem[]
            {
                tsmiOpen,
                tsmiCopy,
                tsmiShowImagePreview,
                tsmiEditImage,
                tsmiPinToScreen,
                tsmiShowMoreInfo
            });
            cmsHistory.Name = "cmsHistory";
            cmsHistory.ShowImageMargin = false;
            cmsHistory.Size = new Size(128, 92);
            cmsHistory.Enabled = false;
            //
            // tsmiOpen
            //
            tsmiOpen.DropDownItems.AddRange(new ToolStripItem[]
            {
                tssOpen1,
                tsmiOpenFile,
                tsmiOpenFolder
            });
            tsmiOpen.Name = "tsmiOpen";
            tsmiOpen.Size = new Size(127, 22);
            tsmiOpen.Text = Resources.HistoryItemManager_InitializeComponent_Open;
            //
            // tssOpen1
            //
            tssOpen1.Name = "tssOpen1";
            tssOpen1.Size = new Size(153, 6);
            //
            // tsmiOpenFile
            //
            tsmiOpenFile.Name = "tsmiOpenFile";
            tsmiOpenFile.ShortcutKeyDisplayString = "Ctrl+Enter";
            tsmiOpenFile.Size = new Size(156, 22);
            tsmiOpenFile.Text = Resources.HistoryItemManager_InitializeComponent_File;
            tsmiOpenFile.Click += tsmiOpenFile_Click;
            //
            // tsmiOpenFolder
            //
            tsmiOpenFolder.Name = "tsmiOpenFolder";
            tsmiOpenFolder.ShortcutKeyDisplayString = "Shift+Enter";
            tsmiOpenFolder.Size = new Size(156, 22);
            tsmiOpenFolder.Text = Resources.HistoryItemManager_InitializeComponent_Folder;
            tsmiOpenFolder.Click += tsmiOpenFolder_Click;
            //
            // tsmiCopy
            //
            tsmiCopy.DropDownItems.AddRange(new ToolStripItem[]
            {
                tsmiCopyFile,
                tsmiCopyImage,
                tsmiCopyText,
                tssCopy2,
                tsmiCopyFilePath,
                tsmiCopyFileName,
                tsmiCopyFileNameWithExtension,
                tsmiCopyFolder
            });
            tsmiCopy.Name = "tsmiCopy";
            tsmiCopy.Size = new Size(127, 22);
            tsmiCopy.Text = Resources.HistoryItemManager_InitializeComponent_Copy;
            //
            // tsmiCopyFile
            //
            tsmiCopyFile.Name = "tsmiCopyFile";
            tsmiCopyFile.ShortcutKeyDisplayString = "Shift+C";
            tsmiCopyFile.Size = new Size(233, 22);
            tsmiCopyFile.Text = Resources.HistoryItemManager_InitializeComponent_File;
            tsmiCopyFile.Click += tsmiCopyFile_Click;
            //
            // tsmiCopyImage
            //
            tsmiCopyImage.Name = "tsmiCopyImage";
            tsmiCopyImage.ShortcutKeyDisplayString = "Alt+C";
            tsmiCopyImage.Size = new Size(233, 22);
            tsmiCopyImage.Text = Resources.HistoryItemManager_InitializeComponent_Image;
            tsmiCopyImage.Click += tsmiCopyImage_Click;
            //
            // tsmiCopyText
            //
            tsmiCopyText.Name = "tsmiCopyText";
            tsmiCopyText.Size = new Size(233, 22);
            tsmiCopyText.Text = Resources.HistoryItemManager_InitializeComponent_Text;
            tsmiCopyText.Click += tsmiCopyText_Click;
            //
            // tssCopy2
            //
            tssCopy2.Name = "tssCopy2";
            tssCopy2.Size = new Size(230, 6);
            //
            // tsmiCopyFilePath
            //
            tsmiCopyFilePath.Name = "tsmiCopyFilePath";
            tsmiCopyFilePath.ShortcutKeyDisplayString = "Ctrl+Shift+C";
            tsmiCopyFilePath.Size = new Size(233, 22);
            tsmiCopyFilePath.Text = Resources.HistoryItemManager_InitializeComponent_File_path;
            tsmiCopyFilePath.Click += tsmiCopyFilePath_Click;
            //
            // tsmiCopyFileName
            //
            tsmiCopyFileName.Name = "tsmiCopyFileName";
            tsmiCopyFileName.Size = new Size(233, 22);
            tsmiCopyFileName.Text = Resources.HistoryItemManager_InitializeComponent_File_name;
            tsmiCopyFileName.Click += tsmiCopyFileName_Click;
            //
            // tsmiCopyFileNameWithExtension
            //
            tsmiCopyFileNameWithExtension.Name = "tsmiCopyFileNameWithExtension";
            tsmiCopyFileNameWithExtension.Size = new Size(233, 22);
            tsmiCopyFileNameWithExtension.Text = Resources.HistoryItemManager_InitializeComponent_File_name_with_extension;
            tsmiCopyFileNameWithExtension.Click += tsmiCopyFileNameWithExtension_Click;
            //
            // tsmiCopyFolder
            //
            tsmiCopyFolder.Name = "tsmiCopyFolder";
            tsmiCopyFolder.Size = new Size(233, 22);
            tsmiCopyFolder.Text = Resources.HistoryItemManager_InitializeComponent_Folder;
            tsmiCopyFolder.Click += tsmiCopyFolder_Click;
            //
            // tsmiShowImagePreview
            //
            tsmiShowImagePreview.Name = "tsmiShowImagePreview";
            tsmiShowImagePreview.Size = new Size(127, 22);
            tsmiShowImagePreview.Text = Resources.HistoryItemManager_InitializeComponent_Image_preview;
            tsmiShowImagePreview.Click += tsmiShowImagePreview_Click;
            //
            // tsmiEditImage
            //
            tsmiEditImage.Name = "tsmiEditImage";
            tsmiEditImage.ShortcutKeyDisplayString = "Ctrl+E";
            tsmiEditImage.Size = new Size(127, 22);
            tsmiEditImage.Text = Resources.HistoryItemManager_InitializeComponent_EditImage;
            tsmiEditImage.Click += tsmiEditImage_Click;
            //
            // tsmiPinToScreen
            //
            tsmiPinToScreen.Name = "tsmiPinToScreen";
            tsmiPinToScreen.ShortcutKeyDisplayString = "Ctrl+P";
            tsmiPinToScreen.Size = new Size(127, 22);
            tsmiPinToScreen.Text = Resources.PinToScreen;
            tsmiPinToScreen.Click += tsmiPinToScreen_Click;
            //
            // tsmiShowMoreInfo
            //
            tsmiShowMoreInfo.Name = "tsmiShowMoreInfo";
            tsmiShowMoreInfo.Size = new Size(127, 22);
            tsmiShowMoreInfo.Text = Resources.HistoryItemManager_InitializeComponent_More_info;
            tsmiShowMoreInfo.Click += tsmiShowMoreInfo_Click;

            cmsHistory.ResumeLayout(false);
        }

        public void UpdateContextMenu(int itemCount)
        {
            cmsHistory.SuspendLayout();
            cmsHistory.Enabled = true;

            if (itemCount > 1)
            {
                tsmiOpenFile.Enabled = false;
                tsmiOpenFolder.Enabled = false;

                // Copy
                tsmiCopyFile.Enabled = true;
                tsmiCopyImage.Enabled = false;
                tsmiCopyText.Enabled = false;

                tsmiCopyFilePath.Enabled = true;
                tsmiCopyFileName.Enabled = true;
                tsmiCopyFileNameWithExtension.Enabled = true;
                tsmiCopyFolder.Enabled = true;

                tsmiCopyFile.Text = Resources.HistoryItemManager_InitializeComponent_File + " (" + itemCount + ")";
                tsmiCopyFilePath.Text = Resources.HistoryItemManager_InitializeComponent_File_path + " (" + itemCount + ")";
                tsmiCopyFileName.Text = Resources.HistoryItemManager_InitializeComponent_File_name + " (" + itemCount + ")";
                tsmiCopyFileNameWithExtension.Text = Resources.HistoryItemManager_InitializeComponent_File_name_with_extension + " (" + itemCount + ")";
                tsmiCopyFolder.Text = Resources.HistoryItemManager_InitializeComponent_Folder + " (" + itemCount + ")";

                // Other
                tsmiShowImagePreview.Enabled = false;
                tsmiEditImage.Enabled = false;
                tsmiPinToScreen.Enabled = false;
                tsmiShowMoreInfo.Enabled = false;
            }
            else
            {
                // Open
                tsmiOpenFile.Enabled = IsFileExist;
                tsmiOpenFolder.Enabled = IsFileExist;

                // Copy
                tsmiCopyFile.Enabled = IsFileExist;
                tsmiCopyImage.Enabled = IsImageFile;
                tsmiCopyText.Enabled = IsTextFile;

                tsmiCopyFilePath.Enabled = IsFilePathValid;
                tsmiCopyFileName.Enabled = IsFilePathValid;
                tsmiCopyFileNameWithExtension.Enabled = IsFilePathValid;
                tsmiCopyFolder.Enabled = IsFilePathValid;

                tsmiCopyFile.Text = Resources.HistoryItemManager_InitializeComponent_File;
                tsmiCopyFilePath.Text = Resources.HistoryItemManager_InitializeComponent_File_path;
                tsmiCopyFileName.Text = Resources.HistoryItemManager_InitializeComponent_File_name;
                tsmiCopyFileNameWithExtension.Text = Resources.HistoryItemManager_InitializeComponent_File_name_with_extension;
                tsmiCopyFolder.Text = Resources.HistoryItemManager_InitializeComponent_Folder;

                // Other
                tsmiShowImagePreview.Enabled = IsImageFile;
                tsmiEditImage.Enabled = editImage != null && IsImageFile;
                tsmiPinToScreen.Enabled = pinToScreen != null && IsImageFile;
                tsmiShowMoreInfo.Enabled = true;
            }

            cmsHistory.ResumeLayout();
        }

        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void tsmiOpenFolder_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private void tsmiCopyFile_Click(object sender, EventArgs e)
        {
            CopyFile();
        }

        private void tsmiCopyImage_Click(object sender, EventArgs e)
        {
            CopyImage();
        }

        private void tsmiCopyText_Click(object sender, EventArgs e)
        {
            CopyText();
        }

        private void tsmiCopyFilePath_Click(object sender, EventArgs e)
        {
            CopyFilePath();
        }

        private void tsmiCopyFileName_Click(object sender, EventArgs e)
        {
            CopyFileName();
        }

        private void tsmiCopyFileNameWithExtension_Click(object sender, EventArgs e)
        {
            CopyFileNameWithExtension();
        }

        private void tsmiCopyFolder_Click(object sender, EventArgs e)
        {
            CopyFolder();
        }

        private void tsmiShowImagePreview_Click(object sender, EventArgs e)
        {
            ShowImagePreview();
        }

        private void tsmiEditImage_Click(object sender, EventArgs e)
        {
            EditImage();
        }

        private void tsmiPinToScreen_Click(object sender, EventArgs e)
        {
            PinToScreen();
        }

        private void tsmiShowMoreInfo_Click(object sender, EventArgs e)
        {
            ShowMoreInfo();
        }
    }
}