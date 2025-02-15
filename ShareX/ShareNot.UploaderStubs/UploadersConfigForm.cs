using System.Windows.Forms;

namespace ShareX.UploadersLib
{
    public class UploadersConfigForm : Form
    {
        public static bool IsInstanceActive => false;

        public static UploadersConfigForm GetFormInstance(UploadersConfig uploadersConfig) => null;

        public void NavigateToTabPage(TabPage getUploadersConfigTabPage) {}
    }
}