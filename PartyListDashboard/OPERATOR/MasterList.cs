using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JLIDashboard.Classes;
using Comm.Common.Extensions;
using static JLIDashboard.OPERATOR._x0j;
using static JLIDashboard.OPERATOR._x0j.Vyw;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard.OPERATOR.frm;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using JLIDashboard.Module;
using DevExpress.XtraGrid;
using System.Net;
using System.Drawing;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR
{
    public partial class MasterList : DevExpress.XtraEditors.XtraForm
    {
        private static DataTable dtReg;
        private static DataTable dtProv;
        private static DataTable dtMun;
        private static DataTable dtBrgy;
        private static DataTable dtNat;
        public MasterList()
        {
            InitializeComponent();
        }
        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null);
            cmsMasterListBtn0a.Visible = hasSelected;
            cmsMasterListBtn0b.Visible = hasSelected;
        }
        private static List<Column_Header> LoadColumnHeader()
        {
            List<Column_Header> lst = new List<Column_Header>();
            lst.Add(new Column_Header { Col_Schema = "Group_NM", Col_NM = "Group" });
            //lst.Add(new Column_Header { Col_Schema = "FRST_NM", Col_NM = "First Name" });
            //lst.Add(new Column_Header { Col_Schema = "LST_NM", Col_NM = "Last Name" });
            lst.Add(new Column_Header { Col_Schema = "FLL_NM", Col_NM = "Name" });
            lst.Add(new Column_Header { Col_Schema = "BLD_TYP", Col_NM = "Blood Type" });
            lst.Add(new Column_Header { Col_Schema = "MOB_NO", Col_NM = "Mobile No." });
            lst.Add(new Column_Header { Col_Schema = "EML_ADD", Col_NM = "email" });
            lst.Add(new Column_Header { Col_Schema = "LOC_REG_NM", Col_NM = "Region" });
            lst.Add(new Column_Header { Col_Schema = "LOC_PROV_NM", Col_NM = "Province" });
            lst.Add(new Column_Header { Col_Schema = "LOC_MUN_NM", Col_NM = "Municipality" });
            lst.Add(new Column_Header { Col_Schema = "LOC_BRGY_NM", Col_NM = "Barangay" });
            lst.Add(new Column_Header { Col_Schema = "GNDR_NM", Col_NM = "Gender" });
            lst.Add(new Column_Header { Col_Schema = "MRTL_STAT_NM", Col_NM = "Marital Satus" });
            lst.Add(new Column_Header { Col_Schema = "CTZNSHP_NM", Col_NM = "Nationality" });
            lst.Add(new Column_Header { Col_Schema = "BRT_DT_NM", Col_NM = "Birthdate" });
            lst.Add(new Column_Header { Col_Schema = "OCCPTN", Col_NM = "Occupation" });
            lst.Add(new Column_Header { Col_Schema = "SKLLS", Col_NM = "Skills" });
            return lst;
        }
        private void MasterList_Load(object sender, EventArgs e)
        {
            dtReg = ConvertJsonToDataTable(string.Format("{0}Resources\\json\\Regions.json", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            dtProv = ConvertJsonToDataTable(string.Format("{0}Resources\\json\\Provinces.json", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            dtMun = ConvertJsonToDataTable(string.Format("{0}Resources\\json\\Municipalities.json", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            dtBrgy = ConvertJsonToDataTable(string.Format("{0}Resources\\json\\Barangay.json", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            dtNat = ConvertJsonToDataTable(string.Format("{0}Resources\\json\\Country.json", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            
            this.Load_ColumFilter();
            Timeout.Set(() => this.Invoke(new Action(() => this.LoadMasterList())), 250);
        }

        private void Load_ColumFilter()
        {
            //Database.displaySearchlookupEdit($"spfn_TableColumn", tsgridcolumn, "Description", "Column");
            tsgridcolumn.Properties.DataSource = LoadColumnHeader().OrderBy(o=>o.Col_NM).ToList();
            tsgridcolumn.Properties.DisplayMember = "Col_NM";
            tsgridcolumn.Properties.ValueMember = "Col_Schema";
            tsgridcolumn.Properties.PopulateViewColumns();
            x0d(tsgridcolumn);
        }
        public static DataTable ConvertJsonToDataTable(string xmlFilePath)
        {
            DataTable dt = new DataTable();
            var json = File.ReadAllText(xmlFilePath);
            dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dt;
        }
        private static string GetStringVal(DataTable dtP, string colName,string colVal,string colRet)
        {
            string strVal = string.Empty;
            string strQuery = colName + "='" + colVal + "'";
            DataTable fDT = dtP.Select(strQuery).CopyToDataTable();
            strVal = fDT.Rows[0][colRet].Str();
            return strVal;
        }
        public void LoadMasterList(bool defFocused = true)
        {
            API.displayAPI("/api/v1/MasterList/LoadMasterList", gridControl1, gridView1, Login.authentication);

            DataTable dt = (DataTable)gridControl1.DataSource;
            if (dt != null)
            {
                foreach (DataRow DR in dt.Rows)
                {
                    DR["LOC_REG_NM"] = (DR["LOC_REG"].Str() == "") ? "" : GetStringVal(dtReg, "REGION_CODE", DR["LOC_REG"].Str(), "REGION_INSTANCE");
                    DR["LOC_PROV_NM"] = (DR["LOC_PROV"].Str() == "") ? "" : GetStringVal(dtProv, "PROVINCE_CODE", DR["LOC_PROV"].Str(), "PROVINCE");
                    DR["LOC_MUN_NM"] = (DR["LOC_MUN"].Str() == "") ? "" : GetStringVal(dtMun, "MUNICIPALITY_CODE", DR["LOC_MUN"].Str(), "MUNICIPALITY");
                    DR["LOC_BRGY_NM"] = (DR["LOC_BRGY"].Str() == "") ? "" : GetStringVal(dtBrgy, "BRGY_CODE", DR["LOC_BRGY"].Str(), "BRGY");
                    DR["CTZNSHP_NM"] = (DR["CTZNSHP"].Str().Trim() == "") ? "" : GetStringVal(dtNat, "alpha_3_code", DR["CTZNSHP"].Str().Trim(), "nationality");
                }
                gridView1.BestFitColumns();
                gridView1.RefreshData();
            }
            dt = (DataTable)gridControl1.DataSource;
            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();
            gridView1.RefreshData();
            gridView1.ClearSelection();
            //gridView1.DataSource = dt;
            if (x0a(gridView1).RowCount != 0 && defFocused)
            {
                this.gridView1.FocusedRowHandle = 0;
            }
        }
        private void cmsMasterListBtn0b_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.GetFocusedDataRow();
            DataRow row = gridView1.GetFocusedDataRow();
            StaticSettings.showLoading();
            var frm = System.Windows.Forms.Application.OpenForms.Singleton<UpdateMasterListDetails>().setData(row,true);
            StaticSettings.hideLoading();
            frm.ShowDialog(this);
            if (!frm.ok) return;
            frm.retData(row);
        }

        private void cmsMasterListBtn0a_Click(object sender, EventArgs e)
        {
            gridView1.RefreshData();
            this.gvFilter();
        }
        private void tbsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            gvFilter();
        }
        private void gvFilter()
        {
            string filterString = string.Empty;
            gridView1.ClearColumnsFilter();
            if (tbsearch.Text.Trim().Str() != string.Empty)
            {
                filterString +="[" + tsgridcolumn.EditValue.Str() + "] LIKE '%" + tbsearch.Text.Trim().Replace("'","'") + "%'";
                gridView1.ActiveFilter.NonColumnFilter = filterString;
            }
        }

        private void tsgridcolumn_EditValueChanged(object sender, EventArgs e)
        {
            tbsearch.Text = string.Empty;
            tbsearch.ReadOnly = true;
            gvFilter();
            if (tsgridcolumn.Text.Trim().Str() != string.Empty)
            {
                tbsearch.ReadOnly = false;
            }
        }
        private DataTable Load_PrintID()
        {
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("COMP_ID", typeof(string));
            dtNew.Columns.Add("BR_CD", typeof(string));
            dtNew.Columns.Add("USR_ID", typeof(string));
            dtNew.Columns.Add("ACT_ID", typeof(string));
            dtNew.Columns.Add("FLL_NM", typeof(string));
            dtNew.Columns.Add("LST_NM", typeof(string));
            dtNew.Columns.Add("FRST_NM", typeof(string));
            dtNew.Columns.Add("NXTKN_NM", typeof(string));
            dtNew.Columns.Add("NXTKN_NO", typeof(string));
            dtNew.Columns.Add("PRSNT_ADDR", typeof(string));
            dtNew.Columns.Add("LOC_MUN_NM", typeof(string));
            dtNew.Columns.Add("LOC_PROV_NM", typeof(string));
            dtNew.Columns.Add("SUBSCR_TYP", typeof(string));
            dtNew.Columns.Add("PRF_PIC", typeof(string));
            dtNew.Columns.Add("SIGNATUREID", typeof(string));
            //foreach (int rowindex in this.gridView1.GetSelectedRows())
            foreach (int rowindex in this.gridView1.GetSelectedRows())
            {
                DataRow DR = dtNew.NewRow();
                var sPath = string.Empty;
                var sigPath = string.Empty;
                DR["COMP_ID"] = this.gridView1.GetRowCellDisplayText(rowindex, "COMP_ID");
                DR["BR_CD"] = this.gridView1.GetRowCellDisplayText(rowindex, "BR_CD");
                DR["USR_ID"] = this.gridView1.GetRowCellDisplayText(rowindex, "USR_ID");
                DR["ACT_ID"] = this.gridView1.GetRowCellDisplayText(rowindex, "ACT_ID");
                DR["FLL_NM"] = this.gridView1.GetRowCellDisplayText(rowindex, "FLL_NM");
                DR["FRST_NM"] = this.gridView1.GetRowCellDisplayText(rowindex, "FRST_NM");
                DR["LST_NM"] = this.gridView1.GetRowCellDisplayText(rowindex, "LST_NM");
                DR["NXTKN_NM"] = this.gridView1.GetRowCellDisplayText(rowindex, "NXTKN_NM");
                DR["NXTKN_NO"] = this.gridView1.GetRowCellDisplayText(rowindex, "NXTKN_NO");
                DR["PRSNT_ADDR"] = this.gridView1.GetRowCellDisplayText(rowindex, "PRSNT_ADDR");
                DR["LOC_MUN_NM"] = this.gridView1.GetRowCellDisplayText(rowindex, "LOC_MUN_NM");
                DR["LOC_PROV_NM"] = this.gridView1.GetRowCellDisplayText(rowindex, "LOC_PROV_NM");
                DR["SUBSCR_TYP"] = this.gridView1.GetRowCellDisplayText(rowindex, "SUBSCR_TYP");
                sPath = this.gridView1.GetRowCellDisplayText(rowindex, "PRF_PIC");
                sigPath = this.gridView1.GetRowCellDisplayText(rowindex, "SIGNATUREID");
                if (!sPath.Str().IsEmpty())
                {
                        DR["PRF_PIC"] = sPath;
                    
                }
                else
                {
                    sPath = AppDomain.CurrentDomain.BaseDirectory;
                    string FName = string.Format("{0}Resources\\avatar1.jpg", Path.GetFullPath(Path.Combine(sPath, @"..\..\")));
                    string fileName = FName;
                    DR["PRF_PIC"] = fileName;
                }
                if (!sigPath.Str().IsEmpty())
                {
                    DR["SIGNATUREID"] = sigPath;
                }
                //else
                //{
                //    sigPath = AppDomain.CurrentDomain.BaseDirectory;
                //    string FName = string.Format("{0}Resources\\avatar1.jpg", Path.GetFullPath(Path.Combine(sPath, @"..\..\")));
                //    string fileName = FName;
                //    DR["SIGNATUREID"] = fileName;
                //}
                dtNew.Rows.Add(DR);
            }
            return dtNew;
        }
        private void cmsPrintProfiling_Click(object sender, EventArgs e)
        {
            DataTable dt = Load_PrintID();
            StaticSettings.showLoading();
            var frm = System.Windows.Forms.Application.OpenForms.Singleton<GeneratID>().setData(dt, true);
            StaticSettings.hideLoading();
            frm.ShowDialog(this);
            if (!frm.ok) return;
            Timeout.Set(() => this.Invoke(new Action(() => this.LoadMasterList())), 250);
        }

        private void cmsPrintProfilingMul_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;
            StaticSettings.showLoading();
            var frm = System.Windows.Forms.Application.OpenForms.Singleton<GeneratID>().setData(dt, true);
            StaticSettings.hideLoading();
            frm.ShowDialog(this);
            if (!frm.ok) return;
            Timeout.Set(() => this.Invoke(new Action(() => this.LoadMasterList())), 250);
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string dtstr = view.GetRowCellDisplayText(e.RowHandle, view.Columns["EXPRDATE"]);
                string strExpiry = (view.GetRowCellDisplayText(e.RowHandle, view.Columns["EXPRDATE"]) == "") ? string.Empty : view.GetRowCellDisplayText(e.RowHandle, view.Columns["EXPRDATE"]);
                if (!strExpiry.IsEmpty())
                {
                    string strDate = Convert.ToDateTime(strExpiry).ToString("dd-MMM-yyyy");
                    DateTime dtExpiry = DateTime.ParseExact(strDate,"dd-MMM-yyyy", System.Globalization.CultureInfo.CurrentCulture);
                    if (dtExpiry < DateTime.Now)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
                else
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
    }
    public class _x0j
    {
        public class Vyw
        {
            
            public static GridView x0a(GridView gridView)
            {
                if (gridView.RowCount != 0)
                {
                    gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("USR_ID", "User ID", 1, gridView, 100);
                    DevXSettings.XtraFormatColumn("VALTO_DT", "Expiry Date", 2, gridView, 80);
                    DevXSettings.XtraFormatColumn("Group_NM", "Group", 3, gridView, 50);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Name", 5, gridView, 120);
                    DevXSettings.XtraFormatColumn("BLD_TYP", "Blood Type", 7, gridView, 80);
                    DevXSettings.XtraFormatColumn("MOB_NO", "Mobile No.", 8, gridView, 120);
                    DevXSettings.XtraFormatColumn("EML_ADD", "email", 9, gridView, 120);
                    DevXSettings.XtraFormatColumn("HM_ADDR", "Home Address", 10, gridView, 250);
                    DevXSettings.XtraFormatColumn("PRSNT_ADDR", "Present Address", 11, gridView, 250);
                    DevXSettings.XtraFormatColumn("LOC_REG_NM", "Region", 12, gridView, 200);
                    DevXSettings.XtraFormatColumn("LOC_PROV_NM", "Province", 13, gridView, 120);
                    DevXSettings.XtraFormatColumn("LOC_MUN_NM", "Municipality", 14, gridView, 120);
                    DevXSettings.XtraFormatColumn("LOC_BRGY_NM", "Barangay", 15, gridView, 120);
                    DevXSettings.XtraFormatColumn("GNDR_NM", "Gender", 16, gridView, 120);
                    DevXSettings.XtraFormatColumn("MRTL_STAT_NM", "Status", 17, gridView, 120);
                    DevXSettings.XtraFormatColumn("CTZNSHP_NM", "Nationality", 18, gridView, 120);
                    DevXSettings.XtraFormatColumn("BRT_DT_NM", "Birthdate", 19, gridView, 120); //BRT_DT
                    DevXSettings.XtraFormatColumn("OCCPTN", "Occupation", 20, gridView, 120);
                    DevXSettings.XtraFormatColumn("SKLLS", "Skills", 21, gridView, 120);
                }
                return gridView;
            }
            public static SearchLookUpEdit x0b(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("REGION_INSTANCE", "Region", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0c(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("ID", "No", 1, gridview);
                DevXSettings.XtraFormatColumn("Name", "Subscription Type", 2, gridview);
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0d(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("Col_NM", "Col_Schema", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
        }
        public class Column_Header
        {
            public string Col_Schema { get; set; }
            public string Col_NM { get; set; }
        }
    }
}