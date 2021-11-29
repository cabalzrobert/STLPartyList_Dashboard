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

using static JLIDashboard.ACCOUNTS._x0i;
using static JLIDashboard.ACCOUNTS._x0i.Vyw;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard.ACCOUNTS.frm;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using JLIDashboard.Module;
using Comm.Common.Extensions;
using AbacosDashboard.Module.Enum;
using JLIDashboard._Module;
using DevExpress.Utils;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTS
{
    public partial class UserAccounts : DevExpress.XtraEditors.XtraForm
    {
        public UserAccounts()
        {
            InitializeComponent();
        }

        private void UserAccounts_Load(object sender, EventArgs e)
        {
            Timeout.Set(() => this.Invoke(new Action(() => this.loadGenCoord())), 250);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.loadCoord();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.loadPlayer();
        }

        #region General Coordinator

        private void loadGenCoord()
        {
            API.displayAPI("/api/v1/Subscribers/LoadGenCoord", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"subscribetype","1" }
            });
            if (x0a(gridView1).RowCount != 0)
            {
                this.gridView1.FocusedRowHandle = 0;
                this.gridView1_RowClick(this.gridView1, null);
            }
        }
        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView pGridView = null, cGridView = gridView1;
            bool hasRows = (cGridView.RowCount != 0);
            DataRow row = cGridView.GetFocusedDataRow();
            bool hasSelected = (row != null);
            //bool hasDownline = (!hasSelected ? false : row["TTL_USR"].Str().ToDecimalDouble() != 0);
            cmsGenCoordBtn0a.Visible = true;
            cmsGenCoordBtn0b.Visible = true;
            cmsGenCoordBtn0g.Visible = true;
            cmsGenCoordSep0b.Visible = true;
            //
            cmsGenCoordBtn0c.Visible = hasSelected;
            cmsGenCoordBtn0d.Visible = hasSelected;
            cmsGenCoordBtn0f.Visible = hasSelected;
            cmsGenCoordSep0a.Visible = hasSelected;
            //
            if (!hasSelected) return;
            cmsGenCoordBtn0f.Text = (row["S_BLCK"].To<bool>(false) ? "Unblock" : "Block") + "ed User";
        }
        private void cmsGenCoordBtn0a_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms.Singleton<InviteGenCoord>();
            frm.ShowDialog(this);
        }

        private void cmsGenCoordBtn0b_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms.Singleton<GenCoordEntry>();
            frm.ShowDialog(this);
            if (!frm.ok) return;
            this.loadGenCoord();
        }

        private void cmsGenCoordBtn0c_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.FocusedRowHandle;
            var row = gridView1.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<GenCoordEntry>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            frm.retData(row);
            gridView1.RefreshRow(focusedrow);
        }

        private void cmsGenCoordBtn0d_Click(object sender, EventArgs e)
        {
            this.ResetCustomerPassword(gridView1);
        }

        private void cmsGenCoordBtn0f_Click(object sender, EventArgs e)
        {
            this.BlockCustomer(gridView1, "General Coordinator");
        }

        private void cmsGenCoordBtn0g_Click(object sender, EventArgs e)
        {
            StaticSettings.showLoading();
            this.loadGenCoord();
            StaticSettings.hideLoading();
        }


        #endregion

        #region Coordinator
        private void loadCoord()
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row == null) return; 
            API.displayAPI("/api/v1/Subscribers/LoadCoord", gridControl2, gridView2, Login.authentication, new Dictionary<string, object>()
            {
                {"compID",Login.plid },
                {"branchID",Login.pgrpid },
                {"userid",row["SUBSCR_ID"].Str() }
            });
            gridView3.Columns.Clear();
            gridControl3.DataSource = null;
            int count = x0b(gridView2).RowCount;
            if (count != 0)
            {
                this.gridView2.FocusedRowHandle = 0;
                this.gridView2_RowClick(this.gridView2, null);
            }
            row["TTL_USR"] = count;
            gridView1.RefreshRow(gridView1.FocusedRowHandle);
        }
        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView pGridView = gridView1, cGridView = gridView2;
            bool hasParent = (pGridView.RowCount != 0);
            bool hasRows = (cGridView.RowCount != 0);
            DataRow row = cGridView.GetFocusedDataRow();
            bool hasSelected = (row != null);
            bool hasDownline = (!hasSelected ? false : row["TTL_USR"].Str().ToDecimalDouble() != 0);
            cmsCoordBtn0a.Visible = hasParent;
            cmsCoordBtn0b.Visible = hasParent;
            cmsCoordBtn0h.Visible = hasParent;
            cmsCoordSep0b.Visible = hasParent;
            //
            cmsCoordBtn0c.Visible = hasSelected;
            cmsCoordBtn0d.Visible = hasSelected;
            cmsCoordBtn0e.Visible = hasDownline; //cmsCoordBtn0e
            cmsCoordBtn0f.Visible = hasSelected;
            cmsCoordBtn0g.Visible = hasSelected;
            cmsCoordSep0a.Visible = hasSelected;
            //
            if (!hasSelected) return;
            cmsCoordBtn0g.Text = (row["S_BLCK"].To<bool>(false) ? "Unblock" : "Block") + "ed User";
        }
        private void cmsCoordBtn0a_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row == null) return;
            var frm = Application.OpenForms.Singleton<InviteCoord>().setData(row);
            frm.ShowDialog(this);
        }

        private void cmsCoordBtn0b_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<CoordEntry>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            this.loadCoord();
        }

        private void cmsCoordBtn0c_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView2.FocusedRowHandle;
            var row = gridView2.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<CoordEntry>().setData(row, true);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            frm.retData(row);
            gridView2.RefreshRow(focusedrow);
        }

        private void cmsCoordBtn0d_Click(object sender, EventArgs e)
        {
            this.PromotedCoordinator(gridView2, gridView1);
        }

        private void cmsCoordBtn0e_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView2.FocusedRowHandle;
            var row = gridView2.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<TransferPlayer>().setData(row, true);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            this.loadCoord();
            //row["TTL_USR"] = 0;
            //gridView2.RefreshRow(focusedrow);
            //gridControl3.DataSource = null;
        }

        private void cmsCoordBtn0f_Click(object sender, EventArgs e)
        {
            this.ResetCustomerPassword(gridView2);
        }

        private void cmsCoordBtn0g_Click(object sender, EventArgs e)
        {
            this.BlockCustomer(gridView2, "Coordinator");
        }

        private void cmsCoordBtn0h_Click(object sender, EventArgs e)
        {
            StaticSettings.showLoading();
            this.loadCoord();
            StaticSettings.hideLoading();
        }
        private void cmsCoordBtn0i_Click(object sender, EventArgs e)
        {
            var frc = gridView1.FocusedRowHandle;
            var rc = gridView1.GetFocusedDataRow();
            var focusedrow = gridView2.FocusedRowHandle;
            var row = gridView2.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<TransferCoordinator>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            gridView2.DeleteRow(focusedrow);
            if (gridView2.RowCount != 0)
                gridView2.FocusedRowHandle = 0;
            else
            {
                gridView3.Columns.Clear();
                gridControl3.DataSource = null;
            }
            rc["TTL_USR"] = (rc["TTL_USR"].To<Int64>() - 1);
            var rc1 = gridView1.Select($"ACT_ID='{ frm.form.GeneralCoordinatorID }'").FirstOrDefault();
            if (rc1 != null) rc1["TTL_USR"] = (rc1["TTL_USR"].To<Int64>() + 1);
            gridView1.RefreshData();
        }
        #endregion

        #region Player
        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView pGridView = gridView2, cGridView = gridView3;
            bool hasParent = (pGridView.RowCount != 0);
            bool hasRows = (cGridView.RowCount != 0);
            DataRow row = cGridView.GetFocusedDataRow();
            bool hasSelected = (row != null);
            cmsPlayerBtn0a.Visible = hasParent;
            cmsPlayerBtn0d.Visible = hasParent;
            cmsPlayerBtn0b.Visible = hasParent;
            cmsPlayerSep0b.Visible = hasParent;
            //
            cmsPlayerBtn0c.Visible = hasSelected;
            cmsPlayerSep0a.Visible = hasSelected;
            cmsPlayerBtn0e.Visible = hasSelected;
            cmsPlayerBtn0f.Visible = hasSelected;
            cmsPlayerBtn0g.Visible = hasSelected;
            //
            if (!hasSelected) return;
            cmsPlayerBtn0g.Text = (row["S_BLCK"].To<bool>(false) ? "Unblock" : "Block") + "ed User";
        }
        private void cmsPlayerBtn0a_Click(object sender, EventArgs e)
        {
            DataRow row = gridView2.GetFocusedDataRow();
            if (row == null) return;
            var frm = Application.OpenForms.Singleton<InvitePlayer>().setData(row);
            frm.ShowDialog(this);
        }

        private void cmsPlayerBtn0b_Click(object sender, EventArgs e)
        {
            var row = gridView2.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<PlayerEntry>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            this.loadPlayer();
        }

        private void cmsPlayerBtn0e_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView3.FocusedRowHandle;
            var row = gridView3.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<PlayerEntry>().setData(row, true);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            frm.retData(row);
            gridView3.RefreshRow(focusedrow);
        }

        private void cmsPlayerBtn0c_Click(object sender, EventArgs e)
        {
            var frc = gridView2.FocusedRowHandle;
            var rc = gridView2.GetFocusedDataRow();
            var focusedrow = gridView3.FocusedRowHandle;
            var row = gridView3.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<TransferPlayer>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            gridView3.DeleteRow(focusedrow);
            if (gridView3.RowCount != 0)
                gridView3.FocusedRowHandle = 0;
            rc["TTL_USR"] = (rc["TTL_USR"].To<Int64>() - 1);
            var rc1 = gridView2.Select($"ACT_ID='{ frm.form.CoordinatorID }'").FirstOrDefault();
            if (rc1 != null) rc1["TTL_USR"] = (rc1["TTL_USR"].To<Int64>() + 1);
            gridView2.RefreshData();
        }

        private void cmsPlayerBtn0d_Click(object sender, EventArgs e)
        {
            StaticSettings.showLoading();
            this.loadPlayer();
            StaticSettings.hideLoading();
        }
        private void cmsPlayerBtn0f_Click(object sender, EventArgs e)
        {
            this.ResetCustomerPassword(gridView3);
        }

        private void cmsPlayerBtn0g_Click(object sender, EventArgs e)
        {
            this.BlockCustomer(gridView3, "Player");
        }

        #endregion
        private void loadPlayer()
        {
            DataRow row = gridView2.GetFocusedDataRow();
            if (row == null) return;
            API.displayAPI("/api/v1/Subscribers/LoadCoord", gridControl2, gridView2, Login.authentication, new Dictionary<string, object>()
            {
                {"compID",Login.plid },
                {"branchID",Login.pgrpid },
                {"userid",row["SUBSCR_ID"].Str() }
            });
            int count = x0c(gridView3).RowCount;
            row["TTL_USR"] = count;
            gridView2.RefreshRow(gridView2.FocusedRowHandle);
        }


        #region Customer
        private void PromotedCoordinator(GridView gridView, GridView gridViewParent)
        {
            DataRow row = gridView.GetFocusedDataRow();
            if (row == null) return;
            var focusedrow = gridViewParent.FocusedRowHandle;
            string actId = row["ACT_ID"].Str();
            if (actId.IsEmpty())
            {
                StaticSettings.XtraMessage("Please select coordinator.", MessageBoxIcon.Hand);
                return;
            }
            int count = (int)row["TTL_USR"].Str().ToDecimalDouble();
            if (count>0)
            {
                StaticSettings.XtraMessage("Cannot promote account. this account has player(s).\nPlease transfer all players under this account and try again", MessageBoxIcon.Hand);
                return;
            }
            if (XtraMessageBox.Show("Are you sure you want to promote " + row["FLL_NM"].Str() + "?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StaticSettings.showLoading();
                var res = Db.execute0b(actId).Result;
                if (res.result == Results.Success)
                {
                    gridView.DeleteRow(gridView.FocusedRowHandle);
                    StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                    this.loadGenCoord();
                    //gridViewParent.FocusedRowHandle = focusedrow;
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
        }
        private void BlockCustomer(GridView gridView, string title)
        {
            DataRow row = gridView.GetFocusedDataRow();
            if (row == null) return;
            var focusedrow = gridView.FocusedRowHandle;
            bool blocked = row["S_BLCK"].To<bool>(false); 
            string msg = (blocked ? "Unblock" : "Block");
            if (XtraMessageBox.Show("Are you sure you want to " + msg.ToLower() + " "+ title + "?", msg + ": " + row["FLL_NM"].Str(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StaticSettings.showLoading();
                string actId = row["ACT_ID"].Str();
                var res = Db.execute0a(actId).Result;
                if (res.result == Results.Success)
                {
                    row["S_BLCK"] = !blocked;
                    gridView.RefreshRow(focusedrow);
                    StaticSettings.XtraMessage(title + " successfully " + msg.ToLower() + "ed", MessageBoxIcon.Asterisk);
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
        }
        private void ResetCustomerPassword(GridView gridView)
        {
            DataRow row = gridView.GetFocusedDataRow();
            if (row == null) return;
            var win = Application.OpenForms.Singleton<ResetPassword>().setData(row);
            win.ShowDialog();
        }
        #endregion

    }



    public class _x0i
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("S_BLCK", "Block", 1, gridView, MaxWidth: 35);
                    DevXSettings.XtraFormatColumn("ACT_ID", "Account ID", 2, gridView);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 3, gridView, 120);
                    DevXSettings.XtraFormatColumn("COM_RT", "Shared", 4, gridView);
                    DevXSettings.XtraFormatColumn("ACT_CRDT_BAL", "Credit", 5, gridView);
                    DevXSettings.XtraFormatColumn("ACT_COM_BAL", "Commission", 6, gridView);
                    DevXSettings.XtraFormatColumn("TTL_USR", "Coordinator(s)", 7, gridView);
                    DevXSettings.XgridColCurrency(new string[] { "ACT_CRDT_BAL", "ACT_COM_BAL" }, gridView);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "ACT_CRDT_BAL", "ACT_COM_BAL" }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "TTL_USR", "COM_RT" }, gridView, HorzAlignment.Center);
                    DevXSettings.XgridGeneralSummaryNumber(new string[] { "TTL_USR" }, gridView);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static GridView x0b(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("S_BLCK", "Block", 1, gridView, MaxWidth: 35);
                    DevXSettings.XtraFormatColumn("ACT_ID", "Account ID", 2, gridView);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 3, gridView, 120);
                    DevXSettings.XtraFormatColumn("COM_RT", "Shared", 4, gridView);
                    DevXSettings.XtraFormatColumn("ACT_CRDT_BAL", "Credit", 5, gridView);
                    DevXSettings.XtraFormatColumn("ACT_COM_BAL", "Commission", 6, gridView);
                    DevXSettings.XtraFormatColumn("TTL_USR", "Player(s)", 7, gridView);
                    DevXSettings.XgridColCurrency(new string[] { "ACT_CRDT_BAL", "ACT_COM_BAL" }, gridView);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "ACT_CRDT_BAL", "ACT_COM_BAL" }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "TTL_USR", "COM_RT" }, gridView, HorzAlignment.Center);
                    DevXSettings.XgridGeneralSummaryNumber(new string[] { "TTL_USR" }, gridView);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static GridView x0c(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("S_BLCK", "Block", 1, gridView, MaxWidth: 35);
                    DevXSettings.XtraFormatColumn("ACT_ID", "Account ID", 2, gridView);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 3, gridView, 120);
                    DevXSettings.XtraFormatColumn("MOB_NO", "Mobile Number", 4, gridView);
                    DevXSettings.XtraFormatColumn("ACT_CRDT_BAL", "Credit", 5, gridView);
                    DevXSettings.XgridColCurrency(new string[] { "ACT_CRDT_BAL" }, gridView);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "ACT_CRDT_BAL" }, gridView);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
        }
        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(String AccountID)
            {
                var result = API.DSpQueryAPIParam($"/api/v1/Subscribers/PromoteCustomer?accountid={AccountID}", Login.authentication);
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["RESULT"].Str();
                    if (ResultCode == "1")
                    {
                        if (row["S_BLCK"].Str().Equals("1"))
                        {
                            if (row["HS_USR"].Str().Equals("1"))
                            {
                                await Pusher.PushAsync($"/{Login.plid}/{Login.pgrpid}/{row["SUBSCR_ID"]}/downline"
                                    , new { type = "device.session-end", message = "Your session has been expired! Your upline blocked by admin", });
                            }
                            await Pusher.PushAsync($"/{Login.plid}/{Login.pgrpid}/{row["CUST_ID"]}/notify"
                                , new { type = "device.session-end", message = "Your session has been expired! Your account has blocked by admin", });
                        }
                        return (Results.Success, "Successfully save!");
                    }
                    return (Results.Failed, "Somethings wrong in your data. Please try again");
                }
                return (Results.Null, null);
            }
            public static async Task<(Results result, String message)> execute0b(String AccountID)
            {
                var result = API.DSpQueryAPIParam($"/api/v1/Coordinator/PromotedCoordinator?accountid={AccountID}", Login.authentication);
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["RESULT"].Str();
                    if (ResultCode == "1")
                        return (Results.Success, "Successfully promoted!");
                    else if (ResultCode == "2")
                        return (Results.Failed, "Cannot promote account due to invalid user type.");
                    else if (ResultCode == "3")
                        return (Results.Failed, "Cannot promote account. this account has player(s).\nPlease transfer all players under this account and try again");
                    return (Results.Failed, "Somethings wrong in your data. Please try again");
                }
                return (Results.Null, null);
            }
        }
    }
}