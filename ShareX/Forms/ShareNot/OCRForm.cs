using System;

namespace ShareX
{
    public partial class OCRForm
    {
        protected override void OnCreateControl()
        {
            btnOpenServiceLink.Visible = false;
            lblService.Visible = false;
            cbServices.Visible = false;
            cbEditServices.Visible = false;
            btnOpenOCRHelp.Visible = false;
            base.OnCreateControl();
        }
    }
}