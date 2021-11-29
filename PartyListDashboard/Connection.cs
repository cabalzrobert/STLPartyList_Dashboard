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
using Microsoft.Win32;
using System.Data.SqlClient;
using JLIDashboard.Classes;

namespace JLIDashboard
{
    public partial class Connection : DevExpress.XtraEditors.XtraForm
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = null;
            try
            {
                var connectionString = "Data Source=" + txtservername.Text + ";Initial Catalog=" + cbodbname.Text + ";User ID =" + txtserverid.Text + ";Password=" + txtserverpassword.Text + ";";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                {
                    XtraMessageBox.Show("Connection Successful.");
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            //string result = Database.getSingleResultSet($"exec dbo.spfunc_017LG9PR '0002','006','00600000014','01','3PM','20210114','123' ");
            txtservername.Text = System.Environment.MachineName.ToString();
        }

        private void txtconnsettingsname_Click(object sender, EventArgs e)
        {

        }
        private void display_databases()
        {
            SqlConnection cnn = null;
            try
            {
                var connectionString = "Data Source=" + txtservername.Text + ";Initial Catalog=" + cbodbname.Text + ";User ID =" + txtserverid.Text + ";Password=" + txtserverpassword.Text + ";";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                //
                string str = "SELECT name FROM master.dbo.sysdatabases WHERE name NOT IN ('master','model','msdb','tempdb') ";
                SqlCommand com = new SqlCommand(str, cnn);
                SqlDataReader reader = com.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        cbodbname.Items.Add(reader["name"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }

        }
        private void cbodbname_Click(object sender, EventArgs e)
        {
            cbodbname.Items.Clear();
            display_databases();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //regkey = Registry.CurrentUser.CreateSubKey(txtconnsettingsname.Text);
            var regkey = Database.RegKey;//Registry.CurrentUser.CreateSubKey(@"ESAT\ConnSettingsMain");
            regkey.SetValue("dbconn", "Data Source=" + txtservername.Text + ";Initial Catalog=" + cbodbname.Text + ";User ID =" + txtserverid.Text + ";Password=" + txtserverpassword.Text + ";Connection Timeout = 3600;Persist Security Info = True;");
            regkey.SetValue("servername", txtservername.Text);
            regkey.SetValue("dbname", cbodbname.Text);
            regkey.SetValue("serverid", txtserverid.Text);
            regkey.SetValue("serverpassword", txtserverpassword.Text);
            Application.Restart();
            //Thread.Sleep(3000);
        }
    }
}