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

using static JLIDashboard.ACCOUNTS.frm._x0h;
using static JLIDashboard.ACCOUNTS.frm._x0h.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using Comm.Common.Extensions;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTS.frm
{
    public partial class TransferPlayer : DevExpress.XtraEditors.XtraForm
    {
        public bool isAll;
        public bool ok;
        public TransferPlayer()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public TransferPlayer setData(DataRow row, bool isAll = false)
        {
            this.isAll = isAll;
            if (!this.isAll) this.Text = "TRANSFER PLAYER: " + row["FLL_NM"].Str();
            else this.Text = "TRANSFER ALL PLAYER UNDER: " + row["FLL_NM"].Str();
            form.AccountID = row["ACT_ID"].Str();
            form.GeneralCoordinatorID = row["REF_USR_ID"].Str();
            form.CoordinatorID = (this.isAll ? row["ACT_ID"].Str() : row["REF_USR_ID2"].Str());
            this.fillGenCoord(form.GeneralCoordinatorID);
            return this;
        }


        private void fillGenCoord(string genCoordId)
        {
            API.displaySearchLookupEditAPI("/api/v1/PlayerAccount/LoadGenCoord", Login.authentication, tsgencoord, "ACT_NM", "ACT_ID", new Dictionary<string, object>()
            {
                {"subscribetype","1" }
            });
            x0a(tsgencoord);
            if (genCoordId.IsEmpty()) return;
            DataRow row = tsgencoord.Select($"SUBSCR_ID='{genCoordId}' OR ACT_ID='{genCoordId}'").FirstOrDefault();
            if (row == null) return;
            tsgencoord.EditValue = row["ACT_ID"].Str();
        }
        private void fillCoord(string coordId)
        {
            if (tsgencoord.Text.IsEmpty())
            {
                tscoord.Properties.DataSource = null;
                return;
            }
            DataRow rgc = tsgencoord.GetFocusedDataRow();
            API.displaySearchLookupEditAPI("/api/v1/PlayerAccount/LoadCoord", Login.authentication, tscoord, "ACT_NM", "ACT_ID", new Dictionary<string, object>()
            {
                {"subscribetype","2" },
                {"subscribeID", rgc["SUBSCR_ID"].Str() }
            });
            x0a(tscoord);
            if (coordId.IsEmpty()) return;
            DataRow row = tscoord.Select($"SUBSCR_ID='{coordId}' OR ACT_ID='{coordId}'").FirstOrDefault();
            if (row == null) return;
            tscoord.EditValue = row["ACT_ID"].Str();
        }
        private void tsgencoord_EditValueChanged(object sender, EventArgs e)
        {
            this.fillCoord(form.CoordinatorID);
        }
        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = (!this.isAll ? Db.execute0a(form) : Db.execute0b(form)).Result;
            if (res.result == Results.Success)
            {
                this.ok = true;
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
            StaticSettings.hideLoading();
        }

        public Input form = new Input();
        private bool ValidateEntries()
        {
            string gencoordinator = tsgencoord.Text.Str();
            if (gencoordinator.IsEmpty())
            {
                StaticSettings.XtraMessage("General Coordinator is required", MessageBoxIcon.Exclamation);
                return false;
            }
            string coordinator = tscoord.Text.Str();
            if (coordinator.IsEmpty())
            {
                StaticSettings.XtraMessage("Coordinator is required", MessageBoxIcon.Exclamation);
                return false;
            }

            form.GeneralCoordinatorID = tsgencoord.EditValue.Str();
            form.CoordinatorID = tscoord.EditValue.Str();
            return true;
        }

    }

    public partial class _x0h
    {
        public class Vyw
        {
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("ACT_ID", "Account#", 0, gridView, MaxWidth:150);
                DevXSettings.XtraFormatColumn("ACT_NM", "Name", 1, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string GeneralCoordinatorID;
            public string CoordinatorID;
            public string AccountID;
        }

        public class Db
        {

            public static async Task<(Results result, String message)> execute0a(Input input) //player
            {
                var result = API.DSpQueryAPI("/api/v1/PlayerAccount/SaveTransferPlayer", Login.authentication, new Dictionary<string, object>(){
                    { "accountID", input.AccountID },
                    { "manageractid", input.GeneralCoordinatorID },
                    { "supervisoractid", input.CoordinatorID },
                });
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
            public static async Task<(Results result, String message)> execute0b(Input input)//coordinator
            {
                var result = API.DSpQueryAPI("/api/v1/PlayerAccount/SaveTransferPlayer", Login.authentication, new Dictionary<string, object>(){
                    { "accountID", input.AccountID },
                    { "manageractid", input.GeneralCoordinatorID },
                    { "supervisoractid", input.CoordinatorID },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, row["message"].Str());
                    else if (ResultCode == "1")
                        return (Results.Failed, row["message"].Str());
                    return (Results.Failed, row["result"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}