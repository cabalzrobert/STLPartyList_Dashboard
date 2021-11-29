namespace JLIDashboard.OPERATOR
{
    partial class APKVersion
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsuploadapk = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsupdateapk = new System.Windows.Forms.ToolStripMenuItem();
            this.cmssetapk = new System.Windows.Forms.ToolStripMenuItem();
            this.cmddownloadapk = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsrefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(772, 405);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(768, 401);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsuploadapk,
            this.cmsupdateapk,
            this.cmssetapk,
            this.cmddownloadapk,
            this.toolStripSeparator1,
            this.cmsrefresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 142);
            // 
            // cmsuploadapk
            // 
            this.cmsuploadapk.Name = "cmsuploadapk";
            this.cmsuploadapk.Size = new System.Drawing.Size(180, 22);
            this.cmsuploadapk.Text = "Upload APK";
            this.cmsuploadapk.Click += new System.EventHandler(this.cmsuploadapk_Click);
            // 
            // cmsupdateapk
            // 
            this.cmsupdateapk.Name = "cmsupdateapk";
            this.cmsupdateapk.Size = new System.Drawing.Size(180, 22);
            this.cmsupdateapk.Text = "Update";
            this.cmsupdateapk.Click += new System.EventHandler(this.cmsupdateapk_Click);
            // 
            // cmssetapk
            // 
            this.cmssetapk.Name = "cmssetapk";
            this.cmssetapk.Size = new System.Drawing.Size(180, 22);
            this.cmssetapk.Text = "Set Primary";
            this.cmssetapk.Click += new System.EventHandler(this.cmssetapk_Click);
            // 
            // cmddownloadapk
            // 
            this.cmddownloadapk.Name = "cmddownloadapk";
            this.cmddownloadapk.Size = new System.Drawing.Size(180, 22);
            this.cmddownloadapk.Text = "Download APK";
            this.cmddownloadapk.Click += new System.EventHandler(this.cmddownloadapk_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // cmsrefresh
            // 
            this.cmsrefresh.Name = "cmsrefresh";
            this.cmsrefresh.Size = new System.Drawing.Size(180, 22);
            this.cmsrefresh.Text = "Refresh";
            this.cmsrefresh.Click += new System.EventHandler(this.cmsrefresh_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            // 
            // APKVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 405);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.Image = global::JLIDashboard.Properties.Resources.APKLogo;
            this.Name = "APKVersion";
            this.Text = "APK Version";
            this.Load += new System.EventHandler(this.APK_Version_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsuploadapk;
        private System.Windows.Forms.ToolStripMenuItem cmsupdateapk;
        private System.Windows.Forms.ToolStripMenuItem cmssetapk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsrefresh;
        private System.Windows.Forms.ToolStripMenuItem cmddownloadapk;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}