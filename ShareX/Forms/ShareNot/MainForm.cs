using System;

namespace ShareX
{
    partial class MainForm
    {
        protected override void OnCreateControl()
        {
            tsbX.Visible = false;
            tsbDiscord.Visible = false;
            tsbDestinationSettings.Visible = false;
            tsbCustomUploaderSettings.Visible = false;
            base.OnCreateControl();
        }
    }
}