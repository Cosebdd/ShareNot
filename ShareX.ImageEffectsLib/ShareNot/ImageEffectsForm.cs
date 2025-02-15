using System;

namespace ShareX.ImageEffectsLib
{
    public partial class ImageEffectsForm
    {
        protected override void OnCreateControl()
        {
            btnUploadImage.Visible = false;
            base.OnCreateControl();
        }
    }
}