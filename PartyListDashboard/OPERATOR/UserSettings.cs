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
using System.IO;
using JLIDashboard.Classes.Common.Extensions;
using Comm.Common.Extensions;
using Newtonsoft.Json;
using JLIDashboard._Module;
using static JLIDashboard.OPERATOR.UsrSettings;
using static JLIDashboard.OPERATOR.UsrSettings.Vyw;
using JLIDashboard.Module;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Classes;
using DevExpress.XtraEditors.Controls;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR
{
    public partial class UserSettings : DevExpress.XtraEditors.XtraForm
    {
        private string userid = string.Empty;
        private string strItem = string.Empty;
        private string strRegs = string.Empty;
        public UserSettings()
        {
            InitializeComponent();
        }
        public static DataTable ConvertJsonToDataTable(string xmlFilePath)
        {
            DataTable dt = new DataTable();
            var json = File.ReadAllText(xmlFilePath);
            dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dt;
        }
        private void fillRegionJson(string regionID)
        {
            string spath = AppDomain.CurrentDomain.BaseDirectory;
            string sFilename = string.Format("{0}Resources\\json\\Regions.json", Path.GetFullPath(Path.Combine(spath, @"..\..\")));
            DataTable dt = new DataTable();
            dt = ConvertJsonToDataTable(sFilename);
            if (dt.Rows.Count == 0) return;
            DataView dv = dt.DefaultView;
            dv.RowFilter = " COUNTRY_CODE='63'";
            DataTable dtNew = dv.ToTable();
            ccbxregion.Properties.DataSource = dtNew;
            ccbxregion.Properties.DisplayMember = "REGION_NAME";
            ccbxregion.Properties.ValueMember = "REGION_CODE";
            if (regionID.IsEmpty()) return;

        }

        public void ItemList(string strList, CheckedListBoxControl current_list)
        {
            string itemfile = strList.Str();
            string[] itemfield = itemfile.Split('|');
            foreach (dynamic item in current_list.Items)
            {
                bool hasVal = itemfield.Contains(((object)item.Value).ToString());
                item.CheckState = (hasVal ? CheckState.Checked : CheckState.Unchecked);
            }
        }
        void checkAccess()
        {
            Loc_Region(strRegs, ccbxregion);
            ItemList(strItem, item_checklist);
        }
        public UserSettings setdata()
        {
            this.fillRegionJson("");
            DataTable dt = API.APITableParam($"/api/v1/UserSettings/LoadUserSettings?handler=1", Login.authentication);
            if (dt.Rows.Count > 0)
            {
                strItem =(dt.Rows[0]["ITEM"].Str()=="") ? "" : dt.Rows[0]["ITEM"].Str();
                strRegs = (dt.Rows[0]["LOC_REG"].Str()=="") ? "" : dt.Rows[0]["LOC_REG"].Str();
                checkAccess();
            }
            return this;
        }
        String checkMenu(CheckedListBoxControl xlist)
        {
            string strmenulist = "";
            if (xlist.Items.Count > 0)
            {
                for (int x = 0; x <= xlist.Items.Count - 1; x++)
                {
                    if (xlist.Items[x].CheckState == CheckState.Checked)
                    {
                        strmenulist = strmenulist + "|" + xlist.Items[x].Value.ToString();
                    }
                }
            }
            if (String.IsNullOrEmpty(strmenulist))
            {
                strmenulist = "<empty>";
            }
            else
            {
                strmenulist = strmenulist + "|";
            }
            return strmenulist;
        }
        String checkRegion(CheckedComboBoxEdit control)
        {
            DataTable dt = (DataTable)control.Properties.DataSource;
            string strRegList = "";
            var items = control.Properties.Items;
            if (items.Count > 0)
            {
                for (int x = 0; x < items.Count - 1; x++)
                {

                    if (items[x].CheckState != CheckState.Checked) continue;

                    strRegList = strRegList + "|" + dt.Rows[x]["REGION_CODE"].Str();
                }
                if (String.IsNullOrEmpty(strRegList))
                {
                    strRegList = "<empty>";
                }
                else
                {
                    strRegList = strRegList + "|";
                }
            }

            return strRegList;
        }
        public void Loc_Region(string strList, CheckedComboBoxEdit reg_list)
        {
            string fieldReg = strList.Str().Replace('|', ',');
            reg_list.SetEditValue(fieldReg);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            strItem = checkMenu(item_checklist);
            strRegs = checkRegion(ccbxregion);
            if (String.IsNullOrEmpty(strRegs))
            {
                XtraMessageBox.Show("Please Select Region!");
                return;
            }
            else if (string.IsNullOrEmpty(strItem) || strItem == "<empty>")
            {
                XtraMessageBox.Show("Please Select Item!");
                return;
            }
            else
            {
                StaticSettings.showLoading();
                var res = (Vyw.executex0b(strItem, strRegs)).Result;
                if (res.result == Results.Success)
                {
                    StaticSettings.hideLoading();
                    StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
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
        }

    }

    public partial class UsrSettings
    {
        public class Vyw
        {
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("REGION_INSTANCE", "Region", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
            public static async Task<(Results result, String message)> executex0b(string strItem, string strReg)
            {
                var result = API.DSpQueryAPI("/api/v1/UserSettings/UpdateUserSettings", Login.authentication, new Dictionary<string, object>()
                {
                    {"item",strItem },
                    {"reg",strReg }
                });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
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