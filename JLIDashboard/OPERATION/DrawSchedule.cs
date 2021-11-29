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
using AbacosDashboard.Module.Enum;
using Comm.Common.Extensions;

using static JLIDashboard.OPERATION._x0a;
using static JLIDashboard.OPERATION._x0a.Vyw;
using JLIDashboard.Module;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Mask;
using JLIDashboard.Classes.Common;
using System.Xml.Serialization;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATION
{
    public partial class DrawSchedule : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public DrawSchedule()
        {
            InitializeComponent();
        }

        private void DrawSchedule_Load(object sender, EventArgs e)
        {
            ok = false;
        }

        public DrawSchedule setData()
        {
            this.fillGameTypes();
            return this;
        }
        private void fillGameTypes()
        {
            API.displaySearchLookupEditAPI("/api/v1/DrawSchedule/LoadGameType", Login.authentication, tsgmtype, "GM_NM", "GM_ID");
            x0a(tsgmtype).EditValue = null;
        }

        private void tsactnum_EditValueChanged(object sender, EventArgs e)
        {
            form.GameID = tsgmtype.GetSelectedSingleValue("GM_ID").Str();
            this.loadDrawSchedules();
        }
        public void loadDrawSchedules()
        {
            API.displayAPIParam($"/api/v1/DrawSchedule/LoadDrawSchedule?gameID={form.GameID}", gridControl1, gridView1, Login.authentication);
            x0a(gridView1);
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
                var frm = Application.OpenForms.Find<GameSettings>();
                if (frm != null) frm.fillCutOff();
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
            Schedule item = null;
            List<Schedule> schedules = new List<Schedule>();
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                if (this.gridView1.GetRowCellValue(i, "SEQ_NO").ToString().Length < 1)
                    continue;
                schedules.Add(item = new Schedule());
                item.sequenceNo = this.gridView1.GetRowCellValue(i, "SEQ_NO").Str();
                item.drawName = this.gridView1.GetRowCellValue(i, "DRW_TYP").Str();
                item.cutOffStart = this.gridView1.GetRowCellValue(i, "CUT_STRT").Str();
                item.cutOffEnd = this.gridView1.GetRowCellValue(i, "CUT_END").Str();
            }
            form.Schedules = schedules;
            return true;
        }

    }
    public partial class _x0a
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {

                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("SEQ_NO", "Sequence", 0, gridView);
                DevXSettings.XtraFormatColumn("DRW_TYP", "Draw Name", 1, gridView);
                DevXSettings.XtraFormatColumn("CUT_STRT", "Cutoff Begin", 2, gridView);
                DevXSettings.XtraFormatColumn("CUT_END", "Cutoff End", 3, gridView);
                gridView.Columns["SEQ_NO"].ColumnEdit = DevXSettings.ColumnEditTextMasking("\\d\\d", 10);
                gridView.Columns["DRW_TYP"].ColumnEdit = DevXSettings.ColumnEditTextMasking("[A-Z, 0-9]+", 10);
                gridView.Columns["CUT_STRT"].ColumnEdit = DevXSettings.ColumnEditTextMasking("\\d\\d:\\d\\d:\\d\\d", 8);
                gridView.Columns["CUT_END"].ColumnEdit = DevXSettings.ColumnEditTextMasking("\\d\\d:\\d\\d:\\d\\d", 8);
                DevXSettings.XgridColAlign(new[] { "SEQ_NO", "DRW_TYP", "CUT_STRT", "CUT_END" }, gridView, HorzAlignment.Center);
                gridView.BestFitColumns();
                gridView.Focus();
                gridView.GridControl.Refresh();
                gridView.RefreshData();
                gridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
                gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                gridView.OptionsSelection.InvertSelection = true;
                gridView.OptionsSelection.EnableAppearanceFocusedCell = true;
                gridView.OptionsView.ShowIndicator = true;

                return gridView;
            }
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("GM_CD", "Code", 0, gridView, MaxWidth: 75);
                DevXSettings.XtraFormatColumn("GM_NM", "Game Type", 1, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
        public class Input
        {
            public string AccountID;
            public string GameID;
            public List<Schedule> Schedules = new List<Schedule>();
            public object iSchedules;

            public static bool validaty(Input input)
            {
                var schedules = input.Schedules;
                if (schedules != null && schedules.Count != 0)
                    input.iSchedules = AggrUtils.Xml.toXmlString(schedules).ToString().Trim();
                else input.iSchedules = null;
                return true;
            }
        }

        [XmlRoot(ElementName = "item")]
        public class Schedule
        {
            [XmlAttribute("SEQ_NO")]
            public string sequenceNo;
            [XmlAttribute("DRW_TYP")]
            public string drawName;
            [XmlAttribute("CUT_STRT")]
            public string cutOffStart;
            [XmlAttribute("CUT_END")]
            public string cutOffEnd;
        }

        public class Db
        {
            public static async Task<(Results result, string message)> execute0a(Input input)
            {
                Input.validaty(input);
                input.iSchedules = input.iSchedules.Str().Replace("\"", "'");
                dynamic result = API.DSpQueryAPI("/api/v1/DrawSchedule/UpdateDrawSchedule", Login.authentication, new Dictionary<string, object>(){
                    { "gameID", input.GameID },
                    { "iSchedule", input.iSchedules },
                });

                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                        return (Results.Success, row["message"].Str());
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}