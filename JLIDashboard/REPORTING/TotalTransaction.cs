using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JLIDashboard.Classes;
using Comm.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using DevExpress.Utils;
using JLIDashboard.Classes.Common;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard.Module;


using System.Xml.Serialization;
using static JLIDashboard.REPORTING._x0b;
using static JLIDashboard.REPORTING._x0b.VywA;
using Newtonsoft.Json;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Customization.ViewInfo;
using DevExpress.XtraPrinting;
using System.Data.SqlClient;
using System.Diagnostics;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.REPORTING
{
    public partial class TotalTransaction : DevExpress.XtraEditors.XtraForm
    {
        private static DataTable dtReg;
        private static DataTable dtProv;
        private static DataTable dtMun;
        private static DataTable dtBrgy;
        private FilterA filter = new FilterA();
        public TotalTransaction()
        {
            InitializeComponent();
            tbdatefrom.Properties.MaxValue = DateTime.Today;
        }
        public static DataTable ConvertJsonToDataTable(string xmlFilePath)
        {
            DataTable dt = new DataTable();
            var json = File.ReadAllText(xmlFilePath);
            dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dt;
        }
        private void ccbxgmtyp_EditValueChanged(object sender, EventArgs e)
        {
            var gmtyps = ccbxgmtyp.GetSelectedDataRows().Select((row) => row["GM_ID"].Str()).ToArray();
            var igmtyps = (gmtyps.Length == 0 ? "" : AggrUtils.Xml.toXmlString(XItemA.AsList(gmtyps)).ToString());
            ccbxdrawsched.SetEditValue(null);
            ccbxdrawsched.DeselectAll();
            API.displayCheckedcomboboxEditAPI("/api/v1/GameBetsHistory/LoadDrawSchedule", Login.authentication, ccbxdrawsched, "DRW_TYP", "DRW_TYP", new Dictionary<string, object>()
            {
                {"igmtyps", igmtyps },
                {"gmtyp", (gmtyps.Length < 2 ? 0 : 1) }
            });
        }
        private void TotalTransaction_Load(object sender, EventArgs e)
        {

            btngenerate.Location = new Point(539, 27);
            btnexportxl.Location = new Point(540, 55);
            cboReportType.Size = new Size(1280, 101);
            dtReg = ConvertJsonToDataTable(string.Format("{0}Resources\\json\\Regions.json", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            dtProv = ConvertJsonToDataTable(string.Format("{0}Resources\\json\\Provinces.json", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            dtMun = ConvertJsonToDataTable(string.Format("{0}Resources\\json\\Municipalities.json", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            dtBrgy = ConvertJsonToDataTable(string.Format("{0}Resources\\json\\Barangay.json", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))));
            tbdatefrom.EditValue = tbdateto.EditValue = DateTime.Now;
            this.fillGameType();
        }
        private void fillGameType()
        {
            API.displayCheckedcomboboxEditAPIParam("/api/v1/DrawSchedule/LoadGameType", Login.authentication, ccbxgmtyp, "GM_NM", "GM_ID");
            ccbxgmtyp.EditValue = null;
        }
        private void btngenerate_Click(object sender, EventArgs e)
        {
            var gameIDs = ccbxgmtyp.GetSelectedDataRows();
            if (cbReport.Text.Trim().Str() == "Select Report")
            {
                StaticSettings.XtraMessage("Please select Report", MessageBoxIcon.Exclamation);
                cbReport.Focus();
                return;
            }
            if (gameIDs.Length == 0)
            {
                StaticSettings.XtraMessage("Please select game type", MessageBoxIcon.Exclamation);
                ccbxgmtyp.Focus();
                return;
            }
            var drawSchedules = ccbxdrawsched.GetSelectedDataRows();
            if (drawSchedules.Length == 0)
            {
                StaticSettings.XtraMessage("Please select draw schedule", MessageBoxIcon.Exclamation);
                ccbxdrawsched.Focus();
                return;
            }

            //gridControl1.DataSource = null;
            filter.Gametypes = drawSchedules.Select((row) => (new XItem0B() { GameID = row["GM_TYP"].Str(), DrawSchedule = row["DRW_TYP"].Str() })).ToList();
            filter.DateFrom = tbdatefrom.EditValue.Str();
            filter.DateTo = tbdateto.EditValue.Str();
            FilterA.validityA(filter);
            this.LoadGenTable();
        }
        private void LoadGenTable()
        {
            StaticSettings.showLoading();
            this.GenTable();
            StaticSettings.hideLoading();
        }
        public static List<string> Load_ColumnHeader(GridControl cont)
        {
            List<string> colHeader = new List<string>();
            DataTable dt = (DataTable)cont.DataSource;
            if (dt != null)
            {
                foreach (DataColumn DC in dt.Columns)
                {
                    colHeader.Add(DC.Str());
                }
            }
            return colHeader;
        }
        public static List<string> Get_ColumnHeader(DataTable dt)
        {
            List<string> colHeader = new List<string>();
            if (dt != null)
            {
                foreach (DataColumn DC in dt.Columns)
                {
                    colHeader.Add(DC.Str());
                }
            }
            return colHeader;
        }
        private void GenTable()
        {

            pivotGridControl1.Visible = false;
            DataTable dt = new DataTable();
            dt = null;
            List<string> colHeader = new List<string>();
            if (cbReport.EditValue.Str() == "Sales Transaction by Player")
            {
                pivotGridControl1.Visible = false;
                dt = API.APITable("/api/v1/UserStatistics/SalesTransactionbyDate", Login.authentication, new Dictionary<string, object>()
                {
                    {"dateFrom", filter.DateFrom },
                    {"dateTo", filter.DateTo },
                    {"iGameTypes", filter.iGameTypes }
                });
                Load_PivotTable(pivotGridControl1, cbReport.EditValue.Str(), dt);
                pivotGridControl1.Visible = true;

            }
            else if (cbReport.EditValue.Str() == "Sales Transaction by Date")
            {
                pivotGridControl1.Visible = false;
                //dt = GetDatable($"exec dbo.spfn_ACBBDB0C '{Login.compid}', '{Login.brcode}', '{filter.iGameTypes}', '{filter.DateFrom}', '{filter.DateTo}' ");
                dt = API.APITable("/api/v1/UserStatistics/SalesTransactionbyDate", Login.authentication, new Dictionary<string, object>()
                {
                    {"dateFrom", filter.DateFrom },
                    {"dateTo", filter.DateTo },
                    {"iGameTypes", filter.iGameTypes }
                });
                Load_PivotTable(pivotGridControl1, cbReport.EditValue.Str(), dt);
                pivotGridControl1.Visible = true;
            }
            else if (cbReport.EditValue.Str() == "Total Ticket Generated by Player")
            {
                pivotGridControl1.Visible = false;
                dt = API.APITable("/api/v1/UserStatistics/TotalTicketGeneratedbyDate", Login.authentication, new Dictionary<string, object>()
                {
                    {"dateFrom", filter.DateFrom },
                    {"dateTo", filter.DateTo },
                    {"iGameTypes", filter.iGameTypes }
                });
                Load_PivotTable(pivotGridControl1, cbReport.EditValue.Str(), dt);
                pivotGridControl1.Visible = true;
            }
            else if (cbReport.EditValue.Str() == "Total Ticket Generated by Date")
            {
                pivotGridControl1.Visible = false;
                dt = API.APITable("/api/v1/UserStatistics/TotalTicketGeneratedbyDate", Login.authentication, new Dictionary<string, object>()
                {
                    {"dateFrom", filter.DateFrom },
                    {"dateTo", filter.DateTo },
                    {"iGameTypes", filter.iGameTypes }
                });
                Load_PivotTable(pivotGridControl1, cbReport.EditValue.Str(), dt);
                pivotGridControl1.Visible = true;
            }
            else if (cbReport.EditValue.Str() == "Total Winning Amount by Date")
            {
                pivotGridControl1.Visible = false;
                dt = API.APITable("/api/v1/UserStatistics/TotalWinningAmountbyDate", Login.authentication, new Dictionary<string, object>()
                {
                    {"dateFrom", filter.DateFrom },
                    {"dateTo", filter.DateTo },
                    {"iGameTypes", filter.iGameTypes }
                });
                Load_PivotTable(pivotGridControl1, cbReport.EditValue.Str(), dt);
                pivotGridControl1.Visible = true;

            }
            else if (cbReport.EditValue.Str() == "Total Sales")
            {
                pivotGridControl1.Visible = false;
                dt = API.APITable("/api/v1/UserStatistics/TotalSales", Login.authentication, new Dictionary<string, object>()
                {
                    {"dateFrom", filter.DateFrom },
                    {"dateTo", filter.DateTo },
                    {"iGameTypes", filter.iGameTypes },
                    {"region", tsregion.EditValue.Str().Trim() },
                    {"province", tsprovince.EditValue.Str().Trim() },
                    {"municipality", tsmunicipality.EditValue.Str().Trim() },
                    {"barangay", tsBrgy.EditValue.Str().Trim() }
                });
                if (dt != null)
                {
                    foreach (DataRow DR in dt.Rows)
                    {
                        DR["LOC_REG_NM"] = (DR["ACT_REG"].Str() == "") ? "" : GetStringVal(dtReg, "REGION_CODE", DR["ACT_REG"].Str(), "REGION_INSTANCE");
                        DR["LOC_PROV_NM"] = (DR["ACT_PROV"].Str() == "") ? "" : GetStringVal(dtProv, "PROVINCE_CODE", DR["ACT_PROV"].Str(), "PROVINCE");
                        DR["LOC_MUN_NM"] = (DR["ACT_MUN"].Str() == "") ? "" : GetStringVal(dtMun, "MUNICIPALITY_CODE", DR["ACT_MUN"].Str(), "MUNICIPALITY");
                        DR["LOC_BRGY_NM"] = (DR["ACT_BRGY"].Str() == "") ? "" : GetStringVal(dtBrgy, "BRGY_CODE", DR["ACT_BRGY"].Str(), "BRGY");
                    }
                }
                Load_PivotTable(pivotGridControl1, cbReport.EditValue.Str(), dt);
                pivotGridControl1.Visible = true;
            }
            else if (cbReport.EditValue.Str() == "Sales Transaction Sheet")
            {
                pivotGridControl1.Visible = false;
                dt = API.APITable("/api/v1/UserStatistics/SalesTransactionSheet", Login.authentication, new Dictionary<string, object>()
                {
                    {"dateFrom", filter.DateFrom },
                    {"dateTo", filter.DateTo },
                    {"iGameTypes", filter.iGameTypes }
                });
                Load_PivotTable(pivotGridControl1, cbReport.EditValue.Str(), dt);
                pivotGridControl1.Visible = true;
            }
        }
        private static string GetStringVal(DataTable dtP, string colName, string colVal, string colRet)
        {
            string strVal = string.Empty;
            string strQuery = colName + "='" + colVal + "'";
            DataTable fDT = dtP.Select(strQuery).CopyToDataTable();
            strVal = fDT.Rows[0][colRet].Str();
            return strVal;
        }
        private PivotGridControl Load_PivotTable(PivotGridControl pvt, string rpt, DataTable dt)
        {
            pvt.OptionsView.ShowFilterHeaders = false;
            pvt.OptionsView.ShowDataHeaders = false;
            pvt.OptionsView.ShowRowHeaders = false;
            pvt.OptionsView.ShowRowTotals = false;
            pvt.OptionsView.ShowRowGrandTotalHeader = false;
            pvt.OptionsView.ShowRowHeaders = false;
            pvt.OptionsView.ShowRowTotals = false;
            pvt.OptionsView.ShowColumnGrandTotalHeader = false;
            pvt.OptionsView.ShowColumnGrandTotals = false;
            pvt.OptionsView.ShowColumnHeaders = false;
            pvt.OptionsView.ShowColumnTotals = false;
            pvt.Fields.Clear();
            if (dt.Rows.Count > 0)
            {
                pvt.OptionsView.ShowFilterHeaders = true;
                pvt.OptionsView.ShowDataHeaders = false;
                pvt.OptionsView.ShowRowHeaders = true;
                pvt.OptionsView.ShowRowTotals = true;
                pvt.OptionsView.ShowRowGrandTotalHeader = true;
                pvt.OptionsView.ShowRowHeaders = true;
                pvt.OptionsView.ShowRowTotals = true;
                pvt.OptionsView.ShowColumnGrandTotalHeader = true;
                pvt.OptionsView.ShowColumnGrandTotals = true;
                pvt.OptionsView.ShowColumnHeaders = true;
                pvt.OptionsView.ShowColumnTotals = true;
                if (rpt == "Sales Transaction by Player" || rpt == "Total Ticket Generated by Player")
                {
                    pvt.Visible = true;
                    pvt.DataSource = dt;
                    pvt.OptionsBehavior.SortBySummaryDefaultOrder = PivotSortBySummaryOrder.Descending;
                    PivotGridField fieldAccount = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 1,
                        Caption = "Account Name",
                        FieldName = "FLL_NM",
                        Width = 400,
                    };
                    PivotGridField fieldGenCoor = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 2,
                        Caption = "Gen Coor",
                        FieldName = "GEN_COORD_NM",
                        Width = 400,
                    };
                    PivotGridField fieldCoor = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 3,
                        Caption = "Coor",
                        FieldName = "COORD_NM",
                        Width = 400,
                    };
                    PivotGridField fieldDate = new PivotGridField()
                    {
                        Area = PivotArea.ColumnArea,
                        Caption = "Date",
                        FieldName = "RGS_TRN_TS",
                        Width = 400,
                    };
                    PivotGridField fieldDrawType = new PivotGridField()
                    {
                        Area = PivotArea.ColumnArea,
                        Caption = "Draw Type",
                        FieldName = "DRW_TYP",
                        Width = 400
                    };
                    PivotGridField fieldTotal = new PivotGridField();
                    if (rpt == "Total Ticket Generated by Player")
                    {
                        fieldTotal = new PivotGridField()
                        {
                            Area = PivotArea.DataArea,
                            Caption = "Total Ticket",
                            FieldName = "TOT_TRN",
                            Width = 400,
                        };
                        fieldTotal.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldTotal.CellFormat.FormatString = "#,##0.00";
                    }
                    else if (rpt == "Sales Transaction by Player")
                    {
                        fieldTotal = new PivotGridField()
                        {
                            Area = PivotArea.DataArea,
                            Caption = "Total Gross",
                            FieldName = "TOT_AMT_BET",
                            Width = 400,
                        };
                        fieldTotal.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        fieldTotal.CellFormat.FormatString = "#,##0.00";
                    }


                    //fieldTotal.Options.ShowGrandTotal = true;
                    fieldAccount.Options.AllowExpand = DefaultBoolean.False;
                    fieldGenCoor.Options.AllowExpand = DefaultBoolean.False;
                    fieldCoor.Options.AllowExpand = DefaultBoolean.False;
                    fieldDate.Options.AllowExpand = DefaultBoolean.False;
                    //fieldType.SortOrder = PivotSortOrder.Descending;

                    //fieldAccount.SortBySummaryInfo.Conditions.Clear();
                    //fieldAccount.SortBySummaryInfo.Field = fieldTotal;
                    //pvt.OptionsBehavior.SortBySummaryDefaultOrder = PivotSortBySummaryOrder.Descending;
                    //fieldAccount.SortBySummaryInfo.Field = fieldDate;

                    pvt.Fields.AddRange(new PivotGridField[] { fieldDate, fieldAccount, fieldGenCoor, fieldCoor, fieldTotal, fieldDrawType });
                    pvt.OptionsView.ShowRowTotals = true;
                    pvt.OptionsView.ShowRowGrandTotals = true;
                    pvt.OptionsView.ShowColumnTotals = false;
                    pvt.OptionsView.ShowFilterHeaders = true;
                }
                else if (rpt == "Total Sales")
                {
                    pvt.Visible = true;
                    pvt.DataSource = dt;
                    pvt.OptionsBehavior.SortBySummaryDefaultOrder = PivotSortBySummaryOrder.Descending;
                    PivotGridField fieldAccount = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 1,
                        Caption = "Account Name",
                        FieldName = "FLL_NM",
                        Width = 400,
                    };
                    PivotGridField fieldGenCoor = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 2,
                        Caption = "Gen Coor",
                        FieldName = "GEN_COORD_NM",
                        Width = 400,
                    };
                    PivotGridField fieldCoor = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 3,
                        Caption = "Coor",
                        FieldName = "COORD_NM",
                        Width = 400,
                    };
                    PivotGridField fieldReg = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 4,
                        Caption = "Region",
                        FieldName = "LOC_REG_NM",
                        Width = 400,
                    };
                    PivotGridField fieldProv = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 5,
                        Caption = "Province",
                        FieldName = "LOC_PROV_NM",
                        Width = 400,
                    };
                    PivotGridField fieldMun = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 6,
                        Caption = "Municipality",
                        FieldName = "LOC_MUN_NM",
                        Width = 400,
                    };
                    PivotGridField fieldBrgy = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 7,
                        Caption = "Barangay",
                        FieldName = "LOC_BRGY_NM",
                        Width = 400,
                    };
                    PivotGridField fieldDate = new PivotGridField()
                    {
                        Area = PivotArea.ColumnArea,
                        Caption = "Date",
                        FieldName = "RGS_TRN_TS",
                        Width = 400,
                    };
                    PivotGridField fieldDrawType = new PivotGridField()
                    {
                        Area = PivotArea.ColumnArea,
                        Caption = "Draw Type",
                        FieldName = "DRW_TYP",
                        Width = 400
                    };
                    PivotGridField fieldTotal = new PivotGridField()
                    {
                        Area = PivotArea.DataArea,
                        Caption = "Total Gross",
                        FieldName = "TOT_AMT_BET",
                        Width = 400,
                    };
                    fieldTotal.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fieldTotal.CellFormat.FormatString = "#,##0.00";

                    PivotGridField filterAccount = new PivotGridField()
                    {
                        Area = PivotArea.FilterArea,
                        Caption = "Account Name",
                        FieldName = "FLL_NM",
                        Width = 400,
                    };
                    //fieldTotal.Options.ShowGrandTotal = true;
                    fieldAccount.Options.AllowExpand = DefaultBoolean.False;
                    fieldGenCoor.Options.AllowExpand = DefaultBoolean.False;
                    fieldCoor.Options.AllowExpand = DefaultBoolean.False;
                    filterAccount.Options.AllowExpand = DefaultBoolean.False;
                    fieldDate.Options.AllowExpand = DefaultBoolean.False;
                    fieldReg.Options.AllowExpand = DefaultBoolean.False;
                    fieldProv.Options.AllowExpand = DefaultBoolean.False;
                    fieldMun.Options.AllowExpand = DefaultBoolean.False;
                    fieldBrgy.Options.AllowExpand = DefaultBoolean.False;
                    //fieldType.SortOrder = PivotSortOrder.Descending;

                    //fieldAccount.SortBySummaryInfo.Field = fieldDate;

                    pvt.Fields.AddRange(new PivotGridField[] { filterAccount, fieldDate, fieldAccount, fieldGenCoor, fieldCoor, fieldReg, fieldProv, fieldMun, fieldBrgy, fieldTotal, fieldDrawType });
                    pvt.OptionsView.ShowRowTotals = true;
                    pvt.OptionsView.ShowRowGrandTotals = true;
                    pvt.OptionsView.ShowColumnTotals = false;
                    pvt.OptionsView.ShowFilterHeaders = false;
                }
                else if (rpt == "Sales Transaction by Date" || rpt == "Total Ticket Generated by Date")
                {

                    pvt.Visible = true;
                    pvt.DataSource = dt;
                    pvt.OptionsBehavior.SortBySummaryDefaultOrder = PivotSortBySummaryOrder.Descending;

                    PivotGridField fieldDate = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        Caption = "Date",
                        FieldName = "RGS_TRN_TS",
                        Width = 400,
                        SortOrder = PivotSortOrder.Descending,
                    };
                    PivotGridField fieldDrawType = new PivotGridField()
                    {
                        Area = PivotArea.ColumnArea,
                        Caption = "Draw Type",
                        FieldName = "DRW_TYP",
                        Width = 400
                    };
                    PivotGridField fieldTotal = new PivotGridField();
                    if (rpt == "Sales Transaction by Date")
                    {
                        fieldTotal = new PivotGridField()
                        {
                            Area = PivotArea.DataArea,
                            Caption = "Total Gross",
                            FieldName = "TOT_AMT_BET",
                            Width = 400,
                        };
                    }
                    else if (rpt == "Total Ticket Generated by Date")
                    {
                        fieldTotal = new PivotGridField()
                        {
                            Area = PivotArea.DataArea,
                            Caption = "Total Ticket",
                            FieldName = "TOT_TRN",
                            Width = 400,
                        };
                    }

                    fieldTotal.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fieldTotal.CellFormat.FormatString = "#,##0.00";
                    //fieldTotal.Options.ShowGrandTotal = true;
                    fieldDate.Options.AllowExpand = DefaultBoolean.False;
                    //fieldType.SortOrder = PivotSortOrder.Descending;

                    //fieldAccount.SortBySummaryInfo.Field = fieldDate;

                    pvt.Fields.AddRange(new PivotGridField[] { fieldDate, fieldTotal, fieldDrawType });
                    pvt.OptionsView.ShowRowTotals = true;
                    pvt.OptionsView.ShowRowGrandTotals = true;
                    pvt.OptionsView.ShowColumnTotals = false;
                    pvt.OptionsView.ShowFilterHeaders = false;
                }
                else if (rpt == "Sales Transaction Sheet")
                {
                    pvt.DataSource = dt;
                    PivotGridField fieldAccount = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 1,
                        Caption = "Account Name",
                        FieldName = "FLL_NM",
                        Width = 400
                    };
                    PivotGridField fieldGenCoor = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 2,
                        Caption = "Gen Coor",
                        FieldName = "GEN_COORD_NM",
                        Width = 400
                    };
                    PivotGridField fieldCoor = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 3,
                        Caption = "Coor",
                        FieldName = "COORD_NM",
                        Width = 400
                    };
                    PivotGridField fieldType = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 4,
                        Caption = "Type",
                        FieldName = "TYPE",
                        Width = 400
                    };
                    PivotGridField fieldDate = new PivotGridField()
                    {
                        Area = PivotArea.ColumnArea,
                        Caption = "Date",
                        FieldName = "RGS_TRN_TS",
                        Width = 400
                    };
                    PivotGridField fieldTotal = new PivotGridField()
                    {
                        Area = PivotArea.DataArea,
                        Caption = "Total Ticket and Gross",
                        FieldName = "TOTAL",
                        Width = 400
                    };

                    fieldTotal.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fieldTotal.CellFormat.FormatString = "#,##0.00";
                    fieldAccount.Options.AllowExpand = DefaultBoolean.False;
                    fieldGenCoor.Options.AllowExpand = DefaultBoolean.False;
                    fieldCoor.Options.AllowExpand = DefaultBoolean.False;
                    fieldType.Options.AllowExpand = DefaultBoolean.False;
                    fieldType.SortOrder = PivotSortOrder.Descending;
                    pvt.Fields.AddRange(new PivotGridField[] { fieldDate, fieldAccount, fieldGenCoor, fieldCoor, fieldType, fieldTotal });
                    pvt.OptionsView.ShowRowTotals = false;
                    pvt.OptionsView.ShowRowGrandTotals = false;
                    pvt.OptionsView.ShowFilterHeaders = false;
                    pvt.OptionsBehavior.SortBySummaryDefaultOrder = PivotSortBySummaryOrder.Descending;
                }
                else if (rpt == "Total Winning Amount by Date")
                {
                    pvt.DataSource = dt;
                    PivotGridField fieldDate = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 1,
                        Caption = "Date",
                        FieldName = "RGS_TRN_TS",
                        Width = 400
                    };
                    PivotGridField fieldNumRes = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 2,
                        Caption = "Result Combination",
                        FieldName = "NUM_RES",
                        Width = 400
                    };
                    PivotGridField fieldTot_Rmb_Cnt = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 3,
                        Caption = "Ramble Winners",
                        FieldName = "TOT_CNT_RMBL_WNRS",
                        Width = 400
                    };
                    PivotGridField fieldTot_Strght_Cnt = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 4,
                        Caption = "Straight Winners",
                        FieldName = "TOT_CNT_STRGHT_WNRS",
                        Width = 400
                    };
                    PivotGridField fieldDrawType = new PivotGridField()
                    {
                        Area = PivotArea.RowArea,
                        AreaIndex = 5,
                        Caption = "Draw Type",
                        FieldName = "DRW_TYP",
                        Width = 400
                    };
                    PivotGridField fieldWinTStrghtAmt = new PivotGridField()
                    {
                        Area = PivotArea.DataArea,
                        AreaIndex = 6,
                        Caption = "Straight Amount",
                        FieldName = "WIN_STRGHT_AMT",
                        Width = 400
                    };
                    PivotGridField fieldWinTRmbltAmt = new PivotGridField()
                    {
                        Area = PivotArea.DataArea,
                        AreaIndex = 7,
                        Caption = "Ramble Amount",
                        FieldName = "WIN_RMB_AMT",
                        Width = 400
                    };
                    PivotGridField fieldWinTotAmt = new PivotGridField()
                    {
                        Area = PivotArea.DataArea,
                        AreaIndex = 8,
                        Caption = "Total Amount",
                        FieldName = "WIN_TOT_AMT",
                        Width = 400
                    };

                    fieldWinTotAmt.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fieldWinTotAmt.CellFormat.FormatString = "#,##0.00";

                    fieldWinTStrghtAmt.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fieldWinTStrghtAmt.CellFormat.FormatString = "#,##0.00";

                    fieldWinTRmbltAmt.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fieldWinTRmbltAmt.CellFormat.FormatString = "#,##0.00";

                    fieldDate.Options.AllowExpand = DefaultBoolean.False;
                    fieldTot_Rmb_Cnt.Options.AllowExpand = DefaultBoolean.False;
                    fieldTot_Strght_Cnt.Options.AllowExpand = DefaultBoolean.False;
                    fieldNumRes.Options.AllowExpand = DefaultBoolean.False;
                    fieldDrawType.Options.AllowExpand = DefaultBoolean.False;
                    fieldWinTotAmt.Options.AllowExpand = DefaultBoolean.False;
                    fieldWinTStrghtAmt.Options.AllowExpand = DefaultBoolean.False;
                    fieldWinTRmbltAmt.Options.AllowExpand = DefaultBoolean.False;
                    fieldDate.SortOrder = PivotSortOrder.Descending;
                    pvt.Fields.AddRange(new PivotGridField[] { fieldDate, fieldNumRes, fieldDrawType, fieldTot_Rmb_Cnt, fieldTot_Strght_Cnt, fieldWinTRmbltAmt, fieldWinTStrghtAmt, fieldWinTotAmt });
                    pvt.OptionsView.ShowRowTotals = false;
                    pvt.OptionsView.ShowRowGrandTotals = true;
                    pvt.OptionsView.ShowFilterHeaders = false;
                    pvt.OptionsBehavior.SortBySummaryDefaultOrder = PivotSortBySummaryOrder.Descending;
                }
                pvt.BestFit();
            }

            return pvt;
        }
        public DataTable GetDatable(string query)
        {
            SqlConnection con = Database.getConnection();
            con.Open();
            //  cont.BeginUpdate();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            try
            {
                com.CommandTimeout = 180;
                adapter.Fill(table);
            }
            catch (SqlException ee)
            {
                XtraMessageBox.Show(ee.ToString());
            }
            finally
            {
                //   cont.EndUpdate();
                con.Close();
            }
            return table;
        }
        private void btnexportxl_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)pivotGridControl1.DataSource;
            if (dt.Rows.Count > 0)
            {
                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.DataAware;
                
                string strName = cbReport.EditValue.Str().Replace(' ', '_');
                saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog1.FileName =strName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffftt");
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StaticSettings.showLoading();
                    string filepath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                    string fname = System.IO.Path.GetFileName(saveFileDialog1.FileName);

                    pivotGridControl1.ExportToXlsx(filepath + "\\" + fname, new XlsxExportOptionsEx
                    {
                        AllowGrouping = DefaultBoolean.False,
                        AllowFixedColumnHeaderPanel = DefaultBoolean.False,
                        ShowBandHeaders = DefaultBoolean.True,
                        ShowColumnHeaders = DefaultBoolean.True,

                    });
                    StaticSettings.hideLoading();
                    StaticSettings.XtraMessage("Exporting Succesfully.", MessageBoxIcon.None);
                    //System.Diagnostics.Process.Start(filepath + "\\" + fname);
                }
            }
            else
            {
                StaticSettings.XtraMessage("Cannot Extract Empty Data", MessageBoxIcon.Exclamation);
            }

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
            tsregion.Properties.DataSource = dtNew;
            tsregion.Properties.DisplayMember = "REGION_INSTANCE";
            tsregion.Properties.ValueMember = "REGION_CODE";
            tsregion.Properties.PopulateViewColumns();
            x0a(tsregion);
            DataRow drReg = tsregion.GetFocusedDataRow();
            if (regionID.IsEmpty()) return;
            DataRow row = tsregion.Select($"REGION_CODE='{regionID}'").FirstOrDefault();
            if (row == null) return;
            tsregion.EditValue = row["REGION_CODE"].Str();

        }
        private void fillProvinceJson(string regionID)
        {
            if (regionID.IsEmpty())
            {
                tsprovince.Properties.DataSource = null;
                return;
            }
            DataRow rgn = tsregion.GetFocusedDataRow();

            string spath = AppDomain.CurrentDomain.BaseDirectory;
            string sFilename = string.Format("{0}Resources\\json\\Provinces.json", Path.GetFullPath(Path.Combine(spath, @"..\..\")));
            DataTable dt = new DataTable();
            dt = ConvertJsonToDataTable(sFilename);
            if (dt.Rows.Count == 0) return;
            DataView dv = dt.DefaultView;
            dv.RowFilter = " COUNTRY_CODE='63' and REGION_CODE='" + regionID + "'";
            DataTable dtNew = dv.ToTable();
            DataRow drProv = tsprovince.GetFocusedDataRow();
            tsprovince.Properties.DataSource = dtNew;
            tsprovince.Properties.DisplayMember = "PROVINCE";
            tsprovince.Properties.ValueMember = "PROVINCE_CODE";
            tsprovince.Properties.PopulateViewColumns();
            x0b(tsprovince);
            if (regionID.IsEmpty()) return;
            DataRow row = tsprovince.Select($"REGION_CODE='{regionID}'").FirstOrDefault();
            if (row == null) return;
            tsprovince.EditValue = row["PROVINCE_CODE"].Str();

        }
        private void fillMunicipalityJson(string regionID, string provinceID)
        {
            if (regionID.IsEmpty() && provinceID.IsEmpty())
            {
                tsmunicipality.Properties.DataSource = null;
            }
            if (provinceID.IsEmpty()) return;
            string spath = AppDomain.CurrentDomain.BaseDirectory;
            string sFilename = string.Format("{0}Resources\\json\\Municipalities.json", Path.GetFullPath(Path.Combine(spath, @"..\..\")));
            DataTable dt = new DataTable();
            dt = ConvertJsonToDataTable(sFilename);
            if (dt.Rows.Count == 0) return;
            DataView dv = dt.DefaultView;
            dv.RowFilter = " COUNTRY_CODE='63' and REGION_CODE='" + regionID + "' and PROVINCE_CODE='" + Convert.ToInt32(provinceID) + "'";
            DataTable dtNew = dv.ToTable();
            DataRow drMun = tsmunicipality.GetFocusedDataRow();
            tsmunicipality.Properties.DataSource = dtNew;
            tsmunicipality.Properties.DisplayMember = "MUNICIPALITY";
            tsmunicipality.Properties.ValueMember = "MUNICIPALITY_CODE";
            tsmunicipality.Properties.PopulateViewColumns();
            x0c(tsmunicipality);
            if (provinceID.IsEmpty()) return;
            DataRow row = tsmunicipality.Select($"PROVINCE_CODE='{provinceID}'").FirstOrDefault();
            if (row == null) return;
            tsmunicipality.EditValue = row["MUNICIPALITY_CODE"].Str();

        }
        private void fillBarangayJson(string munID)
        {
            if (munID.IsEmpty())
            {
                tsBrgy.Properties.DataSource = null;
            }
            if (munID.IsEmpty()) return;
            string spath = AppDomain.CurrentDomain.BaseDirectory;
            string sFilename = string.Format("{0}Resources\\json\\Barangay.json", Path.GetFullPath(Path.Combine(spath, @"..\..\")));
            DataTable dt = new DataTable();
            dt = ConvertJsonToDataTable(sFilename);
            if (dt.Rows.Count == 0) return;
            DataView dv = dt.DefaultView;
            dv.RowFilter = " COUNTRY_CODE='63' and MUNICIPALITY_CODE='" + munID + "'";
            DataTable dtNew = dv.ToTable();
            DataRow brgy = tsBrgy.GetFocusedDataRow();
            tsBrgy.Properties.DataSource = dtNew;
            tsBrgy.Properties.DisplayMember = "BRGY";
            tsBrgy.Properties.ValueMember = "BRGY_CODE";
            tsBrgy.Properties.PopulateViewColumns();
            x0d(tsBrgy);
        }
        private void cbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gridControl1.DataSource = null;
            //GridView view = new GridView(gridControl1);
            //view.OptionsView.ShowGroupPanel = false;
            //view.OptionsView.ShowColumnHeaders = false;
            //gridControl1.MainView = view;
            //gridView1.RefreshData();
            //gridView1.BestFitColumns();
            lblReg.Visible = false;
            lblProv.Visible = false;
            lblMun.Visible = false;
            lblBrgy.Visible = false;
            tsregion.Visible = false;
            tsprovince.Visible = false;
            tsmunicipality.Visible = false;
            tsBrgy.Visible = false;
            btngenerate.Location = new Point(539, 27);
            btnexportxl.Location = new Point(540, 55);
            cboReportType.Size = new Size(1280, 101);
            gridControl1.Visible = true;
            if (cbReport.EditValue.Str() == "Total Sales")
            {
                lblReg.Visible = true;
                lblProv.Visible = true;
                lblMun.Visible = true;
                lblBrgy.Visible = true;
                tsregion.Visible = true;
                tsprovince.Visible = true;
                tsmunicipality.Visible = true;
                tsBrgy.Visible = true;
                btngenerate.Location = new Point(912, 27);
                btnexportxl.Location = new Point(912, 55);
                cboReportType.Size = new Size(1280, 138);
                this.fillRegionJson("");
                tsregion.Properties.DataSource = dtReg;
            }
            //else if(cbReport.EditValue.Str()== "Sales Transaction Sheet")
            //{
            //    gridControl1.Visible = false;
            //    pivotGridControl1.Fields.Clear();
            //    pivotGridControl1.Visible = true;
            //}
        }

        private void tsregion_EditValueChanged(object sender, EventArgs e)
        {
            string val1 = tsregion.EditValue.Str();
            this.fillProvinceJson(val1.Str());
            this.tsprovince.Text = string.Empty;
        }

        private void tsprovince_EditValueChanged(object sender, EventArgs e)
        {
            string valRegion = tsregion.EditValue.Str();
            string valProvince = tsprovince.EditValue.Str();
            this.fillMunicipalityJson(valRegion, valProvince);
            this.tsmunicipality.Text = string.Empty;
        }

        private void tsmunicipality_EditValueChanged(object sender, EventArgs e)
        {
            string valMunicipality = tsmunicipality.EditValue.Str();
            this.fillBarangayJson(tsmunicipality.EditValue.Str());
            this.tsBrgy.Text = string.Empty;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            gridView1.IndicatorWidth = 50;
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).Str();
            }
        }

        private void tbdatefrom_EditValueChanged(object sender, EventArgs e)
        {
            tbdateto.Properties.MaxValue = DateTime.Today;
            tbdateto.Properties.MinValue = Convert.ToDateTime(tbdatefrom.Text.Trim());
        }

        private void pivotGridControl1_CustomCellValue(object sender, PivotCellValueEventArgs e)
        {
            if (e.Value == null)
            {
                e.Value = 0;
            }
        }

        private void pivotGridControl1_CustomDrawFieldValue(object sender, PivotCustomDrawFieldValueEventArgs e)
        {
            if (e.Area == PivotArea.ColumnArea)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        
    }
    public partial class _x0b
    {
        public class VywA
        {
            public static GridView x0_a(GridView gridView, FilterA filter, string rpt, List<string> colHeader)
            {
                int iCnt = 1;
                //var cN;
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    if (rpt == "Sales Transaction by Player")
                    {
                        var DC = colHeader;
                        if (colHeader != null)
                        {
                            string cN = string.Empty;
                            foreach (string colN in DC)
                            {
                                if (colN != "Total_Amount1")
                                {
                                    if (colN == "Acct_Name")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "Name", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else if (colN == "GenCor")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "General Coordinator", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else if (colN == "Coor")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "Coordinator", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else
                                    {
                                        DevXSettings.XtraFormatColumn(colN, colN, iCnt, gridView);
                                        //cN += colN.Str() + ",";
                                        cN += colN.Str() + ",";
                                        iCnt++;
                                    }
                                }

                            }
                            cN = cN.Remove(cN.Length - 1);
                            var cNar = cN.Split(',');
                            DevXSettings.XgridGeneralSummaryNumber(cNar, gridView);
                            DevXSettings.XgridColAlign(cNar, gridView, HorzAlignment.Center);
                        }
                    }
                    else if (rpt == "Sales Transaction by Date" || rpt == "Total Winning Amount by Date" || rpt == "Total Sales")
                    {
                        var DC = colHeader;
                        if (colHeader != null)
                        {
                            string cN = string.Empty;
                            foreach (string colN in DC)
                            {
                                if (colN == "DRW_TRN_DT")
                                {
                                    DevXSettings.XtraFormatColumn(colN, "Date", iCnt, gridView);
                                    iCnt++;
                                }
                                else
                                {
                                    DevXSettings.XtraFormatColumn(colN, colN, iCnt, gridView);
                                    //cN += colN.Str() + ",";
                                    cN += colN.Str() + ",";
                                    iCnt++;
                                }
                            }
                            cN = cN.Remove(cN.Length - 1);
                            var cNar = cN.Split(',');
                            DevXSettings.XgridGeneralSummaryNumber(cNar, gridView);
                            DevXSettings.XgridColAlign(cNar, gridView, HorzAlignment.Center);
                        }
                        //DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Draw Date", 4, gridView);
                        //DevXSettings.XtraFormatColumn("TwoPM", "2 PM", 5, gridView);
                        //DevXSettings.XtraFormatColumn("FivePM", "5 PM", 6, gridView);
                        //DevXSettings.XtraFormatColumn("NinePM", "9 PM", 7, gridView);
                        //DevXSettings.XtraFormatColumn("TOTAL_BET", "Tota Bet", 8, gridView);
                        //DevXSettings.XgridColCurrency(new string[] { "Total_Bet", "TwoPM", "FivePM", "NinePM", "TOTAL_BET" }, gridView);
                        //DevXSettings.XgridGeneralSummaryCurrency(new string[] { "Total_Bet", "TwoPM", "FivePM", "NinePM", "TOTAL_BET" }, gridView);
                        //DevXSettings.XgridColAlign(new string[] { "Total_Bet", "TwoPM", "FivePM", "NinePM", "TOTAL_BET" }, gridView, HorzAlignment.Center);
                    }
                    else if (rpt == "Total Ticket Generated by Player" || rpt == "Total Ticket Generated by Date")
                    {
                        var DC = colHeader;
                        if (colHeader != null)
                        {
                            string cN = string.Empty;
                            foreach (string colN in DC)
                            {
                                if (colN != "TOTAL_BET1")
                                {
                                    if (colN == "Acct_Name")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "Name", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else if (colN == "GenCor")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "General Coordinator", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else if (colN == "Coor")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "Coordinator", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else if (colN == "DRW_TRN_DT")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "Date", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else
                                    {
                                        DevXSettings.XtraFormatColumn(colN, colN, iCnt, gridView);
                                        //cN += colN.Str() + ",";
                                        cN += colN.Str() + ",";
                                        iCnt++;
                                    }
                                }

                            }
                            cN = cN.Remove(cN.Length - 1);
                            var cNar = cN.Split(',');
                            DevXSettings.XgridGeneralSummaryNumber(cNar, gridView);
                            DevXSettings.XgridColAlign(cNar, gridView, HorzAlignment.Center);
                        }
                    }
                    else if (rpt == "Sales Transaction Sheet")
                    {
                        var DC = colHeader;
                        if (colHeader != null)
                        {
                            string cN = string.Empty;
                            foreach (string colN in DC)
                            {
                                if (colN != "Total_Amount1")
                                {
                                    if (colN == "FLL_NM")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "Name", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else if (colN == "GEN_COORD_NM")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "General Coordinator", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else if (colN == "COORD_NM")
                                    {
                                        DevXSettings.XtraFormatColumn(colN, "Coordinator", iCnt, gridView);
                                        iCnt++;
                                    }
                                    else
                                    {
                                        DevXSettings.XtraFormatColumn(colN, colN, iCnt, gridView);
                                        //cN += colN.Str() + ",";
                                        cN += colN.Str() + ",";
                                        iCnt++;
                                    }
                                }

                            }
                        }
                    }

                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("REGION_INSTANCE", "Region", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0b(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("PROVINCE", "Province", 1, gridview);
                gridview.Columns[0].Visible = false;
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0c(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("MUNICIPALITY", "Municipality", 1, gridview);
                gridview.Columns[0].Visible = false;
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0d(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("BRGY", "Barangay", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0e(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("nationality", "Nationality", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0f(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("GRP_NM", "Group", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
        }
        public class FilterA
        {
            public List<XItem0B> Gametypes;
            public string iGameTypes;
            public string DateFrom;
            public string DateTo;
            public bool IsMultiGameType;

            public static bool validityA(FilterA filter)
            {
                var gameTypes = filter.Gametypes;
                if (gameTypes != null && gameTypes.Count != 0)
                    filter.iGameTypes = AggrUtils.Xml.toXmlString(gameTypes).ToString().Trim();
                else filter.iGameTypes = null;
                filter.IsMultiGameType = (gameTypes.Count > 1);
                return true;
            }
        }
        [XmlRoot(ElementName = "item")]
        public class XItemA
        {
            [XmlAttribute("ID")]
            public string ID;
            public static List<XItemA> AsList(string[] arr)
            {
                List<XItemA> list = null;
                if (arr != null && arr.Length != 0) list = arr.Select((str) => (new XItemA() { ID = str })).ToList();
                return list;
            }
        }
        [XmlRoot(ElementName = "item")]
        public class XItem0B
        {
            [XmlAttribute("GM_TYP")]
            public string GameID;
            [XmlAttribute("DRW_TYP")]
            public string DrawSchedule;
        }
    }
}
