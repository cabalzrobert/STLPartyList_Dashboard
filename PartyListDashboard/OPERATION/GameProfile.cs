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

namespace JLIDashboard.OPERATION
{
    public partial class GameProfile : DevExpress.XtraEditors.XtraForm
    {
        string gametype, drawdate, drawsched, cutoffstart,cutoffend;
        object gameid = null;
        public GameProfile()
        {
            InitializeComponent();
        }

        private void GameProfile_Load(object sender, EventArgs e)
        {
            disablefields();
            display();
            populate();
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }
        void populate()
        {
            Classes.Database.displaySearchlookupEdit("SELECT CodeInstance as GameID,InstanceName as GameType FROM dbo.ESAT000 WHERE CodeID='CD001'", txtgametype, "GameType", "GameType");

        }
        void display()
        {
            Classes.Database.display($"SELECT * FROM dbo.vw_GameProfile WHERE GM_TYP='{gameid.ToString()}'", gridControl1, gridView1);        }
        void clear()
        {
            txtgametype.Text = "";
            txtdate.Text = "";
            txtdrawsched.Text = "";
            txtcutofftime.Text = "";
          
            //txtgencoor.Text = "";

        }
        void enablefields()
        {
            txtgametype.Enabled = true;
            txtdate.Enabled = true;
            txtdrawsched.Enabled = true;
            txtcutofftime.Enabled = true;
           
        }
        void disablefields()
        {
            txtgametype.Enabled = false;
            txtdate.Enabled = false;
            txtdrawsched.Enabled = false;
            txtcutofftime.Enabled = false;
           
        }

