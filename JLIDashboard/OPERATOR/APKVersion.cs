using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JLIDashboard.Classes.Common.Extensions;
using static JLIDashboard.OPERATOR._apk;
using static JLIDashboard.OPERATOR._apk.Vyw;
using JLIDashboard.Module;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using JLIDashboard.Classes;
using Comm.Common.Extensions;
using JLIDashboard.OPERATOR.frm;
using System.IO;
using System.Net;
using System.Threading;
using AbacosDashboard.Module.Enum;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR
{
    public partial class APKVersion : DevExpress.XtraEditors.XtraForm
    {
        public APKDetails form = new APKDetails();
        public APKVersion()
        {
            InitializeComponent();
        }

        private void cmsuploadapk_Click(object sender, EventArgs e)
        {
            var frm = System.Windows.Forms.Application.OpenForms.Singleton<OPERATOR.frm.UploadAPK>();
            StaticSettings.hideLoading();
            frm.ShowDialog(this);
            if (!frm.ok) return;
            Timeout.Set(() => this.Invoke(new Action(() => this.Load_APK())), 250);
        }
        public void Load_APK(bool defFocused = true)
        {
            API.displayAPI("/api/v1/APK/GetApk", gridControl1, gridView1, Login.authentication);
            if (x0a(gridView1).RowCount != 0 && defFocused)
            {
                this.gridView1.FocusedRowHandle = 0;
            }
        }

        private void APK_Version_Load(object sender, EventArgs e)
        {
            Timeout.Set(() => this.Invoke(new Action(() => this.Load_APK())), 250);
        }
        
        private void cmsupdateapk_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.GetFocusedDataRow();
            DataRow row = gridView1.GetFocusedDataRow();
            StaticSettings.showLoading();
            var frm = System.Windows.Forms.Application.OpenForms.Singleton<UploadAPK>().setData(row, true);
            StaticSettings.hideLoading();
            frm.ShowDialog(this);
            if (!frm.ok) return;
            frm.retData(row);

        }
        //WebClient client;
        private void cmddownloadapk_Click(object sender, EventArgs e)
        {

            DataRow row = gridView1.GetFocusedDataRow();
            string strURL = row["APK_PATH_BAA"].Str();
            if (!strURL.IsEmpty())
            {
                Uri url = new Uri(strURL);
                string filename = Path.GetFileName(url.AbsolutePath);
                saveFileDialog1.Filter = "APK Files (*.apk)|*.apk";
                saveFileDialog1.FileName = filename;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StaticSettings.showLoading();
                    string filepath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                    WebClient webclient = new WebClient();
                    webclient.DownloadFile(strURL, filepath + "\\" + filename);
                    StaticSettings.XtraMessage("Downloaded Successfully", MessageBoxIcon.Asterisk);

                    StaticSettings.hideLoading();
                }
            }
            else
            {
                StaticSettings.XtraMessage("Please Provide URL", MessageBoxIcon.Asterisk);
            }

        }

        private void cmssetapk_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            form.COMP_ID = row["COMP_ID"].Str();
            form.BR_CD = row["BR_CD"].Str();
            form.USR_ID = row["USR_ID"].Str();
            form.APK_TRN = row["APK_TRN"].Str();
            form.APK_Path = row["APK_PATH_BAA"].Str();
            form.APK_VER_NO = row["APK_VER"].Str();
            if (!form.APK_Path.IsEmpty())
            {
                if (XtraMessageBox.Show("Are you sure you want to set this Primary APK?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var res = (_apk.executeSetPrimaryAPK(form)).Result;
                    if (res.result == Results.Success)
                    {
                        Timeout.Set(() => this.Invoke(new Action(() => this.Load_APK())), 250);
                        //row["APK_PRIMARY"] = form.APK_PRIMARY;
                        StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                    }
                    else if (res.result != Results.Null)
                    {
                        StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            else
            {
                StaticSettings.XtraMessage("Please Provide URL", MessageBoxIcon.Asterisk);
            }
        }

        private void cmsrefresh_Click(object sender, EventArgs e)
        {
            Timeout.Set(() => this.Invoke(new Action(() => this.Load_APK())), 250);
        }
    }
    public class _apk
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                if (gridView.RowCount != 0)
                {
                    gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("APK_PRIMARY", "Current", 1, gridView, 5);
                    DevXSettings.XtraFormatColumn("APK_VER", "Version", 2, gridView, 100);
                    DevXSettings.XtraFormatColumn("APK_TRN", "APK No.", 3, gridView, 100);
                    DevXSettings.XtraFormatColumn("APK_NM", "Name", 4, gridView, 100);
                    DevXSettings.XtraFormatColumn("APK_PATH_BAA", "URL", 5, gridView, 100);
                    DevXSettings.XtraFormatColumn("UPD_TRN_TS", "Date Uploaded", 6, gridView, 100);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            
        }
        public static async Task<(Results result, string message)> executeSetPrimaryAPK(APKDetails apk)
        {
            var result = API.DSpQueryAPI("/api/v1/APK/SetAPK", Login.authentication, new Dictionary<string,object>()
                {
                    {"apK_TRN",apk.APK_TRN },
                    {"apK_Path",apk.APK_Path },
                    {"apK_VER_NO",apk.APK_VER_NO }
                });
            if (result != null)
            {
                var row = ((IDictionary<string, object>)result);
                string ResultCode = row["result"].Str();
                if (ResultCode == "2")
                {
                    apk.APK_PRIMARY = Convert.ToBoolean(row["primaryapk"].Str());
                    return (Results.Success, row["message"].Str());
                }
                return (Results.Failed, row["message"].Str());
            }
            return (Results.Null, null);
        }
    }

    public class APKDetails
    {
        public string COMP_ID;
        public string BR_CD;
        public string USR_ID;
        public string APK_TRN;
        public string APK_Path;
        public string APK_VER_NO;
        public bool APK_PRIMARY;
    }
}