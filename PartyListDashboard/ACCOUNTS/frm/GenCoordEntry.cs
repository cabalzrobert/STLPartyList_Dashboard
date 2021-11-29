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

using static JLIDashboard.ACCOUNTS.frm._x0d;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using Comm.Common.Extensions;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTS.frm
{
    public partial class GenCoordEntry : DevExpress.XtraEditors.XtraForm
    {
        public bool isEdit;
        public bool ok;
        public GenCoordEntry()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public GenCoordEntry setData(DataRow row)
        {
            this.isEdit = true;
            form.AccountID = row["ACT_ID"].Str();
            this.tbpassword.Text = "";
            this.tbpassword.Enabled = false;
            this.tbfirstname.Text = row["FRST_NM"].Str();
            this.tblastname.Text = row["LST_NM"].Str();
            this.tbaddress.Text = row["PRSNT_ADDR"].Str();
            this.tbmobilenumber.Text = row["MOB_NO"].Str().Replace("+639", "09");
            this.tbemailaddress.Text = row["EML_ADD"].Str();
            this.tbcommrate.EditValue = row["COM_RT"].Str();
            this.chckreseller.Checked = row["S_RSLR"].To<bool>();
            return this;
        }
        public GenCoordEntry retData(DataRow row)
        {
            row["FLL_NM"] = $"{form.Firstname} {form.Lastname}".Trim();
            row["FRST_NM"] = form.Firstname;
            row["LST_NM"] = form.Lastname;
            row["PRSNT_ADDR"] = form.PresentAddress;
            row["MOB_NO"] = form.MobileNumber;
            row["EML_ADD"] = form.EmailAddress;
            row["COM_RT"] = form.SharedCommission.ToAccountingFormat("0.00");
            row["S_RSLR"] = form.IsReseller;
            return this;
        }

        private void tbcommrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            if (this.tbcommrate.Text.Str().ToDecimalDouble() > 100) return;
            string str = this.tbcommrate.Text;
            int ss = tbcommrate.SelectionStart, sl = tbcommrate.SelectionLength;
            string str1 = str.Substring(0, ss), str2 = str.Substring(ss), str3 = str1 + e.KeyChar + str2;
            double parse = Convert.ToDouble(str3);
            if (parse > 100)
            {
                e.Handled = true;
                tbcommrate.Text = "100";
                tbcommrate.SelectionStart = ss + 1;
                return;
            }
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = (!this.isEdit? Db.execute0a(form): Db.execute0b(form)).Result;
            if (res.result == Results.Success)
            {
                this.ok = true;
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

            form.Firstname = firstname;
            form.Lastname = lastname;
            form.Password = password;
            form.PresentAddress = address;
            form.EmailAddress = this.tbemailaddress.Text.Trim();
            form.MobileNumber = mobilenumber;
            form.SharedCommission = commission;
            form.IsReseller = this.chckreseller.Checked;
            return true;
        }
    }

    public partial class _x0d
    {
        public class Input
        {
            public string AccountID;
            public string Firstname;
            public string Lastname;
            public string MobileNumber;
            public string Password;
            public string PresentAddress;
            public string EmailAddress;
            public double SharedCommission;
            public bool IsReseller;
        }

        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/GeneralCoordinator/AddGeneralCoord", Login.authentication, new Dictionary<string, object>(){
                    { "usrmobno", input.MobileNumber },
                    { "sharedCommission", input.SharedCommission },
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
                var result = API.DSpQueryAPI("/api/v1/GeneralCoordinator/ModifyGeneralCoord", Login.authentication, new Dictionary<string, object>(){
                    { "accountID", input.AccountID },
                    { "usrmobno", input.MobileNumber },
                    { "sharedCommission", input.SharedCommission },
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