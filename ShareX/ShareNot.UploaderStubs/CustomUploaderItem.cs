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

using System.Collections.Generic;
using System.Collections.Specialized;

namespace ShareX.UploadersLib
{
    public class CustomUploaderInput
    {
        public string FileName { get; set; }
        public string Input { get; set; }

        public CustomUploaderInput(string fileName, string input)
        {
            FileName = fileName;
            Input = input;
        }
    }

    public class CustomUploaderItem
    {
        public string Version { get; set; }
        public string Name { get; set; }
        public bool ShouldSerializeName() => false;
        public CustomUploaderDestinationType DestinationType { get; set; }
        public HttpMethod RequestMethod { get; set; } = HttpMethod.POST;
        public string RequestURL { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public bool ShouldSerializeParameters() => false;
        public Dictionary<string, string> Headers { get; set; }
        public bool ShouldSerializeHeaders() => false;
        public CustomUploaderBody Body { get; set; }
        public Dictionary<string, string> Arguments { get; set; }
        public bool ShouldSerializeArguments() => false;
        public string FileFormName { get; set; }
        public bool ShouldSerializeFileFormName() => false;
        public string Data { get; set; }
        public bool ShouldSerializeData() => false;
        public string URL { get; set; }
        public string ThumbnailURL { get; set; }
        public string DeletionURL { get; set; }
        public string ErrorMessage { get; set; }

        private CustomUploaderItem()
        {
        }

        public static CustomUploaderItem Init() => new CustomUploaderItem();
        public override string ToString() => string.Empty;
        public string GetFileName() => string.Empty;
        public string GetRequestURL(CustomUploaderInput input) => string.Empty;
        public Dictionary<string, string> GetParameters(CustomUploaderInput input) => null;
        public string GetContentType() => null;
        public string GetData(CustomUploaderInput input) => string.Empty;
        private string EncodeBodyData(string input) => string.Empty;
        public string GetFileFormName() => string.Empty;
        public Dictionary<string, string> GetArguments(CustomUploaderInput input) => null;
        public NameValueCollection GetHeaders(CustomUploaderInput input) => null;
        public void ParseResponse(UploadResult result, ResponseInfo responseInfo, UploaderErrorManager errors, CustomUploaderInput input, bool isShortenedURL = false)
        {

        }

        public void TryParseResponse(UploadResult result, ResponseInfo responseInfo, UploaderErrorManager errors, CustomUploaderInput input, bool isShortenedURL = false)
        {

        }

        public void CheckBackwardCompatibility()
        {

        }
    }
}