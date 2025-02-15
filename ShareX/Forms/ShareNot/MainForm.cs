using System;

namespace ShareX
{
    partial class MainForm
    {
        protected override void OnCreateControl()
        {
            tsmiTweetMessage.Visible = false;
            tsmiTrayTweetMessage.Visible = false;
            tsbX.Visible = false;
            tsbDiscord.Visible = false;
            base.OnCreateControl();
        }
    }
}