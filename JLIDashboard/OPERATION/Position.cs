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

namespace JLIDashboard.OPERATION
{
    public partial class Position : DevExpress.XtraEditors.XtraForm
    {
        public Position()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            tbpolitcalposition.Enabled = false;
            if (btnNew.Text == "New")
            {
                btnCancel.Enabled = true;
                tbpolitcalposition.Enabled = true;
                btnNew.Text = "Save";
            }
            else if (btnNew.Text == "Save")
            {
                //Execute save
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            tbpolitcalposition.Enabled = false;
            btnNew.Text = "New";
            tbpolitcalposition.Text = "";
        }
    }
}