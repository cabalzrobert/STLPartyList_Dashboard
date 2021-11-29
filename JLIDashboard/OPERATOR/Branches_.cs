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
    public partial class Branches_ : DevExpress.XtraEditors.XtraForm
    {
        object brcode = null;
        public Branches_()
        {
            InitializeComponent();
        }

        private void Branches_Load(object sender, EventArgs e)
        {
            disablefields();
            //display();
            Classes.Database.displaySearchlookupEdit($"SELECT BR_CD BranchCode,BR_NME BranchName FROM dbo.ESAT003 WHERE COMP_ID='{Login.plid}' AND BR_CD <> '888'", txtbranchfilter, "BranchName", "BranchName");
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }
       
        void display(string branchcode)
        {
            //Classes.Database.display($"SELECT * FROM dbo.vw_UserAdminAccount WHERE CompID='{Login.compid}' AND  ", gridControlwinningsandlimit, gridViewwinningsandlimit);
            Classes.Database.display($"SELECT * FROM dbo.functable_getBranchAccounts('{Login.plid}','{branchcode}','{Login.userid}')  ", gridControlwinningsandlimit, gridViewwinningsandlimit);
        }
        void clear()
        {
            txtbrcode.Text = "";
            txtaddress.Text = "";
            txtareaname.Text = "";
            txtbranchaddress.Text = "";
            txtbranchemail.Text = "";
            txtbranchname.Text = "";
            txtemail.Text = "";
            txtfirstname.Text = "";
            txtlicenseno.Text = "";
            txtlname.Text = "";
            txtmobno.Text = "";
            txtpassword.Text = "";
            txtshortname.Text = "";
            txttechsupp.Text = "";
            txttelno.Text = "";
            txttinno.Text = "";
            txtusername.Text = "";
            txtwebsite.Text = "";
            txtzipcode.Text = "";
        }
        void enablefields()
        {
            txtaddress.Enabled = true;
            txtareaname.Enabled = true;
            txtbranchaddress.Enabled = true;
            txtbranchemail.Enabled = true;
            txtbranchname.Enabled = true;
            txtemail.Enabled = true;
            txtfirstname.Enabled = true;
            txtlicenseno.Enabled = true;
            txtlname.Enabled = true;
            txtmobno.Enabled = true;
            txtpassword.Enabled = true;
            txtshortname.Enabled = true;
            txttechsupp.Enabled = true;
            txttelno.Enabled = true;
            txttinno.Enabled = true;
            txtusername.Enabled = true;
            txtwebsite.Enabled = true;
            txtzipcode.Enabled = true;

        }
        void disablefields()
        {
            
            txtaddress.Enabled = false;
            txtareaname.Enabled = false;
            txtbranchaddress.Enabled = false;
            txtbranchemail.Enabled = false;
            txtbranchname.Enabled = false;
            txtemail.Enabled = false;
            txtfirstname.Enabled = false;
            txtlicenseno.Enabled = false;
            txtlname.Enabled = false;
            txtmobno.Enabled = false;
            txtpassword.Enabled = false;
            txtshortname.Enabled = false;
            txttechsupp.Enabled = false;
            txttelno.Enabled = false;
            txttinno.Enabled = false;
            txtusername.Enabled = false;
            txtwebsite.Enabled = false;
            txtzipcode.Enabled = false;

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            enablefields();
            display(brcode.ToString());
            clear();
            int getlastbranchcode = Classes.Database.getLastID("ESAT003", $"COMP_ID='{Login.plid}'", "BR_CD") + 1;
            string newbrcode=Classes.HelperFunction.sequencePadding(getlastbranchcode.ToString(), 3);
            txtbrcode.Text = newbrcode;
            btnnew.Enabled = false;
            btnadd.Enabled = true;
            btnupdate.Enabled = false;
            btncancel.Enabled = true;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtaddress.Text) || String.IsNullOrEmpty(txtareaname.Text) || String.IsNullOrEmpty(txtbranchaddress.Text) 
                || String.IsNullOrEmpty(txtusername.Text) || String.IsNullOrEmpty(txtbranchname.Text) || String.IsNullOrEmpty(txtzipcode.Text) 
                || String.IsNullOrEmpty(txtfirstname.Text) || String.IsNullOrEmpty(txtlicenseno.Text) || String.IsNullOrEmpty(txtlname.Text) 
                || String.IsNullOrEmpty(txtmobno.Text) || String.IsNullOrEmpty(txtpassword.Text) || String.IsNullOrEmpty(txtshortname.Text) 
                || String.IsNullOrEmpty(txttechsupp.Text) || String.IsNullOrEmpty(txttelno.Text) || String.IsNullOrEmpty(txttinno.Text))
            {
                XtraMessageBox.Show("Fields must not Empty!..");
                return;
            }
            else
            {
                Add();

                //display(brcode.ToString());
                clear();
                disablefields();

                btnnew.Enabled = true;
                btnadd.Enabled = false;
                btnupdate.Enabled = false;
                btncancel.Enabled = false;
            }
        }

        void executeSP(string actioncode,string optrid)
        {
            string result = Classes.Database.getSingleResultSet($"EXEC dbo.spfunc_003BA9O '{Login.plid}'" +
                   $",'{Login.userid}'" +
                   $",'{actioncode}'" +
                   $",'{txtbrcode.Text}'" + //branchcode
                   $",'{optrid}'" + //@parmagntid
                   $",'{txtbranchname.Text}'" +
                   $",'{txtbranchaddress.Text}'" +
                   $",'{txtlicenseno.Text}'" +
                   $",'{txttinno.Text}'" +
                   $",'{txtshortname.Text}'" +
                   $",'{txtareaname.Text}'" +
                   $",'{txttelno.Text}'" +
                   $",'{txttechsupp.Text}'" +
                   $",'{txtbranchemail.Text}'" +
                   $",'{txtwebsite.Text}'" +
                   $",'{txtzipcode.Text}'" +
                   $",0" + //@BrComm decimal(7,2) = 23.00
                   $",0" + //@EsatComm decimal(7,2) = 0.0
                   $",0" + //@ManagerComm decimal(7,2) = 23.00
                   $",'{txtfirstname.Text}'" +
                   $",'{txtlname.Text}'" +
                   $",'{txtusername.Text}'" +
                   $",'{txtpassword.Text}'" +
                   $",'{txtaddress.Text}'" +
                   $",'{txtmobno.Text}'" +
                   $",'{txtemail.Text}' ");
            if (result == "1")
            {
                XtraMessageBox.Show("Successfully Executed");

            }
            else { XtraMessageBox.Show("Error"); }
        }
        void Add()
        {
            bool checkifexists = Classes.Database.checkifExist($"SELECT TOP(1) COMP_ID,BR_CD FROM dbo.ESAT003 WHERE COMP_ID='{Login.plid}' AND BR_CD='{txtbrcode.Text}' ");
            if (checkifexists)
            {
                XtraMessageBox.Show("Branch Code Already Exists");
                return;
            }
             
            else
            {
                executeSP("1", "");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            updateSettings();
            clear();
            disablefields();
            //display(brcode.ToString());
            btnnew.Enabled = true;
            btnadd.Enabled = false;
            btnupdate.Enabled = false;
            btncancel.Enabled = false;
        }
        void updateSettings()
        {
            string getUserCustID = Classes.Database.getSingleQuery($"SELECT TOP(1) CUST_ID FROM dbo.ESAT002 WHERE COMP_ID='{Login.plid}' AND BR_CD='{txtbrcode.Text}' AND USR_NM='{txtusername.Text}'", "CUST_ID");
            executeSP("3", Login.plid+getUserCustID);   
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

        private void gridControlwinningsandlimit_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(gridControlwinningsandlimit, e.Location);
        }

        private void editDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnnew.Enabled = false;
            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btncancel.Enabled = true;

            enablefields();
            string getUserCustID = Classes.Database.getSingleQuery($"SELECT TOP(1) CUST_ID FROM dbo.ESAT002 WHERE COMP_ID='{Login.plid}' AND BR_CD='{Login.pgrpid}' AND USR_NM='{txtusername.Text}'", "CUST_ID");

            string brcd = gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "BranchCode").ToString();
            var rowz = Classes.Database.getMultipleQuery($"SELECT * FROM dbo.functable_BranchProfile('{Login.plid}','{brcd}','{Login.plid + getUserCustID}')"); //, "COMP_ID,BR_CD,CUST_ID,USR_NM,USR_FLLNME,USR_FRST_NM,USR_LST_NM,USR_TYP,USR_STAT,IS_BLCK,DateRegistered,EML_ADD,USR_MOB_NO,PRSNT_ADDR,BR_NME,BR_LOC_ZP,BR_BRGY_CD,RGS_TRN_TS,BR_ADDRS,LCNSD_NO,TIN_NO,SHRT_NM,AREA_NM,BR_TEL_NO,BR_TCHSUPNO,BR_EML,BR_WBST"
            string COMP_ID, BR_CD, CUST_ID, USR_NM, USR_FLLNME, USR_FRST_NM, USR_LST_NM, USR_TYP, USR_STAT, IS_BLCK, DateRegistered, EML_ADD, USR_MOB_NO, PRSNT_ADDR, BR_NME, BR_LOC_ZP, BR_BRGY_CD, RGS_TRN_TS, BR_ADDRS, LCNSD_NO, TIN_NO, SHRT_NM, AREA_NM, BR_TEL_NO, BR_TCHSUPNO, BR_EML, BR_WBST;
            COMP_ID = rowz["COMP_ID"].ToString();
            BR_CD = rowz["BR_CD"].ToString();
            CUST_ID = rowz["CUST_ID"].ToString();
            USR_NM = rowz["USR_NM"].ToString();
            USR_FLLNME = rowz["USR_FLLNME"].ToString();
            USR_FRST_NM = rowz["USR_FRST_NM"].ToString();
            USR_LST_NM = rowz["USR_LST_NM"].ToString();
            USR_TYP = rowz["USR_TYP"].ToString();
            USR_STAT = rowz["USR_STAT"].ToString();
            IS_BLCK = rowz["IS_BLCK"].ToString();
            DateRegistered = rowz["DateRegistered"].ToString();
            EML_ADD = rowz["EML_ADD"].ToString();
            USR_MOB_NO = rowz["USR_MOB_NO"].ToString();
            PRSNT_ADDR = rowz["PRSNT_ADDR"].ToString();
            BR_NME = rowz["BR_NME"].ToString();
            BR_LOC_ZP = rowz["BR_LOC_ZP"].ToString();
            BR_BRGY_CD = rowz["BR_BRGY_CD"].ToString();
            RGS_TRN_TS = rowz["RGS_TRN_TS"].ToString();
            BR_ADDRS = rowz["BR_ADDRS"].ToString();
            LCNSD_NO = rowz["LCNSD_NO"].ToString();
            TIN_NO= rowz["TIN_NO"].ToString();
            SHRT_NM = rowz["SHRT_NM"].ToString();
            AREA_NM = rowz["AREA_NM"].ToString();
            BR_TEL_NO = rowz["BR_TEL_NO"].ToString();
            BR_TCHSUPNO = rowz["BR_TCHSUPNO"].ToString();
            BR_EML = rowz["BR_EML"].ToString();
            BR_WBST = rowz["BR_WBST"].ToString();

            txtbrcode.Text = BR_CD;
            txtaddress.Text = PRSNT_ADDR;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "Address").ToString();
            txtareaname.Text = AREA_NM;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "AreaName").ToString();
            txtbranchaddress.Text = BR_ADDRS; //gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "Address").ToString();
            txtbranchemail.Text = BR_EML;//gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "Email").ToString();
            txtbranchname.Text = BR_NME;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "BranchName").ToString();
            txtemail.Text = EML_ADD;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "Email").ToString();
            txtfirstname.Text = USR_FRST_NM;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "FirstName").ToString();
            txtlicenseno.Text = LCNSD_NO;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "LicensedNo").ToString();
            txtlname.Text = USR_LST_NM;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "LastName").ToString();
            txtmobno.Text = USR_MOB_NO;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "UserMobileNo").ToString();
            //txtpassword.Text = gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "GameType").ToString();
            txtshortname.Text = SHRT_NM;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "ShortName").ToString();
            txttechsupp.Text = BR_TCHSUPNO;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "TechSupport").ToString();
            txttelno.Text = BR_TEL_NO;//gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "TelNo").ToString();
            txttinno.Text = TIN_NO;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "TinNo").ToString();
            txtusername.Text = USR_NM;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "UserName").ToString();
            txtwebsite.Text = BR_WBST;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "Website").ToString();
            txtzipcode.Text = BR_LOC_ZP;// gridViewwinningsandlimit.GetRowCellValue(gridViewwinningsandlimit.FocusedRowHandle, "ZipCode").ToString();


        }

        private void txtbranchfilter_EditValueChanged(object sender, EventArgs e)
        {
            brcode = Classes.SearchLookUpClass.getSingleValue(txtbranchfilter, "BranchCode");
            display(brcode.ToString());
        }
    }
}