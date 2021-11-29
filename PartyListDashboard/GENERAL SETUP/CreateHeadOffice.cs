﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Comm.Common.Extensions;
using JLIDashboard.Module;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Classes;
using static JLIDashboard.GENERAL_SETUP._x0c;

namespace JLIDashboard.GENERAL_SETUP
{
    public partial class CreateHeadOffice : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        private bool isNew;
        public CreateHeadOffice()
        {
            InitializeComponent();
        }

        private void CreateHeadOffice_Load(object sender, EventArgs e)
        {
             
        }
      
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = Db.execute0a(form).Result;
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

        public class Db
        {
           
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                var agent = input.Agent;
                //dynamic result = Database.DSpQuery<dynamic>("dbo.spfn_BAACC0SA1C", new Dictionary<string, object>(){
                //    { "parmcompid", "8888" },
                //    { "parmcompnm", input.CompanyName },
                //    { "parmcompadd", input.CompanyAddress },
                //    { "parmcomptelno", input.TelephoneNumber },
                //    { "parmtinno", input.TinNo },
                //    { "parmshrtnm", input.ShortName },
                //    { "parmareanm", input.AreaName },
                //    { "parmtechsuppno", input.TechSupportNumber },
                //    { "parmcompemladd", input.EmailAddress },
                //    { "parmwebsite", input.WebsiteUrl },
                //    { "parmgeoloc", input.ZipCode },
                //    { "parmlcnsdno", input.LicenseNo },
                //    { "parmlcnsdky1", "" },
                //    { "parmlcnsdky2", "" },
                //    { "parmlcnsdky3", "" },
                //    //{ "parmurlstrmngnm", "John Denver | Take Me Home, Country Roads" },
                //    //{ "parmurlstrmng", "https://youtu.be/oTeUdJky9rY" },
                //    //{ "parmappvrsn", "v21.03080257" },
                //    //{ "parmapkurl", "http://210.213.236.202:3102/d/apk/app.apk" },
                //    //{ "parmapkupdturl", "http://210.213.236.202:3102/d/apk/app.apk" },
                //    { "parmusrfnm", agent.Firstname },
                //    { "parmusrlnm", agent.Lastname },
                //    { "parmusrnm", agent.Username },
                //    { "parmusrpsswrd", agent.Password },
                //    { "parmaddrss", agent.PresentAddress },
                //    { "parmusrmobno", agent.MobileNumber },
                //    { "parmemladd", agent.EmailAddress },
                //    { "parmuserid", "888888888888" },
                //}).FirstOrDefault();
                dynamic result = Database.DAPIQueryResult<dynamic>("/api/HeadOffice/SaveHeadOffice", new Dictionary<string, object>(){
                    { "parmcompid", "8888" },
                    { "parmcompnm", input.CompanyName },
                    { "parmcompadd", input.CompanyAddress },
                    { "parmcomptelno", input.TelephoneNumber },
                    { "parmtinno", input.TinNo },
                    { "parmshrtnm", input.ShortName },
                    { "parmareanm", input.AreaName },
                    { "parmtechsuppno", input.TechSupportNumber },
                    { "parmcompemladd", input.EmailAddress },
                    { "parmwebsite", input.WebsiteUrl },
                    { "parmgeoloc", input.ZipCode },
                    { "parmlcnsdno", input.LicenseNo },
                    { "parmlcnsdky1", "" },
                    { "parmlcnsdky2", "" },
                    { "parmlcnsdky3", "" },
                    //{ "parmurlstrmngnm", "John Denver | Take Me Home, Country Roads" },
                    //{ "parmurlstrmng", "https://youtu.be/oTeUdJky9rY" },
                    //{ "parmappvrsn", "v21.03080257" },
                    //{ "parmapkurl", "http://210.213.236.202:3102/d/apk/app.apk" },
                    //{ "parmapkupdturl", "http://210.213.236.202:3102/d/apk/app.apk" },
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
                    var row = ((IDictionary<string, object>)result.ToObject<IDictionary<string, object>>());
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