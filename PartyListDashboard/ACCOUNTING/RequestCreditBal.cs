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

using static JLIDashboard.ACCOUNTING._x0d;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Classes;
using Comm.Common.Extensions;
using JLIDashboard.Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTING
{
    public partial class RequestCreditBal : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public RequestCreditBal()
        {
            InitializeComponent();
        }

        private void RequestCreditBal_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public RequestCreditBal setData()
        {
            var row = API.GetDictionaryRow("/api/v1/PowerAppCredit/GetCompanyCreditBalance", Login.authentication, new Dictionary<string, object>()
            {
                {"compID",Login.compid },
                {"branchID",Login.brcode }
            });
            form.AccountID = row["ACT_ID"].Str();
            form.PurchaseOrderNo = row["PO_NO"].Str(); 
            tbpono.Text = form.PurchaseOrderNo;
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
                tbpono.Text = form.PurchaseOrderNo;

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
            string stramount = this.tbamt.Text.Trim();
            if (stramount.IsEmpty())
            {
                StaticSettings.XtraMessage("Request Amount is required", MessageBoxIcon.Exclamation);
                this.tbamt.Focus();
                return false;
            }

            double amount = stramount.ToDecimalDouble();
            if (amount < 1)
            {
                StaticSettings.XtraMessage("Request Amount must be greather than zero", MessageBoxIcon.Exclamation);
                this.tbamt.Focus();
                return false;
            }
            form.Amount = amount;
            return true;
        }
    }

    public partial class _x0d
    {
        public class Input
        {
            public string AccountID;
            public string PurchaseOrderNo;
            public double Amount;
            public string DateSend;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                dynamic result = API.DSpQueryAPIParam($"/api/v1/AccountCredit/SaveRequestCredit?amount{input.Amount.ToString()}", Login.authentication);
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, row["message"].Str());
                    }
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}