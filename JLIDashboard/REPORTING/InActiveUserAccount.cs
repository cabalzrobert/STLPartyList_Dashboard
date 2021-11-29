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
using static JLIDashboard.REPORTING._x0e;
using static JLIDashboard.REPORTING._x0e.VywB;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using JLIDashboard.Classes;
using Comm.Common.Extensions;
using JLIDashboard.Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.REPORTING
{
    public partial class InActiveUserAccount : DevExpress.XtraEditors.XtraForm
    {
        public InActiveUserAccount()
        {
            InitializeComponent();
        }

        private void btngenerate_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbmonths.Text.Trim()) <= 0) return;
            StaticSettings.showLoading();
            groupControl2.Text = "In-active Account for " + tbmonths.Text.Trim() + " month(s)";
            Load_InActivePlayer();
            StaticSettings.hideLoading();
        }
        public void Load_InActivePlayer()
        {
            API.displayAPIParam($"/api/v1/InActivePlayer/LoadInactivePlayer?numberofmonths={(Convert.ToInt32(tbmonths.Text.Trim()) * -1).Str()}", gridControl1, gridView1, Login.authentication);
            if (gridView1.RowCount > 0)
            {
                x0_a(gridView1);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            gridView1.IndicatorWidth = 50;
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).Str();
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.FieldName== "LST_LOG_IN")
            {
                e.DisplayText = ((DateTime)e.Value).ToString("dd-MMM-yyyy HH:mm:ss tt");
            }
        }

        private void btnexportxl_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                HelperFunction.ExportToExcelAndSaveDialog(saveFileDialog1, gridView1, "InActiveAccount" + DateTime.Now.ToString("yyyyMMddhhmmss"));
            }
        }
    }
    public partial class _x0e
    {
        public class VywB
        {
            public static GridView x0_a(GridView gridView)
            {
                if (gridView.RowCount > 0)
                {
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("USR_ID", "User ID", 1, gridView, 10);
                    DevXSettings.XtraFormatColumn("GEN_COORD_NM", "Gen Coor", 2, gridView, 10);
                    DevXSettings.XtraFormatColumn("COORD_NM", "Coor", 3, gridView, 5);
                    DevXSettings.XtraFormatColumn("PLAYER_NM", "Name", 5, gridView, 10);
                    DevXSettings.XtraFormatColumn("LST_LOG_IN", "Last Login", 6, gridView, 50);
                }
                return gridView;
            } 
        }
    }
}