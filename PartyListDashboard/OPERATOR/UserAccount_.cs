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

namespace JLIDashboard.OPERATOR
{
    public partial class UserAccount_ : DevExpress.XtraEditors.XtraForm
    {
        string custid;
        object deptid = null;
        public UserAccount_()
        {
            InitializeComponent();
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            disablefields();
            display(Login.brcode);
            populate();
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }
        void populate()
        {
            Classes.Database.displaySearchlookupEdit("SELECT CodeInstance as DeptID,InstanceName as DeptName FROM dbo.ESAT000 WHERE CodeID='CD008'", txtdept, "DeptName", "DeptName");

        }
        void display(string branchcode)
        {
            //Classes.Database.display($"SELECT * FROM dbo.vw_UserAdminAccount WHERE CompID='{Login.compid}' AND  ", gridControlwinningsandlimit, gridViewwinningsandlimit);
            Classes.Database.display($"SELECT * FROM dbo.functable_getBranchAccounts('{Login.compid}','{branchcode}','{Login.userid}')  ", gridControlUsers, gridViewUsers);
        }
       
        void clear()
        {
            txtaddress.Text = "";
            txtdept.Text = "";
            txtemail.Text = "";
            txtfirstname.Text = "";
            txtlname.Text = "";
            txtmobno.Text = "";
            txtpassword.Text = "";
            txtusername.Text = "";

            //txtgencoor.Text = "";

        }
        void enablefields()
        {
            txtaddress.Enabled = true;
            txtdept.Enabled = true;
            txtemail.Enabled = true;
            txtfirstname.Enabled = true;
            txtlname.Enabled = true;
            txtmobno.Enabled = true;
            txtpassword.Enabled = true;
            txtusername.Enabled = true;

        }
        void disablefields()
        {
            txtaddress.Enabled = false;
            txtdept.Enabled = false;
            txtemail.Enabled = false;
            txtfirstname.Enabled = false;
            txtlname.Enabled = false;
            txtmobno.Enabled = false;
            txtpassword.Enabled = false;
            txtusername.Enabled = false;

        }

        private void txtdept_EditValueChanged(object sender, EventArgs e)
        {
            deptid = Classes.SearchLookUpClass.getSingleValue(txtdept, "DeptID");
        }

        private void gridControlUsers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(gridControlUsers, e.Location);
        }

        private void editDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnnew.Enabled = false;
            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btncancel.Enabled = true;

            enablefields();

            custid= gridViewUsers.GetRowCellValue(gridViewUsers.FocusedRowHandle, "CustID").ToString();
            txtusername.Text = gridViewUsers.GetRowCellValue(gridViewUsers.FocusedRowHandle, "UserName").ToString();//gridViewUsers.GetRowCellValue(gridViewUsers.FocusedRowHandle, "UserName").ToString();
            txtfirstname.Text = gridViewUsers.GetRowCellValue(gridViewUsers.FocusedRowHandle, "FirstName").ToString();
            txtlname.Text = gridViewUsers.GetRowCellValue(gridViewUsers.FocusedRowHandle, "LastName").ToString();
            txtaddress.Text = gridViewUsers.GetRowCellValue(gridViewUsers.FocusedRowHandle, "Address").ToString();
            txtmobno.Text = gridViewUsers.GetRowCellValue(gridViewUsers.FocusedRowHandle, "MobileNo").ToString();
            //txtdept.Text = gridViewUsers.GetRowCellValue(gridViewUsers.FocusedRowHandle, "Department").ToString();
            txtemail.Text = gridViewUsers.GetRowCellValue(gridViewUsers.FocusedRowHandle, "EmailAdd").ToString();
            
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            enablefields();
            display(Login.brcode);
            clear();
            btnnew.Enabled = false;
            btnadd.Enabled = true;
            btnupdate.Enabled = false;
            btncancel.Enabled = true;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtaddress.Text) || String.IsNullOrEmpty(txtdept.Text) || String.IsNullOrEmpty(txtfirstname.Text) || String.IsNullOrEmpty(txtlname.Text) || String.IsNullOrEmpty(txtmobno.Text) || String.IsNullOrEmpty(txtpassword.Text) || String.IsNullOrEmpty(txtusername.Text))
            {
                XtraMessageBox.Show("Fields must not Empty!..");
                return;
            }
            else
            {
                Add();

                display(Login.brcode);
                clear();
                disablefields();

                btnnew.Enabled = true;
                btnadd.Enabled = false;
                btnupdate.Enabled = false;
                btncancel.Enabled = false;
            }
        }

        void Add()
        {
            executeSP("1", "");
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            clear();
            disablefields();

            btnnew.Enabled = true;
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            updateSettings();
            clear();
            disablefields();
            display(Login.brcode);

            btnnew.Enabled = true;
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }

        void executeSP(string actioncode,string optrid)
        {
            string result = Classes.Database.getSingleResultSet($"EXEC dbo.spfunc_003BO9O '{Login.compid}'" +
                $",'{Login.brcode}'" +
                $",'{Login.userid}'" +
                $",'{actioncode}'" +
                $",'{optrid}'" +
                $",'{txtfirstname.Text}'" +//@parmusrfnm
                $",'{txtlname.Text}'" +
                $",'{txtusername.Text}'" +
                $",'{txtpassword.Text}'" +
                $",'{txtaddress.Text}'" +
                $",'{txtmobno.Text}'" +
                $",'{txtemail.Text}'" +
                $",'{deptid.ToString()}' ");
            if (result == "1")
            {
                XtraMessageBox.Show("Successfully Executed!...");
            }
            else
            {
                XtraMessageBox.Show("Error");
                this.Close();
            }
        }

        void updateSettings() 
        {
            executeSP("3", Login.compid + custid);
        }
    }
}