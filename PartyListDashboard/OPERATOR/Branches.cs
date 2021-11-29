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

using static JLIDashboard.OPERATOR._x0c;
using static JLIDashboard.OPERATOR._x0c.Vyw;
using Comm.Common.Extensions;
using JLIDashboard.Module;
using JLIDashboard.Classes;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using DevExpress.Utils;
using AbacosDashboard.Module.Enum;
using JLIDashboard.OPERATOR.frm;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR
{
    public partial class Branches : DevExpress.XtraEditors.XtraForm
    {
        private bool isNew;
        public Branches()
        {
            InitializeComponent();
        }

        private void Branches_Load(object sender, EventArgs e)
        {
            Timeout.Set(() => this.Invoke(new Action(() => this.loadTableWProgress())), 250);
            this.setData();
        }

        public Branches setData()
        {
            this.setInput(null);
            this.inputEnability(false);
            //this.fillDept();
            return this;
        }
        private Branches retData(DataRow row)
        {
            row["BR_NME"] = form.BranchName;
            row["BR_ADDRS"] = form.BranchAddress;
            row["BR_LOC_ZP"] = form.ZipCode;
            row["LCNSD_NO"] = form.LicenseNo;
            row["TIN_NO"] = form.TinNo;
            row["SHRT_NM"] = form.ShortName;
            row["AREA_NM"] = form.AreaName;
            row["BR_TEL_NO"] = form.TelephoneNumber;
            row["BR_TCHSUPNO"] = form.TechSupportNumber;
            row["BR_EML"] = form.EmailAddress;
            row["BR_WBST"] = form.WebsiteUrl;

            var agent = form.Agent;
            row["FRST_NM"] = agent.Firstname;
            row["LST_NM"] = agent.Lastname;
            row["FLL_NM"] = agent.Fullname;
            row["PRSNT_ADDR"] = agent.PresentAddress;
            row["MOB_NO"] = agent.MobileNumber;
            row["EML_ADD"] = agent.EmailAddress;
            return this;
        }

        private void inputEnability(bool enable)
        {
            tbbrcode.Enabled = enable;
            tbbrname.Enabled = enable;
            tbbraddress.Enabled = enable;
            tbzipcode.Enabled = enable;
            tblicenseno.Enabled = enable;
            tbtinno.Enabled = enable;
            tbshortname.Enabled = enable;
            tbareaname.Enabled = enable;
            tbtelno.Enabled = enable;
            tbtechsupp.Enabled = enable;
            tbbremail.Enabled = enable;
            tbwebsite.Enabled = enable;

            tbfname.Enabled = enable;
            tblname.Enabled = enable;
            tbusername.Enabled = enable;
            tbpassword.Enabled = enable;
            tbaddress.Enabled = enable;
            tbmobno.Enabled = enable;
            tbemail.Enabled = enable;
        }
        private void setInput(DataRow row)
        {
            bool isNull = (row == null);
            this.isNew = isNull;
            
            tbbrcode.Text = (isNull ? "" : row["BR_CD"].Str());
            tbbrname.Text = (isNull ? "" : row["BR_NME"].Str());
            tbbraddress.Text = (isNull ? "" : row["BR_ADDRS"].Str());
            tbzipcode.Text = (isNull ? "" : row["BR_LOC_ZP"].Str());
            tblicenseno.Text = (isNull ? "" : row["LCNSD_NO"].Str());
            tbtinno.Text = (isNull ? "" : row["TIN_NO"].Str());
            tbshortname.Text = (isNull ? "" : row["SHRT_NM"].Str());
            tbareaname.Text = (isNull ? "" : row["AREA_NM"].Str());
            tbtelno.Text = (isNull ? "" : row["BR_TEL_NO"].Str());
            tbtechsupp.Text = (isNull ? "" : row["BR_TCHSUPNO"].Str());
            tbbremail.Text = (isNull ? "" : row["BR_EML"].Str());
            tbwebsite.Text = (isNull ? "" : row["BR_WBST"].Str());
            //
            tbfname.Text = (isNull ? "" : row["FRST_NM"].Str());
            tblname.Text = (isNull ? "" : row["LST_NM"].Str());
            tbaddress.Text = (isNull ? "" : row["PRSNT_ADDR"].Str());
            tbusername.Text = (isNull ? "" : row["USR_NM"].Str());
            tbpassword.Text = "";// (isNull ? "" : row["REM_TRM"].Str());
            tbmobno.Text = (isNull ? "" : row["MOB_NO"].Str().Replace("+639", "09"));
            tbemail.Text = (isNull ? "" : row["EML_ADD"].Str());

            tbbrcode.Enabled = false;
            tbusername.ReadOnly = !this.isNew;
            tbpassword.Enabled = this.isNew;
        }
        private void loadTableWProgress(int focusedRow = 0)
        {
            StaticSettings.showLoading();
            this.loadTable(focusedRow);
            StaticSettings.hideLoading();
        }

        private void loadTable(int focusedRow = 0)
        {
            API.displayAPI("/api/v1/Branches/GetBranch", gridControl1, gridView1, Login.authentication);
            if (v0a(gridView1).RowCount != 0)
            {
                this.gridView1.FocusedRowHandle = focusedRow;
                this.gridView1_RowClick(this.gridView1, null);
            }
        }
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            filter.BranchID = row["BR_CD"].Str();
            if (e == null) this.loadOperator();
            else this.loadOperatorWProgress();
        }


        private Filter filter = new Filter();
        private void loadOperatorWProgress()
        {
            StaticSettings.showLoading();
            this.loadOperator();
            StaticSettings.hideLoading();
        }

        private void loadOperator()
        {
            API.displayAPI("/api/v1/Users/GetUsers", gridControl2, gridView2, Login.authentication);
            v0b(gridView2);
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

        private void btnnew_Click(object sender, EventArgs e)
        {
            this.setInput(null);
            this.inputEnability(true);
            form.BranchID = form.OperatorID = null;
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
        private void cmsOptrBtn0a_Click(object sender, EventArgs e)
        {
            this.loadOperatorWProgress();
        }

        private void cmsBrBtn0a_Click(object sender, EventArgs e)
        {
            this.loadTableWProgress();
        }
        private void cmsBrBtn0b_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            form.BranchID = row["BR_CD"].Str();
            form.OperatorID = row["OPTR_ID"].Str();
            this.inputEnability(true);
            this.setInput(row);
            btnsubmit.Text = "Save Changes";
            btnsubmit.Visible = btncancel.Visible = true;
            btnnew.Visible = false;
        }

        private void cmsBrBtn0c_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row == null) return;
            var win = Application.OpenForms.Singleton<ResetPassword>().setData(row, true);
            win.ShowDialog();
        }

        private void cmsBrBtn0d_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row == null) return;
            int focusedrow = gridView1.FocusedRowHandle;
            string brcd = row["BR_CD"].Str();
            bool blocked = row["S_BLCK"].To<bool>(false);
            string msg = (blocked ? "Unblock" : "Block");
            string custname = row["FLL_NM"].Str(); // " + title + "
            if (XtraMessageBox.Show("Are you sure you want to " + msg.ToLower() + "?", msg + ": " + custname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StaticSettings.showLoading();
                string actId = row["OPTR_ID"].Str();
                var res = Db.execute0c(brcd, actId).Result;
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
                    gridView1_RowClick(gridView1, null);
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
            string branchname = tbbrname.Text.Trim();
            if (branchname.IsEmpty())
            {
                XtraMessageBox.Show("Please enter branch name", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbbrname.Focus();
                return false;
            }
            string branchaddress = tbbraddress.Text.Trim();
            if (branchaddress.IsEmpty())
            {
                XtraMessageBox.Show("Please enter branch address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbbraddress.Focus();
                return false;
            }
            string branchzipcode = tbzipcode.Text.Trim();
            if (branchzipcode.IsEmpty())
            {
                XtraMessageBox.Show("Please enter branch zipcode", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbzipcode.Focus();
                return false;
            }
            string lincenseno = tblicenseno.Text.Trim();
            if (lincenseno.IsEmpty())
            {
                XtraMessageBox.Show("Please enter STL license no", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tblicenseno.Focus();
                return false;
            }
            string tinno = tbtinno.Text.Trim();
            if (tinno.IsEmpty())
            {
                XtraMessageBox.Show("Please enter TIN", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbtinno.Focus();
                return false;
            }
            string shortname = tbshortname.Text.Trim();
            if (shortname.IsEmpty())
            {
                XtraMessageBox.Show("Please enter branch short name", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbshortname.Focus();
                return false;
            }
            string areaname = tbareaname.Text.Trim();
            if (areaname.IsEmpty())
            {
                XtraMessageBox.Show("Please enter branch area name", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbareaname.Focus();
                return false;
            }
            string telno = tbtelno.Text.Trim();
            if (telno.IsEmpty())
            {
                XtraMessageBox.Show("Please enter telephone number", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbtelno.Focus();
                return false;
            }
            string mobileno = tbtechsupp.Text.Trim();
            if (mobileno.IsEmpty())
            {
                XtraMessageBox.Show("Please enter technical support mobile number", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbtechsupp.Focus();
                return false;
            }
            //Admin
            string username = this.tbusername.Text.Trim().ToLower();
            if (username.Length < 5)
            {
                StaticSettings.XtraMessage("Username too short, minimum of 6 digit required", MessageBoxIcon.Exclamation);
                tbusername.Focus();
                return false;
            }
            string password = this.tbpassword.Text;
            if (password.Length < 6 && this.isNew)
            {
                StaticSettings.XtraMessage("Password too short, minimum of 6 digit required", MessageBoxIcon.Exclamation);
                tbpassword.Focus();
                return false;
            }
            string firstname = this.tbfname.Text.Trim();
            if (firstname.IsEmpty())
            {
                StaticSettings.XtraMessage("Firstname is required", MessageBoxIcon.Exclamation);
                tbfname.Focus();
                return false;
            }
            string lastname = this.tblname.Text.Trim();
            if (lastname.IsEmpty())
            {
                StaticSettings.XtraMessage("Lastname is required", MessageBoxIcon.Exclamation);
                tblname.Focus();
                return false;
            }
            string mobilenumber = this.tbmobno.Text.Trim();
            if (mobilenumber.IsEmpty())
            {
                StaticSettings.XtraMessage("Mobile number is required", MessageBoxIcon.Exclamation);
                tbmobno.Focus();
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
                tbaddress.Focus();
                return false;
            }
            form.BranchName = branchname;
            form.BranchAddress = branchaddress;
            form.ZipCode = branchzipcode;
            form.LicenseNo = lincenseno;
            form.TinNo = tinno;
            form.ShortName = shortname;
            form.AreaName = areaname;
            form.TelephoneNumber = telno;
            form.TechSupportNumber = mobileno;
            form.WebsiteUrl = tbwebsite.Text.Trim();
            form.EmailAddress = tbbremail.Text.Trim();
            //
            var agent = this.form.Agent;
            agent.Username = username;
            agent.Password = password;
            agent.Firstname = firstname;
            agent.Lastname = lastname;
            agent.Fullname = $"{firstname} {lastname}".Trim();
            agent.MobileNumber = mobilenumber;
            agent.PresentAddress = address;
            agent.EmailAddress = tbemail.Text.Trim();
            return true;
        }
    }

    public partial class _x0c
    {
        public class Vyw
        {
            public static GridView v0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("S_BLCK", "Block", 0, gridView);
                    DevXSettings.XtraFormatColumn("BR_NME", "Branch Name", 1, gridView);
                    DevXSettings.XtraFormatColumn("BR_ADDRS", "Branch Address", 2, gridView);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Authorized Admin", 4, gridView);
                    DevXSettings.XtraFormatColumn("USR_NM", "Username", 3, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Date Registered", 7, gridView);
                    DevXSettings.XgridColAlign(new[] { "USR_NM", "S_BLCK", "RGS_TRN_TS_NM" }, gridView, HorzAlignment.Center);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static GridView v0b(GridView gridView)
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
                    DevXSettings.XtraFormatColumn("BR_NME", "Branch", 6, gridView);
                    DevXSettings.XtraFormatColumn("USR_TYP_NM", "Department", 7, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Date Registered", 8, gridView);
                    DevXSettings.XgridColAlign(new[] { "USR_NM", "S_BLCK", "RGS_TRN_TS_NM", "MOB_NO" }, gridView, HorzAlignment.Center);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
        }
        public class Filter
        {
            public string BranchID;
        }


        public class Input
        {
            public string BranchID;
            public string OperatorID;
            public string BranchName;
            public string BranchAddress;
            public string ZipCode;
            public string LicenseNo;
            public string TinNo;
            public string ShortName;
            public string AreaName;
            public string TelephoneNumber;
            public string TechSupportNumber;
            public string WebsiteUrl;
            public string EmailAddress;
            public Agent Agent = new Agent();
        }
        public class Agent
        {
            public string Firstname;
            public string Lastname;
            public string Fullname;
            public string PresentAddress;
            public string MobileNumber;
            public string EmailAddress;
            //public string Department;
            //public string DepartmentID;
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
            public static async Task<(Results result, String message)> execute0c(String BranchID, String OperatorID)
            {
                var result = API.DSpQueryAPIParam($"/api/v1/Branches/BlockBranchAccount?branchID={BranchID}&operatorid={OperatorID}", Login.authentication);
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);;
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, row["message"].Str());
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
            private static async Task<(Results result, string message)> _execute0a(Input input, bool IsUpdate = true)
            {
                var agent = input.Agent;
                dynamic result = API.DSpQueryAPI("/api/v1/Branches/UpdateBranches", Login.authentication, new Dictionary<string, object>(){
                    { "branchID", input.BranchID },
                    { "branchName", input.BranchName },
                    { "branchAddress", input.BranchAddress },
                    { "licenseNo", input.LicenseNo },
                    { "tinNo", input.TinNo },
                    { "shortName", input.ShortName },
                    { "areaName", input.AreaName },
                    { "telephoneNumber", input.TelephoneNumber },
                    { "techSupportNumber", input.TechSupportNumber },
                    { "emailAddress", input.EmailAddress },
                    { "websiteUrl", input.WebsiteUrl },
                    { "zipCode", input.ZipCode },
                    { "operatorID", input.OperatorID },
                    { "firstname", agent.Firstname },
                    { "lastname", agent.Lastname },
                    { "username", agent.Username },
                    { "password", agent.Password },
                    { "presentAddress", agent.PresentAddress },
                    { "mobileNumber", agent.MobileNumber },
                    { "agentEmailAddress", agent.EmailAddress },
                    { "parmcd", (!IsUpdate?"1":"3") },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    //var row = ((IDictionary<string, object>)rows);
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