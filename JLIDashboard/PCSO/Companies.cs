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
using JLIDashboard.Module;
using Comm.Common.Extensions;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module;
using DevExpress.XtraGrid.Views.Grid;
using AbacosDashboard.Module.Enum;
using DevExpress.Utils;
using static JLIDashboard.PCSO._x0c;
using static JLIDashboard.PCSO._x0c.Vyw;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.PCSO
{
    public partial class Companies : DevExpress.XtraEditors.XtraForm
    {
        private bool isNew;
        public Companies()
        {
            InitializeComponent();
        }

        private void Companies_Load(object sender, EventArgs e)
        {
            Timeout.Set(() => this.Invoke(new Action(() => this.loadTableWProgress())), 250);
            this.setData();
        }
        public Companies setData()
        {
            this.setInput(null);
            this.inputEnability(false);
            //this.fillDept();
            return this;
        }
        private Companies retData(DataRow row)
        {
            row["COMP_NM"] = form.CompanyName;
            row["COMP_ADD"] = form.CompanyAddress;
            row["GEO_LOC"] = form.ZipCode;
            row["LCNSD_NO"] = form.LicenseNo;
            row["TIN_NO"] = form.TinNo;
            row["SHRT_NM"] = form.ShortName;
            row["AREA_NM"] = form.AreaName;
            row["COMP_TEL_NO"] = form.TelephoneNumber;
            row["TCHSUPNO"] = form.TechSupportNumber;
            row["EML_ADD"] = form.EmailAddress;
            row["WBST"] = form.WebsiteUrl;

            var agent = form.Agent;
            //row["USR_TYP_NM"] = agent.Department;
            //row["USR_TYP"] = agent.DepartmentID;
            row["USR_FRST_NM"] = agent.Firstname;
            row["USR_LST_NM"] = agent.Lastname;
            row["USR_FLLNME"] = agent.Fullname;
            row["PRSNT_ADDR"] = agent.PresentAddress;
            //row["USR_NM"] = form.TermsUrl;
            //row["REM_TRM"] = form.LogoUrl;
            row["USR_MOB_NO"] = agent.MobileNumber;// $"+{}".Replace("+09", "+639");
            row["EML_ADD"] = agent.EmailAddress;
            return this;
        }

        private void inputEnability(bool enable)
        {
         
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

           
            tbbrname.Text = (isNull ? "" : row["COMP_NM"].Str());
            tbbraddress.Text = (isNull ? "" : row["COMP_ADD"].Str());
            tbzipcode.Text = (isNull ? "" : row["GEO_LOC"].Str());
            tblicenseno.Text = (isNull ? "" : row["LCNSD_NO"].Str());
            tbtinno.Text = (isNull ? "" : row["TIN_NO"].Str());
            tbshortname.Text = (isNull ? "" : row["SHRT_NM"].Str());
            tbareaname.Text = (isNull ? "" : row["AREA_NM"].Str());
            tbtechsupp.Text = (isNull ? "" : row["TCHSUPNO"].Str());
            tbtelno.Text = (isNull ? "" : row["COMP_TEL_NO"].Str());
            tbbremail.Text = (isNull ? "" : row["COMP_EML_ADD"].Str());
            tbwebsite.Text = (isNull ? "" : row["COMP_WBST"].Str());
            //
            tbfname.Text = (isNull ? "" : row["FRST_NM"].Str());
            tblname.Text = (isNull ? "" : row["LST_NM"].Str());
            tbaddress.Text = (isNull ? "" : row["PRSNT_ADDR"].Str());
            tbusername.Text = (isNull ? "" : row["USR_NM"].Str());
            tbpassword.Text = "";// (isNull ? "" : row["REM_TRM"].Str());
            tbmobno.Text = (isNull ? "" : row["USR_MOB_NO"].Str().Replace("+639", "09"));
            tbemail.Text = (isNull ? "" : row["EML_ADD"].Str());

             
            tbusername.ReadOnly = !this.isNew;
            tbpassword.Enabled = this.isNew;
        }
        private void loadTableWProgress()
        {
            StaticSettings.showLoading();
            this.loadTable();
            StaticSettings.hideLoading();
        }

        private void loadTable()
        {
            //Database.display($"exec dbo.spfn_BAA0D ", gridControl1, gridView1);
            API.displayAPI("/api/v1/AACCompany/AACCompany", gridControl1, gridView1, Login.authentication);
            if (x0a(gridView1).RowCount != 0)
            {
                this.gridView1.FocusedRowHandle = 0;
                this.gridView1_RowClick(this.gridView1, null);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            filter.CompanyID = row["COMP_ID"].Str();
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
            //Database.display($"exec dbo.spfn_BEABDBBDA0A '{filter.CompanyID}' ", gridControl2, gridView2); //
            API.displayAPIParam($"/api/v1/AACCompany/AACAccount?compid={filter.CompanyID}", gridControl2, gridView2, Login.authentication);
            x0b(gridView2);
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null) && false;
            cmsCmpBtn0b.Visible = hasSelected;
            cmsCmpBtn0c.Visible = hasSelected;
            cmsCmpBtn0d.Visible = hasSelected;
            cmsBrSep0a.Visible = hasSelected;
            if (!hasSelected) return;
            //cmsBrBtn0d.Text = (row["IS_BLCK"].To<bool>(false) ? "Unblock" : "Block") + "ed User"; // "IS_BLCK" not existing in gridView1
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
             
            this.setInput(null);
            this.inputEnability(true);
         
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

        private void cmsBrBtn0a_Click(object sender, EventArgs e)
        {
            this.loadTableWProgress();
        }

        private void cmsBrBtn0b_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            //form.BranchID = row["BR_CD"].Str();
            //form.OperatorID = row["OPTR_ID"].Str();
            this.inputEnability(true);
            this.setInput(row);
            btnsubmit.Text = "Save Changes";
            btnsubmit.Visible = btncancel.Visible = true;
            btnnew.Visible = false;
        }

        private void cmsBrBtn0c_Click(object sender, EventArgs e)
        {
            //DataRow row = gridView1.GetFocusedDataRow();
            //if (row == null) return;
            //var win = Application.OpenForms.Singleton<ResetPassword>().setData(row, true);
            //win.ShowDialog();
        }

        private void cmsBrBtn0d_Click(object sender, EventArgs e)
        {
            //DataRow row = gridView1.GetFocusedDataRow();
            //if (row == null) return;
            //var focusedrow = gridView1.FocusedRowHandle;
            //bool blocked = row["IS_BLCK"].To<bool>(false);
            //string msg = (blocked ? "Unblock" : "Block");
            //string custname = row["USR_FLLNME"].Str(); // " + title + "
            //if (XtraMessageBox.Show("Are you sure you want to " + msg.ToLower() + "?", msg + ": " + custname, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    StaticSettings.showLoading();
            //    string actId = row["OPTR_ID"].Str();
            //    var res = Db.execute0c(actId).Result;
            //    if (res.result == Results.Success)
            //    {
            //        row["IS_BLCK"] = !blocked;
            //        gridView1.RefreshRow(focusedrow);
            //        StaticSettings.XtraMessage("Successfully " + msg.ToLower() + "ed", MessageBoxIcon.Asterisk);
            //    }
            //    else if (res.result != Results.Null)
            //    {
            //        StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    }
            //    StaticSettings.hideLoading();
            //}
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
                if (isNew) this.loadTableWProgress();
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
            form.CompanyName = branchname;
            form.CompanyAddress = branchaddress;
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
            public static GridView x0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    //DevXSettings.XtraFormatColumn("IS_BLCK", "Block", 0, gridView);
                    DevXSettings.XtraFormatColumn("S_ACTV", "IsActive?", 0, gridView);
                    DevXSettings.XtraFormatColumn("COMP_ID", "Company ID", 1, gridView);
                    DevXSettings.XtraFormatColumn("COMP_NM", "Company Name", 2, gridView);
                    DevXSettings.XtraFormatColumn("COMP_ADD", "Company Address", 3, gridView);
                    DevXSettings.XtraFormatColumn("LCNSD_NO", "License No", 4, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Date Registered", 5, gridView);
                    //DevXSettings.XtraFormatColumn("USR_FLLNME", "Authorized Admin", 4, gridView);
                    //DevXSettings.XtraFormatColumn("USR_NM", "Username", 3, gridView);
                    //DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Date Registered", 7, gridView);
                    DevXSettings.XgridColAlign(new[] { "COMP_ID", "COMP_NM", "COMP_ADD", "LCNSD_NO", "S_ACTV" }, gridView, HorzAlignment.Center);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static GridView x0b(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("S_BLCK", "Block?", 0, gridView);
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
        }
        public class Filter
        {
            public string CompanyID;

        }


        public class Input
        {
            
            public string CompanyName;
            public string CompanyAddress;
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
            public static async Task<(Results result, String message)> execute0c(String OperatorID)
            {
                var result = Database.DSpQuery<dynamic>("dbo.spfunc_002BO0BO", new Dictionary<string, object>(){
                    { "parmcompid", Login.plid },
                    { "parmbrcd", Login.pgrpid },
                    { "parmoptrid", Login.userid },
                    { "parmtrgtid", OperatorID },
                    { "parmcompagnt", "0" },
                }).FirstOrDefault();
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["RESULT"].Str();
                    if (ResultCode == "1")
                        return (Results.Success, "Successfully save!");
                    return (Results.Failed, "Somethings wrong in your data. Please try again");
                }
                return (Results.Null, null);
            }
            private static async Task<(Results result, string message)> _execute0a(Input input, bool IsUpdate = true)
            {
                var agent = input.Agent;
                dynamic result = Database.DSpQuery<dynamic>("dbo.spfunc_001CC0SA1C", new Dictionary<string, object>(){
                    { "parmcompid", "8888" },
                    { "parmcompnm", input.CompanyName },
                    { "parmcompadd", input.CompanyAddress },
                    { "parmcomptelno", input.TelephoneNumber },
                    { "parmtinno", input.TinNo },
                    { "parmbrshrtnm", input.ShortName },
                    { "parmbrareanm", input.AreaName },
                    { "parmbrtechsuppno", input.TechSupportNumber },
                    { "parmbrnchemladd", input.EmailAddress },
                    { "parmbrwebsite", input.WebsiteUrl },
                    { "parmbrloczp", input.ZipCode },
                    { "parmbrlcnsdno", input.LicenseNo },
                    { "parmlcnsdky1", "" },
                    { "parmlcnsdky2", "" },
                    { "parmlcnsdky3", "" },
                    { "parmurlstrmngnm", "PCSO Lotto Draw" },
                    { "parmurlstrmng", "https://youtu.be/6Mwy5yLckeA" },
                    { "parmapkurl", "http://18.139.66.234:8090/d/apk/v0320.1210.0814.apk" },
                    { "parmapkupdturl", "http://18.139.66.234:8090/d/apk/v0320.1210.0814.apk" },

                    { "parmusrfnm", agent.Firstname },
                    { "parmusrlnm", agent.Lastname },
                    { "parmusrnm", agent.Username },
                    { "parmusrpsswrd", agent.Password },
                    { "parmaddrss", agent.PresentAddress },
                    { "parmusrmobno", agent.MobileNumber },
                    { "parmemladd", agent.EmailAddress },
                    { "parmuserid", "888888888888" },
                }).FirstOrDefault();
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["RESULT"].Str();
                    if (ResultCode == "1")
                        return (Results.Success, "Successfully save!");
                    return (Results.Failed, "Somethings wrong in your data. Please try again");
                }
                return (Results.Null, null);
            }
        }
    }
}