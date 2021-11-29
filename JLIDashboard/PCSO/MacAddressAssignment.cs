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
using JLIDashboard.Module;
using Comm.Common.Extensions;
using JLIDashboard.Classes;
using static JLIDashboard.PCSO._x0a.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard._Module;
using DevExpress.XtraGrid.Views.Grid;

namespace JLIDashboard.PCSO
{
    public partial class MacAddressAssignment : DevExpress.XtraEditors.XtraForm
    {
        object compid = null;
        object brcode = null;
        private bool isNew;
        string compname, brname, macadd;
        public MacAddressAssignment()
        {
            InitializeComponent();
        }

        private void MacAddressAssignment_Load(object sender, EventArgs e)
        {
            display();
            populate();
            groupControl1.Text = Login.userid;
        }

        void populate()
        {
            Database.displaySearchlookupEdit($"SELECT DISTINCT COMP_ID, COMP_NM FROM dbo.ESATBAA with(nolock) WHERE COMP_ID NOT IN ('8888','0001')", txtcomp, "COMP_NM", "COMP_NM");
            x0a(txtcomp);
        }

        void display()
        {
            Database.display($"SELECT * FROM dbo.ESATAAB with(nolock)",gridControl1,gridView1);
            x0a(gridView1);
        }
        //public MacAddressAssignment setData()
        //{
        //    this.setInput(null);
        //    this.inputEnability(false);
        //    //this.fillDept();
        //    return this;
        //}
        //private MacAddressAssignment retData(DataRow row)
        //{
        //    row["COMP_ID"] = form.Company;
        //    row["BR_CD"] = form.BranchCode;
        //    row["MC_ADD"] = form.MacAddres;


        //    return this;
        //}
        //private void inputEnability(bool enable)
        //{
        //    txtcomp.Enabled = enable;
        //    txtbranch.Enabled = enable;
        //    txtmacadd.Enabled = enable;
        //}
        //private void setInput(DataRow row)
        //{
        //    bool isNull = (row == null);
        //    this.isNew = isNull;

        //    txtcomp.Text = (isNull ? "" : row["COMP_ID"].Str());
        //    txtbranch.Text = (isNull ? "" : row["BR_CD"].Str());
        //    txtmacadd.Text = (isNull ? "" : row["MC_ADD"].Str());

        //}
        //private void loadTableWProgress()
        //{
        //    StaticSettings.showLoading();
        //    this.loadTable();
        //    StaticSettings.hideLoading();
        //}
        //private void loadTable()
        //{
        //    Database.display($"SELECT * FROM dbo.ESAT029 WHERE COMP_ID='' AND BR_CD = '' ", gridControl1, gridView1);
        //    if (x0a(gridView1).RowCount != 0)
        //    {
        //        this.gridView1.FocusedRowHandle = 0;
        //        //this.gridView1_RowClick(this.gridView1, null);
        //    }
        //}
        void clear()
        {
            txtcomp.Text = "";
            txtbranch.Text = "";
            txtmacadd.Text = "";
        }
        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            bool hasSelected = (row != null);
            cmsBrBtn0b.Visible = hasSelected;
            cmsBrSep0a.Visible = hasSelected;
            cmsBrBtn0d.Visible = cmsBrBtn0c.Visible = false;
            if (!hasSelected) return;
            bool isBlocked = !row["S_ACTV"].To<bool>(false);
            cmsBrBtn0c.Visible = !isBlocked;
            cmsBrBtn0d.Visible = isBlocked;
        }

