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
using JLIDashboard.Classes.Common.Extensions;
using Comm.Common.Extensions;
using JLIDashboard.Module;
using JLIDashboard._Module;

using static JLIDashboard.OPERATION._x0z;
using static JLIDashboard.OPERATION._x0z.Vyw;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace JLIDashboard.OPERATION
{
    public partial class GameResults_ : DevExpress.XtraEditors.XtraForm
    {
        public GameResults_()
        {
            InitializeComponent();
        }
        private void GameResults_Load(object sender, EventArgs e)
        {
            this.fillGameTypes();
        }
        private void fillGameTypes()
        {
            Database.displaySearchlookupEdit($"exec dbo.spfn_ABAAAA0B '{Login.compid}','{Login.brcode}' ", tsgmtype, "GM_NM", "GM_ID"); //
            x0a(tsgmtype).EditValue = null; 
        }
        private void tsgmtype_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = tsgmtype.GetFocusedDataRow();
            filter2.GameID = row["GM_ID"].Str();
            string drawdate = row["DRW_TRN_DT"].Str(), draw = row["DRW_TYP"].Str();
            tbdrawdate.Text = (!drawdate.IsEmpty() ? drawdate : "--");
            tbdraw.Text = (!draw.IsEmpty() ? draw : "--");
            this.loadResultWProgress();
        }

        private void btnloadbets_Click(object sender, EventArgs e)
        {
            DataRow row = tsgmtype.GetFocusedDataRow();
            if (row == null) return;
            filter1.GameID = row["GM_ID"].Str();
            filter1.DrawDate = row["DRW_TRN_DT"].Str();
            filter1.DrawSchedule = row["DRW_TYP"].Str();
            filter1.Status = "1";
            this.loadBetsWProgress();
        }

        private void cmsResHisBtn0a_Click(object sender, EventArgs e)
        {
            this.loadResultWProgress();
        }

        public Filter filter2 = new Filter();
        private void loadResultWProgress()
        {
            StaticSettings.showLoading();
            this.loadResult();
            StaticSettings.hideLoading();
        }

        private void loadResult()
        {
            Database.display($"exec dbo.spfn_ADBAAA0C '{Login.compid}','{Login.brcode}','{filter2.GameID}' ", gridControl2, gridView2); //
            x0a(gridView2);
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            bool hasRows = (gridView2.RowCount != 0);
            cmsResHisBtn0b.Visible = hasRows;
            cmsResHisSep0a.Visible = hasRows;
        }
        private void cmsResHisBtn0b_Click(object sender, EventArgs e)
        {
            DataRow row = gridView2.GetFocusedDataRow();
            if (row == null) return;
            filter1.GameID = row["GM_TYP"].Str();
            filter1.DrawDate = row["DRW_TRN_DT"].Str();
            filter1.DrawSchedule = row["DRW_TYP"].Str();
            filter1.Status = "0";
            this.loadBetsWProgress();
        }

        public Filter filter1 = new Filter();
        private void loadBetsWProgress()
        {
            StaticSettings.showLoading();
            this.loadBets();
            StaticSettings.hideLoading();
        }

        private void loadBets()
        {
            Database.display($"exec dbo.spfn_ACBBDB0A '{Login.compid}','{Login.brcode}','{filter1.GameID}','{filter1.DrawDate}','{filter1.DrawSchedule}'", gridControl1, gridView1); //
            x0b(gridView1);
        }

        private void cmsBetsBtn0a_Click(object sender, EventArgs e)
        {
            this.loadBetsWProgress();
        }

       
        private void exportToExcelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //MainDashboard m = new MainDashboard();
            //string transdate = Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('DATE','" + DateTime.Now.ToShortDateString() + "')");
            //string filepath = "C:\\MyFiles\\"+ m.barstaticserverName.Caption+"\\ALLBETS\\" + tsgmtype.Text.Replace(" - ","") + "\\" + transdate + "\\" + tbdraw.Text + "\\";
            //string filename = "GameResults_" + transdate + ".xls";
            //Classes.Utilities.createDirectoryFolder(filepath);
            //if (gridView1.RowCount > 0) { gridView1.ExportToXls(filepath + filename); }
            //else { XtraMessageBox.Show("No Records to Export"); }
            HelperFunction.ExportToExcelAndSaveDialog(saveFileDialog1, gridView1);
        }
    }


    public partial class _x0z
    {
        public class Vyw
        {
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("GM_NM", "Game Type", 0, gridView);
                DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Draw Date", 2, gridView);
                DevXSettings.XtraFormatColumn("DRW_TYP", "Draw Schedule", 3, gridView);
                gridView.BestFitColumns();
                return control;
            }
            public static GridView x0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("GM_TYP_CD", "Game ID", 1, gridView);
                    DevXSettings.XtraFormatColumn("DRW_TRN_DATE", "Date Draw", 2, gridView);
                    DevXSettings.XtraFormatColumn("DRW_TYP", "Draw", 3, gridView);
                    DevXSettings.XtraFormatColumn("NUM_RES", "Result", 4, gridView); //"DRW_TRN_DATE", 
                    DevXSettings.XgridColAlign(new string[] { "GM_TYP_CD", "DRW_TYP", "NUM_RES" }, gridView, HorzAlignment.Center);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static GridView x0b(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("ACT_ID", "Acct. #", 0, gridView);
                    DevXSettings.XtraFormatColumn("ACT_NM", "Acct. Name", 1, gridView);
                    DevXSettings.XtraFormatColumn("TRN_NO", "Trans. #", 2, gridView);
                    DevXSettings.XtraFormatColumn("NUM_BET", "Combination", 3, gridView);
                    DevXSettings.XtraFormatColumn("STRGHT_AMT", "Straight", 4, gridView);
                    DevXSettings.XtraFormatColumn("RMB_AMT", "Rumble", 5, gridView);
                    DevXSettings.XtraFormatColumn("BT_AMT", "Total Bet", 6, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Posted", 7, gridView);
                    DevXSettings.XtraFormatColumn("GEN_COORD_NM", "General Coordinator", 8, gridView); //GEN_COORD_ID
                    DevXSettings.XtraFormatColumn("COORD_NM", "Coordinator", 9, gridView); //COORD_ID
                    DevXSettings.XgridColCurrency(new string[] { "STRGHT_AMT", "RMB_AMT", "BT_AMT" }, gridView);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "STRGHT_AMT", "RMB_AMT", "BT_AMT" }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "RGS_TRN_TS_NM", "ACT_ID", "TRN_NO", "NUM_BET" }, gridView, HorzAlignment.Center);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
        }
        public class Filter
        {
            public string GameID;
            public string GameName;
            public string DrawDate;
            public string DrawSchedule;
            public string Status;
        }

        public class Db
        {
        }
    }
}