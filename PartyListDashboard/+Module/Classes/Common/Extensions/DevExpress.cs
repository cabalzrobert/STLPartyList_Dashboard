using System.Data;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace JLIDashboard.Classes.Common.Extensions
{
    public static class DevExpressExt
    {
        public static Object GetSelectedSingleValue(this SearchLookUpEdit control, string fieldname)
        {
            object value = null;
            try
            {
                DataRow row = control.GetFocusedDataRow();
                value = row[fieldname];
            }
            catch { }
            return value;
        }
        public static DataRow GetFocusedDataRow(this SearchLookUpEdit control)
        {
            DataRow row = null;
            try
            {
                GridView view = control.Properties.View;
                DataRowView drv = (control.GetSelectedDataRow() as DataRowView);
                if (drv != null) row = drv.Row;
            }
            catch { }
            return row;
        }
        private static DataRow[] _rows = new DataRow[0];
        public static DataRow[] Select(this SearchLookUpEdit control, string query)
        {
            DataRow[] rows = _rows;
            try
            {
                DataTable dt = (DataTable)control.Properties.DataSource;
                if (dt != null) rows = dt.Select(query);
            }
            catch { }
            return rows;
        }

        public static DataRow[] Select(this DevExpress.XtraGrid.Views.Grid.GridView control, string query)
        {
            DataRow[] rows = _rows;
            try
            {
                DataTable dt = (DataTable)control.GridControl.DataSource;
                if (dt != null) rows = dt.Select(query);
            }
            catch { }
            return rows;
        }
        public static bool SetFocusedDataRow(this DevExpress.XtraGrid.Views.Grid.GridView control, DataRow row)
        {
            bool found = false;
            try
            {
                for (int i = 0; i < control.RowCount; i++)
                {
                    DataRowView drv = (control.GetRow(i) as DataRowView);
                    if (row == drv.Row)
                    {
                        control.FocusedRowHandle = i;
                        found = true;
                        break;
                    }
                }
            }
            catch { }
            return found;
        }

        public static DataRow[] GetSelectedDataRows(this CheckedComboBoxEdit control)
        {
            DataRow[] rows = _rows;
            var items = control.Properties.Items;
            if (items.Count != 0)
            {
                DataTable table = (control.Properties.DataSource as DataTable);
                if (table != null)
                {
                    DataTable newTable = table.Clone();
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].CheckState != CheckState.Checked)
                            continue;
                        newTable.Rows.Add(table.Rows[i].ItemArray);
                    }
                    rows = newTable.Select();
                    table = newTable = null;
                }
            }
            items = null;
            return rows;
        }
    }
}