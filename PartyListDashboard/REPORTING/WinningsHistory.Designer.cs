namespace JLIDashboard.REPORTING
{
    partial class WinningsHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinningsHistory));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkalldrawsched = new DevExpress.XtraEditors.CheckEdit();
            this.tbdateto = new DevExpress.XtraEditors.DateEdit();
            this.tbdatefrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tsdrawsched = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tsgmtype = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.chkalldrawsched.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsdrawsched.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgmtype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.gridControl1);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 174);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox7.Size = new System.Drawing.Size(1898, 946);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(7);
            this.gridControl1.Location = new System.Drawing.Point(7, 36);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(7);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1884, 903);
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
            this.gridView1.DetailHeight = 781;
            this.gridView1.FixedLineWidth = 4;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkalldrawsched);
            this.panelControl1.Controls.Add(this.tbdateto);
            this.panelControl1.Controls.Add(this.tbdatefrom);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.tsdrawsched);
            this.panelControl1.Controls.Add(this.tsgmtype);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.btnforapprovalsalesorderexcel);
            this.panelControl1.Controls.Add(this.btngenerate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(7);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1898, 174);
            this.panelControl1.TabIndex = 6;
            // 
            // chkalldrawsched
            // 
            this.chkalldrawsched.EditValue = true;
            this.chkalldrawsched.Location = new System.Drawing.Point(206, 125);
            this.chkalldrawsched.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.chkalldrawsched.Name = "chkalldrawsched";
            this.chkalldrawsched.Properties.Caption = "All Draw Schedule";
            this.chkalldrawsched.Size = new System.Drawing.Size(262, 44);
            this.chkalldrawsched.TabIndex = 138;
            this.chkalldrawsched.CheckedChanged += new System.EventHandler(this.chkalldrawsched_CheckedChanged);
            // 
            // tbdateto
            // 
            this.tbdateto.EditValue = new System.DateTime(2021, 2, 2, 15, 58, 3, 0);
            this.tbdateto.Location = new System.Drawing.Point(672, 74);
            this.tbdateto.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
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
            this.tbdateto.TabIndex = 137;
            // 
            // tbdatefrom
            // 
            this.tbdatefrom.EditValue = new System.DateTime(2021, 2, 2, 15, 55, 5, 0);
            this.tbdatefrom.Location = new System.Drawing.Point(672, 13);
            this.tbdatefrom.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
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
            this.tbdatefrom.TabIndex = 136;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(559, 83);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 34);
            this.labelControl3.TabIndex = 135;
            this.labelControl3.Text = "Date To:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(529, 22);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(7);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(141, 34);
            this.labelControl4.TabIndex = 134;
            this.labelControl4.Text = "Date From:";
            // 
            // tsdrawsched
            // 
            this.tsdrawsched.Enabled = false;
            this.tsdrawsched.Location = new System.Drawing.Point(206, 71);
            this.tsdrawsched.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.tsdrawsched.Name = "tsdrawsched";
            this.tsdrawsched.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tsdrawsched.Properties.Appearance.Options.UseFont = true;
            this.tsdrawsched.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsdrawsched.Properties.NullText = "";
            this.tsdrawsched.Properties.PopupView = this.gridView2;
            this.tsdrawsched.Size = new System.Drawing.Size(262, 50);
            this.tsdrawsched.TabIndex = 10;
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 634;
            this.gridView2.FixedLineWidth = 4;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // tsgmtype
            // 
            this.tsgmtype.Location = new System.Drawing.Point(206, 13);
            this.tsgmtype.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.tsgmtype.Name = "tsgmtype";
            this.tsgmtype.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tsgmtype.Properties.Appearance.Options.UseFont = true;
            this.tsgmtype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsgmtype.Properties.NullText = "";
            this.tsgmtype.Properties.PopupView = this.searchLookUpEdit1View;
            this.tsgmtype.Size = new System.Drawing.Size(262, 50);
            this.tsgmtype.TabIndex = 9;
            this.tsgmtype.EditValueChanged += new System.EventHandler(this.tsgmtype_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.DetailHeight = 634;
            this.searchLookUpEdit1View.FixedLineWidth = 4;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(35, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 33);
            this.label4.TabIndex = 8;
            this.label4.Text = "Draw Sched:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(43, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "GameType:";
            // 
            // btnforapprovalsalesorderexcel
            // 
            this.btnforapprovalsalesorderexcel.ImageOptions.Image = global::JLIDashboard.Properties.Resources.ExportToExcel_16x16;
            this.btnforapprovalsalesorderexcel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnforapprovalsalesorderexcel.Location = new System.Drawing.Point(1211, 16);
            this.btnforapprovalsalesorderexcel.Margin = new System.Windows.Forms.Padding(7);
            this.btnforapprovalsalesorderexcel.Name = "btnforapprovalsalesorderexcel";
            this.btnforapprovalsalesorderexcel.Size = new System.Drawing.Size(219, 105);
            this.btnforapprovalsalesorderexcel.TabIndex = 6;
            this.btnforapprovalsalesorderexcel.Text = "Export to Excel";
            this.btnforapprovalsalesorderexcel.Click += new System.EventHandler(this.btnforapprovalsalesorderexcel_Click);
            // 
            // btngenerate
            // 
            this.btngenerate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btngenerate.ImageOptions.Image")));
            this.btngenerate.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btngenerate.Location = new System.Drawing.Point(1014, 16);
            this.btngenerate.Margin = new System.Windows.Forms.Padding(7);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(186, 105);
            this.btngenerate.TabIndex = 5;
            this.btngenerate.Text = "Generate";
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // WinningsHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1120);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(7, 4, 7, 4);
            this.Name = "WinningsHistory";
            this.Text = "WinningsHistory";
            this.Load += new System.EventHandler(this.WinningsHistory_Load);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkalldrawsched.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsdrawsched.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgmtype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
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
        private DevExpress.XtraEditors.SearchLookUpEdit tsgmtype;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit tsdrawsched;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.CheckEdit chkalldrawsched;
        private DevExpress.XtraEditors.DateEdit tbdateto;
        private DevExpress.XtraEditors.DateEdit tbdatefrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}