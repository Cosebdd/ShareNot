#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2025 ShareX Team

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

using ShareX.HelpersLib;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;

namespace ShareX.UploadersLib
{
    public class FTPAccount : ICloneable
    {
        public string Name { get; set; }
        public FTPProtocol Protocol { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string SubFolderPath { get; set; }
        public BrowserProtocol BrowserProtocol { get; set; }
        public string HttpHomePath { get; set; }
        public bool HttpHomePathAutoAddSubFolderPath { get; set; }
        public bool HttpHomePathNoExtension { get; set; }

        public string FTPAddress
        {
            get
            {
                return string.Empty;
            }
        }

        private string exampleFileName = string.Empty;

        public string PreviewFtpPath => GetFtpPath(exampleFileName);
        public string PreviewHttpPath
        {
            get
            {
                try
                {
                    return GetUriPath(exampleFileName);
                }
                catch
                {
                    return "";
                }
            }
        }

        public FTPSEncryption FTPSEncryption { get; set; }
        public string FTPSCertificateLocation { get; set; }
        public string Keypath { get; set; }
        public string Passphrase { get; set; }

        public FTPAccount()
        {
        }

        public string GetSubFolderPath(string fileName = null, NameParserType nameParserType = NameParserType.URL) => string.Empty;
        public string GetHttpHomePath() => string.Empty;
        public string GetUriPath(string fileName, string subFolderPath = null) => string.Empty;
        public string GetFtpPath(string fileName) => string.Empty;
        public override string ToString() => string.Empty;
        public FTPAccount Clone() => MemberwiseClone() as FTPAccount;
        object ICloneable.Clone() => Clone();
    }
}