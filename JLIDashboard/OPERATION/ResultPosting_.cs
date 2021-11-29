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
using System.Data.SqlClient;
using JLIDashboard.Classes;

namespace JLIDashboard.OPERATION
{
    public partial class ResultPosting_ : DevExpress.XtraEditors.XtraForm
    {
        object gametypeid = null;
        public ResultPosting_()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtcomba.Text) || String.IsNullOrEmpty(txtcombb.Text) || String.IsNullOrEmpty(txtcombc.Text) || String.IsNullOrEmpty(txtdate.Text) || String.IsNullOrEmpty(txtdrawsched.Text) || String.IsNullOrEmpty(txtgametype.Text))
            {
                XtraMessageBox.Show("Fields must not Empty");
                return;
            }
            else
            {
                //string result = Database.getSingleResultSet($"exec dbo.spfunc_017LG9PR '0002','006','00600000014','01','3PM','20210114','123' ");
                bool confirm = HelperFunction.ConfirmDialog("Are you sure you want to POST this RESULT?", "CONFIRM");
                if (confirm)
                {
                    string combination = txtcomba.Text + "-" + txtcombb.Text + "-" + txtcombc.Text;
                    string operatorid = Login.userid;
                    string drawtype = Database.getSingleResultSet($"SELECT TOP(1) DRW_TYP FROM dbo.ESAT016 WHERE COMP_ID='{Login.plid}' AND BR_CD='{Login.pgrpid}' AND GM_TYP='{gametypeid.ToString()}'");

                    string transdate = Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('DATE','" + txtdate.Text + "')");
                    string result = Database.getSingleResultSet($"exec dbo.spfunc_017LG9PR '{Login.plid}','{Login.pgrpid}','{operatorid}','{gametypeid.ToString()}','{drawtype}','{transdate}','{combination}' ");
                    if(result== "71")
                    {
                        XtraMessageBox.Show("cut off not assign");
                    }
                    else if(result== "72")
                    {
                        XtraMessageBox.Show("game not active");
                    }
                    else if(result== "70")
                    {
                        XtraMessageBox.Show("game type not available");
                    }
                    else if (result == "1")
                    {
                        XtraMessageBox.Show("Successfully Posted for Approval");
                        this.Dispose();
                    }
                    else
                    {
                        XtraMessageBox.Show("ERROR"+result);
                        
                    }
                    //Database.display($"SELECT Distinct GenCoorID FROM dbo.func_viewUshers('{txtdate.Text}','{txtdrawsched.Text}','USHER') ", gridControlUshersList, gridViewUshersList);
                    //Database.display("SELECT Distinct GenCoorID FROM dbo.func_viewUshers("+txtdate.Text+","+txtdrawsched.Text+",'USHER') ", gridControlUshersList, gridViewUshersList);
                    //Database.display($"SELECT Distinct GenCoorID FROM dbo.vw_ushers WHERE GameType='{txtgametype.Text}' AND DrawDate='{txtdate.Text}' AND DrawSched='{txtdrawsched.Text}' ", gridControlUshersList, gridViewUshersList);
                    /*
                    for (int i = 0; i <= gridViewUshersList.RowCount - 1; i++)
                    {
                        string id = gridViewUshersList.GetRowCellValue(i, "GenCoorID").ToString();
                        Database.display($"SELECT * from dbo.fnc_winning('{txtgametype.Text}','{txtdate.Text}','{txtdrawsched.Text}') WHERE GenCoorID='{id}' "
                            , gridControlUsherView, gridViewUsherView);
                        //Printing.UshersReportWinningsSummary(txtgametype.Text,txtdate.Text, txtdrawsched.Text, gridViewUsherView.GetRowCellValue(i, "GenCoorID").ToString(), gridViewUsherView);
                        Printing.UshersReportWinningsSummary(txtgametype.Text, txtdate.Text, txtdrawsched.Text, id, gridViewUsherView);

                        //for (int k = 0; k <= gridViewUsherView.RowCount - 1; k++)
                        //{
                        //    Printing.UshersReportWinningsSummary(txtdate.Text, txtdrawsched.Text, gridViewUsherView.GetRowCellValue(k, "GenCoorID").ToString(), gridViewUsherView);
                        //}
                    }
                    */

                
                }
                else
                {
                    return;
                }
            }
        }
        
        private void txtgametype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Database.displaySearchlookupEdit($"SELECT DrawSched FROM dbo.A000DRAWSCHED WHERE GameType='{txtgametype.Text}'", txtdrawsched, "DrawSched", "DrawSched");
            Database.displaySearchlookupEdit("SELECT CodeInstance,InstanceName FROM dbo.ESAT000 WHERE CodeID='CD001'", txtgametype, "InstanceName", "InstanceName");
        }

        private void txtgametype_EditValueChanged(object sender, EventArgs e)
        {
            gametypeid = SearchLookUpClass.getSingleValue(txtgametype, "CodeInstance");
            Database.displaySearchlookupEdit($"SELECT DrawSched FROM dbo.A000DRAWSCHED WHERE GameType='{txtgametype.Text}'", txtdrawsched, "DrawSched", "DrawSched");
        }

        private void ResultPosting_Load(object sender, EventArgs e)
        {
            Database.displaySearchlookupEdit("SELECT CodeInstance,InstanceName FROM dbo.ESAT000 WHERE CodeID='CD001'", txtgametype, "InstanceName", "InstanceName");
        }

        private void txtcomba_EditValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtcomba.Text)) { txtcombb.Focus(); }
        }

        private void txtcombb_EditValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtcombb.Text)) { txtcombc.Focus(); }
        }
    }
}