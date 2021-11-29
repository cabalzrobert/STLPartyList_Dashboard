using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace JLIDashboard.Module
{
    class StaticSettings
    {
        public static void XtraMessage(string message, MessageBoxIcon ico)
        {
            XtraMessageBox.Show(message, "Message", MessageBoxButtons.OK, ico);
        }

        public static void showLoading(Form frm = null)
        {
            try
            {
                if (frm == null)
                    SplashScreenManager.ShowForm(typeof(WaitForm1), true, true);
                else SplashScreenManager.ShowForm(frm, typeof(WaitForm1), true, true);
            }
            catch (Exception e)
            {
                StaticSettings.hideLoading();
            }
        }
        public static void hideLoading()
        {
            try
            {
                SplashScreenManager.CloseForm();
            }
            catch (Exception e)
            {
            }
        }



    }
}
