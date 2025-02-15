using System.Windows.Forms;

namespace ShareX.HelpersLib
{
    public partial class TabToTreeView
    {
        public void SetNewMainTabControl(TabControl control)
        {
            mainTabControl = control;
            tvMain.Nodes.Clear();
            FillTreeView(tvMain.Nodes, mainTabControl);
            tvMain.ExpandAll();
        }
    }
}