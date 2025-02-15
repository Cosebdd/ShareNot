using System;

namespace ShareX
{
    partial class FirstTimeConfigForm
    {
        protected override void OnCreateControl()
        {
            cbSendToMenu.Visible = false;
            cbShellContextMenuButton.Visible = false;
            cbSendToMenu.Visible = false;
            base.OnCreateControl();
        }
    }
}