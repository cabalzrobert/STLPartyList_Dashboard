namespace JLIDashboard.ACCOUNTING
{
    partial class TransferCredits
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
            this.btnprintreport = new DevExpress.XtraEditors.SimpleButton();
            this.btnexporttoexcel = new DevExpress.XtraEditors.SimpleButton();
            this.btngenerate = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsTCrdt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsTCrdtBtn0b = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTCrdtSep0a = new System.Windows.Forms.ToolStripSeparator();
            this.cmsTCrdtBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsTCrdt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbdateto);
            this.groupControl1.Controls.Add(this.tbdatefrom);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btnprintreport);
            this.groupControl1.Controls.Add(this.btnexporttoexcel);
            this.groupControl1.Controls.Add(this.btngenerate);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1290, 101);
            this.groupControl1.TabIndex = 3;
            // 
            // tbdateto
            // 
            this.tbdateto.EditValue = new System.DateTime(2021, 2, 2, 15, 58, 3, 0);
            this.tbdateto.Location = new System.Drawing.Point(123, 67);
            this.tbdateto.Name = "tbdateto";
            this.tbdateto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdateto.Properties.Appearance.Options.UseFont = true;
            this.tbdateto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdateto.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdateto.Properties.Mask.EditMask = "MMMM dd, yyyy";
            this.tbdateto.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbdateto.Size = new System.Drawing.Size(161, 26);
            this.tbdateto.TabIndex = 133;
            // 
            // tbdatefrom
            // 
            this.tbdatefrom.EditValue = new System.DateTime(2021, 2, 2, 15, 55, 5, 0);
            this.tbdatefrom.Location = new System.Drawing.Point(123, 34);
            this.tbdatefrom.Name = "tbdatefrom";
            this.tbdatefrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdatefrom.Properties.Appearance.Options.UseFont = true;
            this.tbdatefrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdatefrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdatefrom.Properties.Mask.EditMask = "MMMM dd, yyyy";
            this.tbdatefrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbdatefrom.Size = new System.Drawing.Size(161, 26);
            this.tbdatefrom.TabIndex = 132;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(42, 70);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 18);
            this.labelControl3.TabIndex = 131;
            this.labelControl3.Text = "Date To:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(42, 38);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 18);
            this.labelControl4.TabIndex = 130;
            this.labelControl4.Text = "Date From:";
            // 
            // btnprintreport
            // 
            this.btnprintreport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btnprintreport.Appearance.Options.UseFont = true;
            this.btnprintreport.Location = new System.Drawing.Point(550, 37);
            this.btnprintreport.Name = "btnprintreport";
            this.btnprintreport.Size = new System.Drawing.Size(118, 53);
            this.btnprintreport.TabIndex = 126;
            this.btnprintreport.Text = "Print Report";
            this.btnprintreport.Click += new System.EventHandler(this.btnprintreport_Click);
            // 
            // btnexporttoexcel
            // 
            this.btnexporttoexcel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btnexporttoexcel.Appearance.Options.UseFont = true;
            this.btnexporttoexcel.Location = new System.Drawing.Point(426, 37);
            this.btnexporttoexcel.Name = "btnexporttoexcel";
            this.btnexporttoexcel.Size = new System.Drawing.Size(118, 53);
            this.btnexporttoexcel.TabIndex = 125;
            this.btnexporttoexcel.Text = "Export to Excel";
            this.btnexporttoexcel.Click += new System.EventHandler(this.btnexporttoexcel_Click);
            // 
            // btngenerate
            // 
            this.btngenerate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btngenerate.Appearance.Options.UseFont = true;
            this.btngenerate.Location = new System.Drawing.Point(302, 37);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(118, 53);
            this.btngenerate.TabIndex = 124;
            this.btngenerate.Text = "Generate";
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 101);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1290, 678);
            this.panelControl1.TabIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsTCrdt;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1286, 674);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsTCrdt
            // 
            this.cmsTCrdt.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTCrdt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsTCrdtBtn0b,
            this.cmsTCrdtSep0a,
            this.cmsTCrdtBtn0a});
            this.cmsTCrdt.Name = "contextMenuStrip1";
            this.cmsTCrdt.Size = new System.Drawing.Size(211, 86);
            // 
            // cmsTCrdtBtn0b
            // 
            this.cmsTCrdtBtn0b.Name = "cmsTCrdtBtn0b";
            this.cmsTCrdtBtn0b.Size = new System.Drawing.Size(210, 24);
            this.cmsTCrdtBtn0b.Text = "Transfer Credit";
            this.cmsTCrdtBtn0b.Click += new System.EventHandler(this.cmsTCrdtBtn0b_Click);
            // 
            // cmsTCrdtSep0a
            // 
            this.cmsTCrdtSep0a.Name = "cmsTCrdtSep0a";
            this.cmsTCrdtSep0a.Size = new System.Drawing.Size(207, 6);
            // 
            // cmsTCrdtBtn0a
            // 
            this.cmsTCrdtBtn0a.Name = "cmsTCrdtBtn0a";
            this.cmsTCrdtBtn0a.Size = new System.Drawing.Size(210, 24);
            this.cmsTCrdtBtn0a.Text = "Refresh";
            this.cmsTCrdtBtn0a.Click += new System.EventHandler(this.cmsTCrdtBtn0a_Click);
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
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // TransferCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 779);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "TransferCredits";
            this.Text = "Tranfer Credits - History";
            this.Load += new System.EventHandler(this.TransferCredits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsTCrdt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btngenerate;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmsTCrdt;
        private System.Windows.Forms.ToolStripMenuItem cmsTCrdtBtn0b;
        private DevExpress.XtraEditors.SimpleButton btnexporttoexcel;
        private DevExpress.XtraEditors.SimpleButton btnprintreport;
        private System.Windows.Forms.ToolStripMenuItem cmsTCrdtBtn0a;
        private DevExpress.XtraEditors.DateEdit tbdateto;
        private DevExpress.XtraEditors.DateEdit tbdatefrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ToolStripSeparator cmsTCrdtSep0a;
    }
}