        void execute()
        {
            //bool checkifExist = Database.checkifExist($"SELECT TOP(1) MC_ADD FROM dbo.ESAT029 WHERE COMP_ID='{compid}' AND BR_CD='{brcode}' AND MC_ADD");
            //if (checkifExist)
            //{
            //    XtraMessageBox.Show("MAC Address already Exists");
            //}
            //else
            //{
                 
            //        Database.ExecuteQuery($"INSERT INTO dbo.ESAT029 VALUES('{compid}','{brcode}','{txtmacadd.Text}','1','{DateTime.Now.ToString()}','{Login.compid + Login.custid}')", "Successfully Added");

                
            //}

            Database.ExecuteQuery($"INSERT INTO dbo.ESATAAB VALUES('{compid}','{brcode}','{txtmacadd.Text}','1','{DateTime.Now.ToString()}','{Login.userid}')", "Successfully Added");

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtcomp.Text) || String.IsNullOrEmpty(txtbranch.Text) || String.IsNullOrEmpty(txtmacadd.Text))
            {
                XtraMessageBox.Show("Please Input All Fields");
            }
            else
            {
                execute();
                clear();
                display();
            }
        }

        private void cmsBrBtn0b_Click(object sender, EventArgs e)
        {
            bool confirm = HelperFunction.ConfirmDialog("Are you sure you want to remove this Data?","Remove MAC Address");
            if (confirm)
            {
                DataRow row = gridView1.GetFocusedDataRow();
                Database.ExecuteQuery($"DELETE TOP(1) FROM dbo.ESATAAB WHERE COMP_ID='{row["COMP_ID"].Str()}' AND BR_CD='{row["BR_CD"].Str()}' AND MC_ADD='{row["MC_ADD"].Str()}'", "Successfully Deleted");
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }


        private void cmsBrBtn0c_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            Database.ExecuteQuery($"UPDATE TOP(1) dbo.ESATAAB SET S_ACTV=0 WHERE COMP_ID='{row["COMP_ID"].Str()}' AND BR_CD='{row["BR_CD"].Str()}' AND MC_ADD='{row["MC_ADD"].Str()}'", "Successfully Updated");
            display();
        }

        private void cmsBrBtn0d_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            Database.ExecuteQuery($"UPDATE TOP(1) dbo.ESATAAB SET S_ACTV=1 WHERE COMP_ID='{row["COMP_ID"].Str()}' AND BR_CD='{row["BR_CD"].Str()}' AND MC_ADD='{row["MC_ADD"].Str()}'", "Successfully Updated");
            display();
        }

        private void cmsBrBtn0a_Click(object sender, EventArgs e)
        {
            display();
        }
        private void txtcomp_EditValueChanged(object sender, EventArgs e)
        {
            compid = Classes.SearchLookUpClass.getSingleValue(txtcomp, "COMP_ID");
            Database.displaySearchlookupEdit($"exec dbo.spfn_BBA0B '{compid}' ", txtbranch, "BR_NME", "BR_NME"); //
            x0b(txtbranch);
        }
         
        private void txtbranch_EditValueChanged(object sender, EventArgs e)
        {
            brcode = Classes.SearchLookUpClass.getSingleValue(txtbranch, "BR_CD");
        }
    }
    public partial class _x0a
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("S_ACTV", "Active?", 1, gridView);
                    DevXSettings.XtraFormatColumn("COMP_ID", "Company Code", 2, gridView);
                    DevXSettings.XtraFormatColumn("BR_CD", "Branch Code", 3, gridView);
                    DevXSettings.XtraFormatColumn("MC_ADD", "Register Mac Address", 4, gridView);
                    DevXSettings.XtraFormatColumn("RGS_USR_ID", "Register By", 5, gridView);
                    gridView.BestFitColumns();
                }
                return gridView;
            }
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("COMP_ID", "Code", 0, gridView);
                DevXSettings.XtraFormatColumn("COMP_NM", "Company Name", 1, gridView);
                gridView.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0b(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridView = control.Properties.View;
                DevXSettings.XgridColsVisible(gridView, false);
                DevXSettings.XtraFormatColumn("BR_CD", "Code", 0, gridView);
                DevXSettings.XtraFormatColumn("BR_NME", "Branch Name", 1, gridView);
                gridView.BestFitColumns();
                return control;
            }
        }
    }
}