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

using static JLIDashboard.TREASURY._x0d;
using static JLIDashboard.TREASURY._x0d.Vyw;
using Comm.Common.Extensions;
using JLIDashboard._Module;
using DevExpress.Utils;
using JLIDashboard.Classes.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using AbacosDashboard.Module.Enum;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.TREASURY
{
    public partial class Commissions : DevExpress.XtraEditors.XtraForm
    {
        public Commissions()
        {
            InitializeComponent();
        }
        private void Commissions_Load(object sender, EventArgs e)
        {
            tbdatefrom.EditValue = tbdateto.EditValue = DateTime.Now;
        }

        private void btngenerate_Click(object sender, EventArgs e)
        {
            filter.Status = rgstatus.EditValue.Str();
            filter.DateFrom = tbdatefrom.EditValue.Str();
            filter.DateTo = tbdateto.EditValue.Str();
            this.loadTableWProgress();
        }

        private void btnexporttoexcel_Click(object sender, EventArgs e)
        {

        }

        private void btnprintreport_Click(object sender, EventArgs e)
        {

        }

        private Input input = new Input();
        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            bool isPayable = filter.Status.Str().Equals("0");
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null);
            bool isPayableTbl = (isPayable && hasSelected);
            bool isClaimableTbl = (!isPayable && hasSelected);
            cmsCommBtn0b.Visible = cmsCommSep0a.Visible = isPayableTbl;
            cmsCommBtn0c.Visible = cmsCommBtn0d.Visible = cmsCommSep0b.Visible = isClaimableTbl;
            if (!isClaimableTbl) return;
            var isClaimed = row["S_CLM"].To<bool>(false);
            cmsCommSep0b.Visible = !isClaimed;
            cmsCommBtn0c.Visible = !isClaimed;
            cmsCommBtn0d.Visible = !isClaimed;
            //
            input.AccountID = row["ACT_ID"].Str();
            input.TransactionNo = row["RQS_NO"].Str();
        }

        private void cmsCommBtn0b_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.FocusedRowHandle;
            var row = gridView1.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<ClaimCommission>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            frm.retData(row);
            gridView1.RefreshRow(focusedrow);
        }
        private void cmsCommBtn0c_Click(object sender, EventArgs e)
        {
            if (!(XtraMessageBox.Show("Are you sure you want to resent otp?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = Db.execute0a(input).Result;
            if (res.result == Results.Success)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                this.loadTableWProgress();
            }
            else if (res.result != Results.Null)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
            }
            else
            {
                XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            StaticSettings.hideLoading();
        }
        private void cmsCommBtn0d_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.FocusedRowHandle;
            var row = gridView1.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<ClaimCommissionApproval>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            frm.retData(row);
            gridView1.RefreshRow(focusedrow);
        }

        private void cmsCommBtn0a_Click(object sender, EventArgs e)
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
            if (filter.Status.Str().Equals("0"))
                this.loadPayable();
            else if (filter.Status.Str().Equals("2"))
                this.loadPending();
            else this.loadClaim();
        }

        private void loadClaim()
        {
            API.displayAPI("/api/v1/Commission/Claim", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom", filter.DateFrom },
                {"dateTo", filter.DateTo }
            });
            x0a(gridView1, false);
        }
        private void loadPending()
        {
            API.displayAPI("/api/v1/Commission/Pending", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom", filter.DateFrom },
                {"dateTo", filter.DateTo }
            });
            x0a(gridView1);
        }
        private void loadPayable()
        {
            API.displayAPI("/api/v1/Commission/Payable", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom", filter.DateFrom },
                {"dateTo", filter.DateTo }
            });
            x0b(gridView1);
        }

    }
    public partial class _x0d
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView, bool isPending = true) 
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("RQS_NO", "Trans. #", 0, gridView);
                    DevXSettings.XtraFormatColumn("ACT_ID", "Account No.", 1, gridView);
                    DevXSettings.XtraFormatColumn("ACT_NM", "Account Name", 2, gridView);
                    DevXSettings.XtraFormatColumn("CLM_AMT", "Amount", 3, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Date Requested", 4, gridView);
                    DevXSettings.XtraFormatColumn("CLM_STAT", "Status", 5, gridView);
                    DevXSettings.XtraFormatColumn("UPD_TRN_TS_NM", "Date Claimed", 6, gridView);
                    if (!isPending)
                    {
                        DevXSettings.XtraFormatColumn("APPR_NM", "Approved By", 7, gridView);
                        //DevXSettings.XtraFormatColumn("APPR_TRN_TS_NM", "Date Approved", 8, gridView);
                    }
                    DevXSettings.XgridColCurrency(new string[] { "CLM_AMT" }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "ACT_ID", "RQS_NO", "RGS_TRN_TS_NM", "CLM_STAT", "UPD_TRN_TS_NM" }, gridView, HorzAlignment.Center);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "CLM_AMT" }, gridView);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static GridView x0b(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("ACT_ID", "Account No.", 0, gridView);
                    DevXSettings.XtraFormatColumn("ACT_NM", "Account Name", 1, gridView);
                    DevXSettings.XtraFormatColumn("ACT_COM_BAL_RNG", "Selected Date Commission", 2, gridView);
                    DevXSettings.XtraFormatColumn("ACT_COM_BAL", "Total Commission Balance", 3, gridView);
                    DevXSettings.XtraFormatColumn("USR_TYP_NM", "Account Type", 4, gridView);
                    DevXSettings.XgridColCurrency(new string[] { "ACT_COM_BAL_RNG", "ACT_COM_BAL" }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "ACT_ID", "USR_TYP_NM" }, gridView, HorzAlignment.Center);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "ACT_COM_BAL_RNG", "ACT_COM_BAL" }, gridView);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
        }
        public class Filter
        {
            public string Status;
            public string DateFrom;
            public string DateTo;
        }
        public class Input
        {
            public string AccountID;
            public string TransactionNo;
        }


        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                dynamic result = API.DSpQueryAPI("/api/v1/Commission/ResendOTP", Login.authentication, new Dictionary<string, object>(){
                    { "accountID", input.AccountID },
                    { "transactionNo", input.TransactionNo },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                    {
                        //await notifySentCredit(account, row, request.Amount);
                        //input.DateRequest = row["RQS_TS"].To<DateTime>().ToString("MMMM dd, yyyy hh:mm:ss tt");
                        return (Results.Success, row["message"].Str());
                    }
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
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
