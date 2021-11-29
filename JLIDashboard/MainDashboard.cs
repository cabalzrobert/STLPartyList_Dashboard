using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;
using JLIDashboard.Classes.Common.Extensions;
using Comm.Common.Extensions;
using System.Diagnostics;
using JLIDashboard.Classes;
using JLIDashboard.REPORTING;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard
{
    public partial class MainDashboard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static FormCollection WinForms { get { return Application.OpenForms; } }
        public MainDashboard() //
        {
            InitializeComponent();
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
                        bool isHidden = true;
                        foreach (BarItemLink currentLink in currentGroup.ItemLinks)
                        {
                            if (currentLink.Item.Visibility == BarItemVisibility.Always)
                            {
                                isHidden = false;
                                //break;
                            }
                            mCurrentItem = currentLink.Item;
                            if (currentLink.Item.Name == wordoftexgt)
                            {
                                currentLink.Item.Visibility = BarItemVisibility.Always;
                            }
                        }
                        currentGroup.Visible = !isHidden;
                    }
                }
            }
        }
        private void validate_userAccess()
        {
            //string pages = Database.getSingleQuery("dbo.ESATAAD", $"USR_ID='{Login.userid}'", "PGS");
            //DataTable dt = Database.APITable("/api/v1/Users/GetUserAccess", new Dictionary<string, object>() {
            //    {"username" }
            //});
            DataTable dt = API.APITable("/api/v1/Users/LoadPGS", Login.authentication);
            string pages = string.Empty;
            //if(dt.Rows.Count>0) pages=dt.Rows[0][0].Str();

            if (!Login.menupage.IsEmpty()) pages = Login.menupage.Str();
            readMenu(pages, RibbonTabHomePage);
            RibbonTabProFillingPage.Visible = false;
            if (!pages.IsEmpty())
            {
                RibbonTabProFillingPage.Visible = true;
            }

            /*//MainDashboard m = new MainDashboard();
            SqlConnection con = Classes.Database.getConnection();
            con.Open();
            string userid = Login.compid + Login.custid;
            SqlCommand com = new SqlCommand($"Select * from dbo.ESAT035 where UserID= '{userid}'  ", con);
            SqlDataReader reader = com.ExecuteReader();

            try
            {

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        strMenuHomePage = reader["isHomepage"].ToString();
                        //strmenuAdmin = reader["isAdmin"].ToString();
                        //strmenuAccounting = reader["isSales"].ToString();
                        //strmenuOperation = reader["isInventory"].ToString();
                        //strmenuTreasury = reader["isAccounting"].ToString();
                        //strmenuAccounts = reader["isHotel"].ToString();
                        //strmenuReporting = reader["isReporting"].ToString();
                    }
                }
                readMenu(strMenuHomePage, RibbonTabHomePage);
                
               

                //if (Login.isglobalUserID == "eulz")
                //{
                //    AdminPage.Visible = true;
                //    btnUserAccess.Visibility = BarItemVisibility.Always;
                //}
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }*/
        }

        private void btnUserAccounts_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<ACCOUNTS.Subscribers>()) //UserAccounts
                return;
            this.ShowInParent(new ACCOUNTS.Subscribers());
        }

        private void btnDrawSchedSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<OPERATION.GameSettings>())
                return;
            this.ShowInParent(new OPERATION.GameSettings());
        }

        private void btnGameprofile_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<OPERATION.GameProfile>())
                return;
            this.ShowInParent(new OPERATION.GameProfile());
        }

        private void btnResultConfirmation_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<TREASURY.ResultConfirmation>())
                return;
            this.ShowInParent(new TREASURY.ResultConfirmation());
        }

        private void btnWinners_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<TREASURY.Winnings>())
                return;
            this.ShowInParent(new TREASURY.Winnings());
        }
        private void btnCommissions_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<TREASURY.Commissions>())
                return;
            this.ShowInParent(new TREASURY.Commissions());
        }

        private void btnPostresult_ItemClick(object sender, ItemClickEventArgs e)
        {
            //OPERATION.ResultPosting housers = new OPERATION.ResultPosting();
            //housers.ShowDialog(this);
            var rescon = WinForms.Singleton<OPERATION.ResultPosting>().setData();
            rescon.ShowDialog(this);
        }

        private void btngameresult_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<OPERATION.GameResults>())
                return;
            this.ShowInParent(new OPERATION.GameResults());

        }

        private void btnBranches_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<OPERATOR.Branches>())
                return;
            this.ShowInParent(new OPERATOR.Branches());
        }

        private void btnusers_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<OPERATOR.UserAccount>())
                return;
            this.ShowInParent(new OPERATOR.UserAccount());
        }

        private void btnUserAccess_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<UserAccess>())
                return;
            this.ShowInParent(new UserAccess());
        }

        private void btnPowerApp_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ACCOUNTING.PowerAPCredit housers = new ACCOUNTING.PowerAPCredit();
            //housers.ShowDialog(this);
            if (WinForms.Activated<ACCOUNTING.SentCredits>())
                return;
            this.ShowInParent(new ACCOUNTING.SentCredits());
        }

        private void btnAccountCredits_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<ACCOUNTING.AccountCredits>())
                return;
            this.ShowInParent(new ACCOUNTING.AccountCredits());
        }

        private void btnWinnings_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Office2019Black);

            UserLookAndFeel.Default.SetSkinStyle("DevExpress Dark Style");

            UserLookAndFeel.Default.SetStyle(LookAndFeelStyle.Skin, false, true);
            validate_userAccess();
            barHeaderItem3.Caption = Login.userid.ToUpper();
            barHeaderItem5.Caption = DateTime.Now.ToShortDateString();
            //barstaticserverName.Caption = DateTime.Now.ToShortDateString();
            //barHeaderServerName.Caption = "";
        }

        private void btnWinningsRep_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<REPORTING.WinningsHistory>())
                return;
            this.ShowInParent(new REPORTING.WinningsHistory());
        }

        private void btnDrawSched_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rescon = WinForms.Singleton<OPERATION.DrawSchedule>().setData();
            rescon.ShowDialog();
        }

        private void btnRemittances_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rescon = WinForms.Singleton<TREASURY.Remittances>();
            rescon.ShowDialog();
        }

        private void btnLivestreaming_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rescon = WinForms.Singleton<OPERATION.LiveStreaming>().setData();
            rescon.ShowDialog();
        }

        private void btnTextblasting_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rescon = WinForms.Singleton<OPERATION.TextBlasting>().setData();
            rescon.ShowDialog();
        }

        private void btnAnnouncement_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rescon = WinForms.Singleton<OPERATION.Announcement>().setData();
            rescon.ShowDialog();
        }

        private void btnlivetrends_ItemClick(object sender, ItemClickEventArgs e)
        {
            //string link = Database.getSingleQuery("dbo.ESATBBC", $"COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}'", "LV_TRNDS_LNK");
            string link = API.getSingleQueryAPIParam("/api/v1/LiveTrends/LiveTrendsLink", Login.authentication, "LV_TRNDS_LNK");
            if (link.IsEmpty())
            {
                MessageBox.Show("No live trends link");
                return;
            }
            Process.Start(link + $"/dashboard?t={Login.session}"); //String.Format(dashboard?t={0}, Login.session)
            //Process.Start("http://live-trends.stl-a1.esat-pt.com/dashboard?t=" + Login.session); //String.Format(dashboard?t={0}, Login.session)
            //Process.Start("http://live-trends.stl-b1.esat-pt.com/dashboard?t=" + Login.session);
        }

        private void btnTransferCredits_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rescon = WinForms.Singleton<ACCOUNTING.TransferCredits>();
            rescon.ShowDialog();
        }

        private void btnGameBetsRep_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<REPORTING.GameBetsHistory>())
                return;
            this.ShowInParent(new REPORTING.GameBetsHistory());
        }
        private void ShowInParent(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }

        private void btnMasterList_ItemClick(object sender, ItemClickEventArgs e)
        {            
            if (WinForms.Activated<OPERATOR.MasterList>())
                return;
            this.ShowInParent(new OPERATOR.MasterList());
        }

        private void btnActivePlayer_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<REPORTING.TotalTransaction>()) return;
            this.ShowInParent(new REPORTING.TotalTransaction());
        }

        private void btnMaxSales_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<REPORTING.MaxSales>()) return;
            this.ShowInParent(new REPORTING.MaxSales());
        }

        private void btnSessionLogs_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<ActivityLogs>()) return;
            this.ShowInParent(new REPORTING.ActivityLogs());
        }

        private void btnPlayerNoBet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<PlayerNoBet>()) return;
            this.ShowInParent(new REPORTING.PlayerNoBet());
        }
        private void btnInActiveUserAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<InActiveUserAccount>()) return;
            this.ShowInParent(new REPORTING.InActiveUserAccount());
        }

        private void btnTroubleReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<Trouble>()) return;
            this.ShowInParent(new REPORTING.Trouble());
        }

        private void btnapk_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<OPERATOR.APKVersion>()) return;
            this.ShowInParent(new OPERATOR.APKVersion());
        }

        private void btnForfeitScheduler_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<OPERATOR.ForfeitInterval>()) return;
            this.ShowInParent(new OPERATOR.ForfeitInterval());
        }

        private void btnUserSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rescon = WinForms.Singleton<OPERATOR.UserSettings>().setdata();
            rescon.ShowDialog();
        }

        private void btnPoliticalPosition_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (WinForms.Activated<OPERATION.Position>()) return;
            this.ShowInParent(new OPERATION.Position());
        }
    }
    
}