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

using static JLIDashboard.ACCOUNTS._x0j;
using static JLIDashboard.ACCOUNTS._x0j.Vyw;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using JLIDashboard._Module;
using DevExpress.Utils;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard.ACCOUNTS.frm;
using AbacosDashboard.Module.Enum;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTS
{
    public partial class Subscribers : DevExpress.XtraEditors.XtraForm
    {
        public Subscribers()
        {
            InitializeComponent();
        }
        private void Subscribers_Load(object sender, EventArgs e)
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

        private void loadGenCoord(bool defFocused = true)
        {
            API.displayAPIParam($"/api/v1/Subscribers/LoadGenCoord?subscribetype=1", gridControl1, gridView1, Login.authentication);
            if (x0a(gridView1).RowCount != 0 && defFocused)
            {
                this.gridView1.FocusedRowHandle = 0;
                this.loadCoord();
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
            var row = gridView1.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<GenCoordEntry>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            var focusedrow = gridView1.FocusedRowHandle;
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
        private void loadCoord(bool defFocused = true)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (row == null) return;
            API.displayAPIParam($"/api/v1/Subscribers/LoadCoord?subscriberid={row["SUBSCR_ID"].Str()}", gridControl2, gridView2, Login.authentication);
            gridView3.Columns.Clear();
            gridControl3.DataSource = null;
            int count = x0b(gridView2).RowCount;
            if (count != 0 && defFocused)
            {
                this.gridView2.FocusedRowHandle = 0;
                this.loadPlayer();
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
            cmsCoordBtn0i.Visible = hasSelected;
            cmsCoordBtn0j.Visible = hasSelected;
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
            var row = gridView2.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<CoordEntry>().setData(row, true);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            var focusedrow = gridView2.FocusedRowHandle;
            frm.retData(row);
            gridView2.RefreshRow(focusedrow);
        }

        private void cmsCoordBtn0d_Click(object sender, EventArgs e)
        {
            this.PromotedCoordinator(gridView2, gridView1);
        }

        private void cmsCoordBtn0e_Click(object sender, EventArgs e)
        {
            var row = gridView2.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<TransferPlayer>().setData(row, true);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            this.loadCoord();
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
            var row = gridView2.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<TransferCoordinator>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            var frc = gridView1.FocusedRowHandle;
            var rc = gridView1.GetFocusedDataRow();
            var focusedrow = gridView2.FocusedRowHandle;
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
        private void cmsCoordBtn0j_Click(object sender, EventArgs e)
        {
            var row = gridView2.GetFocusedDataRow();
            if (row == null) return;
            string actId = row["ACT_ID"].Str();
            if (actId.IsEmpty())
            {
                StaticSettings.XtraMessage("Please select coordinator.", MessageBoxIcon.Hand);
                return;
            }
            int count = (int)row["TTL_USR"].Str().ToDecimalDouble();
            if (count > 0)
            {
                StaticSettings.XtraMessage("Cannot promote account. this account has player(s).\nPlease transfer all players under this account and try again", MessageBoxIcon.Hand);
                return;
            }
            var frm = Application.OpenForms.Singleton<TransferToPlayer>().setData(row, true);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            var focusedrow = gridView2.FocusedRowHandle;
            var rc = gridView1.GetFocusedDataRow();
            gridView2.DeleteRow(focusedrow);
            rc["TTL_USR"] = (rc["TTL_USR"].To<Int64>() - 1);
            var rc1 = gridView2.Select($"ACT_ID='{ frm.form.CoordinatorID }'").FirstOrDefault();
            if (rc1 != null) rc1["TTL_USR"] = (rc1["TTL_USR"].To<Int64>() + 1);
            if (gridView3.RowCount == 0) this.loadPlayer();
            gridView2.RefreshData();
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
            var row = gridView3.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<PlayerEntry>().setData(row, true);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            var focusedrow = gridView3.FocusedRowHandle;
            frm.retData(row);
            gridView3.RefreshRow(focusedrow);
        }

        private void cmsPlayerBtn0c_Click(object sender, EventArgs e)
        {
            var row = gridView3.GetFocusedDataRow();
            var frm = Application.OpenForms.Singleton<TransferPlayer>().setData(row);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            var frc = gridView2.FocusedRowHandle;
            var rc = gridView2.GetFocusedDataRow();
            var focusedrow = gridView3.FocusedRowHandle;
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

        private void cmsPlayerBtn0h_Click(object sender, EventArgs e)
        {
            var row = gridView3.GetFocusedDataRow();
            if (row == null) return;
            var frm = Application.OpenForms.Singleton<PromotePlayer>().setData(row, true);
            frm.ShowDialog(this);
            if (!frm.ok) return;
            var focusedrow = gridView3.FocusedRowHandle;
            var rc = gridView2.GetFocusedDataRow();
            var rc1 = gridView1.GetFocusedDataRow();
            if (rc1["ACT_ID"].Str().Equals(frm.form.GeneralCoordinatorID))
            {
                this.loadCoord(false);
                var rc2 = gridView2.Select($"ACT_ID='{ rc["ACT_ID"].Str() }'").FirstOrDefault();
                if (rc2 != null)
                {
                    gridView2.SetFocusedDataRow(rc2);
                    this.loadPlayer();
                }
                return;
            }
            else
            {
                gridView3.DeleteRow(focusedrow);
                rc["TTL_USR"] = (rc["TTL_USR"].To<Int64>() - 1);
                var rc2 = gridView1.Select($"ACT_ID='{ frm.form.GeneralCoordinatorID }'").FirstOrDefault();
                if (rc2 != null) rc2["TTL_USR"] = (rc2["TTL_USR"].To<Int64>() + 1);
                gridView1.RefreshData();
            }
        }

        #endregion
        private void loadPlayer(bool defFocused = true)
        {
            DataRow row = gridView2.GetFocusedDataRow();
            if (row == null) return;
            API.displayAPIParam($"/api/v1/Subscribers/LoadPlayer?subscriberid={row["SUBSCR_ID"].Str()}", gridControl3, gridView3, Login.authentication);
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
            if (count > 0)
            {
                StaticSettings.XtraMessage("Cannot promote account. this account has player(s).\nPlease transfer all players under this account and try again", MessageBoxIcon.Hand);
                return;
            }
            if (XtraMessageBox.Show("Are you sure you want to promote '" + row["FLL_NM"].Str() + "' as General Coordinator?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            if (XtraMessageBox.Show("Are you sure you want to " + msg.ToLower() + " " + title + "?", msg + ": " + row["FLL_NM"].Str(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabMain.SelectedTabPage == tabAccnt2)
            {
                bool isReady = this.isAllCustomerReady;
                this.isAllCustomerReady = true;
                if (isReady) return;
                StaticSettings.showLoading();
                this.loadCustomers();
                StaticSettings.hideLoading();
            }
        }


        #region Customers
        private bool isAllCustomerReady = false;
        private void loadCustomers()
        {
            API.displayAPIParam("/api/v1/Subscribers/LoadCustomers", gridControl4, gridView4, Login.authentication);
            x0d(gridView4).FocusedRowHandle = 0;
        }

        private void cmsSubscrBtn0a_Click(object sender, EventArgs e)
        {
            StaticSettings.showLoading();
            this.loadCustomers();
            StaticSettings.hideLoading();
        }

        private void cmsSubscrBtn0b_Click(object sender, EventArgs e)
        {
            DataRow row = gridView4.GetFocusedDataRow();
            this.BlockCustomer(gridView4, row["USR_TYP_NM"].Str());
        }

        private void cmsSubscrBtn0c_Click(object sender, EventArgs e)
        {
            this.ResetCustomerPassword(gridView4);
        }

        private void cmsSubscrBtn0d_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView4.FocusedRowHandle;
            DataRow row = gridView4.GetFocusedDataRow();
            int type = (int)row["USR_TYP"].Str().ToDecimalDouble();
            GridView gridView = null;
            if (type == 1)
            {
                var frm = Application.OpenForms.Singleton<GenCoordEntry>().setData(row);
                frm.ShowDialog(this);
                if (!frm.ok) return;
                frm.retData(row);
                this.loadGenCoord();
            }
            else if (type == 2)
            {
                var frm = Application.OpenForms.Singleton<CoordEntry>().setData(row, true);
                frm.ShowDialog(this);
                if (!frm.ok) return;
                frm.retData(row);
                this.loadCoord();
            }
            else if (type == 3)
            {
                var frm = Application.OpenForms.Singleton<PlayerEntry>().setData(row, true);
                frm.ShowDialog(this);
                if (!frm.ok) return;
                frm.retData(row);
                this.loadPlayer();
            }
            else return;
            gridView4.RefreshRow(focusedrow);
        }
        #endregion

        private void gridView4_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView pGridView = null, cGridView = gridView4;
            bool hasRows = (cGridView.RowCount != 0);
            DataRow row = cGridView.GetFocusedDataRow();
            bool hasSelected = (row != null);
            cmsSubscrBtn0e.Visible = hasRows;
            cmsSubscrSep0a.Visible = hasSelected;
            cmsSubscrBtn0b.Visible = hasSelected;
            cmsSubscrBtn0c.Visible = hasSelected;
            cmsSubscrBtn0d.Visible = hasSelected;
            if (!hasSelected) return;
            cmsSubscrBtn0b.Text = (row["S_BLCK"].To<bool>(false) ? "Unblock" : "Block") + "ed User";
        }

        private void cmsSubscrBtn0e_Click(object sender, EventArgs e)
        {
            HelperFunction.ExportToExcelAndSaveDialog(saveFileDialog1, gridView4);
        }
    }

    public class _x0j
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
            public static GridView x0d(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("S_BLCK", "Block", 1, gridView, MaxWidth: 35);
                    DevXSettings.XtraFormatColumn("ACT_ID", "Account ID", 2, gridView);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 3, gridView, 120);
                    DevXSettings.XtraFormatColumn("MOB_NO", "Mobile Number", 4, gridView);
                    DevXSettings.XtraFormatColumn("ACT_CRDT_BAL", "Credit", 5, gridView);
                    DevXSettings.XtraFormatColumn("ACT_COM_BAL", "Commission", 6, gridView);
                    DevXSettings.XtraFormatColumn("COM_RT", "Comm.(%)", 7, gridView);
                    DevXSettings.XtraFormatColumn("S_RSLR", "Reseller", 8, gridView, MaxWidth: 55);
                    DevXSettings.XtraFormatColumn("SRIAL_ID", "Terminal", 9, gridView);
                    DevXSettings.XtraFormatColumn("REF_USR_NM", "General Coordinator", 10, gridView);
                    DevXSettings.XtraFormatColumn("REF_USR_NM2", "Coordinator", 11, gridView);
                    DevXSettings.XtraFormatColumn("USR_TYP_NM", "Account Type", 12, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Date Registered", 13, gridView);
                    DevXSettings.XgridColAlign(new string[] { "SRIAL_ID", "REF_USR_NM", "REF_USR_NM", "REF_USR_NM2", "USR_TYP_NM", "RGS_TRN_TS_NM" }, gridView, HorzAlignment.Center);
                    DevXSettings.XgridColCurrency(new string[] { "ACT_CRDT_BAL", "ACT_COM_BAL" }, gridView);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "ACT_CRDT_BAL", "ACT_COM_BAL" }, gridView);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
        }
        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(String AccountID)
            {
                var result = API.DSpQueryAPIParam($"/api/v1/Subscribers/BlockCustomer?accountid={AccountID}", Login.authentication);
                if (result != null)
                {

                    var ResultCode = result["result"].Str();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, result["message"].Str());
                    }
                    return (Results.Success, result["message"].Str());
                }
                return (Results.Null, null);
            }
            public static async Task<(Results result, String message)> execute0b(String AccountID)
            {
                var result = API.DSpQueryAPIParam($"/api/v1/Coordinator/PromotedCoordinator?accountid={AccountID}", Login.authentication);
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, row["message"].Str());
                    else if (ResultCode == "1")
                        return (Results.Failed, row["message"].Str());
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}
