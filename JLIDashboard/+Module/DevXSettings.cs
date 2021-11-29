using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Design;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Localization;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Mask;

namespace JLIDashboard._Module
{
    class DevXSettings
    {
        public static RepositoryItemMemoEdit MemoEdit = new RepositoryItemMemoEdit();

        public static RepositoryItemSpinEdit SpinEdit = new RepositoryItemSpinEdit();

        public static RepositoryItemComboBox ComboBoxEdit = new RepositoryItemComboBox();

        public static RepositoryItemImageEdit colImageEdit = new RepositoryItemImageEdit();

        public static void SetCornerBorder(ref object buttonObj)
        {
            try
            {
                int CornerRadius = 18;
                GraphicsPath gfxPath_mod = new GraphicsPath();
                dynamic buttonDyn = buttonObj;
                int Right = buttonDyn.Width;
                int Bottom = buttonDyn.Height;
                gfxPath_mod.AddArc(0, 0, CornerRadius, CornerRadius, 180f, 90f);
                gfxPath_mod.AddArc(Right - CornerRadius, 0, CornerRadius, CornerRadius, 270f, 90f);
                gfxPath_mod.AddArc(Right - CornerRadius, Bottom - CornerRadius, CornerRadius, CornerRadius, 0f, 90f);
                gfxPath_mod.AddArc(0, Bottom - CornerRadius, CornerRadius, CornerRadius, 90f, 90f);
                gfxPath_mod.CloseAllFigures();
                int inside = 1;
                GraphicsPath gfxPath = new GraphicsPath();
                gfxPath.AddArc(0 + inside + 1, 0 + inside, CornerRadius, CornerRadius, 180f, 100f);
                gfxPath.AddArc(Right - CornerRadius - inside - 2, 0 + inside, CornerRadius, CornerRadius, 270f, 90f);
                gfxPath.AddArc(Right - CornerRadius - inside - 2, Bottom - CornerRadius - inside - 1, CornerRadius, CornerRadius, 0f, 90f);
                gfxPath.AddArc(0 + inside + 1, Bottom - CornerRadius - inside, CornerRadius, CornerRadius, 95f, 95f);
                buttonDyn.Region = new Region(gfxPath_mod);
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(Conversions.ToString(Information.Err().Number) + "\r\n" + Information.Err().Description, MsgBoxStyle.Information, null);
                XtraMessageBox.Show("Message:" + ex.Message + "\r\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static object LoadGridviewAppearance(GridView xgrid)
        {
            XAppearances gvScheme = new XAppearances(Application.StartupPath + "\\DevExpress.XtraGrid.Appearances.xml");
            try
            {
                string gen_fontfamily = "Segoe UI";
                int gen_FontSize = 10;
                xgrid.OptionsSelection.EnableAppearanceFocusedCell = false;
                xgrid.OptionsView.ShowIndicator = false;
                xgrid.OptionsView.EnableAppearanceEvenRow = false;
                xgrid.OptionsView.EnableAppearanceOddRow = false;
                xgrid.OptionsView.ShowHorizontalLines = DefaultBoolean.True;
                xgrid.OptionsView.ShowVerticalLines = (DefaultBoolean)(-1);
                xgrid.Appearance.HeaderPanel.Font = new Font(gen_fontfamily, (float)gen_FontSize, FontStyle.Bold, GraphicsUnit.Point, 204);
                xgrid.Appearance.GroupRow.Font = new Font(gen_fontfamily, (float)gen_FontSize, FontStyle.Bold, GraphicsUnit.Point, 204);
                xgrid.Appearance.Row.Font = new Font(gen_fontfamily, (float)gen_FontSize, FontStyle.Regular, GraphicsUnit.Point, 204);
                xgrid.Appearance.FooterPanel.Font = new Font(gen_fontfamily, (float)gen_FontSize, FontStyle.Bold, GraphicsUnit.Point, 204);
                xgrid.Appearance.GroupFooter.Font = new Font(gen_fontfamily, (float)gen_FontSize, FontStyle.Bold, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                gvScheme.LoadScheme("Default", xgrid);
                xgrid.PaintStyleName = "Default";
            }
            return xgrid;
        }

        public static void XtraFormatColumn(string OriginalColumn, string ProperColumnName, int Index, GridView xgrid, int MinWidth = 0, int MaxWidth = 0)
        {
            xgrid.Columns[OriginalColumn].Name = OriginalColumn;
            xgrid.Columns[OriginalColumn].VisibleIndex = Index;
            xgrid.Columns[OriginalColumn].Caption = ProperColumnName;
            xgrid.Columns[OriginalColumn].Visible = true;
            if (MinWidth > 0) xgrid.Columns[OriginalColumn].MinWidth = MinWidth;
            if (MaxWidth > 0) xgrid.Columns[OriginalColumn].MaxWidth = MaxWidth;
        }
        public static void XtraFormatColumn(string OriginalColumn, string ProperColumnName, GridView xgrid, int MinWidth = 0, int MaxWidth = 0)
        {
            int index = xgrid.Columns.OrderBy(c => c.VisibleIndex).Where(c => c.Visible).Select(c => c.VisibleIndex).LastOrDefault() + 1;
            XtraFormatColumn(OriginalColumn, ProperColumnName, index, xgrid, MinWidth: MinWidth, MaxWidth: MaxWidth);
        }

        public static object LoadXtraGrid(DataTable dt, GridControl Em, GridView xgrid)
        {
            xgrid.ClearGrouping();
            Em.DataSource = null;
            if (xgrid.PaintStyleName != "Web")
                DevXSettings.LoadGridviewAppearance(xgrid);
            Em.DataSource = dt;
            xgrid.PopulateColumns(dt);
            xgrid.BestFitColumns();
            Em.ForceInitialize();
            xgrid.OptionsView.BestFitMaxRowCount = -1;
            xgrid.BestFitColumns();
            XgridColsVisible(xgrid, false);
            return true;
        }

        public static object LoadCustomXtraGrid(DataTable dt, GridControl Em, GridView xgrid)
        {
            xgrid.ClearGrouping();
            Em.DataSource = null;
            Em.DataSource = dt;
            xgrid.PopulateColumns(dt);
            xgrid.BestFitColumns();
            Em.ForceInitialize();
            xgrid.OptionsView.ShowIndicator = false;
            xgrid.OptionsView.BestFitMaxRowCount = -1;
            xgrid.BestFitColumns();
            XgridColsVisible(xgrid, false);
            return true;
        }
        public static object XgridColsVisible(GridView xgrid, bool visibility)
        {
            for (int i = 0; i < xgrid.Columns.Count; i++)
                xgrid.Columns[i].Visible = visibility;
            return true;
        }

        public static object XgridColCurrency(Array column, GridView xgrid)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        int num = xgrid.Columns.Count - 1;
                        for (int I = 0; I <= num; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].DisplayFormat.FormatType = FormatType.Numeric;
                                xgrid.Columns[col].DisplayFormat.FormatString = "n";
                                xgrid.Columns[col].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridColWrapText(Array column, GridView xgrid)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        int num = xgrid.Columns.Count - 1;
                        for (int I = 0; I <= num; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].ColumnEdit = DevXSettings.MemoEdit;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridColAlign(Array column, GridView xgrid, HorzAlignment algn)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        int num = xgrid.Columns.Count - 1;
                        for (int I = 0; I <= num; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].AppearanceCell.TextOptions.HAlignment = algn;
                                xgrid.Columns[col].AppearanceHeader.TextOptions.HAlignment = algn;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridColMemo(Array column, GridView xgrid)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        int num = xgrid.Columns.Count - 1;
                        for (int I = 0; I <= num; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].ColumnEdit = DevXSettings.MemoEdit;
                                xgrid.Columns[col].AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
                                xgrid.Columns[col].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static DataGridView GridHideColumn(DataGridView grdView, Array column)
        {
            foreach (string valueArr in column)
            {
                for (int i = 0; i < grdView.ColumnCount; i++)
                {
                    if (valueArr == grdView.Columns[i].Name)
                    {
                        grdView.Columns[i].Visible = false;
                    }
                }
            }
            return grdView;
        }

        public static object XgridAllowColumnEdit(Array column, GridView xgrid, bool allowedit)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        xgrid.Columns[col].OptionsColumn.AllowEdit = allowedit;
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridColWidth(Array column, GridView xgrid, int size)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        for (int I = 0; I < xgrid.Columns.Count; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].Width = size;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridDisableColumn(Array column, GridView xgrid, bool WrapText)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        for (int I = 0; I < xgrid.Columns.Count; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].OptionsColumn.AllowEdit = false;
                                xgrid.Columns[col].OptionsColumn.AllowFocus = false;
                                if (WrapText)
                                {
                                    xgrid.Columns[col].AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
                                    xgrid.Columns[col].ColumnEdit = DevXSettings.MemoEdit;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridEnableColumn(Array column, GridView xgrid, bool WrapText)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        for (int I = 0; I < xgrid.Columns.Count; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].OptionsColumn.AllowEdit = true;
                                xgrid.Columns[col].OptionsColumn.AllowFocus = true;
                                if (WrapText)
                                {
                                    xgrid.Columns[col].AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
                                    xgrid.Columns[col].ColumnEdit = DevXSettings.MemoEdit;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridGeneralSummaryCurrency(Array column, GridView xgrid)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        for (int I = 0; I < xgrid.Columns.Count; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].Summary.Clear();
                                xgrid.Columns[col].Summary.Add(SummaryItemType.Sum, col, "{0:n}");
                                ((GridView)xgrid.Columns[col].View).OptionsView.ShowFooter = true;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridGeneralSummaryNumber(Array column, GridView xgrid)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        for (int I = 0; I < xgrid.Columns.Count; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].Summary.Clear();
                                xgrid.Columns[col].Summary.Add(SummaryItemType.Sum, col, "{0:n0}");
                                ((GridView)xgrid.Columns[col].View).OptionsView.ShowFooter = true;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridGeneralSummaryStatus(Array column, SummaryItemType val, string caption, GridView xgrid)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        for (int I = 0; I < xgrid.Columns.Count; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].Summary.Clear();
                                xgrid.Columns[col].Summary.Add(val, col, caption + " {N0}");
                                ((GridView)xgrid.Columns[col].View).OptionsView.ShowFooter = true;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridGroupSummaryCurrency(Array column, GridView xgrid)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        for (int I = 0; I < xgrid.Columns.Count; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                GridGroupSummaryItem item = new GridGroupSummaryItem();
                                item.FieldName = col;
                                item.SummaryType = SummaryItemType.Sum;
                                item.DisplayFormat = "{0:n}";
                                item.ShowInGroupColumnFooter = xgrid.Columns[col];
                                xgrid.GroupSummary.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgridHideColumn(Array column, GridView xgrid)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        for (int I = 0; I < xgrid.Columns.Count; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }

        public static object XgriDisableColumn(Array column, GridView xgrid)
        {
            try
            {
                foreach (object obj in column)
                {
                    string col = (obj ?? "").ToString();
                    if (!String.IsNullOrEmpty(col))
                    {
                        for (int I = 0; I < xgrid.Columns.Count; I++)
                        {
                            if (col == xgrid.Columns[I].FieldName)
                            {
                                xgrid.Columns[col].OptionsColumn.AllowEdit = false;
                            }
                        }
                    }
                }
            }
            catch (Exception errMS)
            {
                XtraMessageBox.Show("Message:" + errMS.Message + "\r\nDetails:" + errMS.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return 0;
        }
        public static string SetupTheGridviewPrinter(string TableTitle, GridView gv, string[] indexes)
        {
            string ColumnName = "", rows = "";
            double width = 0, cnt = 0;
            foreach (string colstr in indexes)
            {
                var col = gv.Columns[colstr];
                if (col != null && col.Visible)
                {
                    ColumnName += $"<th style='padding: 3px 5px; background-color: #fff8d6'>{ col.Caption }</th>";
                    width += col.Width;
                    cnt += 1;
                }
            }

            for (int i = 0; i < gv.RowCount; i++)
            {
                string rowRowTableData = "", rowColor = "000000";
                foreach (string colstr in indexes)
                {
                    var col = gv.Columns[colstr];
                    if (col != null && col.Visible)
                    {
                        string colalignment = "", strvalue = "", columnSize = "";
                        if (col.AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                        {
                            colalignment = "align='center'";
                            if (String.IsNullOrEmpty(gv.GetRowCellValue(i, col.Name).ToString()))
                                strvalue = "&nbsp;";
                            else strvalue = gv.GetRowCellValue(i, col.Name).ToString();
                        }
                        else if (col.AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                        {
                            colalignment = "align='right'";
                            if (String.IsNullOrEmpty(gv.GetRowCellValue(i, col.Name).ToString()))
                                strvalue = "&nbsp;";
                            else strvalue = Double.Parse(gv.GetRowCellValue(i, col.Name).ToString()).ToString("#,##0.00");
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(gv.GetRowCellValue(i, col.Name).ToString()))
                                strvalue = "&nbsp;";
                            else strvalue = gv.GetRowCellValue(i, col.Name).ToString();
                        }

                        if (col.Width == 350)
                            columnSize = $"width='{ col.Width }'";

                        rowRowTableData += $"<td style='padding: 3px 5px' {colalignment} {columnSize}> { strvalue.Replace("True", "YES").Replace("False", "-").Replace("\n", "<br/>") }</td> ";
                        //Dim CellData As String = strvalue.Replace("True", "YES").Replace("False", "-").Replace(Chr(13), "<br/>").Replace(vbCrLf, "<br/>").Replace(vbCr, "<br/>").Replace(vbLf, "<br/>")
                    }
                }
                rows += $"<tr style='color:#{rowColor}'>{ rowRowTableData }</tr>";
            }

            string SummaryColumn = "";
            if (gv.OptionsView.ShowFooter)
            {
                foreach (string colstr in indexes)
                {
                    var col = gv.Columns[colstr];
                    if (col != null && col.Visible)
                        SummaryColumn += $"<td align='right' style=' padding: 3px 5px'>{ col.SummaryText }</td>";
                }
            }

            // header/footer
            return $@"
<table border='1' { (width > 700 ? "width='100%' " : "width='700'") }  style='min-width:650px; margin:3px 0' cellpadding='4' cellspacing='0' style='border-collapse:collapse;'>
    <tr><td colspan='{ cnt }' align='center'><b>{ TableTitle.ToUpper() }</b></td></tr>
    <tr>{ ColumnName }<tr>
    { rows }
    <tr style='font-weight:bold;'>{ SummaryColumn }</tr>
</table>
";
        }

        public static object ExportGridToExcel(string filename, GridView gv)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Excel (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FileName = filename + ".xlsx";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }
                gv.ExportToXlsx(saveFileDialog.FileName);
                return true;
            }
            return false;
        }

        //--
        private readonly static string MenuColumnColumnCustomization = GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnColumnCustomization);
        public static bool XgridColumnMenu(PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                foreach (DXMenuItem item in e.Menu.Items)
                {
                    if (item.Caption == MenuColumnColumnCustomization)
                    {
                        item.Visible = false;
                    }
                }
                return true;
            }
            return false;
        }

        public static GridHitInfo XgridGridHitInfo(GridControl gc, Point pt)
        {
            var view = gc.GetViewAt(pt);
            return (view.CalcHitInfo(pt) as GridHitInfo);
        }
        public static RepositoryItemTextEdit ColumnEditTextMasking(string mask_string, int text_length)
        {
            return new RepositoryItemTextEdit
            {
                Mask =
                {
                    MaskType = MaskType.RegEx,
                    EditMask = mask_string
                },
                MaxLength = text_length
            };
        }
    }
}
