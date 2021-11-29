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

using static JLIDashboard.OPERATION._x0h;
using static JLIDashboard.OPERATION._x0h.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using System.Xml.Serialization;
using JLIDashboard.Classes.Common;
using JLIDashboard._Module;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATION
{
    public partial class TextBlasting : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public TextBlasting()
        {
            InitializeComponent();
        }
        private void TextBlast_Load(object sender, EventArgs e)
        {
            ok = false;
            Timeout.Set(() => this.Invoke(new Action(() => this.loadTableWProgress())), 250);
        }
        public TextBlasting setData()
        {
            return this;
        }

        private void loadTableWProgress()
        {
            StaticSettings.showLoading();
            this.loadTable();
            StaticSettings.hideLoading();
        }
        private void loadTable()
        {
            API.displayAPIParam("/api/v1/TextBlasting/MobileNumberList", gridControl1, gridView1, Login.authentication);
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
            string txtmsg = this.tbtxt.Text.Trim();
            if (txtmsg.IsEmpty())
            {
                StaticSettings.XtraMessage("Please enter text message", MessageBoxIcon.Hand);
                this.tbtxt.Focus();
                return false;
            }

            MobileNumber item = null;
            List<MobileNumber> MobileNumbers = new List<MobileNumber>();
            foreach (int rowindex in this.gridView1.GetSelectedRows())
            {
                MobileNumbers.Add(item = new MobileNumber());
                item.mobileNumber = this.gridView1.GetRowCellDisplayText(rowindex, "MOB_NO");
            }
            if (MobileNumbers.Count < 1)
            {
                StaticSettings.XtraMessage("Please select recipient", MessageBoxIcon.Hand);
                this.tbtxt.Focus();
                return false;
            }

            form.MobileNumbers = MobileNumbers;
            form.TextMessage = txtmsg;
            return true;
        }
    }
    public partial class _x0h
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("ACT_ID", "Account#", 0, gridView, MaxWidth: 150);
                DevXSettings.XtraFormatColumn("ACT_NM", "Name", 2, gridView);
                DevXSettings.XtraFormatColumn("MOB_NO", "Mobile Number", 3, gridView);
                gridView.BestFitColumns();
                gridView.ClearSelection();
                return gridView;
            }
        }

        public class Input
        {
            public string TextMessage;
            public string iMobileNumbers;
            public List<MobileNumber> MobileNumbers = new List<MobileNumber>();

            public static bool validity(Input input)
            {
                var mobileNumbers = input.MobileNumbers;
                if (mobileNumbers != null && mobileNumbers.Count != 0)
                    input.iMobileNumbers = AggrUtils.Xml.toXmlString(mobileNumbers).ToString().Trim();
                else input.iMobileNumbers = null;

                return true;
            }
        }

        [XmlRoot(ElementName = "item")]
        public class MobileNumber
        {
            [XmlAttribute("MOB_NO")]
            public string mobileNumber;
        }
        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(Input input)
            {
                Input.validity(input);
                input.iMobileNumbers = input.iMobileNumbers.Replace("\"", "\"");
                var result = API.DSpQueryAPI("/api/v1/TextBlasting/TextBlasting",Login.authentication, new Dictionary<string, object>(){
                    { "textMessage", input.TextMessage },
                    { "iMobileNumber", input.iMobileNumbers },
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str().Trim();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, row["message"].Str());
                    }
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
    }
}