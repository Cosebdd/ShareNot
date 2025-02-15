using System;
using System.Windows.Forms;

namespace ShareX
{
    public partial class TaskSettingsForm
    {
        protected override void OnCreateControl()
        {
            RemoveTabsAndMoveFileNamingToGeneral();

            cbFileUploadUseNamePattern.Visible = false;
            cbFileUploadReplaceProblematicCharacters.Visible = false;
            cbURLRegexReplace.Visible = false;
            lblURLRegexReplacePattern.Visible = false;
            txtURLRegexReplacePattern.Visible = false;
            lblURLRegexReplaceReplacement.Visible = false;
            txtURLRegexReplaceReplacement.Visible = false;
            base.OnCreateControl();
        }

        private void RemoveTabsAndMoveFileNamingToGeneral()
        {
            tcTaskSettings.TabPages.RemoveByKey(nameof(tpUpload));
            tcTaskSettings.TabPages.RemoveByKey(nameof(tpWatchFolders));
            (tcTaskSettings.TabPages[nameof(tpGeneral)].Controls[0] as TabControl)?.TabPages.Add(tpFileNaming);
            tttvMain.SetNewMainTabControl(tcTaskSettings);
        }
    }
}