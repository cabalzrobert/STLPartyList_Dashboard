namespace JLIDashboard.TREASURY
{
    partial class Commissions
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
            this.tbdateto = new DevExpress.XtraEditors.DateEdit();
            this.tbdatefrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.rgstatus = new DevExpress.XtraEditors.RadioGroup();
            this.btnprintreport = new DevExpress.XtraEditors.SimpleButton();
            this.btnexporttoexcel = new DevExpress.XtraEditors.SimpleButton();
            this.btngenerate = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsComm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCommBtn0b = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCommSep0a = new System.Windows.Forms.ToolStripSeparator();
            this.cmsCommBtn0d = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCommBtn0c = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCommSep0b = new System.Windows.Forms.ToolStripSeparator();
            this.cmsCommBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsComm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbdateto);
            this.groupControl1.Controls.Add(this.tbdatefrom);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.rgstatus);
            this.groupControl1.Controls.Add(this.btnprintreport);
            this.groupControl1.Controls.Add(this.btnexporttoexcel);
            this.groupControl1.Controls.Add(this.btngenerate);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(2396, 209);
            this.groupControl1.TabIndex = 3;
            // 
            // tbdateto
            // 
            this.tbdateto.EditValue = new System.DateTime(2021, 2, 2, 15, 58, 3, 0);
            this.tbdateto.Location = new System.Drawing.Point(746, 124);
            this.tbdateto.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbdateto.Name = "tbdateto";
            this.tbdateto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdateto.Properties.Appearance.Options.UseFont = true;
            this.tbdateto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdateto.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdateto.Properties.Mask.EditMask = "MMMM dd, yyyy";
            this.tbdateto.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbdateto.Size = new System.Drawing.Size(299, 50);
            this.tbdateto.TabIndex = 133;
            // 
            // tbdatefrom
            // 
            this.tbdatefrom.EditValue = new System.DateTime(2021, 2, 2, 15, 55, 5, 0);
            this.tbdatefrom.Location = new System.Drawing.Point(746, 64);
            this.tbdatefrom.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbdatefrom.Name = "tbdatefrom";
            this.tbdatefrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdatefrom.Properties.Appearance.Options.UseFont = true;
            this.tbdatefrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdatefrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdatefrom.Properties.Mask.EditMask = "MMMM dd, yyyy";
            this.tbdatefrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbdatefrom.Size = new System.Drawing.Size(299, 50);
            this.tbdatefrom.TabIndex = 132;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(596, 130);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 34);
            this.labelControl3.TabIndex = 131;
            this.labelControl3.Text = "Date To:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(596, 72);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(141, 34);
            this.labelControl4.TabIndex = 130;
            this.labelControl4.Text = "Date From:";
            // 
            // rgstatus
            // 
            this.rgstatus.EditValue = "0";
            this.rgstatus.Location = new System.Drawing.Point(45, 54);
            this.rgstatus.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.rgstatus.Name = "rgstatus";
            this.rgstatus.Properties.ColumnIndent = 1;
            this.rgstatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Payable Commission"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Claimed Commission"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Pending Commission")});
            this.rgstatus.Size = new System.Drawing.Size(539, 129);
            this.rgstatus.TabIndex = 129;
            // 
            // btnprintreport
            // 
            this.btnprintreport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btnprintreport.Appearance.Options.UseFont = true;
            this.btnprintreport.Location = new System.Drawing.Point(1539, 70);
            this.btnprintreport.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnprintreport.Name = "btnprintreport";
            this.btnprintreport.Size = new System.Drawing.Size(219, 96);
            this.btnprintreport.TabIndex = 126;
            this.btnprintreport.Text = "Print Report";
            this.btnprintreport.Click += new System.EventHandler(this.btnprintreport_Click);
            // 
            // btnexporttoexcel
            // 
            this.btnexporttoexcel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btnexporttoexcel.Appearance.Options.UseFont = true;
            this.btnexporttoexcel.Location = new System.Drawing.Point(1309, 70);
            this.btnexporttoexcel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnexporttoexcel.Name = "btnexporttoexcel";
            this.btnexporttoexcel.Size = new System.Drawing.Size(219, 96);
            this.btnexporttoexcel.TabIndex = 125;
            this.btnexporttoexcel.Text = "Export to Excel";
            this.btnexporttoexcel.Click += new System.EventHandler(this.btnexporttoexcel_Click);
            // 
            // btngenerate
            // 
            this.btngenerate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btngenerate.Appearance.Options.UseFont = true;
            this.btngenerate.Location = new System.Drawing.Point(1078, 70);
            this.btngenerate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(219, 96);
            this.btngenerate.TabIndex = 124;
            this.btngenerate.Text = "Generate";
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 209);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(2396, 1203);
            this.panelControl1.TabIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsComm;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(2390, 1197);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsComm
            // 
            this.cmsComm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsComm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCommBtn0b,
            this.cmsCommSep0a,
            this.cmsCommBtn0d,
            this.cmsCommBtn0c,
            this.cmsCommSep0b,
            this.cmsCommBtn0a});
            this.cmsComm.Name = "contextMenuStrip1";
            this.cmsComm.Size = new System.Drawing.Size(440, 184);
            // 
            // cmsCommBtn0b
            // 
            this.cmsCommBtn0b.Name = "cmsCommBtn0b";
            this.cmsCommBtn0b.Size = new System.Drawing.Size(439, 42);
            this.cmsCommBtn0b.Text = "Claim Commission";
            this.cmsCommBtn0b.Click += new System.EventHandler(this.cmsCommBtn0b_Click);
            // 
            // cmsCommSep0a
            // 
            this.cmsCommSep0a.Name = "cmsCommSep0a";
            this.cmsCommSep0a.Size = new System.Drawing.Size(436, 6);
            // 
            // cmsCommBtn0d
            // 
            this.cmsCommBtn0d.Name = "cmsCommBtn0d";
            this.cmsCommBtn0d.Size = new System.Drawing.Size(439, 42);
            this.cmsCommBtn0d.Text = "Approved Claim Commission";
            this.cmsCommBtn0d.Click += new System.EventHandler(this.cmsCommBtn0d_Click);
            // 
            // cmsCommBtn0c
            // 
            this.cmsCommBtn0c.Name = "cmsCommBtn0c";
            this.cmsCommBtn0c.Size = new System.Drawing.Size(439, 42);
            this.cmsCommBtn0c.Text = "Resend OTP";
            this.cmsCommBtn0c.Click += new System.EventHandler(this.cmsCommBtn0c_Click);
            // 
            // cmsCommSep0b
            // 
            this.cmsCommSep0b.Name = "cmsCommSep0b";
            this.cmsCommSep0b.Size = new System.Drawing.Size(436, 6);
            // 
            // cmsCommBtn0a
            // 
            this.cmsCommBtn0a.Name = "cmsCommBtn0a";
            this.cmsCommBtn0a.Size = new System.Drawing.Size(439, 42);
            this.cmsCommBtn0a.Text = "Refresh";
            this.cmsCommBtn0a.Click += new System.EventHandler(this.cmsCommBtn0a_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.DetailHeight = 634;
            this.gridView1.FixedLineWidth = 4;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // Commissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2396, 1412);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Commissions";
            this.Text = "Commission";
            this.Load += new System.EventHandler(this.Commissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsComm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btngenerate;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmsComm;
        private System.Windows.Forms.ToolStripMenuItem cmsCommBtn0b;
        private DevExpress.XtraEditors.SimpleButton btnexporttoexcel;
        private DevExpress.XtraEditors.SimpleButton btnprintreport;
        private System.Windows.Forms.ToolStripMenuItem cmsCommBtn0a;
        private DevExpress.XtraEditors.RadioGroup rgstatus;
        private DevExpress.XtraEditors.DateEdit tbdateto;
        private DevExpress.XtraEditors.DateEdit tbdatefrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ToolStripSeparator cmsCommSep0a;
        private System.Windows.Forms.ToolStripMenuItem cmsCommBtn0c;
        private System.Windows.Forms.ToolStripMenuItem cmsCommBtn0d;
        private System.Windows.Forms.ToolStripSeparator cmsCommSep0b;
    }
}