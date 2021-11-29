using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using JLIDashboard._Module;
using DevExpress.XtraGrid.Views.Grid;

namespace JLIDashboard.PCSO
{
    public partial class PCSODashboard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public PCSODashboard()
        {
            InitializeComponent();
        }

        private void btnCompanies_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Companies))
                {
                    form.Activate();
                    return;
                }
            }
            Companies comp = new Companies();
            comp.MdiParent = this;
            comp.Show();
        }

        private void btnMacAddressAssignment_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MacAddressAssignment))
                {
                    form.Activate();
                    return;
                }
            }
            MacAddressAssignment comp = new MacAddressAssignment();
            comp.MdiParent = this;
            comp.Show();
        }
    }
}