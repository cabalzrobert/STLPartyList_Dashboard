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
using AbacosDashboard.Module.Enum;
using Comm.Common.Extensions;

using static JLIDashboard.TREASURY._x0bh;
using static JLIDashboard.TREASURY._x0bh.Vyw;
using JLIDashboard.Module;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.TREASURY
{
    public partial class Remittances : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        private bool isNew;
        public Remittances()
        {
            InitializeComponent();
        }

        private void ClaimCommission_Load(object sender, EventArgs e)
        {
            ok = false;
            Timeout.Set(() => this.Invoke(new Action(() => this.loadTableWProgress())), 250);
        }

        private void loadTableWProgress()
        {
            StaticSettings.showLoading();
            this.loadTable();
            StaticSettings.hideLoading();
        }
        private void loadTable()
        {
            API.displayAPIParam("/api/v1/Remittance/LoadRemittance", gridControl1, gridView1, Login.authentication);
            x0a(gridView1);
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null);
            cmsRemBtn0c.Visible = hasSelected;
            cmsRemBtn0b.Visible = false;// hasSelected;
            //cmsRemSep0a.Visible = hasSelected;
        }
        private void cmsRemBtn0a_Click(object sender, EventArgs e)
        {
            this.loadTableWProgress();
        }

        private void cmsRemBtn0b_Click(object sender, EventArgs e)
        {
            /*if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = Db.execute0a(form).Result;
            if (res.result == Results.Success)
            {
                ok = true;
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else if (res.result != Results.Null)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
            }
            else
            {
                XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            StaticSettings.hideLoading();*/
        }

        private void cmsRemBtn0c_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.FocusedRowHandle;
            var row = gridView1.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<RemittanceEntry>().setData(row, true);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            frm.retData(row);
            gridView1.RefreshRow(focusedrow);
        }

        private void cmsRemBtn0d_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms.Singleton<RemittanceEntry>().setData(null);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            this.loadTableWProgress();
        }
    }

    public partial class _x0bh
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("REM_CD", "Code", 0, gridView);
                DevXSettings.XtraFormatColumn("REM_NM", "Remittance Name", 1, gridView);
                DevXSettings.XtraFormatColumn("ENC_NM", "Encashment Type", 2, gridView);
                DevXSettings.XtraFormatColumn("REM_LOGO", "Logo URL", 3, gridView);
                DevXSettings.XtraFormatColumn("REM_TRM", "Terms URL", 4, gridView);
                gridView.BestFitColumns();
                return gridView;
            }
        }
    }
}