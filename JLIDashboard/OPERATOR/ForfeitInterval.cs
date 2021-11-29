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
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using static JLIDashboard.OPERATOR._forfeit;
using static JLIDashboard.OPERATOR._forfeit.Vyw;
using Comm.Common.Extensions;
using JLIDashboard.Module;
using AbacosDashboard.Module.Enum;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR
{
    public partial class ForfeitInterval : DevExpress.XtraEditors.XtraForm
    {
        private bool isNew;
        public ForfeitInterval()
        {
            InitializeComponent();
        }

        private void ForfeitInterval_Load(object sender, EventArgs e)
        {
            Timeout.Set(() => this.Invoke(new Action(() => this.Load_ForfeitScheduler())), 250);
        }
        public void Load_ForfeitScheduler(bool defFocused = true)
        {
            API.displayAPI("/api/v1/ForfeitInterval/GetForfeitInterval", gridControl1, gridView1, Login.authentication, new Dictionary<string, string>()
            {
                {"parmHandler","1" },
                {"parmintrvlsts","" }
            });
            if (x0a(gridView1).RowCount != 0 && defFocused)
            {
                this.gridView1.FocusedRowHandle = 0;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.isNew = true;
            form.INTRVL_HNDLR = 2;
            enableField(1);

        }
        public Input form = new Input();
        private void enableField(int handler)
        {
            if (handler == 1)
            {
                cbType.Text = "Select Type";
                rdmPrimary.SelectedIndex = -1;
                cbType.ReadOnly = false;
                cbType.Enabled = true;
                tbInterval.Enabled = true;
                rdmPrimary.Enabled = true;
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
            else if (handler == 2)
            {
                rdmPrimary.SelectedIndex = -1;
                cbType.Text = string.Empty;
                cbType.ReadOnly = true;
                cbType.Enabled = false;
                tbInterval.Text = string.Empty;
                tbInterval.Enabled = false;
                rdmPrimary.Enabled = false;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;

            }
            else if (handler == 3)
            {
                cbType.ReadOnly = false;
                cbType.Enabled = true;
                tbInterval.Enabled = true;
                rdmPrimary.Enabled = true;
                btnNew.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;

            }
        }
        private bool ValidateEntries()
        {
            if (cbType.Text == "Select Type" || cbType.Text.IsEmpty())
            {
                XtraMessageBox.Show("Please Select Type", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbType.Focus();
                return false;
            }
            else if (tbInterval.Text.IsEmpty())
            {
                XtraMessageBox.Show("Please enter Scheduler Interval", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbInterval.Focus();
                return false;
            }
            string strSts = rdmPrimary.EditValue.Str();
            form.INTRVL_TP = cbType.Text.Trim();
            form.INTRVL_NM = Convert.ToInt32(tbInterval.Text.Trim());
            form.INTRVL_STS = (rdmPrimary.SelectedIndex == -1) ? 0 : Convert.ToInt32(rdmPrimary.EditValue.Str());
            //form.INTRVL_HNDLR = 2;
            enableField(form.INTRVL_HNDLR);
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) return;
            StaticSettings.showLoading();
            var res = (Db.execute0a(form)).Result;
            if (res.result == Results.Success)
            {
                StaticSettings.hideLoading();
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                    enableField(2);
                    Timeout.Set(() => this.Invoke(new Action(() => this.Load_ForfeitScheduler())), 250);
            }
            else if (res.result != Results.Null)
            {
                StaticSettings.hideLoading();
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
            }
            else
            {
                StaticSettings.hideLoading();
                XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //form.INTRVL_HNDLR = 2;
            enableField(2);
        }

        private void cmsEditSchedule_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.GetFocusedDataRow();
            DataRow row = gridView1.GetFocusedDataRow();
            string strSts = row["INTRVL_STS"].Str().Trim();
            string strType = row["INTRVL_TP"].Str().Trim();
            //this.cbType.Text = (row["INTRVL_TP"].Str()=="") ? "Select Type" : row["INTRVL_TP"].Str();
            this.cbType.EditValue = (row["INTRVL_TP"].Str() == "") ? "Select Type" : row["INTRVL_TP"].Str();
            this.tbInterval.Text = (row["INTRVL_NM"].Str() == "") ? string.Empty : row["INTRVL_NM"].Str();
            this.rdmPrimary.SelectedIndex = (row["INTRVL_STS"].Str().Trim() == string.Empty || row["INTRVL_STS"].Str().Trim() == "False") ? -1 : 1;
            form.INTRVL_ID = (row["INTRVL_ID"].Str() == "") ? string.Empty : row["INTRVL_ID"].Str();
            form.INTRVL_HNDLR = 3;
            enableField(3);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class _forfeit
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                if (gridView.RowCount != 0)
                {
                    gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("INTRVL_STS", "Active", 1, gridView, 5);
                    DevXSettings.XtraFormatColumn("FORFEIT", "Schedule", 2, gridView, 100);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS", "Added Date", 3, gridView, 100);
                    DevXSettings.XtraFormatColumn("UPD_TRN_TS", "Updated Date", 3, gridView, 100);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Encode by", 4, gridView, 100);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
        }
        public class Input
        {
            public string INTRVL_ID;
            public string INTRVL_TP;
            public int INTRVL_NM;
            public int INTRVL_STS;
            public int INTRVL_HNDLR;
        }
        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(Input input)
            {
                var result=API.DSpQueryAPI("/api/v1/ForfeitInterval/UpdateForfeitInterval", Login.authentication, new Dictionary<string,object>()
                {
                    {"intrvl_id",input.INTRVL_ID },
                    {"intrvl_tp",input.INTRVL_TP },
                    {"intrvl_nm",input.INTRVL_NM },
                    {"intrvl_sts",input.INTRVL_STS },
                    {"parmHandler",input.INTRVL_HNDLR }
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                    {
                        input.INTRVL_ID = row["intervalid"].Str();
                        return (Results.Success, row["message"].Str());
                    }
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }

        }
    }
}