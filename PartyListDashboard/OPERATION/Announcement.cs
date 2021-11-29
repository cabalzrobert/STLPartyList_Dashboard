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

using static JLIDashboard.OPERATION._x0g;
using static JLIDashboard.OPERATION._x0i;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATION
{
    public partial class Announcement : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public Announcement()
        {
            InitializeComponent();
        }

        private void Announcement_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public Announcement setData()
        {
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
            string title = this.tbttl.Text.Trim();
            if (title.IsEmpty())
            {
                StaticSettings.XtraMessage("Please enter title", MessageBoxIcon.Hand);
                this.tbttl.Focus();
                return false;
            }
            string description = this.tbdescr.Text.Trim();
            if (description.IsEmpty())
            {
                StaticSettings.XtraMessage("Description is required", MessageBoxIcon.Hand);
                this.tbdescr.Focus();
                return false;
            }
            form.Title = title;
            form.Description = description;
            return true;
        }
    }
    public partial class _x0g
    {
        public class Input
        {
            public string Title;
            public string Description;
        }

        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/Announcement/PublishAnnouncement", Login.authentication, new Dictionary<string, object>(){
                    { "title", input.Title },
                    { "description", input.Description },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = result["result"].Str();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, result["message"].Str());
                    }
                }
                return (Results.Null, null);
            }
        }
    }
    public partial class _x0i
    {
        public class notify
        {
            public static async Task<bool> PostAnnouncement(IDictionary<string, object> data)
            {
                await Pusher.PushAsync($"/{Login.compid}/{Login.brcode}/notify"
                    //, new { type = "post-notification", content = dto.Notifications(data) });
                    , new { type = "post-notification", content = data });
                return true;
            }
        }
        public class dto
        {
            public static IEnumerable<dynamic> Notifications(IEnumerable<dynamic> list)
            {
                if (list == null) return null;
                return list.Select(e => Notification(e));
            }
            public static IEnumerable<dynamic> Notifications(IDictionary<string, object> data)
            {
                List<IDictionary<string, object>> list = new List<IDictionary<string, object>>();
                list.Add(Notification(data));
                return list;
            }
            public static IDictionary<string, object> Notification(IDictionary<string, object> data)
            {
                dynamic o = Dynamic.Object;
                o.NotificationID = ((int)data["NOTIF_ID"].Str().ToDecimalDouble()).ToString("X");
                o.DateTransaction = data["RGS_TRN_TS"];
                o.Title = data["NOTIF_TTL"].Str();
                o.Description = data["NOTIF_DESC"].Str();
                o.IsCompany = data["S_COMP"].To<bool>(false);
                o.IsOpen = data["S_OPN"].To<bool>(false);
                bool IsWinning = data["S_WNNG"].To<bool>(false);
                bool IsReceivedAmount = data["S_RCVNG_AMT"].To<bool>(false);
                if (IsWinning || IsReceivedAmount)
                {
                    if (IsWinning) o.IsWinning = IsWinning;
                    else if (IsReceivedAmount) o.IsReceivedAmount = IsReceivedAmount;
                    o.Amount = data["AMT"].Str().ToDecimalDouble();
                }
                string type = data["TYP"].Str();
                if (!type.IsEmpty()) o.Type = type;

                try
                {
                    DateTime datetime = data["RGS_TRN_TS"].To<DateTime>();
                    o.DateDisplay = datetime.ToString("MMM dd, yyyy");
                    o.TimeDisplay = datetime.ToString("hh:mm:ss tt");
                    o.FulldateDisplay = $"{o.DateDisplay} {o.TimeDisplay}";
                }
                catch { }
                return o;
            }
        }
    }
}