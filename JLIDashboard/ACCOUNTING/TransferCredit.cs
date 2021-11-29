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

using static JLIDashboard.ACCOUNTING._x0e;
using static JLIDashboard.ACCOUNTING._x0e.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTING
{
    public partial class TransferCredit : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public TransferCredit()
        {
            InitializeComponent();
        }

        private void TransferCredit_Load(object sender, EventArgs e)
        {

        }

        public TransferCredit setData()
        {
            this.fillAccounts();
            return this;
        }


        private void fillAccounts()
        {
            API.displaySearchLookupEditAPI("/api/v1/TransferCredit/Load_AccountList", Login.authentication, tsactnum, "ACT_ID", "ACT_ID", new Dictionary<string, object>()
            {
                {"compID",Login.plid },
                {"branchID",Login.pgrpid }
            });

            x0a(tsactnum).EditValue = null;
            API.displaySearchLookupEditAPI("/api/v1/TransferCredit/Load_AccountList", Login.authentication, tsactnum1, "ACT_ID", "ACT_ID");
            x0a(tsactnum1).EditValue = null;
        }
        private void tsactnum_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = tsactnum.GetFocusedDataRow();
            var isEmpty = (row == null);
            tbacctname.Text = (isEmpty ? "" : row["ACT_NM"]).Str();
            tbcreditbal.Text = (isEmpty ? "" : row["ACT_CRDT_BAL"]).Str().getAccountingFormat();
            tbamttransfer.EditValue = 0;
            calculateTotalBalance();
        }

        private void tbamttransfer_EditValueChanged(object sender, EventArgs e)
        {
            this.calculateTotalBalance();
        }
        private void tbamttransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            if (tbcreditbal.Text.IsEmpty()) return;
            var limit = tbcreditbal.Text.Str().ToDecimalDouble();
            if (this.tbamttransfer.Text.Str().ToDecimalDouble() > limit) return;
            string str = this.tbamttransfer.Text;
            int ss = tbamttransfer.SelectionStart, sl = tbamttransfer.SelectionLength;
            string str1 = str.Substring(0, ss), str2 = str.Substring(ss), str3 = str1 + e.KeyChar + str2;
            double parse = Convert.ToDouble(str3);
            if (parse > limit)
            {
                e.Handled = true;
                tbamttransfer.Text = limit.ToString();
                tbamttransfer.SelectionStart = ss + 1;
                return;
            }
        }

        private void tsactnum1_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = tsactnum1.GetFocusedDataRow();
            var isEmpty = (row == null);
            tbacctname1.Text = (isEmpty ? "" : row["ACT_NM"]).Str();
            tbcreditbal1.Text = (isEmpty ? "" : row["ACT_CRDT_BAL"]).Str().getAccountingFormat();
            calculateTotalBalance();
        }

        private void calculateTotalBalance()
        {
            tbtotalbal.Text = "-";
            DataRow row1 = tsactnum.GetFocusedDataRow();
            if (row1 == null) return;
            DataRow row2 = tsactnum1.GetFocusedDataRow();
            if (row2 == null) return;
            if (row1["ACT_ID"].Str().Equals(row2["ACT_ID"])) return;
            //double source = row1["ACT_CRDT_BAL"].Str().ToDecimalDouble();
            double source = tbamttransfer.Text.ToDecimalDouble();
            if (source < 1) return;
            double destination = row2["ACT_CRDT_BAL"].Str().ToDecimalDouble();
            tbtotalbal.Text = (source + destination).ToAccountingFormat();
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
            string source = this.tsactnum.Text.Trim();
            if (source.IsEmpty())
            {
                StaticSettings.XtraMessage("Source Account Number is required", MessageBoxIcon.Exclamation);
                this.tsactnum.Focus();
                return false;
            }
            //double amounttranfer = tbamttranfer.Text.ToDecimalDouble();
            double amount = tbamttransfer.Text.Str().ToDecimalDouble();
            if (amount<1)
            {
                StaticSettings.XtraMessage("Insufficient Credit Balance", MessageBoxIcon.Exclamation); //Source Account Balance is required
                this.tsactnum.Focus();
                return false;
            }
            string destination = this.tsactnum1.Text.Trim();
            if (destination.IsEmpty())
            {
                StaticSettings.XtraMessage("Destination Account Number is required", MessageBoxIcon.Exclamation);
                this.tsactnum1.Focus();
                return false;
            }
            if (tsactnum.EditValue.Str().Equals(tsactnum1.EditValue.Str()))
            {
                StaticSettings.XtraMessage("Cannot transfer account due to the same account", MessageBoxIcon.Exclamation);
                this.tsactnum.Focus();
                return false;
            }
            form.AmountTransfer = amount;
            form.SourceID = tsactnum.EditValue.Str();
            form.DestinationID = tsactnum1.EditValue.Str();
            return true;
        }
    }
    public partial class _x0e
    {
        public class Vyw
        {
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("ACT_ID", "Account#", 0, gridView, MaxWidth: 150);
                DevXSettings.XtraFormatColumn("ACT_NM", "Name", 1, gridView, 125);
                DevXSettings.XtraFormatColumn("MOB_NO", "Mobile Number", 2, gridView);
                DevXSettings.XtraFormatColumn("ACT_CRDT_BAL", "Credit Balance", 3, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string SourceID;
            public double AmountTransfer;
            public string DestinationID;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                dynamic result = API.DSpQueryAPI("/api/v1/TransferCredit/TransferCredit", Login.authentication, new Dictionary<string, object>(){
                    { "sourceID", input.SourceID },
                    { "destinationID", input.DestinationID },
                    { "amountTransfer", input.AmountTransfer },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                    {
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