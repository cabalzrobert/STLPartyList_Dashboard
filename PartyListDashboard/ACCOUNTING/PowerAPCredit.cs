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
using JLIDashboard.Classes.Common.Extensions;
using Comm.Common.Extensions;

using static JLIDashboard.ACCOUNTING._x0b;
using static JLIDashboard.ACCOUNTING._x0b.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using static JLIDashboard.OPERATION._x0i;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTING
{
    public partial class PowerAPCredit : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public PowerAPCredit()
        {
            InitializeComponent();
        }

        private void PowerAPCredit_Load(object sender, EventArgs e)
        {
        }

        public PowerAPCredit setData()
        {
            string creditBal = API.getSingleQueryAPI("/api/v1/PowerAppCredit/GetCompanyCreditBalance", "ACT_CRDT_BAL",null);
            form.TotalBalance = creditBal.Str().ToDecimalDouble();
            //
            tbcreditbal.EditValue = form.TotalBalance.ToAccountingFormat("0.00");
            this.fillAccounts();
            return this;
        }
        private void fillAccounts()
        { 
            API.displaySearchLookupEditAPI("/api/v1/PowerAppCredit/GetAccountRequestor", Login.authentication, tsactnum, "ACT_ID", "ACT_ID");
            x0a(tsactnum);
            tsactnum.EditValue = null; 
        }
        private void tsactnum_EditValueChanged(object sender, EventArgs e)
        {
            tbacctname.Text = tsactnum.GetSelectedSingleValue("ACT_NM").Str();
        }

        private void tbamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            var limit = form.TotalBalance;
            if (this.tbamt.Text.Str().ToDecimalDouble() > limit) return;
            string str = this.tbamt.Text;
            int ss = tbamt.SelectionStart, sl = tbamt.SelectionLength;
            string str1 = str.Substring(0, ss), str2 = str.Substring(ss), str3 = str1 + e.KeyChar + str2;
            double parse = Convert.ToDouble(str3);
            if (parse > limit)
            {
                e.Handled = true;
                tbamt.Text = limit.ToString();
                tbamt.SelectionStart = ss + 1;
                return;
            }
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
            string acctno = this.tsactnum.Text.Trim();
            if (acctno.IsEmpty())
            {
                StaticSettings.XtraMessage("Account Number is required", MessageBoxIcon.Exclamation);
                this.tsactnum.Focus();
                return false;
            }
            double amount = this.tbamt.Text.Trim().ToDecimalDouble();
            if (amount < 1)
            {
                StaticSettings.XtraMessage("Load Amount is required", MessageBoxIcon.Exclamation);
                this.tbamt.Focus();
                return false;
            }
            form.AccountID = tsactnum.EditValue.Str();
            form.AmountSend = amount;
            return true;
        }

    }
    public partial class _x0b
    {
        public class Vyw
        {
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("ACT_ID", "Account#", 0, gridView, MaxWidth: 150);
                DevXSettings.XtraFormatColumn("ACT_NM", "Name", 1, gridView);
                DevXSettings.XtraFormatColumn("MOB_NO", "Mobile Number", 2, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string AccountID;
            public double AmountSend;
            public double TotalBalance;
            public string DateSend;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                var results = API.DAPIQueryMultiple("/api/v1/PowerAppCredit/SendCreditAmount", Login.authentication, new Dictionary<string, object>()
                {
                    {"accountID",input.AccountID },
                    {"amountSend",input.AmountSend }
                });
                if (results != null)
                {
                    string ResultCode = results["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, results["message"].Str());
                    return (Results.Failed, results["message"].Str());
                }
                return (Results.Null, null);
            }
        }
        private class notify
        {
            public static async Task<bool> Subscriber(string subscriberID, string type, IEnumerable<dynamic> list)
            {
                await Pusher.PushAsync($"/{Login.compid}/{Login.brcode}/{subscriberID}/notify"
                    , new { type=type, content=list});
                return true;
            }
        }
    }
}