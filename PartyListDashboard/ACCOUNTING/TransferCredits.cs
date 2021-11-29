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
using JLIDashboard.Module;

using static JLIDashboard.ACCOUNTING._x0g;
using static JLIDashboard.ACCOUNTING._x0g.Vyw;
using Comm.Common.Extensions;
using JLIDashboard._Module;
using DevExpress.Utils;
using JLIDashboard.Classes.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTING
{
    public partial class TransferCredits : DevExpress.XtraEditors.XtraForm
    {
        public TransferCredits()
        {
            InitializeComponent();
        }
        private void TransferCredits_Load(object sender, EventArgs e)
        {
            tbdatefrom.EditValue = tbdateto.EditValue = DateTime.Now;
        }

        private void btngenerate_Click(object sender, EventArgs e)
        {
            filter.DateFrom = tbdatefrom.EditValue.Str();
            filter.DateTo = tbdateto.EditValue.Str();
            this.loadTableWProgress();
        }

        private void btnexporttoexcel_Click(object sender, EventArgs e)
        {
            MainDashboard m = new MainDashboard();
            //string transdate = Database.getSingleResultSet("SELECT dbo.func_ConvertDateTimeToChar('DATE','" + DateTime.Now.ToShortDateString() + "')");
            string transdate = DateTime.Now.ToString("yyyyMMddmmss");
            string filepath = "C:\\MyFiles\\"+m.barstaticserverName+"\\TransferCredits\\" + transdate + "\\";
            string filename = "TransferCreditsRep_" + transdate + ".xls";
            Classes.Utilities.createDirectoryFolder(filepath);
            if (gridView1.RowCount > 0) { gridView1.ExportToXls(filepath+filename); }
            else { XtraMessageBox.Show("No Records to Export"); }
        }

        private void btnprintreport_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            /*bool isPayable = filter.Status.Str().Equals("0");
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null && isPayable);
            bool isClaimable = (hasSelected);
            cmsTCrdtBtn0b.Visible = isClaimable;
            cmsTCrdtSep0a.Visible = isClaimable;
            if (!hasSelected) return;*/
        }
        private void cmsTCrdtBtn0b_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms.Singleton<TransferCredit>().setData();
            frm.ShowDialog(this);
            if (!frm.ok) return;
            this.loadTableWProgress();
        }
        private void cmsTCrdtBtn0a_Click(object sender, EventArgs e)
        {
            this.loadTableWProgress();
        }

        private Filter filter = new Filter();
        private void loadTableWProgress()
        {
            StaticSettings.showLoading();
            this.loadTable();
            StaticSettings.hideLoading();
        }

        private void loadTable()
        {
            API.displayAPI("/api/v1/TransferCredit/Load_TransferCreditHistory", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom",filter.DateFrom },
                {"dateTo",filter.DateTo }
            });
            x0a(gridView1);
        }
    }
    public partial class _x0g
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Transfer Date", 0, gridView);
                    DevXSettings.XtraFormatColumn("DST_ACT_ID", "Destination Account#", 1, gridView);
                    DevXSettings.XtraFormatColumn("DST_FLL_NM", "Account Name", 2, gridView);
                    DevXSettings.XtraFormatColumn("SRC_ACT_ID", "Source Account#", 3, gridView);
                    DevXSettings.XtraFormatColumn("SRC_FLL_NM", "Account Name", 4, gridView);
                    DevXSettings.XtraFormatColumn("TRNSFR_AMNT", "Credit Transfer", 5, gridView);
                    DevXSettings.XtraFormatColumn("RGS_FLL_NM", "Transfer By", 6, gridView);
                    DevXSettings.XgridColCurrency(new[] { "TOT_AMT" }, gridView);
                    DevXSettings.XgridColAlign(new[] { "DST_ACT_ID", "SRC_ACT_ID", "RGS_TRN_TS_NM" }, gridView, HorzAlignment.Center);
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
/*
 
        private void gridControlwinningsandlimit_MouseUp(object sender, MouseEventArgs e)
        {
            if(radpayable.Checked==true)
            {
                if (e.Button == MouseButtons.Right)
                    cmsComm.Show(gridControl1, e.Location);
            }
            
        } 
  
  
 
            ClaimCommission claimcom = new ClaimCommission();
            string id, name, combal;
            id = gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "AccountID").ToString();
            name = gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "AccountName").ToString();
            combal = gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "TotalCommissionBalance").ToString();

            claimcom.txtaccountid.Text = id;
            claimcom.txtactname.Text = name;
            claimcom.txtcombal.Text = combal;
            claimcom.ShowDialog(this);
            if(ClaimCommission.ok==true)
            {
                ClaimCommission.ok = false;
                claimcom.Dispose();
                btngenerate.PerformClick();
            }
     */
