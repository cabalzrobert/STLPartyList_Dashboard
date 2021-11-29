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
using DevExpress.XtraGrid.Views.Grid;
using static JLIDashboard.OPERATOR.frm._genID;
using static JLIDashboard.OPERATOR.frm._genID.Vyw;
using JLIDashboard._Module;
using Comm.Common.Extensions;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using System.IO;
using JLIDashboard.Module;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Classes;
using System.Xml.Serialization;
using JLIDashboard.Classes.Common;
using Comm.Common.Advance;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR.frm
{
    public partial class GeneratID : DevExpress.XtraEditors.XtraForm
    {
        public bool ok;
        public SelectedAccount selAct=new SelectedAccount();
        public GeneratID()
        {
            InitializeComponent();
            tbValFrom.Text = Convert.ToDateTime(DateTime.Now.Str()).ToString("MMMM dd, yyyy");
            tbValTo.Text = Convert.ToDateTime(DateTime.Now.AddMonths(3)).ToString("MMMM dd, yyyy");
        }
        
        public GeneratID setData(DataTable dt, bool isEdit = false)
        {
            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();
            gridView1.RefreshData();
            if (dt.Rows.Count != 1)
            {
                gridView1.ClearSelection();
            }
            if(x0a(gridView1).RowCount != 0)
            {
                //this.gridView1.FocusedRowHandle = 0;
            }
            return this;
        }



        private Bitmap Generate_QRCode(string ACCT_ID,string FLL_NM, string VAL_FRM_DT, string VAL_TO_DT,string strCompid, string strBRCD)
        {
            Bitmap fImage;
            string baseID = $"2|{ACCT_ID}";
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(baseID);
            string decodestring = System.Convert.ToBase64String(data);
            string strCode = $"Account:{ACCT_ID}\nFullname:{FLL_NM}\nSignature:{decodestring}";
            ImageConverter imgconvert = new ImageConverter();
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var MyData = QG.CreateQrCode(strCode, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(MyData);
            fImage = code.GetGraphic(50);
            return fImage;
        }
        private DataTable Load_PrintID(GridControl cont, string valFromDT, string valTODT)
        {
            DataTable dtNew = new DataTable();
            List<XItem0B> ActList = new List<XItem0B>();
            dtNew.Columns.Add("ACT_ID", typeof(string));
            dtNew.Columns.Add("FLL_NM", typeof(string));
            dtNew.Columns.Add("NXTKN_NM", typeof(string));
            dtNew.Columns.Add("NXTKN_NO", typeof(string));
            dtNew.Columns.Add("PRSNT_ADDR", typeof(string));
            dtNew.Columns.Add("LOC_MUN_NM", typeof(string));
            dtNew.Columns.Add("LOC_PROV_NM", typeof(string));
            dtNew.Columns.Add("EXPRDATE", typeof(string));
            dtNew.Columns.Add("PRF_PIC", typeof(string));
            dtNew.Columns.Add("VAL_FRM_DT", typeof(string));
            dtNew.Columns.Add("VAL_TO_DT", typeof(string));
            dtNew.Columns.Add("SUBSCR_TYP", typeof(string));
            dtNew.Columns.Add("QRCODE", typeof(Bitmap));
            dtNew.Columns.Add("SIGNATUREID", typeof(string));
            //foreach (int rowindex in this.gridView1.GetSelectedRows())
            foreach (int rowindex in this.gridView1.GetSelectedRows())
            {
                DataRow DR = dtNew.NewRow();
                var sPath = string.Empty;
                var sigPath = string.Empty;
                string strCompId = this.gridView1.GetRowCellDisplayText(rowindex, "COMP_ID");
                string strBRCD = this.gridView1.GetRowCellDisplayText(rowindex, "BR_CD");
                DR["ACT_ID"] = this.gridView1.GetRowCellDisplayText(rowindex, "ACT_ID");
                DR["FLL_NM"] = this.gridView1.GetRowCellDisplayText(rowindex, "FLL_NM");
                DR["NXTKN_NM"] = (this.gridView1.GetRowCellDisplayText(rowindex, "NXTKN_NM").IsEmpty()) ? "" : this.gridView1.GetRowCellDisplayText(rowindex, "NXTKN_NM");
                DR["NXTKN_NO"] = (this.gridView1.GetRowCellDisplayText(rowindex, "NXTKN_NO").IsEmpty()) ? "" : this.gridView1.GetRowCellDisplayText(rowindex, "NXTKN_NO");
                DR["PRSNT_ADDR"] =(this.gridView1.GetRowCellDisplayText(rowindex, "PRSNT_ADDR").IsEmpty()) ? "" : this.gridView1.GetRowCellDisplayText(rowindex, "PRSNT_ADDR");
                DR["LOC_MUN_NM"] = (this.gridView1.GetRowCellDisplayText(rowindex, "LOC_MUN_NM").IsEmpty()) ? "" : this.gridView1.GetRowCellDisplayText(rowindex, "LOC_MUN_NM");
                DR["LOC_PROV_NM"] = (this.gridView1.GetRowCellDisplayText(rowindex, "LOC_PROV_NM").IsEmpty()) ? "" : this.gridView1.GetRowCellDisplayText(rowindex, "LOC_PROV_NM");
                DR["EXPRDATE"] = valTODT.Str();
                DR["QRCODE"] = Generate_QRCode(DR["ACT_ID"].Str(), DR["FLL_NM"].Str(), valFromDT.Str(), valTODT.Str(),strCompId,strBRCD);
                sPath = this.gridView1.GetRowCellDisplayText(rowindex, "PRF_PIC");
                sigPath = this.gridView1.GetRowCellDisplayText(rowindex, "SIGNATUREID");
                ActList.Add(new XItem0B { AcctID = DR["ACT_ID"].Str(),FL_NM = DR["FLL_NM"].Str() });
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
                //    string FName = string.Format("{0}Resources\\avatar1.jpg", Path.GetFullPath(Path.Combine(sigPath, @"..\..\")));
                //    string fileName = FName;
                //    DR["SIGNATUREID"] = fileName;
                //}

                if (this.gridView1.GetRowCellDisplayText(rowindex, "SUBSCR_TYP") == "1")
                {
                    DR["SUBSCR_TYP"] = "GENERAL COORDINATOR";
                }
                else if (this.gridView1.GetRowCellDisplayText(rowindex, "SUBSCR_TYP") == "2")
                {
                    DR["SUBSCR_TYP"] = "COORDINATOR";
                }
                else if (this.gridView1.GetRowCellDisplayText(rowindex, "SUBSCR_TYP") == "3")
                {
                    DR["SUBSCR_TYP"] = "SALES REPRESENTATIVE";
                }
                DR["VAL_FRM_DT"] = valFromDT.Str();
                DR["VAL_TO_DT"] = valTODT.Str();
                dtNew.Rows.Add(DR);
            }
            selAct.ACT_ID = ActList;
            return dtNew;
        }
        private bool ValidEntries()
        {
            if (tbValFrom.Text.IsEmpty())
            {
                StaticSettings.XtraMessage("Valid From is Required", MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbValFrom.Text.IsEmpty())
            {
                StaticSettings.XtraMessage("Valid To is Required", MessageBoxIcon.Exclamation);
                return false;
            }
            selAct.valfrmdt = Convert.ToDateTime(tbValFrom.Text.Trim()).ToString("yyyyMMdd");
            selAct.valtodt = Convert.ToDateTime(tbValTo.Text.Trim()).ToString("yyyyMMdd");
            selAct.compid = Login.compid.Str().Trim();
            selAct.brcid = Login.brcode.Str().Trim();
            return true;
        }
        private void Update_AcctValidity()
        {
            var res = (DB.executeUpdate(selAct)).Result;
            if(res.result == Results.Success)
            {
                this.ok = true;
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
            }

        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var actSelected = gridView1.GetSelectedRows();
            //selAct.ACT_ID = actSelected.Select((row)=>(new XItem0B() { AcctID=row[System.Data.DataRow]["ACT_ID"].str }))
            DataTable dt = Load_PrintID(gridControl1, tbValFrom.Text.Trim(), tbValTo.Text.Trim());
            SelectedAccount.validityA(selAct);
            if (ValidEntries())
            {
                if (dt.Rows.Count > 0)
                {
                    var res = (DB.executeUpdate(selAct)).Result;
                    if (res.result == Results.Success)
                    {
                        PrintID report = new PrintID();
                        //Print_IDs report = new Print_IDs();
                        //XRSubreport xr = report.FindControl("xrSubreport1", true) as XRSubreport;
                        //XRSubreport xr = new XRSubreport(); 
                        //report.Bands["Detail"].Controls.Add(xr);
                        DataSet1 ds = new DataSet1();
                        ds.Tables.Add(dt);
                        report.DataSource = dt;
                        report.DataMember = "dtPrintID";
                        //xr.Report.DataSource = report.DataSource;
                        //xr.Report.DataMember = "dtPrintID";

                        report.PaperKind = System.Drawing.Printing.PaperKind.A4;
                        //report.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                        ReportPrintTool printit = new ReportPrintTool(report);
                        var strAct = selAct.ACT_ID;
                        this.ok = true;
                        this.Close();
                        printit.ShowPreviewDialog();
                    }
                }
                else
                {
                    StaticSettings.XtraMessage("Please select atleast 1 to Generate ID", MessageBoxIcon.Exclamation);
                }

            }
            
        }
    }
    public class _genID
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                if (gridView.RowCount != 0)
                {
                    gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("USR_ID", "User ID", 1, gridView);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Last Name", 4, gridView, 120);
                    //DevXSettings.XtraFormatColumn("FRST_NM", "First Name", 5, gridView, 120);
                }
                return gridView;
            }
        }
        public class DB
        {
            public static async Task<(Results result, String message)> executeUpdate(SelectedAccount selact)
            {
                var result = API.DSpQueryAPI($"/api/v1/MasterList/UpdateValidityAccount", Login.authentication, new Dictionary<string, object>()
                {
                    {"dateFrom",selact.valfrmdt },
                    {"dateTo",selact.valtodt },
                    {"iACCT_ID",selact.iACCT_ID }
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

        [XmlRoot(ElementName = "item")]
        public class SelectedAccount
        {
            public List<XItem0B> ACT_ID;
            public string iACCT_ID;
            public string valfrmdt;
            public string valtodt;
            public string compid;
            public string brcid;
            public string qrcode;
            public static bool validityA(SelectedAccount selAct)
            {
                var acctid = selAct.ACT_ID;
                if (acctid != null && acctid.Count != 0)
                    selAct.iACCT_ID = AggrUtils.Xml.toXmlString(acctid).ToString().Trim();
                else selAct.iACCT_ID = null;
                return true;
            }
        }
        [XmlRoot(ElementName ="item")]
        public class XItem0B
        {
            [XmlAttribute("ACT_ID")]
            public string AcctID;
            [XmlAttribute("FL_NM")]
            public string FL_NM;
        }
    }
}