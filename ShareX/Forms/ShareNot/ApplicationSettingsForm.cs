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
            base.OnCreateControl();
        }
    }
}