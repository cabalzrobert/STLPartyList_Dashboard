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
using System.Globalization;
using static JLIDashboard.REPORTING._x0g2;
using static JLIDashboard.REPORTING._x0g2.Vyw;
using Comm.Common.Extensions;
using System.IO;
using System.Net;
using System.Drawing.Imaging;
using JLIDashboard.Classes;
using JLIDashboard._Module;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using JLIDashboard.Module;
using AbacosDashboard.Module.Enum;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.REPORTING
{
    public partial class CorrectiveAction : DevExpress.XtraEditors.XtraForm
    {
        public bool isEdit;
        public bool ok;
        public Input form = new Input();
        public CorrectiveAction()
        {
            InitializeComponent();
        }

        public CorrectiveAction retData(DataRow row)
        {
            row["BODY"] = form.BODY;
            row["COR_ACTION"] = form.COR_ACTION;
            row["STAT"] = form.STAT;
            row["STAT_NM"] = form.STAT_NM;
            row["FXD_TRN_TS"] = form.FXD_TRN_TS;
            return this;
        }
        public CorrectiveAction setData(DataRow row, bool isEdit = false)
        {
            CultureInfo culture = new CultureInfo("es-ES");
            form.USR_ID = row["USR_ID"].Str();
            form.BR_CD = row["BR_CD"].Str();
            form.COMP_ID = row["COMP_ID"].Str();
            form.FLL_NM = row["FLL_NM"].Str();
            form.UPD_TRN_TS = row["UPD_TRN_TS"].Str();
            form.TRN_NO = row["TRN_NO"].Str();
            form.TCKT_NO = row["TCKT_NO"].Str();
            form.SBJCT_CD = row["SBJCT_CD"].Str();
            form.BODY = row["BODY"].Str();
            form.COR_ACTION = row["COR_ACTION"].Str();
            form.STAT = row["STAT"].Str();
            form.STAT_NM = row["STAT_NM"].Str();
            //form.ATTCHMNT = row["ATTCHMNT"].Str();
            lblsubject.Text = form.SBJCT_CD;
            lblticketno.Text = form.TCKT_NO;
            lbldate.Text = Convert.ToDateTime(form.UPD_TRN_TS).ToString("dd-MMM-yyyy");
            this.rdmstatus.SelectedIndex = (row["STAT"].Str().Trim() == string.Empty) ? -1 : Convert.ToInt32(row["STAT"].Str().Trim());
            lblbody.Text = form.BODY;
            tbcorrectiveaction.Text = form.COR_ACTION;
            tbcorrectiveaction.Focus();
            Timeout.Set(() => this.Invoke(new Action(() => this.Load_Attachment())), 250);
            return this;
        }
        public void Load_Attachment()
        {
            API.displayAPI("/api/v1/TroubleReport/LoadTroubleAttachment", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"transactionNo", form.TRN_NO  },
                {"userID", form.USR_ID },
            });

            x0a(gridView1);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.GetFocusedDataRow();
            DataRow row = gridView1.GetFocusedDataRow();
            string fpath = row["ATTCHMNT"].Str();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = fpath;
            info.UseShellExecute = true;
            info.CreateNoWindow = true;
            info.Verb = string.Empty;
            Process.Start(info);
        }
        private bool ValidEntries()
        {
            if (tbcorrectiveaction.Text.IsEmpty())
            {
                StaticSettings.XtraMessage("Corrective Action is required", MessageBoxIcon.Exclamation);
                return false;
            }
            if (rdmstatus.EditValue.Str().Trim() == "0")
            {
                StaticSettings.XtraMessage("Please Select Solved", MessageBoxIcon.Exclamation);
                return false;
            }
            form.COR_ACTION = tbcorrectiveaction.Text.Trim();
            form.STAT = rdmstatus.EditValue.Str().Trim();
            form.STAT_NM = rdmstatus.Properties.Items[rdmstatus.SelectedIndex].Description.Str();
            return true;
        }
        private void bntsave_Click(object sender, EventArgs e)
        {
            if (!ValidEntries() && XtraMessageBox.Show("Are you sure you want to Continue", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) return;
            StaticSettings.showLoading();
            var res = (DB.executeCorAction(form)).Result;
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
    }
    public partial class _x0g2
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                if (gridView.RowCount != 0)
                {
                    gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("SEQ_NO", "Attachment", 1, gridView, 100);
                }
                return gridView;
            }
        }
        public class DB
        {
            public static async Task<(Results result, string message)> executeCorAction(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/TroubleReport/UpdateCorrectiveAction", Login.authentication, new Dictionary<string, object>()
                {
                    {"userID",input.USR_ID },
                    {"transactionNo",input.TRN_NO },
                    {"tckT_NO",input.TCKT_NO },
                    {"coR_ACTION",input.COR_ACTION },
                    {"stat",input.STAT }
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    input.FXD_TRN_TS = row["fld_trn_ts"].Str();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, row["message"].Str());
                    }
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
        public class Input
        {
            public string COMP_ID;
            public string BR_CD;
            public string USR_ID;
            public string FLL_NM;
            public string UPD_TRN_TS;
            public string TRN_NO;
            public string TCKT_NO;
            public string SBJCT_CD;
            public string BODY;
            public string COR_ACTION;
            public string STAT;
            public string STAT_NM;
            public string ATTCHMNT;
            public string FXD_TRN_TS;
        }
    }
}