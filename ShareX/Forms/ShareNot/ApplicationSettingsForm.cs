using System;
using ShareX.HelpersLib;

namespace ShareX
{
    public partial class ApplicationSettingsForm
    {
        protected override void OnCreateControl()
        {
            tcSettings.TabPages.RemoveByKey(nameof(tpUpload));
            tttvMain.SetNewMainTabControl(tcSettings);

            gbChrome.Visible = false;

            gbFirefox.Visible = false;

            cbShellContextMenu.Visible = false;
            cbSendToMenu.Visible = false;

            cbEditWithShareX.Location = cbShellContextMenu.Location;

            gbWindows.Height = 75;

            base.OnCreateControl();
        }
    }
}