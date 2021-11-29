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

using static JLIDashboard.TREASURY._x0h;
using static JLIDashboard.TREASURY._x0h.Vyw;
using JLIDashboard.Module;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.TREASURY
{
    public partial class RemittanceEntry : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        private bool isEdit;
        public RemittanceEntry()
        {
            InitializeComponent();
        }

        private void RemittanceEntry_Load(object sender, EventArgs e)
        {
            ok = false;
            this.Text = "Remittance - " + (!this.isEdit ? "New" : "Edit");
        }

        public RemittanceEntry setData(DataRow row, bool isEdit = false)
        {
            this.isEdit = isEdit;
            this.fillEncType();
            this.setInput(row);
            if (this.isEdit)
            {
                form.RemittanceID = row["REM_ID"].Str();
            }
            return this;
        }
        public RemittanceEntry retData(DataRow row)
        {
            row["REM_CD"] = form.RemittanceCode;
            row["REM_NM"] = form.RemittanceName;
            row["ENC_CD"] = form.EncashmentTypeID;
            row["REM_LOGO"] = form.LogoUrl;
            row["REM_TRM"] = form.TermsUrl;
            return this;
        }

        private void fillEncType()
        {
            API.displaySearchLookupEditAPIParam("/api/v1/Remittance/LoadEncashmentType", Login.authentication, tsenctype, "ENC_NM", "ENC_ID");
            x0a(tsenctype);
            tsenctype.EditValue = null;
        }

        private void setInput(DataRow row)
        {
            bool isNull = (row == null);
            tbremcode.Text = (isNull ? "" : row["REM_CD"].Str());
            tbremname.Text = (isNull ? "" : row["REM_NM"].Str());
            tsenctype.EditValue = (isNull ? "" : row["ENC_TYP"].Str());
            tblogourl.Text = (isNull ? "" : row["REM_LOGO"].Str());
            tbtermsurl.Text = (isNull ? "" : row["REM_TRM"].Str());
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = (!this.isEdit ? Db.execute0a(form) : Db.execute0b(form)).Result;
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
            StaticSettings.hideLoading();
        }

        public Input form = new Input();
        private bool ValidateEntries()
        {
            string code = this.tbremcode.Text.Trim();
            if (code.IsEmpty())
            {
                StaticSettings.XtraMessage("Remittance code is required", MessageBoxIcon.Exclamation);
                this.tbremcode.Focus();
                return false;
            }
            string name = this.tbremname.Text.Trim();
            if (name.IsEmpty())
            {
                StaticSettings.XtraMessage("Remittance Name is required", MessageBoxIcon.Exclamation);
                this.tbremname.Focus();
                return false;
            }
            string enchtype = this.tsenctype.Text.Trim();
            if (enchtype.IsEmpty())
            {
                StaticSettings.XtraMessage("Encashment Type is required", MessageBoxIcon.Exclamation);
                this.tsenctype.Focus();
                return false;
            }
            form.RemittanceCode = code;
            form.RemittanceName = name;
            form.EncashmentTypeID = this.tsenctype.EditValue.Str();
            form.LogoUrl = this.tblogourl.Text;
            form.TermsUrl = this.tbtermsurl.Text;
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
                DevXSettings.XtraFormatColumn("ENC_ID", "Code", 0, gridView, MaxWidth: 35);
                //DevXSettings.XtraFormatColumn("ENC_NM", "Game Type", 1, gridView);
                DevXSettings.XtraFormatColumn("ENC_NM", "Encashment Type", 1, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string RemittanceID;
            public string RemittanceCode;
            public string RemittanceName;
            public string EncashmentTypeID;
            public string LogoUrl;
            public string TermsUrl;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                return await _execute0a(input, false);
            }
            public static async Task<(Results result, string message)> execute0b(Input input)
            {
                return await _execute0a(input);
            }
            private static async Task<(Results result, string message)> _execute0a(Input input, bool IsUpdate = true)
            {
                dynamic result = API.DSpQueryAPI("/api/v1/Remittance/UpdateRemittance", Login.authentication, new Dictionary<string, object>(){
                    { "remittanceID", input.RemittanceID },
                    { "remittanceCode", input.RemittanceCode },
                    { "remittanceName", input.RemittanceName },
                    { "encashmentTypeID", input.EncashmentTypeID },
                    { "logoUrl", input.LogoUrl },
                    { "termsUrl", input.TermsUrl },
                    { "isUpdate", (!IsUpdate?"1":"3") },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}