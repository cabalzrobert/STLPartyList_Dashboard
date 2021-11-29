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
using System.Data.SqlClient;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Comm.Common.Extensions;
using AbacosDashboard.Module.Enum;
using static JLIDashboard.UserAccess.menuAccess;
using JLIDashboard.Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard
{
    public partial class UserAccess : DevExpress.XtraEditors.XtraForm
    {
        private string userid = "";
        private string strmenuhomepage = "";
        public UserAccess()
        {
            InitializeComponent();
        }

        private void UserAccess_Load(object sender, EventArgs e)
        {
            display();
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            userid = SearchLookUpClass.getSingleValue(searchLookUpEdit1, "USR_ID").Str();
            checkAccess();
        }
        private void display()
        {
            //Database.display("select * from UserMenuAccess", gridControl1, gridView1);
            //string where = "";
            //spfn_BDA001
            //if (!Login.brcode.Str().Equals("888")) where += $" AND BR_CD='{Login.brcode}' ";
            //Database.displaySearchlookupEdit($"SELECT COMP_ID, BR_CD, USR_ID, USR_NM FROM dbo.ESATBDA with(nolock) WHERE COMP_ID='{Login.compid}' AND ISNULL(USR_NM,'')<>'' {where}", searchLookUpEdit1, "USR_NM", "USR_NM");
            API.displaySearchLookupEditAPI("/api/v1/Users/GetUserAccess", Login.authentication, searchLookUpEdit1, "USR_NM", "USR_NM");
            //    , new Dictionary<string, string>()
            //{
            //    { "compID",Login.compid},
            //    {"branchID",Login.brcode }
            //});
            loadeulz();
        }

        void checkAccess()
        {
            //spfn_AAD002
            DataTable dt = API.APITableParam($"/api/v1/Users/UserMenuAccess?userid={userid}", Login.authentication);
            //string pages = Database.getSingleQuery("dbo.ESATAAD", $"USR_ID='{userid}'", "PGS");
            string pages = string.Empty;
            if (dt.Rows.Count > 0) pages = dt.Rows[0]["PGS"].Str();
            readData_Menu_listbox(pages, homepage_checklist);



            /*SqlConnection con = Database.getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM ESAT035 WHERE UserID='" + userid + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    strmenuhomepage = reader["isHomepage"].ToString();
                   
                    reader.Close();
                    readData_Menu_listbox(strmenuhomepage, homepage_checklist);
                 
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally { con.Close(); }*/
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            strmenuhomepage = checkMenu(homepage_checklist);
            if (String.IsNullOrEmpty(searchLookUpEdit1.Text))
            {
                XtraMessageBox.Show("Please Select User!");
                return;
            }
            else
            {
                //spfn_AAD001
                //Database.ExecuteQuery($"DELETE TOP(1) FROM dbo.ESATAAD WHERE USR_ID='{userid}'");
                //Database.ExecuteQuery($"INSERT INTO dbo.ESATAAD(USR_ID,PGS) VALUES('{userid}','{strmenuhomepage}')", "Successfully Inserted!");
                var res = (DB.executeUpdateAccess(userid, strmenuhomepage)).Result;
                if (res.result == Results.Success)
                {
                    StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                    if (Login.userid == userid)
                    {
                        Application.Restart();
                    }
                }
                else if (res.result != Results.Null)
                {
                    StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
                }
                else
                {
                    XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }


            }
        }
        void loadeulz()
        {
            MainDashboard main = new MainDashboard();
            BarItem mcurrentitem;
            homepage_checklist.Items.Clear();
            foreach (RibbonPage currentPage in main.ribbon.Pages)
            {
                foreach (RibbonPageGroup currentgroup in currentPage.Groups)
                {
                    foreach (BarItemLink currentlink in currentgroup.ItemLinks)
                    {
                        mcurrentitem = currentlink.Item;
                        string STR = currentPage.Text;
                        // if (currentPage.Text == "HOME")
                        //adminTools_checklist.Items.Add(mcurrentitem.Name);
                        if (currentPage.Text == "HOMEPAGE")
                            homepage_checklist.Items.Add(mcurrentitem.Name);

                    }
                }
            }
        }

        String checkMenu(CheckedListBoxControl xlist)
        {
            string strmenulist = "";
            if (xlist.SelectedItems.Count > 0)
            {
                for (int x = 0; x <= xlist.Items.Count - 1; x++)
                {
                    if (xlist.Items[x].CheckState == CheckState.Checked)
                    {
                        strmenulist = strmenulist + "|" + xlist.Items[x].ToString();
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

        public void readData_Menu_listbox(string strMenu, DevExpress.XtraEditors.CheckedListBoxControl current_list)
        {
            string wholefile = strMenu.Str();
            string[] fieldData = wholefile.Split('|');
            foreach (dynamic item in current_list.Items)
            {
                bool hasVal = fieldData.Contains(((object)item.Value).ToString());
                item.CheckState = (hasVal ? CheckState.Checked : CheckState.Unchecked);
            }
            /*foreach (string lineOfText in lineData)
            {
                fieldData = lineOfText.Split('|');
                foreach (string wordOfText in fieldData)
                {
                    if (wordOfText == "")
                    {
                        continue;
                    }
                    for (int i = 0; i <= current_list.Items.Count - 1; i++)
                    {
                        var d = current_list.Items[i];
                        if (current_list.Items[i].Value.ToString() == wordOfText)
                        {
                            current_list.Items[i].CheckState = CheckState.Checked;
                        }
                    }
                }
            }*/

        }
        public partial class menuAccess
        {
            public class DB
            {
                public static async Task<(Results result, String message)> executeUpdateAccess(string userid, string strmenuhomepage)
                {
                    var result = API.DSpQueryAPI("/api/v1/Users/UserAssignedAccess", Login.authentication, new Dictionary<string, object>()
                    {
                        { "userID",userid },
                        { "menuAccess",strmenuhomepage }
                    });
                    if (result != null)
                    {
                        var row = ((IDictionary<string, object>)result);
                        string ResultCode = row["result"].Str();
                        if (ResultCode == "2")
                        {
                            return (Results.Success, row["message"].Str());
                        }
                        return (Results.Failed, "Something wrong in your data. Please try again");
                    }
                    return (Results.Null, null);
                }
            }
        }

    }
}