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

using static JLIDashboard.ACCOUNTS.frm._x0f;
using static JLIDashboard.ACCOUNTS.frm._x0f.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using Comm.Common.Extensions;
using JLIDashboard.Classes.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.ACCOUNTS.frm
{
    public partial class InvitePlayer : DevExpress.XtraEditors.XtraForm
    {
        public InvitePlayer()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public InvitePlayer setData(DataRow row)
        {
            form.GeneralCoordinatorID = row["REF_USR_ID"].Str();
            form.CoordinatorID = row["ACT_ID"].Str();
            form.Commission = row["COM_RT"].Str().ToDecimalDouble();
            //
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
            var res = Db.execute0a(form).Result;
            if (res.result == Results.Success)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else if(res.result != Results.Null)
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
            string firstname = tbfirstname.Text.Trim();
            if (firstname.IsEmpty())
            {
                StaticSettings.XtraMessage("Firstname is required", MessageBoxIcon.Exclamation);
                this.tbfirstname.Focus();
                return false;
            }
            string lastname = this.tblastname.Text.Trim();
            if (lastname.IsEmpty())
            {
                StaticSettings.XtraMessage("Lastname is required", MessageBoxIcon.Exclamation);
                this.tblastname.Focus();
                return false;
            }
            string mobilenumber = this.tbmobilenumber.Text.Trim();
            if (mobilenumber.IsEmpty())
            {
                StaticSettings.XtraMessage("Mobile number is required", MessageBoxIcon.Exclamation);
                this.tbmobilenumber.Focus();
                return false;
            }
            form.GeneralCoordinatorID = tsgencoord.EditValue.Str();
            form.CoordinatorID = tscoord.EditValue.Str(); 
            form.Firstname = firstname;
            form.Lastname = lastname;
            form.MobileNumber = mobilenumber;
            return true;
        }
    }

    public partial class _x0f
    {
        public class Vyw
        {
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("ACT_ID", "Account#", 0, gridView, MaxWidth: 150);
                DevXSettings.XtraFormatColumn("ACT_NM", "Name", 1, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string GeneralCoordinatorID;
            public string CoordinatorID;
            public double Commission;
            public string Firstname;
            public string Lastname;
            public string MobileNumber;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/PlayerAccount/UpdatePlayer", Login.authentication, new Dictionary<string, object>(){
                    { "supervisoractid", input.CoordinatorID },
                    { "usrmobno", input.MobileNumber },
                    { "usrfnm", input.Firstname },
                    { "usrlnm", input.Lastname },
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
        }
    }
}