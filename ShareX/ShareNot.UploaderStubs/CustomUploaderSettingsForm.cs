using System.Windows.Forms;

namespace ShareX.UploadersLib
{
    public class CustomUploaderSettingsForm : Form
    {
        public static bool IsInstanceActive => false;

        public static CustomUploaderSettingsForm GetFormInstance(UploadersConfig uploadersConfig)
        {
            return null;
        }

        public static void CustomUploaderUpdateTab()
        {
            throw new System.NotImplementedException();
        }
    }
}