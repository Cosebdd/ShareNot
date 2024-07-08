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
using System.Windows.Forms;
using ShareNot.HelpersLib;
using ShareNot.HelpersLib.Extensions;
using ShareNot.HelpersLib.Helpers;
using ShareNot.HelpersLib.Native;
using ShareNot.Properties;

namespace ShareNot
{
    public static class IntegrationHelpers
    {
        private static readonly string ApplicationPath = $"\"{Application.ExecutablePath}\"";

        private static readonly string ShellCustomUploaderExtensionPath = @"Software\Classes\.sxcu";
        private static readonly string ShellCustomUploaderExtensionValue = "ShareNot.sxcu";
        private static readonly string ShellCustomUploaderAssociatePath = $@"Software\Classes\{ShellCustomUploaderExtensionValue}";
        private static readonly string ShellCustomUploaderAssociateValue = "ShareNot custom uploader";
        private static readonly string ShellCustomUploaderIconPath = $@"{ShellCustomUploaderAssociatePath}\DefaultIcon";
        private static readonly string ShellCustomUploaderIconValue = $"{ApplicationPath},0";
        private static readonly string ShellCustomUploaderCommandPath = $@"{ShellCustomUploaderAssociatePath}\shell\open\command";
        private static readonly string ShellCustomUploaderCommandValue = $"{ApplicationPath} -CustomUploader \"%1\"";

        private static readonly string ShellImageEffectExtensionPath = @"Software\Classes\.sxie";
        private static readonly string ShellImageEffectExtensionValue = "ShareNot.sxie";
        private static readonly string ShellImageEffectAssociatePath = $@"Software\Classes\{ShellImageEffectExtensionValue}";
        private static readonly string ShellImageEffectAssociateValue = "ShareNot image effect";
        private static readonly string ShellImageEffectIconPath = $@"{ShellImageEffectAssociatePath}\DefaultIcon";
        private static readonly string ShellImageEffectIconValue = $"{ApplicationPath},0";
        private static readonly string ShellImageEffectCommandPath = $@"{ShellImageEffectAssociatePath}\shell\open\command";
        private static readonly string ShellImageEffectCommandValue = $"{ApplicationPath} -ImageEffect \"%1\"";

        public static bool CheckCustomUploaderExtension()
        {
            try
            {
                return RegistryHelpers.CheckStringValue(ShellCustomUploaderExtensionPath, null, ShellCustomUploaderExtensionValue) &&
                    RegistryHelpers.CheckStringValue(ShellCustomUploaderCommandPath, null, ShellCustomUploaderCommandValue);
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }

            return false;
        }

        public static void CreateCustomUploaderExtension(bool create)
        {
            try
            {
                if (create)
                {
                    UnregisterCustomUploaderExtension();
                    RegisterCustomUploaderExtension();
                }
                else
                {
                    UnregisterCustomUploaderExtension();
                }
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }
        }

        private static void RegisterCustomUploaderExtension()
        {
            RegistryHelpers.CreateRegistry(ShellCustomUploaderExtensionPath, ShellCustomUploaderExtensionValue);
            RegistryHelpers.CreateRegistry(ShellCustomUploaderAssociatePath, ShellCustomUploaderAssociateValue);
            RegistryHelpers.CreateRegistry(ShellCustomUploaderIconPath, ShellCustomUploaderIconValue);
            RegistryHelpers.CreateRegistry(ShellCustomUploaderCommandPath, ShellCustomUploaderCommandValue);

            NativeMethods.SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
        }

        private static void UnregisterCustomUploaderExtension()
        {
            RegistryHelpers.RemoveRegistry(ShellCustomUploaderExtensionPath);
            RegistryHelpers.RemoveRegistry(ShellCustomUploaderAssociatePath, true);
        }

        public static bool CheckImageEffectExtension()
        {
            try
            {
                return RegistryHelpers.CheckStringValue(ShellImageEffectExtensionPath, null, ShellImageEffectExtensionValue) &&
                    RegistryHelpers.CheckStringValue(ShellImageEffectCommandPath, null, ShellImageEffectCommandValue);
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }

            return false;
        }

        public static void CreateImageEffectExtension(bool create)
        {
            try
            {
                if (create)
                {
                    UnregisterImageEffectExtension();
                    RegisterImageEffectExtension();
                }
                else
                {
                    UnregisterImageEffectExtension();
                }
            }
            catch (Exception e)
            {
                DebugHelper.WriteException(e);
            }
        }

        private static void RegisterImageEffectExtension()
        {
            RegistryHelpers.CreateRegistry(ShellImageEffectExtensionPath, ShellImageEffectExtensionValue);
            RegistryHelpers.CreateRegistry(ShellImageEffectAssociatePath, ShellImageEffectAssociateValue);
            RegistryHelpers.CreateRegistry(ShellImageEffectIconPath, ShellImageEffectIconValue);
            RegistryHelpers.CreateRegistry(ShellImageEffectCommandPath, ShellImageEffectCommandValue);

            NativeMethods.SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
        }

        private static void UnregisterImageEffectExtension()
        {
            RegistryHelpers.RemoveRegistry(ShellImageEffectExtensionPath);
            RegistryHelpers.RemoveRegistry(ShellImageEffectAssociatePath, true);
        }

        public static void Uninstall()
        {
            StartupManager.State = StartupState.Disabled;
            CreateCustomUploaderExtension(false);
            CreateImageEffectExtension(false);
        }
    }
}