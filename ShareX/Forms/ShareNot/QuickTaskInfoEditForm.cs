namespace ShareX
{
    public partial class QuickTaskInfoEditForm
    {
        protected override void OnCreateControl()
        {
            cmsAfterUpload.Visible = false;
            lblAfterUploadTasks.Visible = false;
            mbAfterUploadTasks.Visible = false;
            base.OnCreateControl();
        }
    }
}