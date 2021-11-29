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
using JLIDashboard.Module;
using System.IO;
using Comm.Common.Extensions;
using JLIDashboard.Classes.Common.Extensions;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Classes;
using System.Net;
using Newtonsoft.Json;
using System.Globalization;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR.frm
{
    public partial class UploadAPK : DevExpress.XtraEditors.XtraForm
    {
        public bool isEdit;
        public bool ok;
        public APKDetails form = new APKDetails();
        public UploadAPK()
        {
            InitializeComponent();
            txtversion.Focus();
        }
        private byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] fileData = new byte[fs.Length];
            fs.Read(fileData, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return fileData;
        }
        private void btnbrowse_Click(object sender, EventArgs e)
        {
            DialogResult dlgupload = openFileDialog1.ShowDialog();
            //OpenFileDialog f = new OpenFileDialog();
            //f.Filter = "*.apk";
            string strExtension = Path.GetExtension(openFileDialog1.FileName);
            if (dlgupload == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog1.FileName) != ".apk")
                {
                    StaticSettings.XtraMessage("Please Upload APK files", MessageBoxIcon.Exclamation);
                }
                else
                {
                    string strFilename = Path.GetFileName(openFileDialog1.FileName).Str();
                    txtupload.Text = strFilename;
                    //byte[] bytes = File.ReadAllBytes(f.FileName);
                    //byte[] bytes = File.ReadAllBytes(strFilename);
                    //FileStream fs = new FileStream(strFilename, FileMode.Open, FileAccess.Read);
                    //byte[] bytes = File.ReadAllBytes(strFilename);

                    //form.APK_File = bytes;
                    form.APK_File = StreamFile(openFileDialog1.FileName);
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (ValidEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StaticSettings.showLoading();
                if (!form.APK_File.Str().IsEmpty())
                {
                    form.APK_Handler = isEdit;
                    var resApp = ApkUploader.SendAsync("app", form.APK_VER_NO, form.APK_File).Result;
                    var data = JsonConvert.DeserializeObject<dynamic>(resApp);
                    if (data.status == "success")
                    {
                        form.APK_Path = data.url;
                        form.APK_Path_Version = data.url_version;
                        var res = (apkDB.executeSave(form)).Result;
                        if (res.result == Results.Success)
                        {
                            this.ok = true;
                            StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                            this.Close();
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
                    else if (data.status == "error")
                    {
                        XtraMessageBox.Show(data.message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                StaticSettings.hideLoading();


            }

        }
        private bool ValidEntries()
        {
            if (txtversion.Text.IsEmpty())
            {
                StaticSettings.XtraMessage("Apk Version is required", MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtname.Text.IsEmpty())
            {
                StaticSettings.XtraMessage("Apk Name is required", MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtupload.Text.IsEmpty())
            {
                StaticSettings.XtraMessage("Please Upload apk file", MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                form.APK_VER_NO = txtversion.Text.Trim();
                form.APK_NM = txtname.Text.Trim();
                form.APK_Path = txtupload.Text.Trim();
                return true;
            }
        }
        public UploadAPK setData(DataRow row, bool _isEdit = false)
        {
            form.APK_TRN = row["APK_TRN"].Str();
            this.txtversion.Text = row["APK_VER"].Str();
            this.txtname.Text = row["APK_NM"].Str();
            isEdit = _isEdit;
            return this;
        }
        public UploadAPK retData(DataRow row)
        {
            row["APK_PRIMARY"] = form.APK_PRIMARY;
            row["APK_VER"] = form.APK_VER_NO;
            row["APK_TRN"] = form.APK_TRN;
            row["APK_NM"] = form.APK_NM;
            row["APK_PATH_BAA"] = form.APK_Path;
            row["UPD_TRN_TS"] = form.UPD_TRN_TS;
            return this;
        }
        
    }
    public class apkDB
    {
        public static async Task<(Results result, String message)> executeSave(APKDetails apk)
        {
            var result=API.DSpQueryAPI("/api/v1/APK/UploadAPK", Login.authentication ,new Dictionary<string,object>()
            {
                {"apK_VER_NO",apk.APK_VER_NO },
                {"apK_NM",apk.APK_NM },
                {"apK_Path_Version",apk.APK_Path_Version },
                {"apK_Path",apk.APK_Path },
                {"apK_TRN",apk.APK_TRN },
                {"apK_Handler",apk.APK_Handler }
            });
            if (result != null)
            {
                var row = ((IDictionary<string, object>)result);
                string ResultCode = row["result"].Str();
                if (ResultCode == "2")
                {
                    apk.UPD_TRN_TS = row["upd_trn_ts"].Str();
                    return (Results.Success, row["message"].Str());
                }
                return (Results.Failed, row["message"].Str());
            }
            return (Results.Null, null);
        }
    }
    public class APKDetails
    {
        public bool APK_Handler;
        public string APK_VER_NO;
        public string APK_TRN;
        public string APK_NM;
        public string APK_Path;
        public string APK_Path_Version;
        public byte[] APK_File;
        public string UPD_TRN_TS;
        public bool APK_PRIMARY;
    }
}