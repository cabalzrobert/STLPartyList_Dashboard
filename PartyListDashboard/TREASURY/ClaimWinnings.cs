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
using Comm.Common.Extensions;
using AbacosDashboard.Module.Enum;

using static JLIDashboard.TREASURY._x0c;
using JLIDashboard.Module;
using JLIDashboard.Classes.Common.Extensions;
using static JLIDashboard.OPERATION._x0i;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.TREASURY
{
    public partial class ClaimWinnings : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public ClaimWinnings()
        {
            InitializeComponent();
        }

        private void ClaimWinnings_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public ClaimWinnings setData(DataRow row)
        {
            form.AccountID = row["ACT_ID"].Str();
            form.TransactionNo = row["TRN_NO"].Str();
            form.EncashmentType = row["ENC_CD"].Str();
            form.RemittanceID = row["ENC_COM"].Str();
            form.TotalAmount = row["TOT_AMT"].Str().ToDecimalDouble();
            //
            this.fillEncType(row["ENC_CD"].Str());
            //
            bool isBank = form.EncashmentType.Equals("BTB");
            tbrequestid.Text = row["RQS_NO"].Str();
            tbacctid.Text = form.AccountID;
            tbtransno.Text = form.TransactionNo;
            //tbacctname.Text = row["ACT_ID"].Str();
            tbrcvrname.Text = row["NME"].Str();
            tbrcvrrefno.Text = row["NMBER"].Str();
            tbaddress.Text = row["ADDR"].Str();
            tbwinningamnt.EditValue = form.TotalAmount;
            tbttlsent.EditValue = form.TotalAmount;
            lblrcvrname.Text = (isBank ? "Bank Account Name" : "Receiver's Name");
            lblrcvrrefno.Text = (isBank ? "Bank Account No." : "Receiver's Mobile No.");
            tsenctype.EditValue = form.EncashmentType;
            tsencname.EditValue = form.RemittanceID;
            return this;
        }

        private void fillEncType(string enctype)
        {
            API.displaySearchLookupEditAPIParam("/api/v1/Remittance/LoadEncashmentType", Login.authentication, tsenctype, "ENC_NM", "ENC_CD");
            if (enctype.IsEmpty()) return;
            tsenctype.EditValue = enctype;
        }
        private void fillRemType(string remcd)
        {
            if (tsenctype.Text.IsEmpty())
            {
                tsencname.Properties.DataSource = null;
                return;
            }
            DataRow renctype = tsenctype.GetFocusedDataRow();
            API.displaySearchLookupEditAPIParam($"/api/v1/Winnings/EncashmentName?encType={renctype["ENC_ID"].Str()}", Login.authentication, tsencname, "REM_NM", "REM_CD");
            if (remcd.IsEmpty()) return;
            tsencname.EditValue = remcd;
        }


        private void txtenctype_EditValueChanged(object sender, EventArgs e)
        {
            this.fillRemType(form.RemittanceID);
            this.ChangeConfirmationDetails();
        }

        private void ChangeConfirmationDetails()
        {
            string enctype = tsenctype.EditValue.Str();
            if (enctype == "BTB")
            {
                this.lbldepname.Text = "Deposit by Name";
                this.lbldepcontact.Text = "Deposit by Contact";
                this.tbrefno.Properties.NullValuePrompt = "";
                return;
            }
            else if (enctype == "MRC")
            {
                this.lbldepname.Text = "Receiver's Name";
                this.lbldepcontact.Text = "Receiver's Mobile No.";
                this.tbrefno.Properties.NullValuePrompt = "";
                return;
            }
            this.lbldepname.Text = "Deliver By Name";
            this.lbldepcontact.Text = "Deliver By Contact";
            this.tbrefno.Properties.NullValuePrompt = "(Optional)";
        }

        private void tbsrvccharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            var limit = form.TotalAmount;
            if (this.tbsrvccharge.Text.Str().ToDecimalDouble() > limit) return;
            string str = this.tbsrvccharge.Text;
            int ss = tbsrvccharge.SelectionStart, sl = tbsrvccharge.SelectionLength;
            string str1 = str.Substring(0, ss), str2 = str.Substring(ss), str3 = str1 + e.KeyChar + str2;
            double parse = Convert.ToDouble(str3);
            if (parse > limit)
            {
                e.Handled = true;
                tbsrvccharge.Text = limit.ToString();
                tbsrvccharge.SelectionStart = ss + 1;
                return;
            }
        }
        private void tbsrvccharge_EditValueChanged(object sender, EventArgs e)
        {
            tbttlsent.Text = (form.TotalAmount - this.tbsrvccharge.Text.Str().ToDecimalDouble()).ToAccountingFormat("0.00");
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
            string remittancetype = this.tsenctype.Text.Trim();
            if (remittancetype.IsEmpty())
            {
                StaticSettings.XtraMessage("Encashment type is required", MessageBoxIcon.Exclamation);
                this.tsenctype.Focus();
                return false;
            }
            string remittancename = this.tsencname.Text.Trim();
            if (remittancename.IsEmpty())
            {
                StaticSettings.XtraMessage("Encashment name is required", MessageBoxIcon.Exclamation);
                this.tsencname.Focus();
                return false;
            }
            string sendername = this.tbdepname.Text.Trim();
            if (sendername.IsEmpty())
            {
                if (form.EncashmentType.Equals("MRC"))
                    StaticSettings.XtraMessage("Name of sender is required", MessageBoxIcon.Exclamation);
                else if (form.EncashmentType.Equals("BTB"))
                    StaticSettings.XtraMessage("Name of deposit by is required", MessageBoxIcon.Exclamation);
                else if (form.EncashmentType.Equals("CD")) 
                    StaticSettings.XtraMessage("Name of deliver by is required", MessageBoxIcon.Exclamation);
                this.tbdepname.Focus();
                return false;
            }
            string sendermobilenumber = this.tbdepcontact.Text.Trim();
            if (sendermobilenumber.IsEmpty())
            {
                if (form.EncashmentType.Equals("MRC"))
                    StaticSettings.XtraMessage("Contact # of sender is required", MessageBoxIcon.Exclamation);
                else if (form.EncashmentType.Equals("BTB"))
                    StaticSettings.XtraMessage("Contact # of deposit by is required", MessageBoxIcon.Exclamation);
                else if (form.EncashmentType.Equals("CD"))
                    StaticSettings.XtraMessage("Contact # of deliver by is required", MessageBoxIcon.Exclamation);
                this.tbdepcontact.Focus();
                return false;
            }
            double servicecharge = this.tbsrvccharge.Text.Trim().ToDecimalDouble();
            string refnumber = this.tbrefno.Text.Trim();
            if (refnumber.IsEmpty() && form.EncashmentType.Equals("CD"))
            {
                StaticSettings.XtraMessage("Reference # is required", MessageBoxIcon.Exclamation);
                this.tbrefno.Focus();
                return false;
            }

            DataRow rencnm= tsencname.GetFocusedDataRow();
            form.RemittanceID = rencnm["REM_ID"].Str();
            form.SenderName = sendername;
            form.SenderMobileNumber = sendermobilenumber;
            form.ServiceCharge = servicecharge;
            form.ReferenceID = refnumber;
            return true;
        }
    }




    public partial class _x0c
    {
        public class Input
        {
            public string AccountID;
            public string TransactionNo;
            public string RemittanceID;
            public string SenderName;
            public string SenderMobileNumber;
            public double ServiceCharge;
            public string ReferenceID;
            //
            public string EncashmentType;
            public double TotalAmount;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                var results = Database.DAPIQueryMultiple("/api/v1/Winnings/UpdateClaimWinning", Login.authentication, new Dictionary<string, object>(){
                    { "accountID", input.AccountID },
                    { "transactionNo", input.TransactionNo },
                    { "remittanceID", input.RemittanceID },

                    { "senderName", input.SenderName },
                    { "senderMobileNumber", input.SenderMobileNumber },
                    { "serviceCharge", input.ServiceCharge },

                    { "referenceID", input.ReferenceID },
                });
                if (results != null)
                {
                    string ResultCode = results["result"].Str();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, results["message"].Str());
                    }
                    return (Results.Failed, "Somethings wrong in your data. Please try again");
                }
                return (Results.Null, null);
            }
        }
        private class notify
        {
            public static async Task<bool> Subscriber(string subscriberID, string type, IEnumerable<dynamic> list)
            {
                await Pusher.PushAsync($"/{Login.compid}/{Login.brcode}/{subscriberID}/notify"
                    , new { type = type, content = dto.Notifications(list) });
                return true;
            }
        }
    }
}