using System;

namespace ShareX
{
    public partial class QRCodeForm
    {
        protected override void OnCreateControl()
        {
            btnUploadImage.Visible = false;
            base.OnCreateControl();
        }
    }
}