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
using static JLIDashboard.REPORTING._x0c;
using static JLIDashboard.REPORTING._x0c.VywB;
using JLIDashboard.Classes;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using Comm.Common.Extensions;
using JLIDashboard.Module;
using System.Globalization;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.REPORTING
{
    public partial class ActivityLogs : DevExpress.XtraEditors.XtraForm
    {
        public ActivityLogs()
        {
            InitializeComponent();
        }

        private void AuditLogs_Load(object sender, EventArgs e)
        {
            tbdate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        }
        public void Load_SessionLog()
        {
            API.displayAPIParam($"/api/v1/ActivityLog/SessionLog?date={Convert.ToDateTime(tbdate.EditValue.Str()).ToString("yyyyMMdd")}", gridControl1, gridView1, Login.authentication);
            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt.Rows.Count > 0)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "LST_NM asc, RGS_TRN_DT desc";
                gridControl1.DataSource = dv;
                gridView1.BestFitColumns();
                gridView1.RefreshData();
            }
            x0_a(gridView1);
        }
        public void Load_Session()
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row == null) return;
            API.displayAPI("/api/v1/ActivityLog/SessionActivity", gridControl2, gridView2, Login.authentication, new Dictionary<string, object>()
            {
                {"dte", Convert.ToDateTime(tbdate.EditValue.Str()).ToString("yyyyMMdd") },
                {"userid", row["USR_ID"] },
                {"sessionID", row["SSSN_ID"] }
            });
            DataTable dt = (DataTable)gridControl2.DataSource;
            gridControl2.DataSource = dt;
            gridView2.BestFitColumns();
            gridView2.RefreshData();
            x0_b(gridView2);
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            
            StaticSettings.showLoading();
            this.Load_SessionLog();
            gridControl2.DataSource = null;
            gridView2.BestFitColumns();
            gridView2.RefreshData();
            StaticSettings.hideLoading();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            gridView1.IndicatorWidth = 50;
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).Str();
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
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            StaticSettings.showLoading();
            this.Load_Session();
            StaticSettings.hideLoading();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl2.DataSource;
            if (dt == null) return;
            HelperFunction.ExportToExcelAndSaveDialog(saveFileDialog1, gridView2,"ActivityLogHistory"+DateTime.Now.ToString("yyyyMMddhhmmss"));
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.FieldName== "RGS_TRN_TS")
            {
                //string evalue = e.Value.ToString();
                if (e.Value.Str() != "")
                {

                    //DateTime evalue = DateTime.Parse(e.Value.Str());
                    //e.DisplayText = Convert.ToDateTime(e.Value.Str()).ToString("dd-MMM-yyyy HH:mm:ss:fff tt");
                    e.DisplayText = e.Value.Str();
                }
                    //e.DisplayText = ((DateTime)e.Value).ToString("dd-MMM-yyyy HH:mm:ss:fff tt");
                    
            }
        }
    }
    public partial class _x0c
    {
        public class VywB
        {
            public static GridView x0_a(GridView gridView)
            {
                if (gridView.RowCount > 0)
                {
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 1, gridView, 30);
                    DevXSettings.XtraFormatColumn("SSSN_ID", "Session", 2, gridView, 70);
                }
                return gridView;
            }
            public static GridView x0_b(GridView gridView)
            {
                if (gridView.RowCount > 0)
                {
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 1, gridView, 30);
                    DevXSettings.XtraFormatColumn("SSSN_ID", "Session", 2, gridView, 30);
                    DevXSettings.XtraFormatColumn("LG_DESCR", "Particulars", 3, gridView, 70);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS", "Date", 4, gridView, 70);
                }
                return gridView;
            }
        }
    }
}