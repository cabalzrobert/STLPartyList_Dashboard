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
using Microsoft.Win32;
using JLIDashboard.Classes;
using System.Net.Http;
using System.Diagnostics;
using System.Data.SqlClient;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using Newtonsoft.Json;
using Comm.Common.Extensions;
using AbacosDashboard.Module.Enum;
using static JLIDashboard._x0a;
using JLIDashboard.Module;
using Newtonsoft.Json.Linq;
using Comm.Common.Advance;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        // custid, 
        public static string plid, pgrpid, psncd, actno, userfullname, userfname, userlname,username, usermobno, userprsntaddr, useremailaddr, usertype, userstat, authentication, menupage, grpcode;
        public static string constr;
        public static string userid;
        public static string serverpassword;
        public static string servername;
        public static string dbname;
        public static string connsettings;
        public static string session;
        private int passwordctr = 0;
        private string user = "";

        private static FileObject file = new FileObject(Application.StartupPath + "\\checkVersion.txt");
        public Login()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool functionReturnValue = false;
            if (keyData == (Keys.O | Keys.Control)) //PAYMENT
            {
                Connection C = new Connection();
                C.ShowDialog(this);
                this.Opacity = 0;
            }
            return functionReturnValue;
        }
        static async Task<int> GetCTRVersion()
        {
            try
            {
                string urlChecker = file["VersionCheckerUrl"];
                using (var client = new HttpClient())
                {
                    var content = await client.GetStringAsync(urlChecker).ConfigureAwait(false);
                    return Convert.ToInt32(content);
                }
            }
            catch { }
            return -1;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Timeout.Set(() => this.Invoke(new Action(this.ShowForm)), 1);
            Timeout.Set(() => this.Invoke(new Action(this.initialize)), 750);
        }

        private void ShowForm()
        {
            this.Hide();
            this.Opacity = 100;
        }

        private void tryCheckUpdate()
        {
            try
            {
                if (file["Version"].IsEmpty()) return;
                int client_version = Convert.ToInt32(file["Version"]);
                int server_version = GetCTRVersion().Result;
                if (server_version != -1 && client_version < server_version)
                {
                    MessageBox.Show("A New Updates Available\nGet the latest application update now.");
                    string batCmdLaunch = $"bat_{ DateTime.Now.ToString("yyyyMMdd.HHmmss") }.bat";
                    System.IO.File.WriteAllText(batCmdLaunch, @"
@echo off
taskkill /pid " + Process.GetCurrentProcess().Id + @" /f
START exeUpdater.exe 
del ""%~f0""
exit /b
                    ");
                    ProcessStart(batCmdLaunch).WaitForExit();
                    Application.Exit();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void initialize()
        {
            this.tryCheckUpdate();
            try
            {
                var regkey = API.RegKeyAPI;//Registry.CurrentUser.CreateSubKey(@"ESAT\ConnSettingsMain"); // m
                if (regkey.GetValue("apicon") == null)
                {
                    Timeout.Set(() => this.Invoke(new Action(() => this.openConnection(regkey))));
                    return;
                }
                //bool existing = Database.checkifExist($"SELECT TOP(1) COMP_ID FROM dbo.ESATBAA with(nolock) WHERE COMP_ID='0001'");
                bool existing = API.checkifExistAPIAsync("dashboardstl", Login.authentication);
                if (!existing)
                {
                    Timeout.Set(() => this.Invoke(new Action(this.openHeadOffice)));
                    return;
                }
                else
                {
                    this.Show();
                    //constr = regkey.GetValue("dbconn").ToString();
                    //userid = regkey.GetValue("serverid").ToString();
                    //serverpassword = regkey.GetValue("serverpassword").ToString();
                    dbname = regkey.GetValue("apicon").ToString();
                    servername = regkey.GetValue("servername").ToString();
                    constr = regkey.GetValue("apicon").ToString();
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void openConnection(RegistryKey regkey)
        {
            try
            {
                //Connection fcon = new Connection();
                APIConnection fcon = new APIConnection();
                fcon.lblservername.Text = "Main Server";
                //fcon.txtconnsettingsname.Text = regkey.Name;//@"ESAT\ConnSettingsMain";
                this.Hide();
                fcon.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            this.Close();
        }

        private void openHeadOffice()
        {
            try
            {
                GENERAL_SETUP.CreateHeadOffice createho = new GENERAL_SETUP.CreateHeadOffice();
                this.Hide();
                createho.ShowDialog(this);
                if (!createho.ok)
                {
                    this.Close();
                    return;
                }
                this.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            }
        }

        public void readMenu(string strMenu, RibbonPage currentPage)
        {
            if (strMenu == "<empty>")
            {
                currentPage.Visible = false;
                return;
            }
            if (String.IsNullOrEmpty(strMenu))
            {
                currentPage.Visible = false;
                return;
            }
            BarItem mCurrentItem = default(BarItem);
            string wholefile = null;
            string[] linedata = null;
            string[] fielddata = null;
            wholefile = strMenu;
            //linedata = Regex.Split(wholefile, Environment.NewLine);
            linedata = wholefile.Split('\n');
            foreach (string lineoftext in linedata)
            {
                fielddata = lineoftext.Split('|');
                foreach (string wordoftexgt in fielddata)
                {
                    foreach (RibbonPageGroup currentGroup in currentPage.Groups)
                    {
                        foreach (BarItemLink currentLink in currentGroup.ItemLinks)
                        {
                            mCurrentItem = currentLink.Item;
                            if (currentLink.Item.Name == wordoftexgt)
                            {
                                currentLink.Item.Visibility = BarItemVisibility.Always;
                            }
                        }
                    }
                }
            }
        }
        private void validateCredentials()
        {
            var res = Db.execute0a(txtuserid.Text, txtpassword.Text).Result;
            StaticSettings.hideLoading();
            if (res.result == Results.Success)
            {
                string barmenu = "|btnUserAccess|btnBranches|btnDrawSched|btnRemittances|btnusers|btnapk|btnForfeitScheduler|btnUserSettings|btnPowerApp|btnAccountCredits|btnTransferCredits|btnGameSettings|btnlivetrends|btngameresult|btnPostresult|btnLivestreaming|btnTextblasting|btnAnnouncement|btnWinners|btnResultConfirmation|btnCommissions|btnUserAccounts|btnWinningsRep|btnGameBetsRep|btnActivePlayer|btnMaxSales|btnSessionLogs|btnPlayerNoBet|btnInActiveUserAccount|btnTroubleReport|";
                var data = res.user;
                var auth = res.auth;
                var menu = res.menu;
                user = txtuserid.Text;
                plid = data["PL_ID"].Str();
                pgrpid = data["PGRP_ID"].Str();
                //grpcode = data["GRP_CD"].Str();
                userid = data["USR_ID"].Str();
                userfullname = data["FLL_NM"].Str();
                userfname = data["FRST_NM"].Str();
                userlname = data["LST_NM"].Str();
                usermobno = data["MOB_NO"].Str();
                userprsntaddr = data["PRSNT_ADDR"].Str();
                useremailaddr = data["EML_ADD"].Str();
                usertype = data["ACT_TYP"].Str();
                session = data["SessionID"].Str();
                authentication = auth["Token"].Str();
                menupage = (usertype=="1" || usertype=="2") ? barmenu :  menu["MenuPage"].Str();

                if (plid == "0001" && pgrpid == "888" && userid == "000100000001")
                {
                    Timeout.Set(() => this.Invoke(new Action(this.openPCSODashboard)));
                }
                else
                {
                    string marl = HelperFunction.GetMACAddress2().ToString().Replace("-", "");
                    //bool isMacAddressExists = Database.checkifExist($"SELECT TOP(1) MC_ADD FROM dbo.ESATAAB with(nolock) WHERE S_ACTV=1 AND MC_ADD='{marl}' ");
                    bool isMacAddressExists = API.checkifExistLoginAPIAsync("JLILogin/MCAddrees", $"S_ACTV='1' AND MC_ADD='{marl}'");
                    if (!isMacAddressExists && false)
                    {
                        XtraMessageBox.Show("Dashboard is not assigned in this System Unit..Please Contact ESAT Admin", "ESAT Pilipinas Teknik", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        Timeout.Set(() => this.Invoke(new Action(this.openMainDashboard)));
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void openMainDashboard()
        {
            try
            {
                MainDashboard mdash = new MainDashboard();
                //mdash.Text += (" - " + dbname.Substring(dbname.Length - 2));
                //mdash.barstaticserverName.Caption = dbname.ToUpper();
                mdash.barstaticserverName.Caption = (Cipher.Decrypt(servername, "Esatpt123456789!")).ToUpper();
                this.Hide();
                mdash.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            this.Close();
        }


        private void openPCSODashboard()
        {
            try
            {
                PCSO.PCSODashboard pcdash = new PCSO.PCSODashboard();
                this.Hide();
                pcdash.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            this.Close();
        }


        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.performSubmit();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.performSubmit();
        }

        private void performSubmit()
        {
            if (!ValidateEntries())
                return;
            StaticSettings.showLoading(this);
            this.validateCredentials();
            StaticSettings.hideLoading();
        }

        private bool ValidateEntries()
        {
            string username = txtuserid.Text.Trim().Trim();
            if (username.IsEmpty())
            {
                XtraMessageBox.Show("User ID is required.", "ESAT Pilipinas Teknik");
                txtuserid.Focus();
                return false;
            }
            string password = txtpassword.Text.Trim().Trim();
            if (password.IsEmpty())
            {
                XtraMessageBox.Show("Password is required.", "ESAT Pilipinas Teknik");
                return false;
            }
            return true;
        }

        private void txtuserid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpassword.Focus();
            }
        }

        private static Process ProcessStart(string batLocation)
        {
            //var process = Process.Start(batCmd);
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = batLocation;
            p.Start();
            return p;
        }
    }

    public partial class _x0a
    {
        public class Db
        {
            public static async Task<(Results result, IDictionary<string, object> user, IDictionary<string,object> auth, IDictionary<string,object> menu,String message)> execute0a(string username, string password)
            {
                var result = API.DSpQueryAPI("dashboardsignin", null, new Dictionary<string, object>(){
                    { "username", username },
                    { "password", password }
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, JsonConvert.DeserializeObject<IDictionary<string,object>>(row["account"].Str()), JsonConvert.DeserializeObject<IDictionary<string, object>>(row["auth"].Str()), JsonConvert.DeserializeObject<IDictionary<string, object>>(row["menupage"].Str()), null);
                    else if (ResultCode == "1")
                        return (Results.Failed, null, null, null, row["message"].Str());
                    return (Results.Failed, null,null, null, row["message"].Str());
                }
                return (Results.Null, null, null, null, null);
            }
        }
    }
}