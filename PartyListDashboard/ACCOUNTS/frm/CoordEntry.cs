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

using static JLIDashboard.ACCOUNTS.frm._x0e;
using static JLIDashboard.ACCOUNTS.frm._x0e.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using Comm.Common.Extensions;
using JLIDashboard.Classes.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTS.frm
{
    public partial class CoordEntry : DevExpress.XtraEditors.XtraForm
    {
        public bool isEdit;
        public bool ok;
        public CoordEntry()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public CoordEntry setData(DataRow row, bool isEdit = false)
        {
            this.isEdit = isEdit;
            this.fillGenCoord(this.isEdit ? row["REF_USR_ID"].Str() : row["SUBSCR_ID"].Str());
            if (!this.isEdit) return this;
            form.AccountID = row["ACT_ID"].Str();
            form.SerialNo = row["SRIAL_ID"].Str();
            this.tbpassword.Text = "";
            this.tbpassword.Enabled = false;
            this.tsgencoord.ReadOnly = true;
            this.tbfirstname.Text = row["FRST_NM"].Str();
            this.tblastname.Text = row["LST_NM"].Str();
            this.tbaddress.Text = row["PRSNT_ADDR"].Str();
            this.tbmobilenumber.Text = row["MOB_NO"].Str().Replace("+639", "09");
            this.tbemailaddress.Text = row["EML_ADD"].Str();
            //this.tbcommrate.EditValue = row["COM_RT"].Str();
            this.tbcommrate.EditValue = row["COM_RT"].Str();
            this.tbterminalserial.Text = form.SerialNo;
            this.chkterminal.Checked = row["S_TRMNL"].To<bool>();
            this.chckreseller.Checked = row["S_RSLR"].To<bool>();
            return this;
        }
        public CoordEntry retData(DataRow row)
        {
            row["FLL_NM"] = $"{form.Firstname} {form.Lastname}".Trim();
            row["FRST_NM"] = form.Firstname;
            row["LST_NM"] = form.Lastname;
            row["PRSNT_ADDR"] = form.PresentAddress;
            row["MOB_NO"] = form.MobileNumber;
            row["EML_ADD"] = form.EmailAddress;
            row["COM_RT"] = form.SharedCommission.ToAccountingFormat("0.00");
            row["SRIAL_ID"] = form.SerialNo;
            row["S_TRMNL"] = !form.SerialNo.IsEmpty();
            row["S_RSLR"] = form.IsReseller;
            return this;
        }


        private void fillGenCoord(string genCoordId = null)
        {
            API.displaySearchLookupEditAPI("/api/v1/Coordinator/LoadGenCoord", Login.authentication, tsgencoord, "ACT_NM", "ACT_ID", new Dictionary<string, object>()
            {
                {"subscribetype","1" }
            });
            x0a(tsgencoord);
            if (genCoordId.IsEmpty()) return;
            DataRow row = tsgencoord.Select($"SUBSCR_ID='{ genCoordId }' OR ACT_ID='{ genCoordId }'").FirstOrDefault();
            if (row == null) return;
            tsgencoord.EditValue = row["ACT_ID"].Str();
        }

        private void tsgencoord_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = tsgencoord.GetFocusedDataRow();
            form.Commission = (row == null?0:row["COM_RT"].Str().ToDecimalDouble());
            ltbmax.Text = form.Commission.ToAccountingFormat("0.00") + '%';
            this.tbcommrate_EditValueChanged(null, null);
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
        private void chkterminal_CheckedChanged(object sender, EventArgs e)
        {
            this.tbterminalserial.Enabled = chkterminal.Checked;
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = (!this.isEdit ? Db.execute0a(form) : Db.execute0b(form)).Result;
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
            StaticSettings.hideLoading();
        }

        public Input form = new Input();
        private bool ValidateEntries()
        {
            string gencoordid = tsgencoord.Text.Str();
            if (gencoordid.IsEmpty())
            {
                StaticSettings.XtraMessage("General Coordinator is required", MessageBoxIcon.Exclamation);
                this.tsgencoord.Focus();
                return false;
            }

            string password = this.tbpassword.Text;
            if (password.Length < 6 && !this.isEdit)
            {
                StaticSettings.XtraMessage("Password too short, minimum of 6 digit required", MessageBoxIcon.Exclamation);
                return false;
            }

            string firstname = this.tbfirstname.Text.Trim();
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
            else
            {
                var temp = ((mobilenumber.Contains("+639") ? "" : "+") + mobilenumber).Replace("+09", "+639");
                if (!temp.Str().Equals($"+{ mobilenumber }"))
                    mobilenumber = temp;
            }
            string address = this.tbaddress.Text.Trim();
            if (address.IsEmpty())
            {
                StaticSettings.XtraMessage("Address is required", MessageBoxIcon.Exclamation);
                this.tbaddress.Focus();
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
            string serialno = "";
            if (chkterminal.Checked)
            {
                serialno = this.tbterminalserial.Text.Trim();
                if (serialno.IsEmpty())
                {
                    StaticSettings.XtraMessage("Please enter terminal serial code", MessageBoxIcon.Exclamation);
                    this.tbterminalserial.Focus();
                    return false;
                }
            }
            string isreseller = "0";
            if (chckreseller.Checked)
            {
                isreseller = "1";
            }
            form.GeneralCoordinatorID = tsgencoord.EditValue.Str();
            form.Firstname = firstname;
            form.Lastname = lastname;
            form.Password = password;
            form.PresentAddress = address;
            form.EmailAddress = this.tbemailaddress.Text.Trim();
            form.MobileNumber = mobilenumber;
            form.SharedCommission = commission;
            form.SerialNo = (this.chkterminal.Checked ? serialno : "");
            form.IsReseller = this.chckreseller.Checked;
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
                DevXSettings.XtraFormatColumn("ACT_NM", "Name", 1, gridView);
                DevXSettings.XtraFormatColumn("COM_RT", "Commission(%)", 2, gridView, MaxWidth:125);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string GeneralCoordinatorID;
            public double Commission;
            public string AccountID;
            public string Firstname;
            public string Lastname;
            public string MobileNumber;
            public string Password;
            public string PresentAddress;
            public string EmailAddress;
            public double SharedCommission;
            public string SerialNo;
            public bool IsReseller;
        }

        public class Db
        {

            public static async Task<(Results result, String message)> execute0a(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/Coordinator/DirectCoordinator", Login.authentication, new Dictionary<string, object>(){
                    { "manageractid", input.GeneralCoordinatorID },
                    { "usrmobno", input.MobileNumber },
                    { "sharedCommission", input.SharedCommission },
                    { "trmnlsrial", input.SerialNo },
                    { "rslr", (input.IsReseller?"1":"0") },

                    { "usrfnm", input.Firstname },
                    { "usrlnm", input.Lastname },
                    { "addrss", input.PresentAddress },
                    { "emladd", input.EmailAddress },
                    { "passwrd", input.Password },
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
            public static async Task<(Results result, String message)> execute0b(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/Coordinator/ModifyCoordinator", Login.authentication, new Dictionary<string, object>(){
                    { "manageractid", input.GeneralCoordinatorID },
                    { "accounid", input.AccountID },
                    { "usrmobno", input.MobileNumber },
                    { "sharedCommission", input.SharedCommission },
                    { "trmnlsrial", input.SerialNo },
                    { "rslr", (input.IsReseller?"1":"0") },

                    { "usrfnm", input.Firstname },
                    { "usrlnm", input.Lastname },
                    { "addrss", input.PresentAddress },
                    { "emladd", input.EmailAddress },

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