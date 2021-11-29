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

using static JLIDashboard.TREASURY._x0ah;
using JLIDashboard.Module;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module;
using DevExpress.Utils;

namespace JLIDashboard.TREASURY
{
    public partial class Remittances__ : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        private bool isNew;
        public Remittances__()
        {
            InitializeComponent();
        }

        private void ClaimCommission_Load(object sender, EventArgs e)
        {
            ok = false;
            Timeout.Set(() => this.Invoke(new Action(() => this.loadTableWProgress())), 250);
        }

        public Remittances__ setData()
        {
            this.setInput(null);
            this.inputEnability(false);
            this.fillEncType();
            return this;
        }

        private void fillEncType()
        {
            Database.displaySearchlookupEdit($"SELECT ENC_CD, ENC_NM, ENC_TYP FROM dbo.ftbl_enctyp()", tsenctype, "ENC_NM", "ENC_CD");
            tsenctype.EditValue = null;
        }

        private void loadTableWProgress()
        {
            StaticSettings.showLoading();
            this.loadTable();
            StaticSettings.hideLoading();
        }
        private void loadTable()
        {
            Database.display($"SELECT * FROM dbo.ftbl_enc('{Login.compid}','{Login.brcode}')", gridControl1, gridView1);
            DevXSettings.XgridColsVisible(gridView1, false);
            DevXSettings.XtraFormatColumn("REM_CD", "Code", 0, this.gridView1);
            DevXSettings.XtraFormatColumn("REM_NM", "Remittance Name", 1, this.gridView1);
            DevXSettings.XtraFormatColumn("ENC_NM", "Encashment Type", 2, this.gridView1);
            DevXSettings.XtraFormatColumn("REM_LOGO", "Logo URL", 3, this.gridView1);
            DevXSettings.XtraFormatColumn("REM_TRM", "Terms URL", 4, this.gridView1);
            this.gridView1.BestFitColumns();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null);
            cmsRemBtn0b.Visible = false;// hasSelected;
            cmsRemSep0a.Visible = hasSelected;
        }

        private void inputEnability(bool enable)
        {
            tbremcode.Enabled = enable;
            tbremname.Enabled = enable;
            tsenctype.Enabled = enable;
            tblogourl.Enabled = enable;
            tbtermsurl.Enabled = enable;
            btnsubmit.Enabled = enable;
        }
        private void setInput(DataRow row)
        {
            bool isNull = (row == null);
            this.isNew = isNull;
            tbremcode.Text = (isNull ? "" : row["REM_CD"].Str());
            tbremname.Text = (isNull ? "" : row["REM_NM"].Str());
            tsenctype.EditValue = (isNull ? "" : row["ENC_CD"].Str());
            tblogourl.Text = (isNull ? "" : row["REM_LOGO"].Str());
            tbtermsurl.Text = (isNull ? "" : row["REM_TRM"].Str());
        }
        private Remittances__ retData(DataRow row)
        {
            row["REM_CD"] = form.RemittanceCode;
            row["REM_NM"] = form.RemittanceName;
            row["ENC_CD"] = form.EncashmentTypeID;
            row["REM_LOGO"] = form.LogoUrl;
            row["REM_TRM"] = form.TermsUrl;
            return this;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = (isNew ? Db.execute0a(form) : Db.execute0b(form)).Result;
            if (res.result == Results.Success)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                if (isNew) this.loadTableWProgress();
                else
                {
                    DataRow row = gridView1.GetFocusedDataRow();
                    this.retData(row);
                    gridView1.RefreshRow(gridView1.FocusedRowHandle);
                }
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
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.setInput(null);
            this.inputEnability(false);
            btnnew.Visible = true;
            btnsubmit.Visible = btncancel.Visible = false;
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            this.setInput(null);
            this.inputEnability(true);
            btnsubmit.Text = "Save";
            btnsubmit.Visible = btncancel.Visible = true;
            btnnew.Visible = false;
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
            DataRow row = gridView1.GetFocusedDataRow();
            form.RemittanceID = row["REM_ID"].Str();
            this.setInput(row);
            this.inputEnability(true);
            btnsubmit.Text = "Save Changes";
            btnsubmit.Visible = btncancel.Visible = true;
            btnnew.Visible = false;
        }
    }

    public partial class _x0ah
    {
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
                dynamic result = Database.DSpQuery<dynamic>("dbo.spfunc_042RS0RT9O", new Dictionary<string, object>(){
                    { "parmcompid", Login.compid },
                    { "parmbrcd", Login.brcode },
                    { "parmoptrid", Login.userid },
                    { "parmremitid", input.RemittanceID },
                    { "parmremitcd", input.RemittanceCode },
                    { "parmremitnm", input.RemittanceName },
                    { "parmenctyp", input.EncashmentTypeID },
                    { "parmlogourl", input.LogoUrl },
                    { "parmtermsurl", input.TermsUrl },
                    { "parmcd", (!IsUpdate?"1":"3") },
                }).FirstOrDefault();
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["RESULT"].Str();
                    if (ResultCode == "1")
                        return (Results.Success, "Successfully save!");
                    return (Results.Failed, "Somethings wrong in your data. Please try again");
                }
                return (Results.Null, null);
            }
        }
    }
}