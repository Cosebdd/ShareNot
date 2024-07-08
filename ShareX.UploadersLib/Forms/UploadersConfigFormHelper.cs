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
using System.Windows.Forms;
using ShareNot.HelpersLib;
using ShareNot.HelpersLib.Extensions;
using ShareNot.HelpersLib.Helpers;
using ShareNot.UploadersLib.Controls;
using ShareNot.UploadersLib.OAuth;
using ShareNot.UploadersLib.Properties;

namespace ShareNot.UploadersLib.Forms
{
    public partial class UploadersConfigForm
    {
        #region Generic OAuth2

        private OAuth2Info OAuth2Open(IOAuth2Basic uploader)
        {
            try
            {
                string url = uploader.GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    URLHelpers.OpenURL(url);
                    DebugHelper.WriteLine(uploader.ToString() + " - Authorization URL is opened: " + url);
                    return uploader.AuthInfo;
                }
                else
                {
                    DebugHelper.WriteLine(uploader.ToString() + " - Authorization URL is empty.");
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }

            return null;
        }

        private bool OAuth2Complete(IOAuth2Basic uploader, string code, OAuthControl control)
        {
            try
            {
                if (!string.IsNullOrEmpty(code) && uploader.AuthInfo != null)
                {
                    bool result = uploader.GetAccessToken(code);
                    ConfigureOAuthStatus(control, result);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }

            return false;
        }

        private bool OAuth2Refresh(IOAuth2 uploader, OAuthControl oauth2)
        {
            try
            {
                if (OAuth2Info.CheckOAuth(uploader.AuthInfo))
                {
                    bool result = uploader.RefreshAccessToken();
                    ConfigureOAuthStatus(oauth2, result);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }

            return false;
        }

        private void ConfigureOAuthStatus(OAuthControl oauth2, bool result)
        {
            if (result)
            {
                oauth2.Status = OAuthLoginStatus.LoginSuccessful;
                MessageBox.Show(Resources.UploadersConfigForm_Login_successful, "ShareNot", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                oauth2.Status = OAuthLoginStatus.LoginFailed;
                MessageBox.Show(Resources.UploadersConfigForm_Login_failed, "ShareNot", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Generic OAuth2
    }
}