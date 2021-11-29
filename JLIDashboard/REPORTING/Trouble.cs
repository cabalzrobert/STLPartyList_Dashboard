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
using static JLIDashboard.REPORTING._x0jA;
using static JLIDashboard.REPORTING._x0jA.Vyw;
using JLIDashboard._Module;
using JLIDashboard.Module;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.IO;
using System.Diagnostics;
using Comm.Common.Extensions;
using System.Net;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.REPORTING
{
    public partial class Trouble : DevExpress.XtraEditors.XtraForm
    {
        public Trouble()
        {
            InitializeComponent();
        }
        public void Load_TroubleReport()
        {
            API.displayAPI("/api/v1/TroubleReport/LoadTroubleReport", gridControl1, gridView1,  Login.authentication,new Dictionary<string, object>()
            {
                {"dateFrom", dtFrom.Text.Trim() },
                {"dateTo", dtTo.Text.Trim() }
            });
           
            //gridView1.Columns.AddVisible("ViewAttachment");
            x0a(gridView1);
        }

        private void Trouble_Load(object sender, EventArgs e)
        {
            dtFrom.Text = dtTo.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            dtFrom.Properties.MaxValue = DateTime.Today;
            dtTo.Properties.MaxValue = DateTime.Today;
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.FieldName== "UPD_TRN_TS")
            {
                if (e.Value.Str() != "")
                {
                    e.DisplayText = ((DateTime)e.Value).ToString("dd-MMM-yyyy");
                }
                
            }
            
            else if (e.Column.FieldName == "FXD_TRN_TS")
            {
                string fxd = e.Value.Str();
                if (fxd != "")
                {
                    //e.DisplayText = ((DateTime)e.Value).ToString("MMM dd, yyyy");
                    e.DisplayText = Convert.ToDateTime(fxd).ToString("dd-MMM-yyyy");
                    //e.DisplayText = fxd;
                }
                
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dtFrom.Text == null && dtTo.Text == null)
            {
                StaticSettings.XtraMessage("Please Select Date Range",MessageBoxIcon.Exclamation);
                return;
            }
            this.Load_TroubleReport();
        }


        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format("{0}Resources\\Find_16x16 (2).png", Path.GetFullPath(Path.Combine(FilePath, @"..\..\")));
            Image img = Image.FromFile(FileName);
            if (e.Column.FieldName == "ViewAttachment")
            {
                e.DefaultDraw();
                e.Cache.DrawImage(img, e.Bounds.Location);
            }
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null);
            btnAttachment.Visible = hasSelected;
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            //var focusedrow = gridView1.GetFocusedDataRow();
            //DataRow row = gridView1.GetFocusedDataRow();
            //string fpath = row["ATTCHMNT"].Str();
            ////string fpath = @"D:\SourceTree\JLIDashboard\JLIDashboard\JLIDashboard\Resources\avatar.jpg";
            //string ticketno = row["TCKT_NO"].Str();
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = fpath;
            //info.UseShellExecute = true;
            //info.CreateNoWindow = true;
            //info.Verb = string.Empty;
            //Process.Start(info);

            var focusedrow = gridView1.GetFocusedDataRow();
            DataRow row = gridView1.GetFocusedDataRow();
            StaticSettings.showLoading();
            var frm = System.Windows.Forms.Application.OpenForms.Singleton<TroubleAttachment>().setData(row,true);
            StaticSettings.hideLoading();
            frm.ShowDialog(this);

        }

        private void btnSolved_Click(object sender, EventArgs e)
        {
            var focusedrow = gridView1.GetFocusedDataRow();
            DataRow row = gridView1.GetFocusedDataRow();
            StaticSettings.showLoading();
            var frm = System.Windows.Forms.Application.OpenForms.Singleton<CorrectiveAction>().setData(row, true);
            StaticSettings.hideLoading();
            frm.ShowDialog(this);
            if (!frm.ok) return;
            frm.retData(row);
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string val = (view.GetRowCellDisplayText(e.RowHandle, view.Columns["STAT_NM"]) == "") ? "" : view.GetRowCellDisplayText(e.RowHandle, view.Columns["STAT_NM"]);
                if (val == "Pending")
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                HelperFunction.ExportToExcelAndSaveDialog(saveFileDialog1, gridView1, "TroubleReport" + DateTime.Now.ToString("yyyyMMddhhmmss"));
            }
        }
    }
    public class _x0jA
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                if (gridView.RowCount != 0)
                {
                    gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("FLL_NM", "Report by", 1, gridView, 100);
                    DevXSettings.XtraFormatColumn("UPD_TRN_TS", "Date", 2, gridView, 100);
                    DevXSettings.XtraFormatColumn("TRN_NO", "Ticket #", 3, gridView, 100);
                    DevXSettings.XtraFormatColumn("SBJCT_CD", "Subject", 4, gridView, 100);
                    DevXSettings.XtraFormatColumn("BODY", "Remarks", 5, gridView, 100);
                    DevXSettings.XtraFormatColumn("COR_ACTION", "Corrective Action", 6, gridView, 100);
                    DevXSettings.XtraFormatColumn("FXD_TRN_TS", "Fixed Date", 6, gridView, 100);
                    DevXSettings.XtraFormatColumn("STAT_NM", "Status", 7, gridView, 100);
                    //DevXSettings.XtraFormatColumn("ViewAttachment", "View", 8, gridView, 100);
                }
                return gridView;
            }
        }
    }
}