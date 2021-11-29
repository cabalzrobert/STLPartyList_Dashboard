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

using static JLIDashboard.ACCOUNTS.frm._x0b;
using static JLIDashboard.ACCOUNTS.frm._x0b.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using Comm.Common.Extensions;
using JLIDashboard.Classes.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTS.frm
{
    public partial class InviteCoord : DevExpress.XtraEditors.XtraForm
    {
        public InviteCoord()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public InviteCoord setData(DataRow row)
        {
            form.GeneralCoordinatorID = row["ACT_ID"].Str();
            form.Commission = row["COM_RT"].Str().ToDecimalDouble();
            //
            this.fillGenCoord(form.GeneralCoordinatorID);
            return this;
        }

        private void fillGenCoord(string genCoordId)
        {
            API.displaySearchLookupEditAPI("/api/v1/Coordinator/LoadGenCoord", Login.authentication, tsgencoord, "ACT_NM", "ACT_ID", new Dictionary<string, object>()
            {
                {"subscribetype","1" }
            });
            x0a(tsgencoord);
            if (genCoordId.IsEmpty()) return;
            DataRow row = tsgencoord.Select($"SUBSCR_ID='{genCoordId}' OR ACT_ID='{genCoordId}'").FirstOrDefault();
            if (row == null) return;
            tsgencoord.EditValue = row["ACT_ID"].Str();
        }

        private void tsgencoord_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = tsgencoord.GetFocusedDataRow();
            double commrate = (row == null ? 0 : row["COM_RT"].Str().ToDecimalDouble());
            ltbmax.Text = commrate.ToAccountingFormat("0.00") + '%';
        }

        private void tbcommrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            var limit = form.Commission;
            if (this.tbcommrate.Text.Str().ToDecimalDouble() > limit) return;
            string str = this.tbcommrate.Text;
            int ss = tbcommrate.SelectionStart, sl = tbcommrate.SelectionLength;
            string str1 = str.Substring(0, ss), str2 = str.Substring(ss), str3 = str1 + e.KeyChar + str2;
            double parse = Convert.ToDouble(str3);
            if (parse > limit)
            {
                e.Handled = true;
                tbcommrate.Text = limit.ToString();
                tbcommrate.SelectionStart = ss + 1;
                return;
            }
        }

        private void tbcommrate_EditValueChanged(object sender, EventArgs e)
        {
            double parse = tbcommrate.Text.Str().ToDecimalDouble();
            ltbmax.Text = (form.Commission - parse).ToAccountingFormat("0.00") + '%';
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = Db.execute0a(form).Result;
            if (res.result == Results.Success)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else if(res.result != Results.Null)
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
            string gencoordinator = tsgencoord.Text.Str();
            if (gencoordinator.IsEmpty())
            {
                StaticSettings.XtraMessage("General Coordinator is required", MessageBoxIcon.Exclamation);
                return false;
            }
            string firstname = tbfirstname.Text.Trim();
            if (firstname.IsEmpty())
            {
                StaticSettings.XtraMessage("Firstname is required", MessageBoxIcon.Exclamation);
                this.tbfirstname.Focus();
                return false;
            }
            string lastname = this.tblastname.Text.Trim();
            if (lastname.IsEmpty())
            {
                StaticSettings.XtraMessage("Lastname is required", MessageBoxIcon.Exclamation);
                this.tblastname.Focus();
                return false;
            }
            string mobilenumber = this.tbmobilenumber.Text.Trim();
            if (mobilenumber.IsEmpty())
            {
                StaticSettings.XtraMessage("Mobile number is required", MessageBoxIcon.Exclamation);
                this.tbmobilenumber.Focus();
                return false;
            }
            double commission = this.tbcommrate.Text.Trim().ToDecimalDouble();
            if (commission < 0.0)
            {
                StaticSettings.XtraMessage("Commission is required", MessageBoxIcon.Exclamation);
                this.tbcommrate.Focus();
                return false;
            }
            if (commission > 100.0)
            {
                StaticSettings.XtraMessage("maximum of 100% commission only", MessageBoxIcon.Exclamation);
                this.tbcommrate.Focus();
                return false;
            }
            form.GeneralCoordinatorID = tsgencoord.EditValue.Str();
            form.Firstname = firstname;
            form.Lastname = lastname;
            form.MobileNumber = mobilenumber;
            form.SharedCommission = commission;
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
                DevXSettings.XtraFormatColumn("COM_RT", "Commission(%)", 2, gridView, MaxWidth: 125);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string GeneralCoordinatorID;
            public double Commission;
            public string Firstname;
            public string Lastname;
            public string MobileNumber;
            public double SharedCommission;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/Coordinator/InviteCoordinator", Login.authentication, new Dictionary<string, object>(){
                    { "manageractid", input.GeneralCoordinatorID },
                    { "usrmobno", input.MobileNumber },
                    { "usrfnm", input.Firstname },
                    { "usrlnm", input.Lastname },
                    { "sharedCommission", input.SharedCommission },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, row["message"].Str());
                    else if (ResultCode == "1")
                        return (Results.Failed, row["message"].Str());
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}