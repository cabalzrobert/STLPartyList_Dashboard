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
using System.Data.SqlClient;
using JLIDashboard.Classes;
using JLIDashboard.Classes.Common.Extensions;
using Comm.Common.Extensions;

using static JLIDashboard.OPERATION._x0d;
using static JLIDashboard.OPERATION._x0d.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using static JLIDashboard.OPERATION._x0c;
using JLIDashboard._Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATION
{
    public partial class ResultPosting : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public ResultPosting()
        {
            InitializeComponent();
        }
        private void ResultPosting_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public ResultPosting setData()
        {
            this.fillGameTypes();
            return this;
        }
        public void fillGameTypes(bool nullable = true)
        {
            API.displaySearchLookupEditAPIParam("/api/v1/GameResult/GameType", Login.authentication, tsgmtype, "GM_NM", "GM_ID");
            x0a(tsgmtype);
            if (!nullable) return;
            tsgmtype.EditValue = null;
        }

        private void tsgmtype_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = tsgmtype.GetFocusedDataRow();
            form.GameCode = row["GM_CD"].Str();
            form.GameID = row["GM_ID"].Str();
            form.DrawDate = row["DRW_TRN_DT"].Str();
            form.DrawSchedule = row["DRW_TYP"].Str();
            form.BallCount = (int)row["BLL_CNT"].Str().ToDecimalDouble();
            form.MinDigit = (int)row["MN_DGT"].Str().ToDecimalDouble();
            form.MaxDigit = (int)row["MX_DGT"].Str().ToDecimalDouble(); // + 50
            form.LenDigit = (form.MaxDigit.ToString()).Length;
            form.isValid = !(form.DrawDate.IsEmpty() || form.DrawSchedule.IsEmpty());
            tbdrawdate.Text = (form.isValid ? form.DrawDate : "--");
            tbdraw.Text = (form.isValid ? form.DrawSchedule : "--");
            btnsubmit.Enabled = form.isValid;
            tbno1.Enabled = tbno2.Enabled = tbno3.Enabled = form.isValid;
            //
            this.changeCombinatioPanel();
        }

        private void changeCombinatioPanel()
        {
            tbno1.Properties.MaxLength = form.LenDigit;
            tbno2.Properties.MaxLength = form.LenDigit;
            tbno3.Properties.MaxLength = form.LenDigit;

            tlpcomb.ColumnStyles[0].SizeType = SizeType.Percent;
            tlpcomb.ColumnStyles[1].SizeType = SizeType.Percent;
            tlpcomb.ColumnStyles[2].SizeType = SizeType.Percent;
            if (form.BallCount == 3)
            {
                tlpcomb.ColumnStyles[0].Width = 33.33f;
                tlpcomb.ColumnStyles[1].Width = 33.33f;
                tlpcomb.ColumnStyles[2].Width = 33.33f;
                tbno3.Visible = true;
            }
            else if (form.BallCount == 2)
            {
                tlpcomb.ColumnStyles[0].Width = 50f;
                tlpcomb.ColumnStyles[1].Width = 50f;
                tlpcomb.ColumnStyles[2].Width = 0f;
                tbno3.Visible = false;
            }
        }
        private void tbno1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else if (e.KeyChar != '\b')
                verifyTextNumber(tbno1, tbno2, e);
        }

        private void tbno2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else if (e.KeyChar != '\b')
            {
                if (tbno3.Visible)
                    verifyTextNumber(tbno2, tbno3, e);
                else verifyTextNumber(tbno2, btnsubmit, e);
            }
            else if (tbno2.Text.Length < 2)
                tbno1.Focus();
        }

        private void tbno3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else if (e.KeyChar != '\b')
                verifyTextNumber(tbno3, btnsubmit, e);
            else if(tbno3.Text.Length < 2)
                tbno2.Focus();
        }
        private void verifyTextNumber(TextEdit current, TextEdit next, KeyPressEventArgs e)
        {
            current.SelectionLength = 0;
            double dMaxdigit = form.MaxDigit;
            string str = current.Text;
            int ss = current.SelectionStart, sl = current.SelectionLength;
            string str1 = str.Substring(0, ss), str2 = str.Substring(ss);
            string strnumber = str1 + e.KeyChar + str2;
            double number = (strnumber.Trim()).ToDecimalDouble();
            if (number >= dMaxdigit)
            {
                next.Focus();
                next.SelectAll();
                if (number > dMaxdigit)
                {
                    next.Text = $"{e.KeyChar}";
                    e.Handled = true;
                }
                next.SelectionStart = next.Text.Length;
            }
        }
        private void verifyTextNumber(TextEdit current, SimpleButton next, KeyPressEventArgs e)
        {
            current.SelectionLength = 0;
            double dMaxdigit = form.MaxDigit;
            string str = current.Text;
            int ss = current.SelectionStart, sl = current.SelectionLength;
            string str1 = str.Substring(0, ss), str2 = str.Substring(ss);
            string strnumber = str1 + e.KeyChar + str2;
            double number = (strnumber.Trim()).ToDecimalDouble();
            if (number >= dMaxdigit)
            {
                next.Focus();
                if (number > dMaxdigit)
                    e.Handled = true;
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
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
            StaticSettings.hideLoading();
        }

        public Input form = new Input();
        private bool ValidateEntries()
        {
            if (!form.isValid)
            {
                StaticSettings.XtraMessage("Draw Schedule is required", MessageBoxIcon.Exclamation);
                return false;
            }
            string gmtype = this.tsgmtype.Text.Trim();
            if (gmtype.IsEmpty())
            {
                StaticSettings.XtraMessage("Please select a game", MessageBoxIcon.Exclamation);
                return false;
            }
            string firstnumber = this.tbno1.Text.Trim();
            string secondnumber = this.tbno2.Text.Trim();
            string thirdnumber = this.tbno3.Text.Trim();
            if (form.GameCode == "SWER3" && (firstnumber.IsEmpty() || secondnumber.IsEmpty() || thirdnumber.IsEmpty()))
            {
                StaticSettings.XtraMessage("Please enter 3 digits required fields", MessageBoxIcon.Exclamation);
                return false;
            }
            if ((form.GameCode == "SWER2" || form.GameCode == "PARES") && (firstnumber.IsEmpty() || secondnumber.IsEmpty()))
            {
                StaticSettings.XtraMessage("Please enter 2 digits required fields", MessageBoxIcon.Exclamation);
                return false;
            }

            StringBuilder result = new StringBuilder();
            List<TextEdit> list = new List<TextEdit>(new[] { this.tbno1, this.tbno2 });
            if (form.GameCode == "SWER3") list.Add(this.tbno3);

            foreach (TextEdit tb in list)
            {
                int number = (int)tb.Text.ToDecimalDouble();
                if (form.MinDigit > number || number > form.MaxDigit)
                {
                    StaticSettings.XtraMessage("Invalid Entry", MessageBoxIcon.Exclamation);
                    tb.Focus();
                    return false;
                }
                if (result.Length != 0) result.Append('-');
                result.Append(number);
            }
            form.Combination = result.ToString();
            return true;
        }

    }
    public partial class _x0d
    {
        public class Vyw
        {
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("GM_NM", "Game Type", 0, gridView);
                DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Draw Date", 2, gridView);
                DevXSettings.XtraFormatColumn("DRW_TYP", "Draw Schedule", 3, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string GameCode;
            public string GameID;
            public string DrawSchedule;
            public string DrawDate;
            public string lDrawDate; 
            public string Combination;
            //
            public int BallCount;
            public int MinDigit;
            public int MaxDigit;
            public int LenDigit;
            public bool isValid;
            public static bool validity(Input input)
            {
                try
                {
                    try { input.lDrawDate = DateTime.Parse(input.DrawDate).ToString("yyyyMMdd"); }
                    catch { input.lDrawDate = input.DrawDate.ToDBDateString("yyyyMMdd"); }
                }
                catch { return false; }

                return true;
            }
        }

        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(Input input)
            {
                Input.validity(input);
                var result = API.DSpQueryAPI("/api/v1/PostResult/PostResults", Login.authentication, new Dictionary<string, object>(){
                    { "gameID", input.GameID },
                    { "drawSchedule", input.DrawSchedule },
                    { "drawDate", input.lDrawDate },
                    { "combination", input.Combination },
                });
                if (result != null)
                {
                    string ResultCode = result["result"].Str();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, result["message"].Str());
                    }
                    return (Results.Failed, "Game is already posted. Please update Game Date/Schedule Draw in Game Profile Tab");
                }
                return (Results.Null, null);
            }
        }
    }
    public partial class _x0c
    {
        public class notify
        {
            public static async Task<bool> WebDashboard()
            {
                await Pusher.PushAsync($"/{Login.compid}/{Login.brcode}/lottery/bet/update", "{}");
                return false;
            }
        }
    }
}