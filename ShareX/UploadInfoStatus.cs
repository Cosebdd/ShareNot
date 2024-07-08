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

using System.IO;
using ShareNot.HelpersLib.Helpers;

namespace ShareNot
{
    public class UploadInfoStatus
    {
        public WorkerTask Task { get; private set; }

        public TaskInfo Info => Task.Info;

        public bool IsFilePathValid { get; private set; }
        public bool IsFileExist { get; private set; }
        public bool IsThumbnailFilePathValid { get; private set; }
        public bool IsThumbnailFileExist { get; private set; }
        public bool IsImageFile { get; private set; }
        public bool IsTextFile { get; private set; }

        public UploadInfoStatus(WorkerTask task)
        {
            Task = task;
            Update();
        }

        public void Update()
        {
            IsFilePathValid = !string.IsNullOrEmpty(Info.FilePath) && Path.HasExtension(Info.FilePath);
            IsFileExist = IsFilePathValid && File.Exists(Info.FilePath);
            IsThumbnailFilePathValid = !string.IsNullOrEmpty(Info.ThumbnailFilePath) && Path.HasExtension(Info.ThumbnailFilePath);
            IsThumbnailFileExist = IsThumbnailFilePathValid && File.Exists(Info.ThumbnailFilePath);
            IsImageFile = IsFileExist && FileHelpers.IsImageFile(Info.FilePath);
            IsTextFile = IsFileExist && FileHelpers.IsTextFile(Info.FilePath);
        }
    }
}