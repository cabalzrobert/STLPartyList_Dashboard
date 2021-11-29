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

using static JLIDashboard.TREASURY._x0g;
using static JLIDashboard.TREASURY._x0g.Vyw;
using JLIDashboard.Module;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.TREASURY
{
    public partial class ClaimCommission : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        private bool isSelect;
        public ClaimCommission()
        {
            InitializeComponent();
        }

        private void ClaimCommission_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public ClaimCommission setData(DataRow row, bool isSelect = false)
        {
            this.isSelect = isSelect;
            tsaccountid.Visible = isSelect;
            tbaccountid.Visible = !isSelect;
            if (this.isSelect)
            {
                this.fillAccounts();
            }
            else
            {
                string custname = row["ACT_NM"].Str();
                form.AccountID = row["ACT_ID"].Str();
                form.TotalCommissionBalance = row["ACT_COM_BAL"].Str().ToDecimalDouble();
                tbaccountid.Text = form.AccountID;
                tbactname.Text = custname;
                tbcombal.EditValue = form.TotalCommissionBalance;
            }
            return this;
        }
        public ClaimCommission retData(DataRow row)
        {
            if (this.isSelect) return this;
            row["ACT_COM_BAL"] = (row["ACT_COM_BAL"].Str().ToDecimalDouble() - form.AmountRequest);
            return this;
        }


        private void fillAccounts()
        {
            API.displaySearchLookupEditAPIParam("/api/v1/Commission/Account", Login.authentication, tsaccountid, "ACT_ID", "ACT_ID");
            x0a(tsaccountid).EditValue = null;
        }

        private void tsaccountid_EditValueChanged(object sender, EventArgs e)
        {
            if (!this.isSelect) return;
            DataRow row = tsaccountid.GetFocusedDataRow();
            form.TotalCommissionBalance = row["ACT_COM_BAL"].Str().ToDecimalDouble();
            tbactname.Text = row["ACT_NM"].Str();
            tbcombal.EditValue = form.TotalCommissionBalance;
        }


        private void tbamtclaim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            var limit = form.TotalCommissionBalance;
            if (this.tbamtclaim.Text.Str().ToDecimalDouble() > limit) return;
            string str = this.tbamtclaim.Text;
            int ss = tbamtclaim.SelectionStart, sl = tbamtclaim.SelectionLength;
            string str1 = str.Substring(0, ss), str2 = str.Substring(ss), str3 = str1 + e.KeyChar + str2;
            double parse = Convert.ToDouble(str3);
            if (parse > limit)
            {
                e.Handled = true;
                tbamtclaim.Text = limit.ToString();
                tbamtclaim.SelectionStart = ss + 1;
                return;
            }
        }
        private void tbamtclaim_EditValueChanged(object sender, EventArgs e)
        {

        }

        /*private void btnclaim_Click(object sender, EventArgs e)
        {
           string operatorid = Login.compid + Login.custid;
            
            string result = Database.getSingleResultSet($"exec dbo.spfunc_012BA0P1CC '{Login.compid}','{operatorid}','{tbaccountid.Text}','{tbamtclaim.Text}' ");
            if (result == "1")
            {
                XtraMessageBox.Show("Successfully Confirmed");
                ok = true;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Error Please Try Again! " + result);
            }
        }*/

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
            string acctno = (!this.isSelect? this.tbaccountid:this.tsaccountid).Text.Trim();
            if (acctno.IsEmpty())
            {
                StaticSettings.XtraMessage("Account Number is required", MessageBoxIcon.Exclamation);
                this.tbaccountid.Focus();
                return false;
            }

            double amount = this.tbamtclaim.Text.Trim().ToDecimalDouble();
            if (amount < 0.01)
            {
                StaticSettings.XtraMessage("Please enter amount greater than zero", MessageBoxIcon.Exclamation);
                this.tbamtclaim.Focus();
                return false;
            }
            double commbal = this.tbcombal.Text.Trim().ToDecimalDouble();
            if (amount > commbal)
            {
                StaticSettings.XtraMessage("Insufficient Balance", MessageBoxIcon.Exclamation);
                this.tbcombal.Focus();
                return false;
            }

            form.AccountID = (!this.isSelect ? this.tbaccountid.Text : this.tsaccountid.EditValue).Str();
            form.AmountRequest = amount;
            return true;
        }
    }

    public partial class _x0g
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
                DevXSettings.XtraFormatColumn("ACT_COM_BAL", "Commission(%)", 2, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string AccountID;
            public double AmountRequest;
            public double TotalCommissionBalance;
            public string DateRequest;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                dynamic result = API.DSpQueryAPI("/api/v1/Commission/ClaimCommission", Login.authentication, new Dictionary<string, object>(){
                    { "accountID", input.AccountID },
                    { "amountRequest", input.AmountRequest },
                });
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