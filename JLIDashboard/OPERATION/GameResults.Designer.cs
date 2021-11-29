namespace JLIDashboard.OPERATION
{
    partial class GameResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameResults));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsBets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsBetsBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbdraw = new DevExpress.XtraEditors.TextEdit();
            this.tbdrawdate = new DevExpress.XtraEditors.TextEdit();
            this.tsgmtype = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView01 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnloadbets = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cmsResHis = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsResHisBtn0b = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsResHisSep0a = new System.Windows.Forms.ToolStripSeparator();
            this.cmsResHisBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbdateto1 = new DevExpress.XtraEditors.DateEdit();
            this.tbdatefrom1 = new DevExpress.XtraEditors.DateEdit();
            this.btngenerate1 = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsBets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbdraw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdrawdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgmtype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView01)).BeginInit();
            this.cmsResHis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsBets;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Location = new System.Drawing.Point(2, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(504, 592);
            this.gridControl1.TabIndex = 113;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsBets
            // 
            this.cmsBets.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsBetsBtn0a,
            this.exportToExcelToolStripMenuItem1});
            this.cmsBets.Name = "contextMenuStrip1";
            this.cmsBets.Size = new System.Drawing.Size(178, 52);
            // 
            // cmsBetsBtn0a
            // 
            this.cmsBetsBtn0a.Name = "cmsBetsBtn0a";
            this.cmsBetsBtn0a.Size = new System.Drawing.Size(177, 24);
            this.cmsBetsBtn0a.Text = "Refresh";
            this.cmsBetsBtn0a.Click += new System.EventHandler(this.cmsBetsBtn0a_Click);
            // 
            // exportToExcelToolStripMenuItem1
            // 
            this.exportToExcelToolStripMenuItem1.Name = "exportToExcelToolStripMenuItem1";
            this.exportToExcelToolStripMenuItem1.Size = new System.Drawing.Size(177, 24);
            this.exportToExcelToolStripMenuItem1.Text = "Export to Excel";
            this.exportToExcelToolStripMenuItem1.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbdraw);
            this.groupControl1.Controls.Add(this.tbdrawdate);
            this.groupControl1.Controls.Add(this.tsgmtype);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btnloadbets);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(391, 182);
            this.groupControl1.TabIndex = 114;
            this.groupControl1.Text = "Filter:";
            // 
            // tbdraw
            // 
            this.tbdraw.Location = new System.Drawing.Point(127, 101);
            this.tbdraw.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbdraw.Name = "tbdraw";
            this.tbdraw.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdraw.Properties.Appearance.Options.UseFont = true;
            this.tbdraw.Properties.ReadOnly = true;
            this.tbdraw.Size = new System.Drawing.Size(160, 26);
            this.tbdraw.TabIndex = 1003;
            this.tbdraw.TabStop = false;
            // 
            // tbdrawdate
            // 
            this.tbdrawdate.Location = new System.Drawing.Point(127, 69);
            this.tbdrawdate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tbdrawdate.Name = "tbdrawdate";
            this.tbdrawdate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdrawdate.Properties.Appearance.Options.UseFont = true;
            this.tbdrawdate.Properties.ReadOnly = true;
            this.tbdrawdate.Size = new System.Drawing.Size(160, 26);
            this.tbdrawdate.TabIndex = 1002;
            this.tbdrawdate.TabStop = false;
            // 
            // tsgmtype
            // 
            this.tsgmtype.Location = new System.Drawing.Point(127, 37);
            this.tsgmtype.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tsgmtype.Name = "tsgmtype";
            this.tsgmtype.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tsgmtype.Properties.Appearance.Options.UseFont = true;
            this.tsgmtype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsgmtype.Properties.NullText = "";
            this.tsgmtype.Properties.PopupView = this.gridView01;
            this.tsgmtype.Size = new System.Drawing.Size(160, 26);
            this.tsgmtype.TabIndex = 1001;
            this.tsgmtype.EditValueChanged += new System.EventHandler(this.tsgmtype_EditValueChanged);
            // 
            // gridView01
            // 
            this.gridView01.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView01.Name = "gridView01";
            this.gridView01.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView01.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(39, 41);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(83, 18);
            this.labelControl4.TabIndex = 114;
            this.labelControl4.Text = "Game Type:";
            // 
            // btnloadbets
            // 
            this.btnloadbets.Enabled = false;
            this.btnloadbets.Location = new System.Drawing.Point(139, 134);
            this.btnloadbets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnloadbets.Name = "btnloadbets";
            this.btnloadbets.Size = new System.Drawing.Size(133, 32);
            this.btnloadbets.TabIndex = 1100;
            this.btnloadbets.Text = "Load All Bets";
            this.btnloadbets.Click += new System.EventHandler(this.btnloadbets_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(39, 73);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 18);
            this.labelControl1.TabIndex = 104;
            this.labelControl1.Text = "Draw Date:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(39, 105);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(38, 18);
            this.labelControl8.TabIndex = 102;
            this.labelControl8.Text = "Draw:";
            // 
            // cmsResHis
            // 
            this.cmsResHis.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsResHis.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsResHisBtn0b,
            this.cmsResHisSep0a,
            this.cmsResHisBtn0a});
            this.cmsResHis.Name = "contextMenuStrip1";
            this.cmsResHis.Size = new System.Drawing.Size(212, 58);
            // 
            // cmsResHisBtn0b
            // 
            this.cmsResHisBtn0b.Name = "cmsResHisBtn0b";
            this.cmsResHisBtn0b.Size = new System.Drawing.Size(211, 24);
            this.cmsResHisBtn0b.Text = "Load Report History";
            this.cmsResHisBtn0b.Click += new System.EventHandler(this.cmsResHisBtn0b_Click);
            // 
            // cmsResHisSep0a
            // 
            this.cmsResHisSep0a.Name = "cmsResHisSep0a";
            this.cmsResHisSep0a.Size = new System.Drawing.Size(208, 6);
            // 
            // cmsResHisBtn0a
            // 
            this.cmsResHisBtn0a.Name = "cmsResHisBtn0a";
            this.cmsResHisBtn0a.Size = new System.Drawing.Size(211, 24);
            this.cmsResHisBtn0a.Text = "Refresh";
            this.cmsResHisBtn0a.Click += new System.EventHandler(this.cmsResHisBtn0a_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl3);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(395, 626);
            this.panelControl1.TabIndex = 115;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gridControl2);
            this.groupControl3.Controls.Add(this.panel1);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(2, 184);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(391, 440);
            this.groupControl3.TabIndex = 115;
            this.groupControl3.Text = "Result History";
            // 
            // gridControl2
            // 
            this.gridControl2.ContextMenuStrip = this.cmsResHis;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl2.Location = new System.Drawing.Point(2, 71);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(387, 367);
            this.gridControl2.TabIndex = 115;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsView.RowAutoHeight = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView2_PopupMenuShowing);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(395, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(512, 626);
            this.panelControl2.TabIndex = 116;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(508, 622);
            this.groupControl2.TabIndex = 1006;
            this.groupControl2.Text = "Bets";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btngenerate1);
            this.panel1.Controls.Add(this.tbdateto1);
            this.panel1.Controls.Add(this.tbdatefrom1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 43);
            this.panel1.TabIndex = 116;
            // 
            // tbdateto1
            // 
            this.tbdateto1.EditValue = new System.DateTime(2021, 2, 2, 15, 58, 3, 0);
            this.tbdateto1.Enabled = false;
            this.tbdateto1.Location = new System.Drawing.Point(208, 8);
            this.tbdateto1.Name = "tbdateto1";
            this.tbdateto1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdateto1.Properties.Appearance.Options.UseFont = true;
            this.tbdateto1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdateto1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdateto1.Properties.Mask.EditMask = "MMM dd, yyyy";
            this.tbdateto1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbdateto1.Size = new System.Drawing.Size(120, 26);
            this.tbdateto1.TabIndex = 140;
            // 
            // tbdatefrom1
            // 
            this.tbdatefrom1.EditValue = new System.DateTime(2021, 2, 2, 15, 55, 5, 0);
            this.tbdatefrom1.Enabled = false;
            this.tbdatefrom1.Location = new System.Drawing.Point(56, 8);
            this.tbdatefrom1.Name = "tbdatefrom1";
            this.tbdatefrom1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdatefrom1.Properties.Appearance.Options.UseFont = true;
            this.tbdatefrom1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdatefrom1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdatefrom1.Properties.Mask.EditMask = "MMM dd, yyyy";
            this.tbdatefrom1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbdatefrom1.Size = new System.Drawing.Size(120, 26);
            this.tbdatefrom1.TabIndex = 139;
            // 
            // btngenerate1
            // 
            this.btngenerate1.Enabled = false;
            this.btngenerate1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btngenerate1.ImageOptions.Image")));
            this.btngenerate1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btngenerate1.Location = new System.Drawing.Point(334, 7);
            this.btngenerate1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btngenerate1.Name = "btngenerate1";
            this.btngenerate1.Size = new System.Drawing.Size(42, 28);
            this.btngenerate1.TabIndex = 138;
            this.btngenerate1.Click += new System.EventHandler(this.btngenerate1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 136;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label2.Location = new System.Drawing.Point(180, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 18);
            this.label2.TabIndex = 137;
            this.label2.Text = "To:";
            // 
            // GameResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 626);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "GameResults";
            this.Text = "GameResults";
            this.Load += new System.EventHandler(this.GameResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsBets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbdraw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdrawdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgmtype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView01)).EndInit();
            this.cmsResHis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnloadbets;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SearchLookUpEdit tsgmtype;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView01;
        private System.Windows.Forms.ContextMenuStrip cmsResHis;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.TextEdit tbdraw;
        public DevExpress.XtraEditors.TextEdit tbdrawdate;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.ToolStripMenuItem cmsResHisBtn0a;
        private System.Windows.Forms.ToolStripMenuItem cmsResHisBtn0b;
        private System.Windows.Forms.ContextMenuStrip cmsBets;
        private System.Windows.Forms.ToolStripMenuItem cmsBetsBtn0a;
        private System.Windows.Forms.ToolStripSeparator cmsResHisSep0a;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.DateEdit tbdateto1;
        private DevExpress.XtraEditors.DateEdit tbdatefrom1;
        private DevExpress.XtraEditors.SimpleButton btngenerate1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}