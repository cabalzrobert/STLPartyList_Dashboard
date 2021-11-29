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
using static JLIDashboard.REPORTING._x0b;
using static JLIDashboard.REPORTING._x0b.VywB;
using JLIDashboard.Classes;
using JLIDashboard._Module;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard.Module;
using Comm.Common.Extensions;
using System.Xml.Serialization;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using System.Diagnostics;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.REPORTING
{
    public partial class MaxSales : DevExpress.XtraEditors.XtraForm
    {
        public MaxSales()
        {
            InitializeComponent();
        }
        #region Function
        public void Load_TotalSales()
        {
            var minsale = tbPercentage.Text.Trim().Remove(tbPercentage.Text.Trim().Length - 1);
            API.displayAPIParam($"/api/v1/MaxSales/LoadMaxSales?date={Convert.ToDateTime(tbdate.EditValue.Str()).ToString("yyyyMMdd")}&percentage={minsale}", gridControl2, gridView2, Login.authentication);

            DataTable dt = (DataTable)gridControl2.DataSource;
            if (dt.Rows.Count > 0)
            {
                DataTable dt1 = new DataTable();
                dt1 = dt;

                DataView dv = dt1.DefaultView;
                dv.Sort = "MAX_SALES desc";
                dt = dv.ToTable();
                gridControl1.DataSource = dv;
                gridView1.BestFitColumns();
                gridView1.RefreshData();
                DataView dv2 = dt.DefaultView;
                dv2.Sort = "TOT_AMT_BET desc, MinSales desc, GEN_COORD_NM ASC, COORD_NM ASC, LST_NM ASC";
                //dt = dv2.ToTable();
                gridControl2.DataSource = dv2;
                gridView2.BestFitColumns();
                gridView2.RefreshData();

                x0_b(gridView1);
                x0_a(gridView2);
            }
            
        }

        public void exportToExcel()
        {
            using (var saveDialog = new SaveFileDialog())
            {
                //saveDialog.Filter = “Excel(.xlsx) | *.xlsx”;
                saveDialog.FileName = "MaxSales" + DateTime.Now.ToString("yyyyMMddhhmmss");
                saveDialog.Filter = "Excel (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var printingSystem = new PrintingSystemBase();
                    var compositeLink = new CompositeLinkBase();
                    compositeLink.PrintingSystemBase = printingSystem;

                    var link1 = new PrintableComponentLinkBase();
                    link1.Component = gridControl1;
                    var link2 = new PrintableComponentLinkBase();
                    link2.Component = gridControl2;

                    compositeLink.Links.Add(link1);
                    compositeLink.Links.Add(link2);

                    var options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                    compositeLink.CreatePageForEachLink();
                    compositeLink.ExportToXlsx(saveDialog.FileName, options);
                }
            }
        }
        #endregion
        #region Toolbox
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(tbPercentage.Text.Trim()=="0.00%" || tbPercentage.Text.Trim() == "0.0%")
            {
                StaticSettings.XtraMessage("Please enter how many percent", MessageBoxIcon.Exclamation);
                tbPercentage.Focus();
                return;
            }
            StaticSettings.showLoading();
            this.Load_TotalSales();
            StaticSettings.hideLoading();
        }
        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string salesVal = (view.GetRowCellDisplayText(e.RowHandle, view.Columns["TOT_AMT_BET"])=="") ? "0" : view.GetRowCellDisplayText(e.RowHandle, view.Columns["TOT_AMT_BET"]);
                string minVal = (view.GetRowCellDisplayText(e.RowHandle, view.Columns["MinSales"])=="") ? "0" : view.GetRowCellDisplayText(e.RowHandle, view.Columns["MinSales"]);
                if (Convert.ToDecimal(salesVal) < Convert.ToDecimal(minVal) || Convert.ToDecimal(salesVal)==0)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
        private void MaxSales_Load(object sender, EventArgs e)
        {
            tbdate.EditValue = DateTime.Now;
        }
        private void btnexportxl_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)gridView1.DataSource;
            DataView dv1 = (DataView)gridView2.DataSource;
            //DataTable dt1 = (DataTable)gridControl1.DataSource;
            //DataTable dt2 = (DataTable)gridControl2.DataSource;
            //if (dt1 !=null && dt1!=null)
            if (dv != null && dv1 != null)
            {
                exportToExcel();
            }
            else
            {
                StaticSettings.XtraMessage("Cannot Extract Empty Data", MessageBoxIcon.Exclamation);
            }
        }
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            gridView1.IndicatorWidth = 50;
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle+1).Str();
            }
        }
        private void gridView2_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            gridView2.IndicatorWidth = 50;
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).Str();
            }
        }
        #endregion
    }
    #region Class
    public partial class _x0b
    {
        public class VywB
        {
            public static GridView x0_a(GridView gridView)
            {
                if (gridView.RowCount > 0)
                {
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("USR_ID", "User ID", 1, gridView, 20);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 2, gridView, 20);
                    DevXSettings.XtraFormatColumn("TOT_AMT_BET", "Sales", 3, gridView, 10);
                    DevXSettings.XtraFormatColumn("MinSales", "Min. Sales", 4, gridView, 10);
                    DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Date", 5, gridView, 20);
                    DevXSettings.XtraFormatColumn("GEN_COORD_NM", "Gen Coor", 6, gridView, 50);
                    DevXSettings.XtraFormatColumn("COORD_NM", "Coor", 7, gridView, 100);
                    DevXSettings.XgridGeneralSummaryNumber(new string[] { "TOT_AMT_BET" }, gridView);
                    //DevXSettings.xgr
                }
                return gridView;
            }
            public static GridView x0_b(GridView gridView)
            {
                if (gridView.RowCount > 0)
                {
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("USR_ID", "User ID", 1, gridView, 50);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 2, gridView, 50);
                    DevXSettings.XtraFormatColumn("MAX_SALES", "Max Sales", 3, gridView, 50);
                }
                return gridView;
            }
        }
    }
    #endregion
}