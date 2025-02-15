using System;

namespace ShareX.MediaLib
{
    public partial class ImageBeautifierForm
    {
        protected override void OnCreateControl()
        {
            btnUpload.Visible = false;
            base.OnCreateControl();
        }
    }
}