namespace JLIDashboard.OPERATOR
{
    partial class MasterList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterList));
            this.cmsMasterList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsMasterListBtn0b = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPrintProfiling = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPrintProfilingMul = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsMasterListBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbsearch = new DevExpress.XtraEditors.TextEdit();
            this.tsgridcolumn = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmsMasterList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbsearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgridcolumn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsMasterList
            // 
            this.cmsMasterList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsMasterListBtn0b,
            this.cmsPrintProfiling,
            this.cmsPrintProfilingMul,
            this.toolStripSeparator1,
            this.cmsMasterListBtn0a});
            this.cmsMasterList.Name = "cmsMasterList";
            this.cmsMasterList.Size = new System.Drawing.Size(161, 98);
            // 
            // cmsMasterListBtn0b
            // 
            this.cmsMasterListBtn0b.Name = "cmsMasterListBtn0b";
            this.cmsMasterListBtn0b.Size = new System.Drawing.Size(160, 22);
            this.cmsMasterListBtn0b.Text = "Edit Details";
            this.cmsMasterListBtn0b.Click += new System.EventHandler(this.cmsMasterListBtn0b_Click);
            // 
            // cmsPrintProfiling
            // 
            this.cmsPrintProfiling.Name = "cmsPrintProfiling";
            this.cmsPrintProfiling.Size = new System.Drawing.Size(160, 22);
            this.cmsPrintProfiling.Text = "Print ID";
            this.cmsPrintProfiling.Click += new System.EventHandler(this.cmsPrintProfiling_Click);
            // 
            // cmsPrintProfilingMul
            // 
            this.cmsPrintProfilingMul.Name = "cmsPrintProfilingMul";
            this.cmsPrintProfilingMul.Size = new System.Drawing.Size(160, 22);
            this.cmsPrintProfilingMul.Text = "Print Multiple ID";
            this.cmsPrintProfilingMul.Click += new System.EventHandler(this.cmsPrintProfilingMul_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // cmsMasterListBtn0a
            // 
            this.cmsMasterListBtn0a.Name = "cmsMasterListBtn0a";
            this.cmsMasterListBtn0a.Size = new System.Drawing.Size(160, 22);
            this.cmsMasterListBtn0a.Text = "Refresh";
            this.cmsMasterListBtn0a.Click += new System.EventHandler(this.cmsMasterListBtn0a_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbsearch);
            this.groupControl1.Controls.Add(this.tsgridcolumn);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(930, 78);
            this.groupControl1.TabIndex = 1;
            // 
            // tbsearch
            // 
            this.tbsearch.Location = new System.Drawing.Point(69, 51);
            this.tbsearch.Name = "tbsearch";
            this.tbsearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbsearch.Properties.Appearance.Options.UseFont = true;
            this.tbsearch.Properties.ReadOnly = true;
            this.tbsearch.Size = new System.Drawing.Size(206, 22);
            this.tbsearch.TabIndex = 9;
            this.tbsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbsearch_KeyPress);
            // 
            // tsgridcolumn
            // 
            this.tsgridcolumn.Location = new System.Drawing.Point(68, 26);
            this.tsgridcolumn.Name = "tsgridcolumn";
            this.tsgridcolumn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tsgridcolumn.Properties.Appearance.Options.UseFont = true;
            this.tsgridcolumn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsgridcolumn.Properties.NullText = "";
            this.tsgridcolumn.Properties.PopupView = this.gridView2;
            this.tsgridcolumn.Size = new System.Drawing.Size(207, 22);
            this.tsgridcolumn.TabIndex = 8;
            this.tsgridcolumn.EditValueChanged += new System.EventHandler(this.tsgridcolumn_EditValueChanged);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(14, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Search : ";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(7, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Filter by : ";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsMasterList;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gridControl1.Location = new System.Drawing.Point(0, 78);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(930, 520);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // MasterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 598);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("MasterList.IconOptions.LargeImage")));
            this.Name = "MasterList";
            this.Text = "MasterList";
            this.Load += new System.EventHandler(this.MasterList_Load);
            this.cmsMasterList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbsearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgridcolumn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsMasterList;
        private System.Windows.Forms.ToolStripMenuItem cmsMasterListBtn0b;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsMasterListBtn0a;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit tsgridcolumn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.TextEdit tbsearch;
        private System.Windows.Forms.ToolStripMenuItem cmsPrintProfiling;
        private System.Windows.Forms.ToolStripMenuItem cmsPrintProfilingMul;
    }
}