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
using JLIDashboard.Classes;
using AbacosDashboard.Module.Enum;
using Comm.Common.Extensions;

using static JLIDashboard.TREASURY._x0i;
using JLIDashboard.Module;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.TREASURY
{
    public partial class ClaimCommissionApproval : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public ClaimCommissionApproval()
        {
            InitializeComponent();
        }

        private void ClaimCommissionApproval_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public ClaimCommissionApproval setData(DataRow row, bool isSelect = false)
        {
            string custname = row["ACT_NM"].Str();
            form.AccountID = row["ACT_ID"].Str();
            form.TransactionNo = row["RQS_NO"].Str();
            form.AmountRequest = row["CLM_AMT"].Str().ToDecimalDouble();
            tbaccountid.Text = form.AccountID;
            tbactname.Text = custname;
            tbamtclaim.EditValue = form.AmountRequest;
            return this;
        }
        public ClaimCommissionApproval retData(DataRow row)
        {
            row["CLM_STAT"] = "Approved";
            row["UPD_TRN_TS_NM"] = form.DateRequestDisplay;
            return this;
        }

        private void btnclaim_Click(object sender, EventArgs e)
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
            string otpno = tbotpno.Text.Trim();
            if (otpno.IsEmpty())
            {
                StaticSettings.XtraMessage("OTP is required", MessageBoxIcon.Exclamation);
                this.tbotpno.Focus();
                return false;
            }
            form.OTPNo = otpno;
            return true;
        }
    }

    public partial class _x0i
    {
        public class Input
        {
            public string AccountID;
            public string TransactionNo;
            public string OTPNo;
            public double AmountRequest;
            public string DateRequest;
            public string DateRequestDisplay;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                dynamic result = API.DSpQueryAPI("/api/v1/Commission/ApprovedClaimCommission", Login.authentication, new Dictionary<string, object>(){
                    { "accountID", input.AccountID },
                    { "transactionNo", input.TransactionNo },
                    { "otpno", input.OTPNo },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                    {
                        //await notifySentCredit(account, row, request.Amount);
                        var datetime = row["clm_ts"].To<DateTime>();
                        input.DateRequest = datetime.ToString("MMMM dd, yyyy hh:mm:ss tt");
                        input.DateRequestDisplay = datetime.ToString("yyyy-MM-dd hh:mm:ss tt");
                        return (Results.Success, row["message"].Str());
                    }
                    else if (ResultCode == "1")
                        return (Results.Failed, row["message"].Str());
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}