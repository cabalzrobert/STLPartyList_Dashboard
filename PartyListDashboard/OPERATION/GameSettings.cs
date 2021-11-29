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

using static JLIDashboard.OPERATION._x0e;
using static JLIDashboard.OPERATION._x0e.Vyw;
using JLIDashboard.Classes.Common.Extensions;
using Comm.Common.Extensions;
using AbacosDashboard.Module.Enum;
using JLIDashboard._Module;
using DevExpress.Utils;
using System.Xml.Serialization;
using JLIDashboard.Classes.Common;
using JLIDashboard.Module;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATION
{
    public partial class GameSettings : DevExpress.XtraEditors.XtraForm
    {
        public GameSettings()
        {
            InitializeComponent();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            tbdrawdate.EditValue = DateTime.Now;
            this.fillGameTypes();
            this.inputEnability(false);
        }
        private void fillGameTypes(bool nullable = true)
        {
            API.displaySearchLookupEditAPIParam("/api/v1/GameSettings/GameProfile", Login.authentication, tsgmtype, "GM_NM", "GM_ID");
            x0a(tsgmtype);
            if (!nullable) return;
            tsgmtype.EditValue = null;
        }

        private void tsgmtype_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = tsgmtype.GetFocusedDataRow();
            form.GameID = null;
            form.isValid = false;
            bool hasSelected = (row != null);
            double winnings = 0, limitstraight = 0, limitrumble = 0;
            string cutoffstart = "-", cutoffend = "-";
            if (hasSelected)
            {
                form.GameCode = row["GM_CD"].Str();
                form.GameID = row["GM_ID"].Str();
                form.DrawDate = row["DRW_TRN_DT"].Str();
                form.DrawSchedule = row["DRW_TYP"].Str();
                form.BallCount = (int)row["BLL_CNT"].Str().ToDecimalDouble();
                form.MinDigit = (int)row["MN_DGT"].Str().ToDecimalDouble();
                form.MaxDigit = (int)row["MX_DGT"].Str().ToDecimalDouble(); // + 50
                form.LenDigit = (form.MaxDigit.ToString()).Length;
                form.isValid = !(form.DrawDate.IsEmpty() || form.DrawSchedule.IsEmpty());
                winnings = row["PRC_WNNG_AMNT"].Str().ToDecimalDouble();
                limitstraight = row["STRGHT_AMT_LMT"].Str().ToDecimalDouble();
                limitrumble = row["RMBL_AMT_LMT"].Str().ToDecimalDouble();
                cutoffstart = (!form.isValid ? "-" : row["CUT_STRT"].Str());
                cutoffend = (!form.isValid ? "-" : row["CUT_END"].Str());
            }
            //
            this.fillCutOff();
            DateTime drawdate;
            try { drawdate = DateTime.Parse(form.DrawDate); } catch { drawdate = DateTime.Now; }
            tbdrawdate.EditValue = drawdate;
            tsdrawsched.Text = form.DrawSchedule;
            tbcutoffstart.Text = cutoffstart;
            tbcutoffend.Text = cutoffend;
            //
            tbwinnings.EditValue = winnings;
            tblimitstraight.EditValue = limitstraight;
            tblimitrumble.EditValue = limitrumble;
            //
            this.inputEnability(hasSelected);
            this.changePanels();
            this.display();
        }

        private void inputEnability(bool enable)
        {
            tbdrawdate.Enabled = tsdrawsched.Enabled = enable;
            tbwinnings.Enabled = enable;
            tblimitstraight.Enabled = tblimitrumble.Enabled = enable;
            btnsubmit.Enabled = enable;
            tblimitcom1.Enabled = tblimitcom2.Enabled = tblimitcom3.Enabled = enable;
            tbstrghtlimit.Enabled = tbrmbllimit.Enabled = enable;
            tbsoutcom1.Enabled = tbsoutcom2.Enabled = tbsoutcom3.Enabled = enable;
            btnsubmit1.Enabled = btnsubmit2.Enabled = enable;
        }

        private void changePanels()
        {
            if (form.BallCount == 2)
            {
                tblimitcom3.Visible = false;
                tbsoutcom3.Visible = false;
            }
            else if (form.BallCount == 3)
            {
                tblimitcom3.Visible = true;
                tbsoutcom3.Visible = true;
            }
        }

        private void tblimitcom1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else if (e.KeyChar != '\b')
                verifyTextNumber(tblimitcom1, tblimitcom2, e);
        }

        private void tblimitcom2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else if (e.KeyChar != '\b')
            {
                if (tblimitcom3.Visible)
                    verifyTextNumber(tblimitcom2, tblimitcom3, e);
                else verifyTextNumber(tblimitcom2, btnsubmit1, e);
            }
            else if (tblimitcom2.Text.Length < 2)
                tblimitcom1.Focus();
        }

        private void tblimitcom3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else if (e.KeyChar != '\b')
                verifyTextNumber(tblimitcom3, btnsubmit1, e);
            else if (tblimitcom3.Text.Length < 2)
                tblimitcom2.Focus();
        }

        private void tbsoutcom1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else if (e.KeyChar != '\b')
                verifyTextNumber(tbsoutcom1, tbsoutcom2, e);
        }

        private void tbsoutcom2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else if (e.KeyChar != '\b')
            {
                if (tbsoutcom3.Visible)
                    verifyTextNumber(tbsoutcom2, tbsoutcom3, e);
                else verifyTextNumber(tbsoutcom2, btnsubmit2, e);
            }
            else if (tbsoutcom2.Text.Length < 2)
                tbsoutcom1.Focus();
        }

        private void tbsoutcom3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else if (e.KeyChar != '\b')
                verifyTextNumber(tbsoutcom3, btnsubmit2, e);
            else if (tbsoutcom3.Text.Length < 2)
                tbsoutcom2.Focus();
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

        public void fillCutOff()
        { //
            API.displaySearchLookupEditAPIParam($"/api/v1/DrawSchedule/LoadDrawSchedule?gameID={form.GameID}", Login.authentication, tsdrawsched, "DRW_TYP", "DRW_TYP");
            x0b(tsdrawsched).EditValue = form.DrawSchedule;
        }

        private void tsdrawsched_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = tsdrawsched.GetFocusedDataRow();
            bool hasCutOff = (row != null);
            tbcutoffstart.Text = (!hasCutOff ? "-" : row["CUT_STRT"].Str());
            tbcutoffend.Text = (!hasCutOff ? "-" : row["CUT_END"].Str());
        }


        private void display()
        {
            this.loadLimit();
            this.loadSout();
        }
        private void loadLimit()
        {
            API.displayAPIParam($"/api/v1/GameSettings/LoadLimitBetCombination?GameID={form.GameID}", gridControl1, gridView1, Login.authentication);
            if (gridView1.RowCount == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("GM_TYP", typeof(string));
                dt.Columns.Add("NUM_COMB", typeof(string));
                dt.Columns.Add("STRGHT_AMT_LMT", typeof(string));
                dt.Columns.Add("RMBL_AMT_LMT", typeof(string));
                gridControl1.DataSource = dt;
            }
                x0a(gridView1);
        }
        private void loadSout()
        {
            API.displayAPIParam($"/api/v1/GameSettings/LoadSoldOutCombination?GameID={form.GameID}", gridControl2, gridView2, Login.authentication);
            if (gridView2.RowCount == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("GM_TYP", typeof(string));
                dt.Columns.Add("NUM_COMB", typeof(string));
                gridControl2.DataSource = dt;
                gridView2.BestFitColumns();
            }
            x0b(gridView2);

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = Db.execute0a(form).Result;
            if (res.result == Results.Success)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                var frm1 = Application.OpenForms.Find<ResultPosting>();
                if (frm1 != null) frm1.fillGameTypes(false);
                var frm2 = Application.OpenForms.Find<GameResults>();
                if (frm2 != null) frm2.fillGameTypes(false);
                //
                this.fillGameTypes(false);
                this.tsgmtype_EditValueChanged(tsgmtype, null);
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
            string gmtype = this.tsgmtype.Text.Trim();
            if (gmtype.IsEmpty())
            {
                StaticSettings.XtraMessage("Please select game type", MessageBoxIcon.Exclamation);
                this.tsgmtype.Focus();
                return false;
            }
            string drawdate = tbdrawdate.Text.Str();
            if (drawdate.IsEmpty())
            {
                StaticSettings.XtraMessage("Current draw date is required", MessageBoxIcon.Exclamation);
                this.tsdrawsched.Focus();
                return false;
            }
            string drawsched = tsdrawsched.EditValue.Str();
            if (drawsched.IsEmpty())
            {
                StaticSettings.XtraMessage("Current draw schedule is required", MessageBoxIcon.Exclamation);
                this.tsdrawsched.Focus();
                return false;
            }
            //
            LimitBetCombination item1 = null;
            List<LimitBetCombination> limitComb = new List<LimitBetCombination>();
            //
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetDataRow(i);
                limitComb.Add(item1 = new LimitBetCombination());
                item1.combination = row["NUM_COMB"].Str();
                item1.straight = row["STRGHT_AMT_LMT"].Str().getNumberFormat();
                item1.rumble = row["RMBL_AMT_LMT"].Str().getNumberFormat();
            }

            SoldOutCombination item2 = null;
            List<SoldOutCombination> soldComb = new List<SoldOutCombination>();
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                var row = gridView2.GetDataRow(i);
                soldComb.Add(item2 = new SoldOutCombination());
                item2.combination = row["NUM_COMB"].Str();
            }

            form.DrawSchedule = tsdrawsched.EditValue.Str();
            form.DrawDate = tbdrawdate.Text;
            form.StraightLimitAmount = tblimitstraight.EditValue.Str().ToDecimalDouble();
            form.RumbleLimitAmount = tblimitrumble.EditValue.Str().ToDecimalDouble();
            form.WinPrice = tbwinnings.EditValue.Str().ToDecimalDouble();
            form.LimitBetCombinations = limitComb;
            form.SoldOutCombinations = soldComb;
            return true;
        }

        private void btnsubmit1_Click(object sender, EventArgs e)
        {
            string gmtype = this.tsgmtype.Text.Trim();
            if (gmtype.IsEmpty())
            {
                StaticSettings.XtraMessage("Please select game type", MessageBoxIcon.Exclamation);
                this.tsgmtype.Focus();
                return;
            }
            double strghtlimit = tbstrghtlimit.EditValue.Str().ToDecimalDouble();
            double rmbllimit = tbrmbllimit.EditValue.Str().ToDecimalDouble();

            if (strghtlimit < 0 && rmbllimit < 0)
            {
                StaticSettings.XtraMessage("Please set valid amount of straight or rumble limit", MessageBoxIcon.Exclamation);
                this.tbstrghtlimit.Focus();
                return;
            }
            List<TextEdit> tbs = new List<TextEdit>(new[] { tblimitcom1, tblimitcom2 });
            if (form.BallCount == 3) tbs.Add(tblimitcom3);
            StringBuilder comb = new StringBuilder();
            foreach (TextEdit tb in tbs)
            {
                if (tb.Text.Str().IsEmpty())
                {
                    this.validatyMsg(tb);
                    return;
                }
                double digit = tb.Text.ToDecimalDouble();
                if (digit < form.MinDigit && digit > form.MaxDigit)
                {
                    StaticSettings.XtraMessage($"Allowable combination range is {form.MinDigit} to {form.MaxDigit} only", MessageBoxIcon.Exclamation);
                    tb.Focus();
                    return;
                }
                if (comb.Length != 0) comb.Append('-');
                comb.Append(digit.Str().PadLeft(form.LenDigit, '0'));
            }

            var row = gridView1.Select($"NUM_COMB='{comb.ToString()}'").FirstOrDefault();
            if (row != null)
            {
                row["STRGHT_AMT_LMT"] = strghtlimit;
                row["RMBL_AMT_LMT"] = rmbllimit;
                gridView1.RefreshData();
            }
            else
            {
                gridView1.AddNewRow();
                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["NUM_COMB"], comb.ToString());
                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["STRGHT_AMT_LMT"], strghtlimit);
                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["RMBL_AMT_LMT"], rmbllimit);
                gridView1.UpdateCurrentRow();
            }
            foreach (TextEdit tb in tbs) tb.Text = "";
            tbstrghtlimit.EditValue = 0;
            tbrmbllimit.EditValue = 0;
        }

        private void validatyMsg(TextEdit tb)
        {
            if (tb == tblimitcom1 || tb == tbsoutcom1) StaticSettings.XtraMessage("Invalid first entry combination", MessageBoxIcon.Exclamation);
            else if (tb == tblimitcom2 || tb == tbsoutcom2) StaticSettings.XtraMessage("Invalid second entry combination", MessageBoxIcon.Exclamation);
            else if (tb == tblimitcom3 || tb == tbsoutcom3) StaticSettings.XtraMessage("Invalid third entry combination", MessageBoxIcon.Exclamation);
            tb.Focus();
        }


        private void btnsubmit2_Click(object sender, EventArgs e)
        {
            string gmtype = this.tsgmtype.Text.Trim();
            if (gmtype.IsEmpty())
            {
                StaticSettings.XtraMessage("Please select game type", MessageBoxIcon.Exclamation);
                this.tsgmtype.Focus();
                return;
            }
            List<TextEdit> tbs = new List<TextEdit>(new[] { tbsoutcom1, tbsoutcom2 });
            if (form.BallCount == 3) tbs.Add(tbsoutcom3);
            StringBuilder comb = new StringBuilder();
            foreach (TextEdit tb in tbs)
            {
                if (tb.Text.Str().IsEmpty())
                {
                    this.validatyMsg(tb);
                    return;
                }
                double digit = tb.Text.ToDecimalDouble();
                if (digit < form.MinDigit && digit > form.MaxDigit)
                {
                    StaticSettings.XtraMessage($"Allowable combination range is {form.MinDigit} to {form.MaxDigit} only", MessageBoxIcon.Exclamation);
                    tb.Focus();
                    return;
                }
                if (comb.Length != 0) comb.Append('-');
                comb.Append(digit.Str().PadLeft(form.LenDigit, '0'));
            }

            var row = gridView2.Select($"NUM_COMB='{comb.ToString()}'").FirstOrDefault();
            if (row != null)
            {
                StaticSettings.XtraMessage("Sold out combination already exist", MessageBoxIcon.Exclamation);
            }
            else
            {
                gridView2.AddNewRow();
                gridView2.SetRowCellValue(GridControl.NewItemRowHandle, gridView2.Columns["NUM_COMB"], comb.ToString());
                gridView2.UpdateCurrentRow();
                //x0b(gridView2);
                foreach (TextEdit tb in tbs) tb.Text = "";
            }
        }
        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            bool hasSelected = (gridView1.FocusedRowHandle > -1);
            cmsLmtCombBtn0a.Enabled = hasSelected;
        }
        private void cmsLmtCombBtn0a_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            bool hasSelected = (gridView2.FocusedRowHandle > -1);
            cmsSoutCombBtn0a.Enabled = hasSelected;
        }
        private void cmsSoutCombBtn0a_Click(object sender, EventArgs e)
        {
            gridView2.DeleteRow(gridView2.FocusedRowHandle);
        }
    }

    public partial class _x0e
    {
        public class Vyw
        {
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("GM_CD", "Game ID", 1, gridView);
                DevXSettings.XtraFormatColumn("GM_NM", "Game Name", 2, gridView);
                DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Draw Date", 3, gridView);
                DevXSettings.XtraFormatColumn("DRW_TYP", "Draw Schedule", 4, gridView);
                DevXSettings.XtraFormatColumn("CUT_STRT", "CutOff Start", 5, gridView);
                DevXSettings.XtraFormatColumn("CUT_END", "CutOff End", 6, gridView);
                gridView.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0b(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("DRW_TYP", "Draw Schedule", 1, gridView);
                DevXSettings.XtraFormatColumn("CUT_STRT", "CutOff Start", 2, gridView);
                DevXSettings.XtraFormatColumn("CUT_END", "CutOff End", 3, gridView);
                gridView.BestFitColumns();
                return control;
            }
            public static GridView x0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("NUM_COMB", "Combination", 1, gridView);
                DevXSettings.XtraFormatColumn("STRGHT_AMT_LMT", "Straight", 2, gridView);
                DevXSettings.XtraFormatColumn("RMBL_AMT_LMT", "Rumble", 3, gridView);
                DevXSettings.XgridColAlign(new string[] { "NUM_COMB", }, gridView, HorzAlignment.Center);
                DevXSettings.XgridColCurrency(new string[] { "STRGHT_AMT_LMT", "RMBL_AMT_LMT" }, gridView);
                gridView.BestFitColumns();
                return gridView;
            }
            public static GridView x0b(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("NUM_COMB", "Combination", 1, gridView);
                DevXSettings.XgridColAlign(new string[] { "NUM_COMB", }, gridView, HorzAlignment.Center);
                gridView.BestFitColumns();
                return gridView;
            }
        }
        public class Input
        {
            public string GameCode;
            public string GameID;
            public string DrawSchedule;
            public string DrawDate;
            public string lDrawDate;
            public double WinPrice;
            public double StraightLimitAmount;
            public double RumbleLimitAmount;
            public List<LimitBetCombination> LimitBetCombinations = new List<LimitBetCombination>();
            public List<SoldOutCombination> SoldOutCombinations = new List<SoldOutCombination>();
            public string iLimitBetCombinations;
            public string iSoldOutCombinations;
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

                var limitBetCombinations = input.LimitBetCombinations;
                if (limitBetCombinations != null && limitBetCombinations.Count != 0)
                    input.iLimitBetCombinations = AggrUtils.Xml.toXmlString(limitBetCombinations).ToString().Trim();
                else input.iLimitBetCombinations = null;

                var soldOutCombinations = input.SoldOutCombinations;
                if (soldOutCombinations != null && soldOutCombinations.Count != 0)
                    input.iSoldOutCombinations = AggrUtils.Xml.toXmlString(soldOutCombinations).ToString().Trim();
                else input.iSoldOutCombinations = null;

                return true;
            }
        }

        [XmlRoot(ElementName = "item")]
        public class LimitBetCombination
        {
            [XmlAttribute("NUM_COMB")]
            public string combination;
            [XmlAttribute("STRGHT_AMT_LMT")]
            public string straight;
            [XmlAttribute("RMBL_AMT_LMT")]
            public string rumble;
        }
        [XmlRoot(ElementName = "item")]
        public class SoldOutCombination
        {
            [XmlAttribute("NUM_COMB")]
            public string combination;
        }



        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(Input input)
            {
                Input.validity(input);
                input.iLimitBetCombinations = input.iLimitBetCombinations.Str().Replace("\"", "'");
                input.iSoldOutCombinations = input.iSoldOutCombinations.Str().Replace("\"", "'");
                var result = API.DSpQueryAPI("/api/v1/GameSettings/SetGameSettings", Login.authentication, new Dictionary<string, object>(){
                    { "gameID", input.GameID },
                    { "drawSchedule", input.DrawSchedule },
                    { "lDrawDate", input.lDrawDate },

                    { "straightLimitAmount", input.StraightLimitAmount.ToString("0.00") },
                    { "rumbleLimitAmount", input.RumbleLimitAmount.ToString("0.00") },
                    { "winPrice", input.WinPrice.ToString("0.00") },

                    { "betLimit", "0" },
                    { "iLimitBetCombinations", input.iLimitBetCombinations },
                    { "iSoldOutCombinations", input.iSoldOutCombinations },
                });
                if (result != null)
                {
                    string ResultCode = result["result"].Str();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, result["message"].Str());
                    }
                    return (Results.Success, result["message"].Str());
                }
                return (Results.Null, null);
            }
        }
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
