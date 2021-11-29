using DevExpress.XtraEditors;

namespace JLIDashboard.TREASURY
{
    partial class Remittances
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsRem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRemBtn0c = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemBtn0b = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemSep0a = new System.Windows.Forms.ToolStripSeparator();
            this.cmsRemBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmsRemBtn0d = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsRem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsRem;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(649, 396);
            this.gridControl1.TabIndex = 10037;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsRem
            // 
            this.cmsRem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRemBtn0d,
            this.cmsRemBtn0c,
            this.cmsRemBtn0b,
            this.cmsRemSep0a,
            this.cmsRemBtn0a});
            this.cmsRem.Name = "contextMenuStrip1";
            this.cmsRem.Size = new System.Drawing.Size(211, 134);
            // 
            // cmsRemBtn0c
            // 
            this.cmsRemBtn0c.Name = "cmsRemBtn0c";
            this.cmsRemBtn0c.Size = new System.Drawing.Size(210, 24);
            this.cmsRemBtn0c.Text = "Edit Remittance";
            this.cmsRemBtn0c.Click += new System.EventHandler(this.cmsRemBtn0c_Click);
            // 
            // cmsRemBtn0b
            // 
            this.cmsRemBtn0b.Name = "cmsRemBtn0b";
            this.cmsRemBtn0b.Size = new System.Drawing.Size(210, 24);
            this.cmsRemBtn0b.Text = "Delete";
            this.cmsRemBtn0b.Click += new System.EventHandler(this.cmsRemBtn0b_Click);
            // 
            // cmsRemSep0a
            // 
            this.cmsRemSep0a.Name = "cmsRemSep0a";
            this.cmsRemSep0a.Size = new System.Drawing.Size(207, 6);
            // 
            // cmsRemBtn0a
            // 
            this.cmsRemBtn0a.Name = "cmsRemBtn0a";
            this.cmsRemBtn0a.Size = new System.Drawing.Size(210, 24);
            this.cmsRemBtn0a.Text = "Refresh";
            this.cmsRemBtn0a.Click += new System.EventHandler(this.cmsRemBtn0a_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // cmsRemBtn0d
            // 
            this.cmsRemBtn0d.Name = "cmsRemBtn0d";
            this.cmsRemBtn0d.Size = new System.Drawing.Size(210, 24);
            this.cmsRemBtn0d.Text = "Add Remittance";
            this.cmsRemBtn0d.Click += new System.EventHandler(this.cmsRemBtn0d_Click);
            // 
            // Remittances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 396);
            this.Controls.Add(this.gridControl1);
            this.Name = "Remittances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remittance";
            this.Load += new System.EventHandler(this.ClaimCommission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsRem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmsRem;
        private System.Windows.Forms.ToolStripMenuItem cmsRemBtn0b;
        private System.Windows.Forms.ToolStripSeparator cmsRemSep0a;
        private System.Windows.Forms.ToolStripMenuItem cmsRemBtn0a;
        private System.Windows.Forms.ToolStripMenuItem cmsRemBtn0c;
        private System.Windows.Forms.ToolStripMenuItem cmsRemBtn0d;
    }
}