using System;

namespace ShareX.IndexerLib
{
    public partial class DirectoryIndexerForm
    {
        protected override void OnCreateControl()
        {
            btnUpload.Visible = false;
            base.OnCreateControl();
        }
    }
}