        private void txtgametype_EditValueChanged(object sender, EventArgs e)
        {
            gameid = Classes.SearchLookUpClass.getSingleValue(txtgametype, "GameID");
            Classes.Database.displaySearchlookupEdit("SELECT CodeInstance as DrawID,InstanceName as DrawSched FROM dbo.ESAT000 WHERE CodeID='CD006' AND CodeInstance <> '0' ", txtdrawsched, "DrawSched", "DrawSched");

        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(gridControl1, e.Location);
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            enablefields();
            display();
            clear();
            btnnew.Enabled = false;
            btnadd.Enabled = true;
            btnupdate.Enabled = false;
            btncancel.Enabled = true;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtgametype.Text) || String.IsNullOrEmpty(txtdate.Text) || String.IsNullOrEmpty(txtdrawsched.Text) || String.IsNullOrEmpty(txtcutofftime.Text) )
            {
                XtraMessageBox.Show("Fields must not Empty!..");
                return;
            }
            else
            {
                Add();

                display();
                clear();
                disablefields();

                btnnew.Enabled = true;
                btnadd.Enabled = false;
                btnupdate.Enabled = false;
                btncancel.Enabled = false;
            }
        }
        void Add()
        {
            //bool stat = false;
            //if (txtstat.Text == "ACTIVE") { stat = true; } else { stat = false; }
            bool checkifexists = Classes.Database.checkifExist($"SELECT TOP(1) GM_TYP FROM dbo.ESAT161 WHERE GM_TYP='{gameid.ToString()}' AND DRW_TYP='{txtdrawsched.Text}'");
            bool checkifthereactive = Classes.Database.checkifExist($"SELECT TOP(1) GM_TYP FROM dbo.ESAT016 WHERE GM_TYP='{gameid.ToString()}' and S_ACTIVE=1");
            if (checkifexists)
            {
                XtraMessageBox.Show("Already Exists");
                return;
            }
            else if (checkifthereactive)
            {
                XtraMessageBox.Show("There is already OPEN BET in DrawSchedule, Active Status must set one at a time per gametype");
                return;
            }
            else
            {
                int getlastid = Classes.Database.getLastID("ESAT161", "SEQ_NO");
                string transdate = Classes.Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('DATE','" + DateTime.Now.ToString() + "')");
                string transtime = Classes.Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('TIME','" + DateTime.Now.ToString() + "')");

                Classes.Database.ExecuteQuery($"INSERT INTO dbo.ESAT161 VALUES('{Login.compid}','{Login.brcode}','{gameid.ToString()}','{getlastid+1}','{txtdrawsched.Text}','{txtcutofftime.Text}',{txtcutofftimeend.Text},'{transdate}','{transtime}','{DateTime.Now.ToString()}','{Login.compid+Login.userid}','','','','')", "Successfully Added");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            updateSettings();
            clear();
            disablefields();
            display();

            btnnew.Enabled = true;
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }
        void updateSettings()
        {
            //bool stat = false;
            //if (txtstat.Text == "ACTIVE") { stat = true; } else { stat = false; }
            bool checkifexists = Classes.Database.checkifExist($"SELECT TOP(1) GM_TYP FROM dbo.ESAT161 WHERE GM_TYP='{gameid.ToString()}' AND DRW_TYP='{txtdrawsched.Text}'");
            bool checkifthereactive = Classes.Database.checkifExist($"SELECT TOP(1) GM_TYP FROM dbo.ESAT016 WHERE GM_TYP='{gameid.ToString()}' and S_ACTIVE=1");
            //if (checkifexists)
            //{
            //    XtraMessageBox.Show("Already Exists");
            //    return;
            //}
            //else 
            //if (checkifthereactive && txtstat.Text=="ACTIVE")
            //{
            //    XtraMessageBox.Show("There is already OPEN BET in DrawSchedule, Active Status must set one at a time per gametype");
            //    return;
            //}
            //else
            //{
            //    Database.ExecuteQuery($"UPDATE dbo.GAMEPROFILE SET GameType='{txtgametype.Text}'," +
            //        $"DrawDate='{txtdate.Text}'," +
            //        $"DrawSched='{txtdrawsched.Text}'," +
            //        $"StartCutOff='{txtcutofftime.Text}'," +
            //        $"isActive='{stat}' WHERE GameType='{gametype}' AND DrawSched='{drawsched}')","Successfully Updated!");
            //}
            Classes.Database.ExecuteQuery($"UPDATE dbo.ESAT161 SET StartCutOff='{txtcutofftime.Text}'," +
                    $"DateDraw='{txtdate.Text}'," +
                    //$"DrawSched='{txtdrawsched.Text}'," +
                    //$"StartCutOff='{txtcutofftime.Text}' " +
                    $"EndCutOff='{txtcutofftimeend.Text}' " +
                    $"WHERE GM_TYP='{gameid.ToString()}' AND DRW_TYP='{drawsched}' ", "Successfully Updated!");
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

        private void openBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string drwtype = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DrawType").ToString();
            Classes.Database.ExecuteQuery($"UPDATE dbo.ESAT016 set S_ACTIVE=1 WHERE GM_TYP='{gameid.ToString()}' " +
                $"AND DRW_TYP='{drwtype}' ", "Successfully Updated!..");
           
        }

        private void closedBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string drwtype = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DrawType").ToString();
            Classes.Database.ExecuteQuery($"UPDATE dbo.ESAT016 set S_ACTIVE=0 WHERE GM_TYP='{gameid.ToString()}' " +
                $"AND DRW_TYP='{drwtype}' ", "Successfully Updated!..");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bool confirm = Classes.HelperFunction.ConfirmDialog("Are you sure you want to Delete this Transaction?", "Confirm Delete");
            //if (confirm)
            //{
            //    Classes.Database.ExecuteQuery($"DELETE FROM dbo.GAMEPROFILE WHERE GameType='{gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GameType").ToString()}' AND " +
            //    $"DrawSched='{gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DrawSched").ToString()}'", "Successfully Deleted");
            //    display();
            //}
            //else { return; }
        }

        private void editDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnnew.Enabled = false;
            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btncancel.Enabled = true;

            gametype = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GameType").ToString();
            drawdate = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DateDraw").ToString();
            drawsched = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DrawType").ToString();
            cutoffstart = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "StartCutOff").ToString();
            cutoffend = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "EndCutOff").ToString();
            
            enablefields();

            txtdrawsched.Enabled = false;
            
            txtgametype.Text = gametype;
            txtdrawsched.Text = drawsched;
            txtdate.Text = Convert.ToDateTime(drawdate).ToShortDateString();

            txtcutofftime.EditValue = cutoffstart;
            txtcutofftimeend.EditValue = cutoffend;
            //txtcutofftime.Text = cutoff;// Convert.ToDateTime(cutoff).ToShortTimeString();//cutoff;
            //if (Convert.ToBoolean(status) == true)
            //{ txtstat.Text = "ACTIVE"; }
            //else { txtstat.Text = "INACTIVE"; }

        }
    }
}