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
using static JLIDashboard.REPORTING._x0d;
using static JLIDashboard.REPORTING._x0d.VywB;
using JLIDashboard.Classes;
using Comm.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using JLIDashboard.Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.REPORTING
{
    public partial class PlayerNoBet : DevExpress.XtraEditors.XtraForm
    {
        public PlayerNoBet()
        {
            InitializeComponent();
        }
        public void Load_PlayerNoBet()
        {
            API.displayAPIParam($"/api/v1/PlayerNoBets/LoadPlayerNoBet?date={Convert.ToDateTime(tbdate.EditValue.Str()).ToString("yyyyMMdd")}", gridControl1, gridView1, Login.authentication);
            if (gridView1.RowCount > 0)
            {
                x0_a(gridView1);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            StaticSettings.showLoading();
            this.Load_PlayerNoBet();
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

        private void PlayerNoBet_Load(object sender, EventArgs e)
        {
            tbdate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            HelperFunction.ExportToExcelAndSaveDialog(saveFileDialog1, gridView1, "PlayerNoBet" + DateTime.Now.ToString("yyyyMMddhhmmss"));
        }
    }
    public partial class _x0d
    {
        public class VywB
        {
            public static GridView x0_a(GridView gridView)
            {
                if (gridView.RowCount > 0)
                {
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("USR_ID", "User ID", 1, gridView, 10);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 2, gridView, 10);
                    DevXSettings.XtraFormatColumn("TOT_AMT_BET", "Sales", 3, gridView, 5);
                    DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Date", 5, gridView, 10);
                    DevXSettings.XtraFormatColumn("GEN_COORD_NM", "Gen Coor", 6, gridView, 50);
                    DevXSettings.XtraFormatColumn("COORD_NM", "Coor", 7, gridView, 200);
                }
                return gridView;
            }
        }
    }
}