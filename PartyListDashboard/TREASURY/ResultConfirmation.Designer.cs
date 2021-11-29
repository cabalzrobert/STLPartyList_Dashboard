namespace JLIDashboard.TREASURY
{
    partial class ResultConfirmation
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
            this.gcResult = new DevExpress.XtraGrid.GridControl();
            this.cmsResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsResultBtn0c = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsResultBtn0b = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsResultSep0a = new System.Windows.Forms.ToolStripSeparator();
            this.cmsResultBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.gvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btngenerate = new DevExpress.XtraEditors.SimpleButton();
            this.rgstatus = new DevExpress.XtraEditors.RadioGroup();
            this.tbdateto = new DevExpress.XtraEditors.DateEdit();
            this.tbdatefrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).BeginInit();
            this.cmsResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcResult
            // 
            this.gcResult.ContextMenuStrip = this.cmsResult;
            this.gcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcResult.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcResult.Location = new System.Drawing.Point(0, 105);
            this.gcResult.MainView = this.gvResult;
            this.gcResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcResult.Name = "gcResult";
            this.gcResult.Size = new System.Drawing.Size(848, 420);
            this.gcResult.TabIndex = 7;
            this.gcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvResult});
            // 
            // cmsResult
            // 
            this.cmsResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsResultBtn0c,
            this.cmsResultBtn0b,
            this.cmsResultSep0a,
            this.cmsResultBtn0a});
            this.cmsResult.Name = "contextMenuStrip1";
            this.cmsResult.Size = new System.Drawing.Size(176, 82);
            // 
            // cmsResultBtn0c
            // 
            this.cmsResultBtn0c.Name = "cmsResultBtn0c";
            this.cmsResultBtn0c.Size = new System.Drawing.Size(175, 24);
            this.cmsResultBtn0c.Text = "Confirm Result";
            this.cmsResultBtn0c.Click += new System.EventHandler(this.cmsResultBtn0c_Click);
            // 
            // cmsResultBtn0b
            // 
            this.cmsResultBtn0b.Name = "cmsResultBtn0b";
            this.cmsResultBtn0b.Size = new System.Drawing.Size(175, 24);
            this.cmsResultBtn0b.Text = "Decline Result";
            this.cmsResultBtn0b.Click += new System.EventHandler(this.cmsResultBtn0b_Click);
            // 
            // cmsResultSep0a
            // 
            this.cmsResultSep0a.Name = "cmsResultSep0a";
            this.cmsResultSep0a.Size = new System.Drawing.Size(172, 6);
            // 
            // cmsResultBtn0a
            // 
            this.cmsResultBtn0a.Name = "cmsResultBtn0a";
            this.cmsResultBtn0a.Size = new System.Drawing.Size(175, 24);
            this.cmsResultBtn0a.Text = "Refresh";
            this.cmsResultBtn0a.Click += new System.EventHandler(this.cmsResultBtn0a_Click);
            // 
            // gvResult
            // 
            this.gvResult.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvResult.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvResult.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvResult.Appearance.Row.Options.UseFont = true;
            this.gvResult.GridControl = this.gcResult;
            this.gvResult.Name = "gvResult";
            this.gvResult.OptionsBehavior.Editable = false;
            this.gvResult.OptionsBehavior.ReadOnly = true;
            this.gvResult.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gvResult.OptionsView.ColumnAutoWidth = false;
            this.gvResult.OptionsView.RowAutoHeight = true;
            this.gvResult.OptionsView.ShowFooter = true;
            this.gvResult.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewwinningsandlimit_PopupMenuShowing);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbdateto);
            this.groupControl1.Controls.Add(this.tbdatefrom);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btngenerate);
            this.groupControl1.Controls.Add(this.rgstatus);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(848, 105);
            this.groupControl1.TabIndex = 9;
            // 
            // btngenerate
            // 
            this.btngenerate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.8F);
            this.btngenerate.Appearance.Options.UseFont = true;
            this.btngenerate.Location = new System.Drawing.Point(473, 46);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(130, 37);
            this.btngenerate.TabIndex = 125;
            this.btngenerate.Text = "Generate";
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // rgstatus
            // 
            this.rgstatus.EditValue = "0";
            this.rgstatus.Location = new System.Drawing.Point(31, 31);
            this.rgstatus.Name = "rgstatus";
            this.rgstatus.Properties.ColumnIndent = 1;
            this.rgstatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Pending Results"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "Confirm Results")});
            this.rgstatus.Size = new System.Drawing.Size(148, 70);
            this.rgstatus.TabIndex = 0;
            this.rgstatus.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // tbdateto
            // 
            this.tbdateto.EditValue = new System.DateTime(2021, 2, 2, 15, 58, 3, 0);
            this.tbdateto.Location = new System.Drawing.Point(275, 70);
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
            this.tbdateto.TabIndex = 137;
            // 
            // tbdatefrom
            // 
            this.tbdatefrom.EditValue = new System.DateTime(2021, 2, 2, 15, 55, 5, 0);
            this.tbdatefrom.Location = new System.Drawing.Point(275, 37);
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
            this.tbdatefrom.TabIndex = 136;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(194, 73);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 18);
            this.labelControl3.TabIndex = 135;
            this.labelControl3.Text = "Date To:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(194, 41);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 18);
            this.labelControl4.TabIndex = 134;
            this.labelControl4.Text = "Date From:";
            // 
            // ResultConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 525);
            this.Controls.Add(this.gcResult);
            this.Controls.Add(this.groupControl1);
            this.Name = "ResultConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResultConfirmation";
            this.Load += new System.EventHandler(this.ResultConfirmation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).EndInit();
            this.cmsResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdateto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdatefrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gvResult;
        private System.Windows.Forms.ContextMenuStrip cmsResult;
        private System.Windows.Forms.ToolStripMenuItem cmsResultBtn0a;
        private System.Windows.Forms.ToolStripMenuItem cmsResultBtn0c;
        private System.Windows.Forms.ToolStripMenuItem cmsResultBtn0b;
        private System.Windows.Forms.ToolStripSeparator cmsResultSep0a;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup rgstatus;
        private DevExpress.XtraEditors.SimpleButton btngenerate;
        private DevExpress.XtraEditors.DateEdit tbdateto;
        private DevExpress.XtraEditors.DateEdit tbdatefrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}