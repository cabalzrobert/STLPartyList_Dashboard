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

using static JLIDashboard.SETTINGS._x0b;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using Comm.Common.Extensions;

namespace JLIDashboard.SETTINGS
{
    public partial class AccountInfo : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public AccountInfo()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ok = false;

            tbfirstname.Text = Login.userfname;
            tblastname.Text = Login.userlname;
            tbmobilenumber.Text = Login.usermobno.Str().Replace("+639", "09");
            tbaddress.Text = Login.userprsntaddr;
            tbemailaddress.Text = Login.useremailaddr;
        }


        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = Db.execute0a(form).Result;
            if (res.result == Results.Success)
            {
                this.ok = true;
                Login.userfname = form.Firstname;
                Login.userlname = form.Lastname;
                Login.userprsntaddr = form.PresentAddress;
                Login.useremailaddr = form.EmailAddress;
                Login.usermobno = form.MobileNumber;
                Login.userfullname = ($"{form.Firstname} {form.Lastname}").Trim();
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
            form.Firstname = firstname;
            form.Lastname = lastname;
            form.PresentAddress = address;
            form.EmailAddress = this.tbemailaddress.Text.Trim();
            form.MobileNumber = mobilenumber;
            return true;
        }
    }

    public partial class _x0b
    {
        public class Input
        {
            public string Firstname;
            public string Lastname;
            public string MobileNumber;
            public string PresentAddress;
            public string EmailAddress;
        }

        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(Input input)
            {
                var result = Database.DSpQuery<dynamic>("dbo.spfunc_002OI0CPD1U", new Dictionary<string, object>(){
                    { "parmcompid", Login.compid },
                    { "parmbrcd", Login.brcode },
                    { "parmoptrid", Login.userid },

                    { "parmusrfnm", input.Firstname },
                    { "parmusrlnm", input.Lastname },
                    { "parmprsntadd", input.PresentAddress },
                    { "parmusrmobno", input.MobileNumber },
                    { "parmemladd", input.EmailAddress },
                }).FirstOrDefault();
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["RESULT"].Str();
                    if (ResultCode == "1")
                        return (Results.Success, "Change Successfull!");
                    //else if (ResultCode == "2")
                    //    return (Results.Failed, String.Format("Mobile number {0} has been used!", input.MobileNumber));
                    else if (ResultCode == "66")
                        return (Results.Failed, String.Format("Email address {0} is already associated on existing customer account!", input.EmailAddress));
                    return (Results.Failed, "Somethings wrong in your data. Please try again");
                }
                return (Results.Null, null);
            }
        }
    }
}