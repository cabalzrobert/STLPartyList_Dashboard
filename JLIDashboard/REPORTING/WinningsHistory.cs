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
using Comm.Common.Extensions;

using static JLIDashboard.REPORTING._x0a;
using static JLIDashboard.REPORTING._x0a.Vyw;
using JLIDashboard._Module;
using DevExpress.Utils;
using JLIDashboard.Module;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.REPORTING
{
    public partial class WinningsHistory : DevExpress.XtraEditors.XtraForm
    {
        public WinningsHistory()
        {
            InitializeComponent();
        }

        private void WinningsHistory_Load(object sender, EventArgs e)
        {
            //radChanged();
            tbdatefrom.EditValue = tbdateto.EditValue = DateTime.Now;
            this.fillGameType();
        }

        private void fillGameType()
        {
            API.displaySearchLookupEditAPIParam("/api/v1/DrawSchedule/LoadGameType", Login.authentication, tsgmtype, "GM_NM", "GM_ID");
            x0a(tsgmtype).EditValue = null;
        }

        private void chkalldrawsched_CheckedChanged(object sender, EventArgs e)
        {
            tsdrawsched.Enabled = !chkalldrawsched.Checked;
        }

        private void tsgmtype_EditValueChanged(object sender, EventArgs e)
        {
            API.displaySearchLookupEditAPIParam($"/api/v1/DrawSchedule/LoadDrawSchedule?gameid={tsgmtype.EditValue.Str()}", Login.authentication, tsdrawsched, "DRW_TYP", "DRW_TYP");
            tsdrawsched.EditValue = null;
        }
        private void btngenerate_Click(object sender, EventArgs e)
        {
            filter.DateFrom = tbdatefrom.EditValue.Str();
            filter.DateTo = tbdateto.EditValue.Str();
            filter.GameID = tsgmtype.EditValue.Str();
            filter.DrawSchedule = tsdrawsched.EditValue.Str();
            filter.Status = (chkalldrawsched.Checked ? "1" : "0");
            this.loadTableWProgress();
        }

        private Filter filter = new Filter();
        private void loadTableWProgress()
        {
            StaticSettings.showLoading();
            this.loadTable();
            StaticSettings.hideLoading();
        }

        private void btnforapprovalsalesorderexcel_Click(object sender, EventArgs e)
        {
            HelperFunction.ExportToExcelAndSaveDialog(saveFileDialog1, gridView1);
        }

        private void loadTable()
        {
            API.displayAPI("/api/v1/WinningHistory/LoadWinningHistory", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom", filter.DateFrom },
                {"dateTo", filter.DateTo },
                {"status", filter.Status },
                {"gameID", filter.GameID },
                {"drawSchedule", filter.DrawSchedule }
            });
            x0a(gridView1);
        }
    }
    public partial class _x0a
    {

        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Draw Date", 0, gridView);
                    DevXSettings.XtraFormatColumn("DRW_TYP", "Draw", 1, gridView);
                    DevXSettings.XtraFormatColumn("ACT_ID", "Account#", 2, gridView);
                    DevXSettings.XtraFormatColumn("ACT_NM", "Winner", 3, gridView);
                    DevXSettings.XtraFormatColumn("TRN_NO", "Transaction#", 4, gridView);
                    DevXSettings.XtraFormatColumn("GM_TYP_CD", "Game ID", 5, gridView);
                    DevXSettings.XtraFormatColumn("NUM_BET", "Combination", 6, gridView);
                    DevXSettings.XtraFormatColumn("NUM_RES", "Result", 7, gridView);
                    DevXSettings.XtraFormatColumn("S_CLM", "Claim?", 8, gridView);
                    DevXSettings.XtraFormatColumn("TOT_BET_STRGHT_AMT", "Total Straight", 9, gridView);
                    DevXSettings.XtraFormatColumn("TOT_BET_RMB_AMT", "Total Rumble", 10, gridView);
                    DevXSettings.XtraFormatColumn("TOT_WIN_STRGHT_AMT", "Total Straight", 11, gridView);
                    DevXSettings.XtraFormatColumn("TOT_WIN_RMB_AMT", "Total Rumble", 12, gridView);
                    DevXSettings.XtraFormatColumn("TOT_WIN_AMT", "Total Winnings", 13, gridView);
                    DevXSettings.XtraFormatColumn("DRW_TRN_TS_NM", "Approved", 14, gridView);
                    DevXSettings.XtraFormatColumn("GEN_COORD_NM", "General Coordinator", 15, gridView); //GEN_COORD_ID
                    DevXSettings.XtraFormatColumn("COORD_NM", "Coordinator", 16, gridView); //COORD_ID
                    DevXSettings.XgridColCurrency(new string[] { "TOT_BET_STRGHT_AMT", "TOT_BET_RMB_AMT", "TOT_WIN_STRGHT_AMT", "TOT_WIN_RMB_AMT", "TOT_WIN_AMT" }, gridView);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "TOT_BET_STRGHT_AMT", "TOT_BET_RMB_AMT", "TOT_WIN_STRGHT_AMT", "TOT_WIN_RMB_AMT", "TOT_WIN_AMT" }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "DRW_TRN_DT", "ACT_ID", "TRN_NO", "DRW_TYP", "GM_TYP_CD", "NUM_BET", "NUM_RES" }, gridView, HorzAlignment.Center);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("GM_CD", "Code", 0, gridView, MaxWidth: 75);
                DevXSettings.XtraFormatColumn("GM_NM", "Game Type", 1, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Filter
        {
            public string GameID;
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