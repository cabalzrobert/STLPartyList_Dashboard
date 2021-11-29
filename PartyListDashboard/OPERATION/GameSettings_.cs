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

namespace JLIDashboard.OPERATION
{
    public partial class GameSettings_ : DevExpress.XtraEditors.XtraForm
    {
        object gametypeid = null;
        public GameSettings_()
        {
            InitializeComponent();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            Database.displaySearchlookupEdit("SELECT CodeInstance,InstanceName FROM dbo.ESAT000 WHERE CodeID='CD001'", txtgametype, "InstanceName", "InstanceName");
        }

        private void txtgametype_EditValueChanged(object sender, EventArgs e)
        {
            gametypeid = SearchLookUpClass.getSingleValue(txtgametype, "CodeInstance");
            display();
        }

        void display()
        {
            //winnings and limit
            Database.display($"SELECT GameType,WinningAmount,StraightLimitAmount,RumbleLimitAmount FROM dbo.functable_gameSettings('{gametypeid.ToString()}')", gridControlwinningsandlimit, gridViewwinningsandlimit);
            //limit per combination
            Database.display($"SELECT GameType,Combination,StraightLimitAmount,RumbleLimitAmount FROM dbo.vw_LimitPerCombination WHERE CodeInstance ='{gametypeid.ToString()}'", gridControllimitpercombi, gridViewlimitpercombi);
            //soldout
            Database.display($"SELECT  GameType,Combination FROM dbo.vw_SoldOutSettings WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}'  AND GameType= '{gametypeid.ToString()}'", gridControlsoutsettings, gridViewsoutsettings);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtgametype.Text))
            {
                XtraMessageBox.Show("Please Select GameType First!...");
            }
            else if(String.IsNullOrEmpty(soutcom1.Text) || String.IsNullOrEmpty(soutcom2.Text) || String.IsNullOrEmpty(soutcom3.Text))
            {
                XtraMessageBox.Show("Please Input all fields combination...");
            }
            else
            {
                string combi = soutcom1.Text + soutcom2.Text + soutcom3.Text;
                string transdate = Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('DATE','" + DateTime.Now.ToString() + "')");
                string transtime = Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('TIME','" + DateTime.Now.ToString() + "')");

                Database.ExecuteQuery($"INSERT INTO dbo.ESAT163 VALUES('0002','006','01','{combi}','{transdate}','{transtime}','{DateTime.Now.ToString()}','000200000014','','','','')", "Successfully Added");
                Database.display($"SELECT * FROM dbo.vw_SoldOutSettings WHERE CodeInstance= '{gametypeid}')", gridControlsoutsettings, gridViewsoutsettings);
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtgametype.Text))
            {
                XtraMessageBox.Show("Please Select GameType First!...");
            }
            else if (String.IsNullOrEmpty(limitcom1.Text) || String.IsNullOrEmpty(limitcom2.Text) || String.IsNullOrEmpty(limitcom3.Text) || String.IsNullOrEmpty(strghtlimit.Text) || String.IsNullOrEmpty(rmbllimit.Text))
            {
                XtraMessageBox.Show("Please Input all fields combination...");
            }
            else
            {
                string combi = limitcom1.Text + limitcom2.Text + limitcom3.Text;
                string transdate = Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('DATE','" + DateTime.Now.ToString() + "')");
                string transtime = Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('TIME','" + DateTime.Now.ToString() + "')");

                Database.ExecuteQuery($"INSERT INTO dbo.ESAT162 VALUES('{Login.compid}','{Login.brcode}','{gametypeid}','{combi}','{strghtlimit.Text}','{rmbllimit.Text}','{transdate}','{transtime}','{DateTime.Now.ToString()}','000200000014','','','','')", "Successfully Added");
                Database.display($"SELECT * FROM dbo.vw_LimitPerCombination WHERE CodeInstance= '{gametypeid}'", gridControllimitpercombi, gridViewlimitpercombi);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            addGameSettings();
            btnnew.Enabled = true;
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }
        void addGameSettings()
        {
            bool checkifexists = Database.checkifExist($"SELECT TOP(1) GameType FROM dbo.ESAT016 WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GM_TYP='{txtgametype.Text}' ");
            if (gametypeid.ToString() == "" || String.IsNullOrEmpty(txtgametype.Text) || String.IsNullOrEmpty(txtlimitrumble.Text) || String.IsNullOrEmpty(txtlimitstraight.Text) ||
                 String.IsNullOrEmpty(txtwinnings.Text))
            {
                XtraMessageBox.Show("Please Filled out the all the Field!");
                return;
            }
            else if (checkifexists)
            {
                XtraMessageBox.Show("GameType already exists!!...");
                return;
            }
            else
            {
                string transdate = Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('DATE','" + DateTime.Now.ToString() + "')");
                string transtime = Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('TIME','" + DateTime.Now.ToString() + "')");

                Database.ExecuteQuery($"INSERT INTO dbo.ESAT016 (COMP_ID,BR_CD,GRP_CD,GME_TYP,DRW_TRN_DT,STRGHT_AMT_LMT,RMBL_AMT_LMT,PRC_WNNG_AMNT,RGS_TRN_DT,RGS_TRN_TM,RGS_TRN_TS,RGS_EMP_ID) " +
                    $"VALUES('{Login.compid}','{Login.brcode}','{Login.grpcode}','{gametypeid}','{transdate}','{txtlimitstraight.Text}','{txtlimitrumble.Text}','{txtwinnings.Text}','{transdate}','{transtime}','{DateTime.Now.ToString()}','{Login.userid}')");
                //Database.display($"SELECT GME_TYP as GameType,STRGHT_AMT_LMT as LimitStraight,RMBL_AMT_LMT as LimitRumble,PRC_WNNG_AMNT as Winnings " +
                //    $"FROM dbo.ESAT016 WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GM_TYP='{txtgametype.Text}' ", gridControlwinningsandlimit, gridViewwinningsandlimit);
                Database.display($"SELECT GameType,WinningAmount,StraightLimitAmount,RumbleLimitAmount FROM dbo.functable_gameSettings('{gametypeid.ToString()}' WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' )", gridControlwinningsandlimit, gridViewwinningsandlimit);

                clear();
                disablefields();
            }
        }
        private void btnnew_Click(object sender, EventArgs e)
        {

            enablefields();
            //populate(gencoorid.ToString());
            clear();
            btnnew.Enabled = false;
            btnadd.Enabled = true;

            btnupdate.Enabled = false;
            btncancel.Enabled = true;
        }
        //void populate(string id)
        //{
        //    Database.display($"SELECT * FROM dbo.ESAT016 WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GM_TYP='{txtgametype.Text}' ", gridControlwinningsandlimit, gridViewwinningsandlimit);//display GENCOORSETTINGS
        //    Database.display($"SELECT * FROM dbo.ESAT162 WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GM_TYP='{txtgametype.Text}' ", gridControllimitpercombi, gridViewlimitpercombi);//display LIMITPERNUMSETTINGS
        //    Database.display($"SELECT * FROM dbo.ESAT163 WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GM_TYP='{txtgametype.Text}' ", gridControlsoutsettings, gridViewsoutsettings);//display SOLDOUTSETTINGS
        //}
        void enablefields()
        {
            txtgametype.Enabled = true;
            txtlimitrumble.Enabled = true;
            txtlimitstraight.Enabled = true;
            txtpercentage.Enabled = true;
            txtwinnings.Enabled = true;
        }
        void disablefields()
        {

            txtgametype.Enabled = false;
            txtlimitrumble.Enabled = false;
            txtlimitstraight.Enabled = false;
            txtwinnings.Enabled = false;
            txtpercentage.Enabled = false;
        }
        void clear()
        {
            txtgametype.Text = "";
            txtlimitrumble.Text = "";
            txtlimitstraight.Text = "";
            txtwinnings.Text = "";
        }

        private void gridControlwinningsandlimit_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStripwinningandlimit.Show(gridControlwinningsandlimit, e.Location);
        }

        private void gridControllimitpercombi_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStripLimitPerCom.Show(gridControllimitpercombi, e.Location);
        }

        private void gridControlsoutsettings_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStripSoldout.Show(gridControlsoutsettings, e.Location);
        }

        private void editDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enablefields();
            btnnew.Enabled = false;
            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btncancel.Enabled = true;

            txtgametype.Text = gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "GameType").ToString();
            txtwinnings.Text = gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "Winnings").ToString();
            txtlimitstraight.Text = gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "LimitStraight").ToString();
            txtlimitrumble.Text = gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "LimitRumble").ToString();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool confirm = HelperFunction.ConfirmDialog("Are you sure you want to delete this?", "Delete Settings");
            if (confirm)
            {
                Database.ExecuteQuery($"DELETE FROM dbo.ESAT016 WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' " +
                $"AND GME_TYP='{gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "GameType").ToString()}'", "Succesfully Deleted");

                Database.display($"SELECT GME_TYP as GameType,STRGHT_AMT_LMT as LimitStraight,RMBL_AMT_LMT as LimitRumble,PRC_WNNG_AMNT as Winnings " +
                        $"FROM dbo.ESAT016 WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GM_TYP='{txtgametype.Text}' ", gridControlwinningsandlimit, gridViewwinningsandlimit);
            }
            else
            {
                return;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            bool confirm = HelperFunction.ConfirmDialog("Are you sure you want to delete this LimitPer num combination?", "Delete LimitPer Num Combination");
            if (confirm)
            {
                Database.ExecuteQuery($"DELETE FROM dbo.ESAT162 WHERE NUM_COMB='{gridViewlimitpercombi.GetRowCellValue(gridViewlimitpercombi.FocusedRowHandle, "Number").ToString().Replace("-","")}' " +
                    $"AND COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GM_TYP='{gridViewlimitpercombi.GetRowCellValue(gridViewlimitpercombi.FocusedRowHandle, "GameType").ToString()}''", "Successfully Deleted");

                //limit per combination
                Database.display($"SELECT GameType,Combination,StraightLimitAmount,RumbleLimitAmount FROM dbo.vw_LimitPerCombination WHERE CodeInstance ='{gametypeid}' AND COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}'", gridControllimitpercombi, gridViewlimitpercombi);
                //Database.display($"SELECT AccountID,Number,LimitStraight,LimitRumble,DateAdded,AddedBy " +
                //  $"FROM vw_LimitPerCombination WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GameType='{gametypeid}'", gridControllimitpercombi, gridViewlimitpercombi);
                //gridViewlimitpercombi.Columns["AccountID"].Visible = false;
            }
            else
            {
                return;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool confirm = HelperFunction.ConfirmDialog("Are you sure you want to delete this soldout num combination?", "Delete SoldOut Combination");
            if (confirm)
            {
                Database.ExecuteQuery($"DELETE FROM dbo.ESAT163 " +
                    $"WHERE NUM_COMB='{gridViewsoutsettings.GetRowCellValue(gridViewsoutsettings.FocusedRowHandle, "Number").ToString().Replace("-","")}' " +
                    $"AND GM_TYP='{gametypeid.ToString()}' " +
                    $"AND COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' ", "Successfully Deleted");
                //$"AND AccountID='{gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "AccountID").ToString()}''", "Successfully Deleted");
                Database.display($"SELECT GameType,Combination FROM dbo.vw_SoldOutSettings WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GM_TYP='{gametypeid.ToString()}'", gridControlsoutsettings, gridViewsoutsettings);
                
            }
            else
            {
                return;
            }
        }
        void updateGenCoorSettings()
        {
            if (gametypeid.ToString() == "" || String.IsNullOrEmpty(txtgametype.Text) || String.IsNullOrEmpty(txtlimitrumble.Text) || String.IsNullOrEmpty(txtlimitstraight.Text) ||
                String.IsNullOrEmpty(txtwinnings.Text))
            {
                XtraMessageBox.Show("Please Filled out the all the Field!");
                return;
            }
            else
            {
                Database.ExecuteQuery($"UPDATE dbo.ESAT016 SET PRC_WNNG_AMNT='{txtwinnings.Text}',STRGHT_AMT_LMT='{txtlimitstraight.Text}',RMBL_AMT_LMT='{txtlimitrumble.Text}' WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' AND GM_TYP='{gametypeid.ToString()}'");
                disablefields();
                Database.display($"SELECT GameType,WinningAmount,StraightLimitAmount,RumbleLimitAmount FROM dbo.functable_gameSettings('{gametypeid.ToString()}' WHERE COMP_ID='{Login.compid}' AND BR_CD='{Login.brcode}' )", gridControlwinningsandlimit, gridViewwinningsandlimit);

            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            updateGenCoorSettings();

            btnnew.Enabled = true;
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            clear();
            disablefields();
            btnnew.Enabled = true;
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }
    }
}