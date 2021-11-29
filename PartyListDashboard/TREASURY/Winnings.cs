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
using AbacosDashboard.Module.Enum;
using JLIDashboard.Classes;
using Comm.Common.Extensions;

using static JLIDashboard.TREASURY._x0b;
using static JLIDashboard.TREASURY._x0b.Vyw;
using JLIDashboard.Module;
using JLIDashboard._Module;
using DevExpress.Utils;
using JLIDashboard.Classes.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.TREASURY
{
    public partial class Winnings : DevExpress.XtraEditors.XtraForm
    {
        public Winnings()
        {
            InitializeComponent();
        }

        private void Winnings_Load(object sender, EventArgs e)
        {
            tbdatefrom.EditValue = tbdateto.EditValue = DateTime.Now;
            rgstatus_SelectedIndexChanged(rgstatus, null);
            Timeout.Set(() => this.Invoke(new Action(() => btngenerate.PerformClick())), 250);
        }
        private Filter filter = new Filter();
        private void btngenerate_Click(object sender, EventArgs e)
        {
            tbForfeit.Text = string.Empty;
            filter.Status = rgstatus.EditValue.Str();
            filter.DateFrom = tbdatefrom.EditValue.Str();
            filter.DateTo = tbdateto.EditValue.Str();
            this.loadTableWProgress();
        }
        private void rgstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isPending = rgstatus.EditValue.Str().Equals("0");
            tbdatefrom.Enabled = !isPending;
            tbdateto.Enabled = !isPending;
            lblForfeit.Visible = false;
            tbForfeit.Visible = false;
            tbForfeit.ReadOnly = true;
            if (rgstatus.EditValue.Str()=="3")
            {
                //DataTable dt = Database.GetDatable($"select CONCAT(INTRVL_NM, ' ', INTRVL_TP) FORFEIT  from ESAT1AB where INTRVL_STS = 1");
                //tbForfeit.Text = dt.Rows[0]["FORFEIT"].Str();
                
                lblForfeit.Visible = true;
                tbForfeit.Visible = true;
            }
        }

        private void btnexporttoexcel_Click(object sender, EventArgs e)
        {
            MainDashboard m = new MainDashboard();
            string transdate = DateTime.Now.ToString("yyyyMMdd");//Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('DATE','" + DateTime.Now.ToShortDateString() + "')");
            string filepath = "C:\\MyFiles\\"+m.barstaticserverName+"\\WINNINGS_HISTORY\\" + transdate+"\\";
            string filename = "WinningHistoryRep_" + transdate + ".xls";
            Classes.Utilities.createDirectoryFolder(filepath);
            if (gridView1.RowCount > 0) { gridView1.ExportToXls(filepath+filename); }
            else { XtraMessageBox.Show("No Records to Export"); }
        }

        private void btnprintreport_Click(object sender, EventArgs e)
        {

        }
        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            bool isUnclaim = filter.Status.Str().Equals("2");
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null && !isUnclaim);
            bool isPending = (hasSelected && row["RQS_STAT"].Str().Equals("0"));
            cmsConfirmBtn0b.Visible = isPending;
            cmsConfirmSep0a.Visible = isPending;
            if (!hasSelected) return;
        }
        private void cmsConfirmBtn0b_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.FocusedRowHandle;
            var row = gridView1.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<ClaimWinnings>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            gridView1.DeleteRow(focusedrow);
        }
        private void cmsConfirmBtn0a_Click(object sender, EventArgs e)
        {
            this.loadTableWProgress();
        }
        private void loadTableWProgress()
        {
            StaticSettings.showLoading();
            this.loadTable();
            StaticSettings.hideLoading();
        }

        private void loadTable()
        {
            if (filter.Status.Str().Equals("2"))
                this.loadUnclaim();
            else if (filter.Status.Str().Equals("3")) this.loadForfeit();
            else this.loadWinning();
        }

        private void loadForfeit()
        {
            DataTable dt = API.APITable("/api/v1/ForfeitInterval/GetForfeitIntervalPrimary", Login.authentication, new Dictionary<string, object>()
            {
                {"parmHandler","4" },
                {"parmintrvlsts","1" }
            });
            tbForfeit.Text = $"{dt.Rows[0]["INTRVL_NM"].Str()} {dt.Rows[0]["INTRVL_TP"].Str()}";
            API.displayAPI("/api/v1/Winnings/ForfeitWinning", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom",filter.DateFrom },
                {"dateTo",filter.DateTo }
            });
            x0a(gridView1);
        }
        private void loadUnclaim()
        {
            API.displayAPI("/api/v1/Winnings/UnclaimWinning", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom",filter.DateFrom },
                {"dateTo",filter.DateTo }
            });
            x0a(gridView1);
        }
        private void loadWinning()
        {
            API.displayAPI("/api/v1/Winnings/ClaimWinning", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom",filter.DateFrom },
                {"dateTo",filter.DateTo },
                {"status",filter.Status }
            });
            x0b(gridView1, filter.Status.Str().Equals("0"));
        }
    }
    public partial class _x0b
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("ACT_ID", "Account No.", 0, gridView);
                    DevXSettings.XtraFormatColumn("ACT_NM", "Winner", 1, gridView);
                    DevXSettings.XtraFormatColumn("GM_TYP_CD", "Game", 2, gridView);
                    DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Date Draw", 3, gridView);
                    DevXSettings.XtraFormatColumn("DRW_TYP", "Draw", 4, gridView);
                    DevXSettings.XtraFormatColumn("NUM_RES", "Result", 5, gridView);
                    DevXSettings.XtraFormatColumn("TRN_NO", "Trans. #", 6, gridView);
                    DevXSettings.XtraFormatColumn("NUM_BET", "Combination", 7, gridView);
                    DevXSettings.XtraFormatColumn("STRGHT_AMT", "Bet Straight", 8, gridView);
                    DevXSettings.XtraFormatColumn("RMB_AMT", "Bet Rumble", 9, gridView);
                    DevXSettings.XtraFormatColumn("WIN_STRGHT_AMT", "Win Straight", 10, gridView);
                    DevXSettings.XtraFormatColumn("WIN_RMB_AMT", "Win Rumble", 11, gridView);
                    DevXSettings.XtraFormatColumn("WIN_TOT_AMT", "Total Win", 12, gridView);
                    DevXSettings.XtraFormatColumn("GEN_COORD_NM", "General Coordinator", 13, gridView); //GEN_COORD_ID
                    DevXSettings.XtraFormatColumn("COORD_NM", "Coordinator", 14, gridView); //COORD_ID
                    DevXSettings.XgridColCurrency(new string[] { "STRGHT_AMT", "RMB_AMT", "WIN_STRGHT_AMT", "WIN_RMB_AMT", "WIN_TOT_AMT" }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "ACT_ID", "ACT_NM", "GM_TYP_CD", "DRW_TRN_DATE", "DRW_TYP", "NUM_RES", "TRN_NO", "NUM_BET", "STRGHT_AMT", "RMB_AMT" }, gridView, HorzAlignment.Center);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "STRGHT_AMT", "RMB_AMT", "WIN_STRGHT_AMT", "WIN_RMB_AMT", "WIN_TOT_AMT" }, gridView);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static GridView x0b(GridView gridView, bool isPending = true)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("S_CNFRM", "Confirmed", 0, gridView, MaxWidth: 75);
                    DevXSettings.XtraFormatColumn("RQS_NO", "Request No.", 1, gridView);
                    DevXSettings.XtraFormatColumn("ACT_ID", "Account No.", 2, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Request Date", 3, gridView);
                    DevXSettings.XtraFormatColumn("TRN_NO", "Trans. #", 4, gridView);
                    DevXSettings.XtraFormatColumn("TOT_AMT", "Total Amount", 5, gridView);
                    DevXSettings.XtraFormatColumn("ENC_NM", "Encashment Type", 6, gridView);
                    DevXSettings.XtraFormatColumn("REM_NM", "Remittance Name", 7, gridView);
                    DevXSettings.XtraFormatColumn("ADDR", "Complete Address", 8, gridView);

                    if (!isPending)
                    {
                        DevXSettings.XtraFormatColumn("APPR_NM", "Approved By", 9, gridView);
                        DevXSettings.XtraFormatColumn("APPR_TRN_TS_NM", "Date Approved", 10, gridView);
                    }

                    DevXSettings.XgridColCurrency(new string[] { "TOT_AMT" }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "RQS_ID", "ACT_ID", "TRN_NO", "ENC_NM", "USR_FLL_NM" }, gridView, HorzAlignment.Center); //"primaryid",
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "TOT_AMT" }, gridView);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
        }
        public class Input
        {
            public string GameID;
            public string DrawSchedule;
            public string DateDraw;
            public string Result;
        }
        public class Filter
        {
            public string Status;
            public string DateFrom;
            public string DateTo;
        }
        public class Db
        {
        }
    }
}
