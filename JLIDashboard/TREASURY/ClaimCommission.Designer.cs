using DevExpress.XtraEditors;

namespace JLIDashboard.TREASURY
{
    partial class ClaimCommission
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnclaim = new DevExpress.XtraEditors.SimpleButton();
            this.tbactname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbamtclaim = new DevExpress.XtraEditors.SpinEdit();
            this.tbcombal = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tsaccountid = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tbaccountid = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbactname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbamtclaim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcombal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsaccountid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaccountid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnclaim);
            this.groupControl1.Controls.Add(this.tbactname);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.tbamtclaim);
            this.groupControl1.Controls.Add(this.tbcombal);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.tsaccountid);
            this.groupControl1.Controls.Add(this.tbaccountid);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(854, 408);
            this.groupControl1.TabIndex = 3;
            // 
            // btnclaim
            // 
            this.btnclaim.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnclaim.Appearance.Options.UseFont = true;
            this.btnclaim.Location = new System.Drawing.Point(301, 301);
            this.btnclaim.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnclaim.Name = "btnclaim";
            this.btnclaim.Size = new System.Drawing.Size(531, 85);
            this.btnclaim.TabIndex = 1100;
            this.btnclaim.Text = "Claim Commission";
            this.btnclaim.Click += new System.EventHandler(this.btnclaim_Click);
            // 
            // tbactname
            // 
            this.tbactname.Location = new System.Drawing.Point(301, 127);
            this.tbactname.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbactname.Name = "tbactname";
            this.tbactname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbactname.Properties.Appearance.Options.UseFont = true;
            this.tbactname.Properties.ReadOnly = true;
            this.tbactname.Size = new System.Drawing.Size(531, 50);
            this.tbactname.TabIndex = 1003;
            this.tbactname.TabStop = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(22, 134);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(191, 34);
            this.labelControl4.TabIndex = 123;
            this.labelControl4.Text = "Account Name:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(22, 250);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(217, 34);
            this.labelControl3.TabIndex = 122;
            this.labelControl3.Text = "Amount to Claim:";
            // 
            // tbamtclaim
            // 
            this.tbamtclaim.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbamtclaim.Location = new System.Drawing.Point(301, 243);
            this.tbamtclaim.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbamtclaim.Name = "tbamtclaim";
            this.tbamtclaim.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbamtclaim.Properties.Appearance.Options.UseFont = true;
            this.tbamtclaim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbamtclaim.Size = new System.Drawing.Size(232, 50);
            this.tbamtclaim.TabIndex = 1005;
            this.tbamtclaim.EditValueChanged += new System.EventHandler(this.tbamtclaim_EditValueChanged);
            this.tbamtclaim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbamtclaim_KeyPress);
            // 
            // tbcombal
            // 
            this.tbcombal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbcombal.Location = new System.Drawing.Point(301, 185);
            this.tbcombal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbcombal.Name = "tbcombal";
            this.tbcombal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbcombal.Properties.Appearance.Options.UseFont = true;
            this.tbcombal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbcombal.Properties.Mask.EditMask = "#,###.00";
            this.tbcombal.Properties.ReadOnly = true;
            this.tbcombal.Size = new System.Drawing.Size(232, 50);
            this.tbcombal.TabIndex = 1004;
            this.tbcombal.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(22, 192);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(265, 34);
            this.labelControl2.TabIndex = 119;
            this.labelControl2.Text = "Commission Balance:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(22, 78);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 34);
            this.labelControl1.TabIndex = 117;
            this.labelControl1.Text = "Account ID:";
            // 
            // tsaccountid
            // 
            this.tsaccountid.Location = new System.Drawing.Point(301, 69);
            this.tsaccountid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tsaccountid.Name = "tsaccountid";
            this.tsaccountid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsaccountid.Properties.Appearance.Options.UseFont = true;
            this.tsaccountid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsaccountid.Properties.NullText = "";
            this.tsaccountid.Properties.PopupView = this.gridView2;
            this.tsaccountid.Size = new System.Drawing.Size(531, 50);
            this.tsaccountid.TabIndex = 1002;
            this.tsaccountid.EditValueChanged += new System.EventHandler(this.tsaccountid_EditValueChanged);
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
            // tbaccountid
            // 
            this.tbaccountid.Location = new System.Drawing.Point(301, 69);
            this.tbaccountid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbaccountid.Name = "tbaccountid";
            this.tbaccountid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbaccountid.Properties.Appearance.Options.UseFont = true;
            this.tbaccountid.Properties.ReadOnly = true;
            this.tbaccountid.Size = new System.Drawing.Size(531, 50);
            this.tbaccountid.TabIndex = 1001;
            this.tbaccountid.TabStop = false;
            // 
            // ClaimCommission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 408);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "ClaimCommission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClaimCommission";
            this.Load += new System.EventHandler(this.ClaimCommission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbactname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbamtclaim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcombal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsaccountid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaccountid.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private SimpleButton btnclaim;
        public TextEdit tbaccountid;
        public TextEdit tbactname;
        public SpinEdit tbcombal;
        public SpinEdit tbamtclaim;
        private SearchLookUpEdit tsaccountid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}