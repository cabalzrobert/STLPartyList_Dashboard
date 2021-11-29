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

using static JLIDashboard.OPERATOR.frm._x0c;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using Comm.Common.Extensions;
using System.Text.RegularExpressions;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR.frm
{
    public partial class ResetPassword : DevExpress.XtraEditors.XtraForm
    {
        public ResetPassword()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public ResetPassword setData(DataRow row, bool isAgent = false)
        {
            form.BranchID = ((form.IsAgent = isAgent)? row["BR_CD"].Str() : Login.brcode);
            string custname = row["FLL_NM"].Str().Trim();
            form.OperatorID = row["OPTR_ID"].Str();
            this.Text = "Reset Password - " + custname;
            return this;
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
            string newpassword = this.tbpassword.Text.Trim();
            if (newpassword.IsEmpty())
            {
                XtraMessageBox.Show("Please enter new password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbpassword.Focus();
                return false;
            }
            if (Regex.Replace(newpassword, @"[ ]", "") != newpassword)
            {
                XtraMessageBox.Show("Please do not include space character", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbpassword.Focus();
                return false;
            }
            if (newpassword.Length < 6)
            {
                StaticSettings.XtraMessage("Password too short, minimum of 6 digit required", MessageBoxIcon.Exclamation);
                tbpassword.Focus();
                return false;
            }

            string confirmpassword = this.tbconfirmpassword.Text.Trim();
            if (confirmpassword.IsEmpty())
            {
                XtraMessageBox.Show("Please enter confirm password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbconfirmpassword.Focus();
                return false;
            }
            if (confirmpassword.Length < 6)
            {
                StaticSettings.XtraMessage("Password too short, minimum of 6 digit required", MessageBoxIcon.Exclamation);
                tbconfirmpassword.Focus();
                return false;
            }
            if (newpassword != confirmpassword)
            {
                StaticSettings.XtraMessage("Password mismatched.", MessageBoxIcon.Exclamation);
                tbconfirmpassword.Focus();
                return false;
            }

            form.Password = newpassword;
            form.ConfirmPassword = confirmpassword;
            return true;
        }
    }

    public partial class _x0c
    {
        public class Input
        {
            public string BranchID;
            public string OperatorID; 
            public string Password;
            public string ConfirmPassword;
            public bool IsAgent;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/Branches/ResetUserPassword", Login.authentication, new Dictionary<string, object>(){
                    { "isAgent", input.IsAgent?"1":"0" },
                    { "operatorID", input.OperatorID },
                    { "password", input.Password },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, row["result"].Str());
                    return (Results.Failed, row["result"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}