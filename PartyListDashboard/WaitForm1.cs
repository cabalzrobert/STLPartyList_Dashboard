using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using DevExpress.XtraWaitForm;

namespace JLIDashboard
{
    public partial class WaitForm1 : WaitForm
    {
        public WaitForm1()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        public override void SetCaption(string caption)
        {
            if (String.IsNullOrEmpty(caption))
                caption = "Please Wait";
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, RuntimeHelpers.GetObjectValue(arg));
        }

        private void WaitForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Dispose();
        }
    }
}
