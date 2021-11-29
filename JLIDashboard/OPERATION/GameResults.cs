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

using static JLIDashboard.OPERATION._x0b;
using static JLIDashboard.OPERATION._x0b.Vyw;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATION
{
    public partial class GameResults : DevExpress.XtraEditors.XtraForm
    {
        public GameResults()
        {
            InitializeComponent();
        }
        private void GameResults_Load(object sender, EventArgs e)
        {
            tbdatefrom1.EditValue = tbdateto1.EditValue = DateTime.Now;
            this.fillGameTypes();
        }
        public void fillGameTypes(bool nullable = true)
        {
            API.displaySearchLookupEditAPIParam("/api/v1/GameResult/GameType", Login.authentication, tsgmtype, "GM_NM", "GM_ID");
            x0a(tsgmtype);
            if (!nullable)
            {
                this.tsgmtype_EditValueChanged(tsgmtype, null);
                return;
            }
            tsgmtype.EditValue = null;
        }

        private void tsgmtype_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = tsgmtype.GetFocusedDataRow();
            bool hasSelected = (row != null);
            filter2.GameID = (!hasSelected ? "" : row["GM_ID"].Str());
            string drawdate = (!hasSelected ? "" : row["DRW_TRN_DT"].Str()), draw = (!hasSelected ? "" : row["DRW_TYP"].Str());
            tbdrawdate.Text = (!drawdate.IsEmpty() ? drawdate : "--");
            tbdraw.Text = (!draw.IsEmpty() ? draw : "--");
            btnloadbets.Enabled = hasSelected;
            tbdatefrom1.Enabled = hasSelected;
            tbdateto1.Enabled = hasSelected;
            btngenerate1.Enabled = hasSelected;
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

        private void btngenerate1_Click(object sender, EventArgs e)
        {
            filter2.DateFrom = tbdatefrom1.EditValue.Str();
            filter2.DateTo = tbdateto1.EditValue.Str();
            this.loadResultWProgress();
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
            API.displayAPI("/api/v1/GameResult/LoadGameResult", gridControl2, gridView2, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom",filter2.DateFrom },
                {"dateTo",filter2.DateTo },
                {"gameID",filter2.GameID }
            });
            if (gridView2.RowCount != 0)
            {
                x0a(gridView2);
            }
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
            API.displayAPI("/api/v1/GameResult/LoadGameBets", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"gameID",filter1.GameID },
                {"drawDate",filter1.DrawDate },
                {"drawSchedule",filter1.DrawSchedule }
            });
            if (gridView1.RowCount != 0)
            {
                x0b(gridView1);
            }
        }

        private void cmsBetsBtn0a_Click(object sender, EventArgs e)
        {
            this.loadBetsWProgress();
        }

       
        private void exportToExcelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelperFunction.ExportToExcelAndSaveDialog(saveFileDialog1, gridView1);
        }

    }


    public partial class _x0b
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
                    DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Date Draw", 2, gridView);
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
            public string DateFrom;
            public string DateTo;
        }

        public class Db
        {
        }
    }
}