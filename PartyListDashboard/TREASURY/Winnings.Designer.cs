namespace JLIDashboard.TREASURY
{
    partial class Winnings
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
            this.cmsConfirm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsConfirmBtn0b = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsConfirmSep0a = new System.Windows.Forms.ToolStripSeparator();
            this.cmsConfirmBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbForfeit = new DevExpress.XtraEditors.TextEdit();
            this.lblForfeit = new DevExpress.XtraEditors.LabelControl();
            this.rgstatus = new DevExpress.XtraEditors.RadioGroup();
            this.btnprintreport = new DevExpress.XtraEditors.SimpleButton();
            this.btnexporttoexcel = new DevExpress.XtraEditors.SimpleButton();
            this.btngenerate = new DevExpress.XtraEditors.SimpleButton();
            this.tbdateto = new DevExpress.XtraEditors.DateEdit();
            this.tbdatefrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsConfirm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbForfeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsConfirm;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 141);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1011, 388);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsConfirm
            // 
            this.cmsConfirm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsConfirm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsConfirmBtn0b,
            this.cmsConfirmSep0a,
            this.cmsConfirmBtn0a});
            this.cmsConfirm.Name = "contextMenuStrip1";
            this.cmsConfirm.Size = new System.Drawing.Size(187, 54);
            // 
            // cmsConfirmBtn0b
            // 
            this.cmsConfirmBtn0b.Name = "cmsConfirmBtn0b";
            this.cmsConfirmBtn0b.Size = new System.Drawing.Size(186, 22);
            this.cmsConfirmBtn0b.Text = "Confirm Encashment";
            this.cmsConfirmBtn0b.Click += new System.EventHandler(this.cmsConfirmBtn0b_Click);
            // 
            // cmsConfirmSep0a
            // 
            this.cmsConfirmSep0a.Name = "cmsConfirmSep0a";
            this.cmsConfirmSep0a.Size = new System.Drawing.Size(183, 6);
            // 
            // cmsConfirmBtn0a
            // 
            this.cmsConfirmBtn0a.Name = "cmsConfirmBtn0a";
            this.cmsConfirmBtn0a.Size = new System.Drawing.Size(186, 22);
            this.cmsConfirmBtn0a.Text = "Refresh";
            this.cmsConfirmBtn0a.Click += new System.EventHandler(this.cmsConfirmBtn0a_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.DetailHeight = 284;
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbForfeit);
            this.groupControl1.Controls.Add(this.lblForfeit);
            this.groupControl1.Controls.Add(this.rgstatus);
            this.groupControl1.Controls.Add(this.btnprintreport);
            this.groupControl1.Controls.Add(this.btnexporttoexcel);
            this.groupControl1.Controls.Add(this.btngenerate);
            this.groupControl1.Controls.Add(this.tbdateto);
            this.groupControl1.Controls.Add(this.tbdatefrom);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1011, 141);
            this.groupControl1.TabIndex = 8;
            // 
            // tbForfeit
            // 
            this.tbForfeit.EditValue = "";
            this.tbForfeit.Location = new System.Drawing.Point(272, 97);
            this.tbForfeit.Name = "tbForfeit";
            this.tbForfeit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbForfeit.Properties.Appearance.Options.UseFont = true;
            this.tbForfeit.Size = new System.Drawing.Size(137, 22);
            this.tbForfeit.TabIndex = 130;
            this.tbForfeit.Visible = false;
            // 
            // lblForfeit
            // 
            this.lblForfeit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lblForfeit.Appearance.Options.UseFont = true;
            this.lblForfeit.Location = new System.Drawing.Point(168, 100);
            this.lblForfeit.Name = "lblForfeit";
            this.lblForfeit.Size = new System.Drawing.Size(98, 14);
            this.lblForfeit.TabIndex = 129;
            this.lblForfeit.Text = "Forfeit already in :";
            this.lblForfeit.Visible = false;
            // 
            // rgstatus
            // 
            this.rgstatus.EditValue = "0";
            this.rgstatus.Location = new System.Drawing.Point(21, 24);
            this.rgstatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rgstatus.Name = "rgstatus";
            this.rgstatus.Properties.ColumnIndent = 1;
            this.rgstatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Pending for Confirmation"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Winnings Claimed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Unclaimed Winning"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "Forfeit Winning")});
            this.rgstatus.Size = new System.Drawing.Size(141, 112);
            this.rgstatus.TabIndex = 128;
            this.rgstatus.SelectedIndexChanged += new System.EventHandler(this.rgstatus_SelectedIndexChanged);
            // 
            // btnprintreport
            // 
            this.btnprintreport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btnprintreport.Appearance.Options.UseFont = true;
            this.btnprintreport.Location = new System.Drawing.Point(647, 43);
            this.btnprintreport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnprintreport.Name = "btnprintreport";
            this.btnprintreport.Size = new System.Drawing.Size(101, 43);
            this.btnprintreport.TabIndex = 126;
            this.btnprintreport.Text = "Print Report";
            this.btnprintreport.Click += new System.EventHandler(this.btnprintreport_Click);
            // 
            // btnexporttoexcel
            // 
            this.btnexporttoexcel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btnexporttoexcel.Appearance.Options.UseFont = true;
            this.btnexporttoexcel.Location = new System.Drawing.Point(541, 43);
            this.btnexporttoexcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnexporttoexcel.Name = "btnexporttoexcel";
            this.btnexporttoexcel.Size = new System.Drawing.Size(101, 43);
            this.btnexporttoexcel.TabIndex = 125;
            this.btnexporttoexcel.Text = "Export to Excel";
            this.btnexporttoexcel.Click += new System.EventHandler(this.btnexporttoexcel_Click);
            // 
            // btngenerate
            // 
            this.btngenerate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btngenerate.Appearance.Options.UseFont = true;
            this.btngenerate.Location = new System.Drawing.Point(435, 43);
            this.btngenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(101, 43);
            this.btngenerate.TabIndex = 124;
            this.btngenerate.Text = "Generate";
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // tbdateto
            // 
            this.tbdateto.EditValue = new System.DateTime(2021, 2, 2, 15, 58, 3, 0);
            this.tbdateto.Location = new System.Drawing.Point(272, 69);
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
            this.tbdateto.TabIndex = 121;
            // 
            // tbdatefrom
            // 
            this.tbdatefrom.EditValue = new System.DateTime(2021, 2, 2, 15, 55, 5, 0);
            this.tbdatefrom.Location = new System.Drawing.Point(272, 42);
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
            this.tbdatefrom.TabIndex = 120;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(217, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 14);
            this.labelControl2.TabIndex = 119;
            this.labelControl2.Text = "Date To:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(205, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 14);
            this.labelControl1.TabIndex = 117;
            this.labelControl1.Text = "Date From:";
            // 
            // Winnings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 529);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Winnings";
            this.Text = "Winnings";
            this.Load += new System.EventHandler(this.Winnings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsConfirm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbForfeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnprintreport;
        private DevExpress.XtraEditors.SimpleButton btnexporttoexcel;
        private DevExpress.XtraEditors.SimpleButton btngenerate;
        private DevExpress.XtraEditors.DateEdit tbdateto;
        private DevExpress.XtraEditors.DateEdit tbdatefrom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ContextMenuStrip cmsConfirm;
        private System.Windows.Forms.ToolStripMenuItem cmsConfirmBtn0b;
        private System.Windows.Forms.ToolStripMenuItem cmsConfirmBtn0a;
        private DevExpress.XtraEditors.RadioGroup rgstatus;
        private System.Windows.Forms.ToolStripSeparator cmsConfirmSep0a;
        private DevExpress.XtraEditors.TextEdit tbForfeit;
        private DevExpress.XtraEditors.LabelControl lblForfeit;
    }
}