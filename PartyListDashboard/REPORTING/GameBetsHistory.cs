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

using static JLIDashboard.REPORTING._x0b;
using static JLIDashboard.REPORTING._x0b.Vyw;
using JLIDashboard._Module;
using DevExpress.Utils;
using JLIDashboard.Module;
using DevExpress.XtraGrid.Views.Grid;
using System.Xml.Serialization;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard.Classes.Common;
using JLIDashboard._Module.Classes.Common;
using ClosedXML.Excel;
using System.IO;
using DevExpress.Utils.OAuth.Provider;
using DevExpress.XtraGrid;
using System.Diagnostics;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace JLIDashboard.REPORTING
{
    public partial class GameBetsHistory : DevExpress.XtraEditors.XtraForm
    {
        public GameBetsHistory()
        {
            InitializeComponent();
        }

        private void GameBetsHistory_Load(object sender, EventArgs e)
        {
            tbdatefrom.EditValue = tbdateto.EditValue = DateTime.Now;
            this.fillGameType();
        }

        private void fillGameType()
        {
            API.displayCheckedcomboboxEditAPIParam("/api/v1/DrawSchedule/LoadGameType", Login.authentication, ccbxgmtyp, "GM_NM", "GM_ID");
            ccbxgmtyp.EditValue = null;
        }
        private void btngenerate_Click(object sender, EventArgs e)
        {
            //var values = ccbxgmtyp.EditValue;
            //ccbxgmtyp = <item ID="Z" /><item ID="X" /><item ID="Y" />
            var gameIDs = ccbxgmtyp.GetSelectedDataRows();
            if (gameIDs.Length == 0)
            {
                StaticSettings.XtraMessage("Please select game type", MessageBoxIcon.Exclamation);
                ccbxgmtyp.Focus();
                return;
            }
            var drawSchedules = ccbxdrawsched.GetSelectedDataRows();
            if (drawSchedules.Length == 0)
            {
                StaticSettings.XtraMessage("Please select draw schedule", MessageBoxIcon.Exclamation);
                ccbxdrawsched.Focus();
                return;
            }

            filter.GameTypes = drawSchedules.Select((row) => (new XItem0a() { GameID = row["GM_TYP"].Str(), DrawSchedule = row["DRW_TYP"].Str() })).ToList();
            filter.DateFrom = tbdatefrom.EditValue.Str();
            filter.DateTo = tbdateto.EditValue.Str();
            Filter.validity(filter);
            this.loadTableWProgress();
        }

        private Filter filter = new Filter();
        private void loadTableWProgress()
        {
            StaticSettings.showLoading();
            this.loadTable();
            StaticSettings.hideLoading();
        }

        private void ccbxgmtyp_EditValueChanged(object sender, EventArgs e)
        {
            var gmtyps = ccbxgmtyp.GetSelectedDataRows().Select((row) => row["GM_ID"].Str()).ToArray();
            var igmtyps = (gmtyps.Length == 0 ? "" : AggrUtils.Xml.toXmlString(XItem.AsList(gmtyps)).ToString().Trim());
            //
            ccbxdrawsched.SetEditValue(null);
            ccbxdrawsched.DeselectAll();
            API.displayCheckedcomboboxEditAPI("/api/v1/GameBetsHistory/LoadDrawSchedule", Login.authentication, ccbxdrawsched, "DRW_TYP", "DRW_TYP", new Dictionary<string, object>()
            {
                {"igmtyps", igmtyps },
                {"gmtyp", (gmtyps.Length < 2 ? 0 : 1) }
            });
        }

        private void loadTable()
        {
            gridView1.Columns.Clear();
            DataTable dtNew = new DataTable();
            DateTime dtFrom = Convert.ToDateTime(filter.DateFrom);
            DateTime dtTo = Convert.ToDateTime(filter.DateTo).AddDays(1);
            DateTime dtAdded = dtFrom;
            if (dtFrom != dtTo)
            {
                while (dtAdded != dtTo)
                {
                    DataTable dt = new DataTable();
                    dt = API.APITable("/api/v1/GameBetsHistory/LoadGameBetsHistory", Login.authentication, new Dictionary<string, object>()
                    {
                        {"dateFrom", dtAdded },
                        {"dateTo", dtAdded },
                        {"iGameTypes", filter.iGameTypes }
                    });
                    dtNew.Merge(dt);
                    DateTime nDate = dtAdded.AddDays(1);
                    dtAdded = nDate;
                }
                dtNew.DefaultView.Sort = "DRW_TRN_DT DESC, DRW_TYP DESC";

                gridControl1.DataSource = null;
                gridControl1.DataSource = dtNew;
                gridView1.BestFitColumns();
            }

            x0a(gridView1, filter);
        }

        private void btnforapprovalsalesorderexcel_Click(object sender, EventArgs e)
        {

            //Export to Exceel
            //HelperFunction.ExportToExcelAndSaveDialog(saveFileDialog1, gridView1);

            StaticSettings.showLoading();
            DataTable dt = (DataTable)gridControl1.DataSource;
            DataView row = new DataView(dt);
            DateTime dtFrom = Convert.ToDateTime(filter.DateFrom);
            DateTime dtTo = Convert.ToDateTime(filter.DateTo);
            DateTime dtAdded = dtFrom;
            int i = 0;
            try
            {
                MainDashboard m = new MainDashboard();
                string transdate = DateTime.Now.ToString("yyyyMMddHHmmss");
                string FPath = "C:\\MyFiles\\" + m.barstaticserverName + "\\GAMEBETSHISTORY\\" + transdate + "\\";
                Classes.Utilities.createDirectoryFolder(FPath);
                while (dtAdded <= dtTo)
                {
                    GridControl gc = new GridControl();
                    gc.Parent = this;
                    GridView gv = gc.MainView as GridView;
                    string wsName = $"GBH_{Convert.ToDateTime(dtAdded).ToString("MMM_dd_yyyy")}.xlsx";
                    DataTable newdt = dt.Select("DRW_TRN_DT='" + Convert.ToDateTime(dtAdded).ToString("yyyy-MM-dd") + "'").CopyToDataTable();
                    gc.DataSource = null;
                    gc.DataSource = newdt;
                    gv.BestFitColumns();
                    x0a(gv, filter);

                    ExportToExcelXls(FPath, wsName, gv);
                    DateTime nDate = dtAdded.AddDays(1);
                    dtAdded = nDate;
                    i++;

                }
                StaticSettings.hideLoading();
                XtraMessageBox.Show("Successfully Exported");

                if (Directory.Exists(FPath))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = FPath,
                        FileName = "explorer.exe"
                    };
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message); }
        }
        public static void ExportToExcelXls(string FPath, string FName, GridView viewz)
        {
            XlsxExportOptions options = new XlsxExportOptions();
            options.ExportMode = XlsxExportMode.SingleFilePageByPage;
            if (viewz.RowCount > 0)
            {
                viewz.ExportToXlsx(FPath + "\\" + FName, options);
                viewz.Dispose();
            }
        }
    }
    public partial class _x0b
    {

        public class Vyw
        {
            public static GridView x0a(GridView gridView, Filter filter)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    if (filter.IsMultiGameType)
                    {
                        DevXSettings.XtraFormatColumn("GM_TYP_NM", "Game Type", 0, gridView);
                        DevXSettings.XtraFormatColumn("DRW_TYP", "Draw", 2, gridView);
                    }
                    DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Draw Date", 1, gridView);
                    DevXSettings.XtraFormatColumn("ACT_ID", "Acct. #", 3, gridView);
                    DevXSettings.XtraFormatColumn("ACT_NM", "Acct. Name", 4, gridView);
                    DevXSettings.XtraFormatColumn("TRN_NO", "Trans. #", 5, gridView);
                    DevXSettings.XtraFormatColumn("NUM_BET", "Combination", 6, gridView);
                    DevXSettings.XtraFormatColumn("STRGHT_AMT", "Straight", 7, gridView);
                    DevXSettings.XtraFormatColumn("RMB_AMT", "Rumble", 8, gridView);
                    DevXSettings.XtraFormatColumn("BT_AMT", "Total Bet", 9, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Posted", 10, gridView);
                    DevXSettings.XtraFormatColumn("GEN_COORD_NM", "General Coordinator", 11, gridView); //GEN_COORD_ID
                    DevXSettings.XtraFormatColumn("COORD_NM", "Coordinator", 12, gridView); //COORD_ID
                    DevXSettings.XgridColCurrency(new string[] { "STRGHT_AMT", "RMB_AMT", "BT_AMT" }, gridView);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "STRGHT_AMT", "RMB_AMT", "BT_AMT" }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "DRW_TYP", "RGS_TRN_TS_NM", "ACT_ID", "TRN_NO", "NUM_BET" }, gridView, HorzAlignment.Center);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
        }
        public class Filter
        {
            public List<XItem0a> GameTypes;
            public string iGameTypes;
            public string DateFrom;
            public string DateTo;
            public bool IsMultiGameType;

            public static bool validity(Filter filter)
            {
                var gameTypes = filter.GameTypes;
                if (gameTypes != null && gameTypes.Count != 0)
                    filter.iGameTypes = AggrUtils.Xml.toXmlString(gameTypes).ToString().Trim();
                else filter.iGameTypes = null;
                filter.IsMultiGameType = (gameTypes.Count > 1);
                return true;
            }
        }


        [XmlRoot(ElementName = "item")]
        public class XItem
        {
            [XmlAttribute("ID")]
            public string ID;

            public static List<XItem> AsList(string[] arr)
            {
                List<XItem> list = null;
                if (arr != null && arr.Length != 0)
                    list = arr.Select((str) => (new XItem() { ID = str })).ToList();
                return list;
            }
        }

        [XmlRoot(ElementName = "item")]
        public class XItem0a
        {
            [XmlAttribute("GM_TYP")]
            public string GameID;
            [XmlAttribute("DRW_TYP")]
            public string DrawSchedule;
        }


        public class Db
        {
        }
    }
}