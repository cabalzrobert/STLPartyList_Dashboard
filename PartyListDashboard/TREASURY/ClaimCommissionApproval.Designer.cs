using DevExpress.XtraEditors;

namespace JLIDashboard.TREASURY
{
    partial class ClaimCommissionApproval
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbaccountid = new DevExpress.XtraEditors.TextEdit();
            this.tbotpno = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbactname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbamtclaim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaccountid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbotpno.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.tbotpno);
            this.groupControl1.Controls.Add(this.btnclaim);
            this.groupControl1.Controls.Add(this.tbactname);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.tbamtclaim);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.tbaccountid);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(460, 225);
            this.groupControl1.TabIndex = 3;
            // 
            // btnclaim
            // 
            this.btnclaim.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnclaim.Appearance.Options.UseFont = true;
            this.btnclaim.Location = new System.Drawing.Point(162, 166);
            this.btnclaim.Name = "btnclaim";
            this.btnclaim.Size = new System.Drawing.Size(286, 47);
            this.btnclaim.TabIndex = 1100;
            this.btnclaim.Text = "Approval Claim Commission";
            this.btnclaim.Click += new System.EventHandler(this.btnclaim_Click);
            // 
            // tbactname
            // 
            this.tbactname.Location = new System.Drawing.Point(162, 70);
            this.tbactname.Name = "tbactname";
            this.tbactname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbactname.Properties.Appearance.Options.UseFont = true;
            this.tbactname.Properties.ReadOnly = true;
            this.tbactname.Size = new System.Drawing.Size(286, 26);
            this.tbactname.TabIndex = 1003;
            this.tbactname.TabStop = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 74);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(101, 18);
            this.labelControl4.TabIndex = 123;
            this.labelControl4.Text = "Account Name:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 106);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(113, 18);
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
            this.tbamtclaim.Location = new System.Drawing.Point(162, 102);
            this.tbamtclaim.Name = "tbamtclaim";
            this.tbamtclaim.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbamtclaim.Properties.Appearance.Options.UseFont = true;
            this.tbamtclaim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbamtclaim.Properties.ReadOnly = true;
            this.tbamtclaim.Size = new System.Drawing.Size(125, 26);
            this.tbamtclaim.TabIndex = 1004;
            this.tbamtclaim.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 43);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 18);
            this.labelControl1.TabIndex = 117;
            this.labelControl1.Text = "Account ID:";
            // 
            // tbaccountid
            // 
            this.tbaccountid.Location = new System.Drawing.Point(162, 38);
            this.tbaccountid.Name = "tbaccountid";
            this.tbaccountid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbaccountid.Properties.Appearance.Options.UseFont = true;
            this.tbaccountid.Properties.ReadOnly = true;
            this.tbaccountid.Size = new System.Drawing.Size(286, 26);
            this.tbaccountid.TabIndex = 1001;
            this.tbaccountid.TabStop = false;
            // 
            // tbotpno
            // 
            this.tbotpno.Location = new System.Drawing.Point(162, 134);
            this.tbotpno.Name = "tbotpno";
            this.tbotpno.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbotpno.Properties.Appearance.Options.UseFont = true;
            this.tbotpno.Size = new System.Drawing.Size(206, 26);
            this.tbotpno.TabIndex = 1101;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 138);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 18);
            this.labelControl2.TabIndex = 1102;
            this.labelControl2.Text = "OTP:";
            // 
            // ClaimCommissionApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 225);
            this.Controls.Add(this.groupControl1);
            this.Name = "ClaimCommissionApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClaimCommission - Approval";
            this.Load += new System.EventHandler(this.ClaimCommissionApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbactname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbamtclaim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaccountid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbotpno.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private SimpleButton btnclaim;
        public TextEdit tbaccountid;
        public TextEdit tbactname;
        public SpinEdit tbamtclaim;
        public TextEdit tbotpno;
        private LabelControl labelControl2;
    }
}