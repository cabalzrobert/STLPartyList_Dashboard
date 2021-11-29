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
using JLIDashboard.Module;

using static JLIDashboard.ACCOUNTING._x0c;
using static JLIDashboard.ACCOUNTING._x0c.Vyw;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using JLIDashboard._Module;
using DevExpress.Utils;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTING
{
    public partial class AccountCredits : DevExpress.XtraEditors.XtraForm
    {
        public AccountCredits()
        {
            InitializeComponent();
        }

        private void AccountCredits_Load(object sender, EventArgs e)
        {
            tbdatefrom1.EditValue = tbdateto1.EditValue = DateTime.Now;
            tbdatefrom2.EditValue = tbdateto2.EditValue = DateTime.Now;
            this.getDetails();
        }
        private void getDetails()
        {
            var row = API.GetDictionaryRow("/api/v1/PowerAppCredit/GetCompanyCreditBalance", Login.authentication);
            double creditBal = row.GetValue("ACT_CRDT_BAL").Str().ToDecimalDouble();
            tbacctname.Text = row.GetValue("ACT_ID").Str();
            tbcreditbal.Text = creditBal.ToAccountingFormat("0.00");
        }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            StaticSettings.showLoading();
            this.getDetails();
            StaticSettings.hideLoading();
        }
        private void btnreqcredit_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms.Singleton<RequestCreditBal>().setData();
            frm.ShowDialog(this);
        }

        //--------------------
        private Filter filter1 = new Filter();
        private void btngenerate1_Click(object sender, EventArgs e)
        {
            filter1.DateFrom = tbdatefrom1.EditValue.Str();
            filter1.DateTo = tbdateto1.EditValue.Str();
            filter1.Status = "0";
            this.loadTable1WProgress();
        }
        private void btnexporttoexcel1_Click(object sender, EventArgs e)
        {

        }
        private void loadTable1WProgress()
        {
            StaticSettings.showLoading();
            this.loadTable(gridControl1, gridView1, filter1);
            StaticSettings.hideLoading();
        }

        //--------------------
        private Filter filter2 = new Filter();
        private void btngenerate2_Click(object sender, EventArgs e)
        {
            filter2.DateFrom = tbdatefrom2.EditValue.Str();
            filter2.DateTo = tbdateto2.EditValue.Str();
            filter2.Status = "1";
            this.loadTable2WProgress();
        }
        private void btnexporttoexcel2_Click(object sender, EventArgs e)
        {

        }

        private void loadTable2WProgress()
        {
            StaticSettings.showLoading();
            this.loadTable(gridControl2, gridView2, filter2);
            StaticSettings.hideLoading();
        }

        private void loadTable(GridControl gc, GridView gv, Filter filter)
        {
            API.displayAPI("/api/v1/AccountCredit/LoadRequestCredit", gc, gv, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom",filter.DateFrom },
                {"dateTo",filter.DateTo },
                {"status",filter.Status }
            });
            x0a(gv, filter);
        }
    }
    public partial class _x0c
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView, Filter filter)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("PO_NO", "PO #", 1, gridView, MinWidth: 100);
                    DevXSettings.XtraFormatColumn("TOT_AMT", "Amount", 2, gridView, MinWidth: 125);
                    DevXSettings.XtraFormatColumn("RGS_FLL_NM", "Requested By", 3, gridView, MinWidth: 200);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Date Requested", 4, gridView);
                    if (!filter.Status.Equals("0"))
                    {
                        DevXSettings.XtraFormatColumn("UPD_TRN_TS_NM", "Date Approved", 5, gridView);
                    }
                    DevXSettings.XgridColCurrency(new[] { "TOT_AMT" }, gridView);
                    DevXSettings.XgridGeneralSummaryCurrency(new[] { "TOT_AMT" }, gridView);
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
        public class Db
        {
        }
    }
}

/*
        private void btnReqCredit_Click(object sender, EventArgs e)
        {
            int ponum = Classes.Database.getLastID("ESAT131", $"COMP_ID='{Login.compid}' AND CONCAT(BR_CD,GRP_CD,ACT_NO)='{grouptxtacctname.Text}' ", "PO_NO");
            int newponum = ponum + 1;
            string ponumwleadingzero = Classes.HelperFunction.sequencePadding(newponum.ToString(), 8);
            RequestCreditBal reqcrd = new RequestCreditBal();
            reqcrd.Text = ponumwleadingzero;
            reqcrd.ShowDialog(this);
        }
 
        private void btnForApprovalActCred_Click(object sender, EventArgs e)
        {
            Classes.Database.display($"select * FROM functable_PasaCreditsHistory('{Login.compid}','{Login.brcode}','{datefromforapproval.Text}','{datetoforapproval.Text}',0)",gridControl1,gridView1);
        }

        private void btnApprovedAcctCred_Click(object sender, EventArgs e)
        {
            Classes.Database.display($"select * FROM functable_PasaCreditsHistory('{Login.compid}','{Login.brcode}','{datefromapproved.Text}','{datetoapproved.Text}',1)", gridControl1, gridView1);

        }


        private void btnForApprovalActCred_Click(object sender, EventArgs e)
        {
            Classes.Database.display($"select * FROM functable_PasaCreditsHistory('{Login.compid}','{Login.brcode}','{datefromforapproval.Text}','{datetoforapproval.Text}',0)",gridControl1,gridView1);
        }

        private void btnApprovedAcctCred_Click(object sender, EventArgs e)
        {
            Classes.Database.display($"select * FROM functable_PasaCreditsHistory('{Login.compid}','{Login.brcode}','{datefromapproved.Text}','{datetoapproved.Text}',1)", gridControl1, gridView1);

        
     
     
     */
