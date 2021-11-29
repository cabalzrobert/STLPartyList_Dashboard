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
using System.Data.SqlClient;
using JLIDashboard.Classes;
using JLIDashboard.Classes.Common.Extensions;
using Comm.Common.Extensions;

using static JLIDashboard.OPERATION._x0f;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using static JLIDashboard.OPERATION._x0i;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATION
{
    public partial class LiveStreaming : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public LiveStreaming()
        {
            InitializeComponent();
        }

        private void LiveStreaming_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public LiveStreaming setData()
        {
            var row = API.GetDictionaryStringParameter($"/api/v1/LiveStreaming/URLLiveStreaming", Login.authentication);
            tburl.Text = row["URL_STRMNG"].Str();
            tbdescr.Text = row["URL_STRMNG_NM"].Str();
            return this;
        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = Db.execute0a(form).Result;
            if (res.result == Results.Success)
            {
                ok = true;
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
            StaticSettings.hideLoading();
        }

        public Input form = new Input();
        private bool ValidateEntries()
        {
            string videourl = this.tburl.Text.Trim();
            if (videourl.IsEmpty())
            {
                StaticSettings.XtraMessage("Video url is required", MessageBoxIcon.Hand);
                this.tburl.Focus();
                return false;
            }
            string description = this.tbdescr.Text.Trim();
            if (description.IsEmpty())
            {
                StaticSettings.XtraMessage("Video title is required", MessageBoxIcon.Hand);
                this.tbdescr.Focus();
                return false;
            }
            form.LiveStreamUrl = videourl;
            form.LiveStreamDescription = description;
            return true;
        }
    }
    public partial class _x0f
    {
        public class Input
        {
            public string LiveStreamUrl;
            public string LiveStreamDescription;
        }

        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/LiveStreaming/PostLiveStreaming", Login.authentication, new Dictionary<string, object>(){
                    { "livestreamingurl", input.LiveStreamUrl },
                    { "description", input.LiveStreamDescription },
                });
                if (result != null)
                {
                    string ResultCode = result["result"].Str();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, result["message"].Str());
                    }
                    return (Results.Failed, result["message"].Str());
                }
                return (Results.Null, null);
            }
        }
        public class notify
        {
            public static async Task<bool> CompanySettings(IDictionary<string, object> row)
            {
                var settings = dto0a.CompanySettings(row);
                //var notifications = dto.Notifications(row);
                await Pusher.PushAsync($"/{Login.plid}/{Login.pgrpid}/notify"
                    //, new { type = "post-notification", content = notifications });
                    , new { type = "post-notification", content = row });
                await Pusher.PushAsync($"/{Login.plid}/{Login.pgrpid}/notify"
                    //, new { type = "streaming-update", content = settings });
                    , row);
                return false;
            }
        }
        public class dto0a
        {
            public static IDictionary<string, object> CompanySettings(IDictionary<string, object> data)
            {
                dynamic o = Dynamic.Object;
                //string compid = data["COMP_ID"].Str();
                //if (!compid.IsEmpty()) o.CompanyID = compid;
                o.CompanyName = data["COMP_NM"].Str();
                o.CompanyAddress = data["COMP_ADD"].Str();
                o.LiveStreamUrl = data["URL_STRMNG"].Str();
                o.LiveStreamName = data["URL_STRMNG_NM"].Str();
                o.AppSharingDescription = data["APP_SHRING_DESC"].Str();

                //if (data.ContainsKey("GT01_BT_LMT")) o.LimitBetSWER2 = (int)data["GT01_BT_LMT"].Str().ToDecimalDouble();
                //if (data.ContainsKey("GT02_BT_LMT")) o.LimitBetSWER3 = (int)data["GT02_BT_LMT"].Str().ToDecimalDouble();
                //if (data.ContainsKey("GT03_BT_LMT")) o.LimitBetPARES = (int)data["GT03_BT_LMT"].Str().ToDecimalDouble();

                return o;
            }
        }
    }
}