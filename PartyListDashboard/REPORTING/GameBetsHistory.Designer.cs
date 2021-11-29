namespace JLIDashboard.REPORTING
{
    partial class GameBetsHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBetsHistory));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ccbxdrawsched = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.ccbxgmtyp = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.tbdateto = new DevExpress.XtraEditors.DateEdit();
            this.tbdatefrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnforapprovalsalesorderexcel = new DevExpress.XtraEditors.SimpleButton();
            this.btngenerate = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccbxdrawsched.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbxgmtyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.gridControl1);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 65);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(876, 414);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 17);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(870, 394);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.ForestGreen;
            this.gridView1.Appearance.GroupRow.BackColor2 = System.Drawing.Color.LimeGreen;
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Gold;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 0;
            this.gridView1.FooterPanelHeight = 0;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupRowHeight = 0;
            this.gridView1.LevelIndent = 0;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.PreviewIndent = 0;
            this.gridView1.RowHeight = 0;
            this.gridView1.ViewCaptionHeight = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ccbxdrawsched);
            this.panelControl1.Controls.Add(this.ccbxgmtyp);
            this.panelControl1.Controls.Add(this.tbdateto);
            this.panelControl1.Controls.Add(this.tbdatefrom);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.btnforapprovalsalesorderexcel);
            this.panelControl1.Controls.Add(this.btngenerate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(876, 65);
            this.panelControl1.TabIndex = 6;
            // 
            // ccbxdrawsched
            // 
            this.ccbxdrawsched.EditValue = "";
            this.ccbxdrawsched.Location = new System.Drawing.Point(92, 36);
            this.ccbxdrawsched.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ccbxdrawsched.Name = "ccbxdrawsched";
            this.ccbxdrawsched.Properties.AllowMultiSelect = true;
            this.ccbxdrawsched.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccbxdrawsched.Properties.ItemAutoHeight = true;
            this.ccbxdrawsched.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("x", "X"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("y", "Y")});
            this.ccbxdrawsched.Properties.PopupFormSize = new System.Drawing.Size(0, 102);
            this.ccbxdrawsched.Size = new System.Drawing.Size(144, 20);
            this.ccbxdrawsched.TabIndex = 140;
            // 
            // ccbxgmtyp
            // 
            this.ccbxgmtyp.EditValue = "";
            this.ccbxgmtyp.Location = new System.Drawing.Point(92, 9);
            this.ccbxgmtyp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ccbxgmtyp.Name = "ccbxgmtyp";
            this.ccbxgmtyp.Properties.AllowMultiSelect = true;
            this.ccbxgmtyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccbxgmtyp.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("x", "X"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("y", "Y")});
            this.ccbxgmtyp.Size = new System.Drawing.Size(144, 20);
            this.ccbxgmtyp.TabIndex = 139;
            this.ccbxgmtyp.EditValueChanged += new System.EventHandler(this.ccbxgmtyp_EditValueChanged);
            // 
            // tbdateto
            // 
            this.tbdateto.EditValue = new System.DateTime(2021, 2, 2, 15, 58, 3, 0);
            this.tbdateto.Location = new System.Drawing.Point(310, 33);
            this.tbdateto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbdateto.Name = "tbdateto";
            this.tbdateto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdateto.Properties.Appearance.Options.UseFont = true;
            this.tbdateto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdateto.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdateto.Properties.Mask.EditMask = "MMMM dd, yyyy";
            this.tbdateto.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbdateto.Size = new System.Drawing.Size(138, 22);
            this.tbdateto.TabIndex = 137;
            // 
            // tbdatefrom
            // 
            this.tbdatefrom.EditValue = new System.DateTime(2021, 2, 2, 15, 55, 5, 0);
            this.tbdatefrom.Location = new System.Drawing.Point(310, 6);
            this.tbdatefrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbdatefrom.Name = "tbdatefrom";
            this.tbdatefrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbdatefrom.Properties.Appearance.Options.UseFont = true;
            this.tbdatefrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdatefrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbdatefrom.Properties.Mask.EditMask = "MMMM dd, yyyy";
            this.tbdatefrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbdatefrom.Size = new System.Drawing.Size(138, 22);
            this.tbdatefrom.TabIndex = 136;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(258, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 14);
            this.labelControl3.TabIndex = 135;
            this.labelControl3.Text = "Date To:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(244, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 14);
            this.labelControl4.TabIndex = 134;
            this.labelControl4.Text = "Date From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(16, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Draw Sched:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(20, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "GameType:";
            // 
            // btnforapprovalsalesorderexcel
            // 
            this.btnforapprovalsalesorderexcel.ImageOptions.Image = global::JLIDashboard.Properties.Resources.ExportToExcel_16x16;
            this.btnforapprovalsalesorderexcel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnforapprovalsalesorderexcel.Location = new System.Drawing.Point(559, 7);
            this.btnforapprovalsalesorderexcel.Name = "btnforapprovalsalesorderexcel";
            this.btnforapprovalsalesorderexcel.Size = new System.Drawing.Size(101, 47);
            this.btnforapprovalsalesorderexcel.TabIndex = 6;
            this.btnforapprovalsalesorderexcel.Text = "Export to Excel";
            this.btnforapprovalsalesorderexcel.Click += new System.EventHandler(this.btnforapprovalsalesorderexcel_Click);
            // 
            // btngenerate
            // 
            this.btngenerate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btngenerate.ImageOptions.Image")));
            this.btngenerate.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btngenerate.Location = new System.Drawing.Point(468, 7);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(86, 47);
            this.btngenerate.TabIndex = 5;
            this.btngenerate.Text = "Generate";
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // GameBetsHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 479);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameBetsHistory";
            this.Text = "GameBetsHistory";
            this.Load += new System.EventHandler(this.GameBetsHistory_Load);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccbxdrawsched.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccbxgmtyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnforapprovalsalesorderexcel;
        private DevExpress.XtraEditors.SimpleButton btngenerate;
        private DevExpress.XtraEditors.DateEdit tbdateto;
        private DevExpress.XtraEditors.DateEdit tbdatefrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ccbxgmtyp;
        private DevExpress.XtraEditors.CheckedComboBoxEdit ccbxdrawsched;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}