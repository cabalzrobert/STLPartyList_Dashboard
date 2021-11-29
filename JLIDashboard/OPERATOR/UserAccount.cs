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
using JLIDashboard.Module;
using JLIDashboard.Classes;
using JLIDashboard._Module;

using static JLIDashboard.OPERATOR._x0a;
using static JLIDashboard.OPERATOR._x0a.Vyw;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using Comm.Common.Extensions;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard.OPERATOR.frm;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR
{
    public partial class UserAccount : DevExpress.XtraEditors.XtraForm
    {
        private bool isNew;
        public UserAccount()
        {
            InitializeComponent();
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            Timeout.Set(() => this.Invoke(new Action(() => this.loadTableWProgress())), 250);
            this.setData();
        }


        public UserAccount setData()
        {
            this.setInput(null);
            this.inputEnability(false);
            this.fillDept();
            return this;
        }
        private UserAccount retData(DataRow row)
        {
            row["USR_TYP_NM"] = form.Department;
            row["USR_TYP"] = form.DepartmentID; 
            row["FRST_NM"] = form.Firstname;
            row["LST_NM"] = form.Lastname;
            row["FLL_NM"] = form.Fullname;
            row["PRSNT_ADDR"] = form.PresentAddress;
            row["MOB_NO"] = form.MobileNumber;
            row["EML_ADD"] = form.EmailAddress;
            return this;
        }
        private void fillDept()
        {
            API.displaySearchLookupEditAPIParam("/api/v1/Users/LoadDepartment", Login.authentication, tsdept, "USR_TYP_NM", "USR_TYP");
            x0a(tsdept).EditValue = null;
        }
        private void inputEnability(bool enable)
        {
            tbfname.Enabled = enable;
            tblname.Enabled = enable;
            tbaddress.Enabled = enable;
            tbusername.Enabled = enable;
            tbpassword.Enabled = enable;
            tbmobno.Enabled = enable;
            tbemail.Enabled = enable;
            tsdept.Enabled = enable;
        }
        private void setInput(DataRow row)
        {
            bool isNull = (row == null);
            this.isNew = isNull;
            tsdept.EditValue = (isNull ? "" : row["USR_TYP"].Str());
            tbfname.Text = (isNull ? "" : row["FRST_NM"].Str());
            tblname.Text = (isNull ? "" : row["LST_NM"].Str());
            tbaddress.Text = (isNull ? "" : row["PRSNT_ADDR"].Str());
            tbusername.Text = (isNull ? "" : row["USR_NM"].Str());
            tbpassword.Text = "";// (isNull ? "" : row["REM_TRM"].Str());
            tbmobno.Text = (isNull ? "" : row["MOB_NO"].Str().Replace("+639","09"));
            tbemail.Text = (isNull ? "" : row["EML_ADD"].Str());
            tbusername.ReadOnly = !this.isNew;
            tbpassword.Enabled = this.isNew;
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            this.setInput(null);
            this.inputEnability(true);
            form.OperatorID = null;
            btnsubmit.Text = "Save";
            btnsubmit.Visible = btncancel.Visible = true;
            btnnew.Visible = false;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.setInput(null);
            this.inputEnability(false);
            btnnew.Visible = true;
            btnsubmit.Visible = btncancel.Visible = false;
        }
        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null);
            cmsBrBtn0b.Visible = hasSelected;
            cmsBrBtn0c.Visible = hasSelected;
            cmsBrBtn0d.Visible = hasSelected;
            cmsBrSep0a.Visible = hasSelected;
            if (!hasSelected) return;
            cmsBrBtn0d.Text = (row["S_BLCK"].To<bool>(false) ? "Unblock" : "Block") + "ed User";
        }

        private void cmsBrBtn0b_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            form.OperatorID = row["OPTR_ID"].Str();
            this.inputEnability(true);
            this.setInput(row);
            btnsubmit.Text = "Save Changes";
            btnsubmit.Visible = btncancel.Visible = true;
            btnnew.Visible = false;
        }
        private void cmsBrBtn0a_Click(object sender, EventArgs e)
        {
            this.loadTableWProgress();
        }
        private void loadTableWProgress(int focusedRow = 0)
        {
            StaticSettings.showLoading();
            this.loadTable(focusedRow);
            StaticSettings.hideLoading();
        }

        private void loadTable(int focusedRow = 0)
        {
            API.displayAPI("/api/v1/Users/GetUsers", gridControl1, gridView1, Login.authentication);
            if (v0a(gridView1).RowCount != 0)
            {
                this.gridView1.FocusedRowHandle = focusedRow;
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = (isNew ? Db.execute0a(form) : Db.execute0b(form)).Result;
            if (res.result == Results.Success)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                if (isNew)
                {
                    btncancel.PerformClick();
                    this.loadTableWProgress(gridView1.RowCount);
                }
                else
                {
                    DataRow row = gridView1.GetFocusedDataRow();
                    this.retData(row);
                    gridView1.RefreshRow(gridView1.FocusedRowHandle);
                }
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
            string dept = this.tsdept.Text.Trim();
            if (dept.IsEmpty())
            {
                StaticSettings.XtraMessage("Please select department", MessageBoxIcon.Exclamation);
                this.tsdept.Focus();
                return false;
            }
            string username = this.tbusername.Text.Trim().ToLower();
            if (username.Length < 5 && this.isNew)
            {
                StaticSettings.XtraMessage("Username too short, minimum of 6 digit required", MessageBoxIcon.Exclamation);
                this.tbusername.Focus();
                return false;
            }
            string password = this.tbpassword.Text;
            if (password.Length < 6 && this.isNew)
            {
                StaticSettings.XtraMessage("Password too short, minimum of 6 digit required", MessageBoxIcon.Exclamation);
                this.tbpassword.Focus();
                return false;
            }
            string firstname = this.tbfname.Text.Trim();
            if (firstname.IsEmpty())
            {
                StaticSettings.XtraMessage("Firstname is required", MessageBoxIcon.Exclamation);
                this.tbfname.Focus();
                return false;
            }
            string lastname = this.tblname.Text.Trim();
            if (lastname.IsEmpty())
            {
                StaticSettings.XtraMessage("Lastname is required", MessageBoxIcon.Exclamation);
                this.tblname.Focus();
                return false;
            }
            string mobilenumber = this.tbmobno.Text.Trim();
            if (mobilenumber.IsEmpty())
            {
                StaticSettings.XtraMessage("Mobile number is required", MessageBoxIcon.Exclamation);
                this.tbmobno.Focus();
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
            //
            form.Username = username;
            form.Password = password;
            form.Firstname = firstname;
            form.Lastname = lastname;
            form.Fullname = $"{form.Firstname} {form.Lastname}".Trim();
            form.MobileNumber = mobilenumber;
            form.PresentAddress = address;
            form.EmailAddress = tbemail.Text;
            form.DepartmentID = tsdept.EditValue.Str();
            form.Department = tsdept.Text;
            return true;
        }

        private void cmsBrBtn0c_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row == null) return;
            var win = Application.OpenForms.Singleton<ResetPassword>().setData(row);
            win.ShowDialog();
        }

        private void cmsBrBtn0d_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row == null) return;
            var focusedrow = gridView1.FocusedRowHandle;
            bool blocked = row["S_BLCK"].To<bool>(false);
            string msg = (blocked ? "Unblock" : "Block");
            string custname = row["FLL_NM"].Str(); // " + title + "
            if (XtraMessageBox.Show("Are you sure you want to " + msg.ToLower() + "?", msg + ": " + custname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StaticSettings.showLoading();
                string actId = row["OPTR_ID"].Str();
                var res = Db.execute0c(actId).Result;
                if (res.result == Results.Success)
                {
                    row["S_BLCK"] = !blocked;
                    gridView1.RefreshRow(focusedrow);
                    StaticSettings.XtraMessage("Successfully " + msg.ToLower() + "ed", MessageBoxIcon.Asterisk);
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
        }
    }

    public partial class _x0a
    {
        public class Vyw
        {
            public static GridView v0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("S_BLCK", "Block", 0, gridView);
                    DevXSettings.XtraFormatColumn("USR_NM", "Username", 1, gridView);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Fullname", 2, gridView);
                    DevXSettings.XtraFormatColumn("PRSNT_ADDR", "Address", 3, gridView);
                    DevXSettings.XtraFormatColumn("MOB_NO", "Mobile No.", 4, gridView);
                    DevXSettings.XtraFormatColumn("EML_ADD", "Email Address", 5, gridView);
                    DevXSettings.XtraFormatColumn("USR_TYP_NM", "Department", 6, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Date Registered", 7, gridView);
                    DevXSettings.XgridColAlign(new[] { "USR_NM", "S_BLCK", "RGS_TRN_TS_NM", "MOB_NO" }, gridView, HorzAlignment.Center);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("USR_TYP_NM", "Department", 0, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }

        public class Input
        {
            public string OperatorID;
            public string Firstname;
            public string Lastname;
            public string Fullname;
            public string PresentAddress;
            public string MobileNumber;
            public string EmailAddress;
            public string Department;
            public string DepartmentID;
            public string Username;
            public string Password;
        }

        public class Input0a
        {
            public string OperatorID;
            public string Password;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                return await _execute0a(input, false);
            }
            public static async Task<(Results result, string message)> execute0b(Input input)
            {
                return await _execute0a(input);
            }
            public static async Task<(Results result, String message)> execute0c(String OperatorID)
            {
                var result = API.DSpQueryAPIParam($"/api/v1/Branches/BlockBranchAccount?branchid={Login.pgrpid}&operatorid={OperatorID}", Login.authentication);
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, row["message"].Str());
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
            private static async Task<(Results result, string message)> _execute0a(Input input, bool IsUpdate = true)
            {
                dynamic result = API.DSpQueryAPI("/api/v1/Users/UpdateUsers", Login.authentication, new Dictionary<string, object>(){
                    { "parmcd", (!IsUpdate?"1":"3") },
                    { "operatorID", input.OperatorID },
                    { "firstname", input.Firstname  },
                    { "lastname", input.Lastname  },
                    { "username", input.Username  },
                    { "password", input.Password  },
                    { "presentAddress", input.PresentAddress  },
                    { "mobileNumber", input.MobileNumber  },
                    { "emailAddress", input.EmailAddress  },
                    { "departmentID", input.DepartmentID  },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, row["message"].Str());
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}