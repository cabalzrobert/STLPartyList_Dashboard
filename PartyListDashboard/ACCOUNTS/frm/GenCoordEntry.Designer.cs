using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace JLIDashboard.ACCOUNTS.frm
{
    partial class GenCoordEntry
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
            this.chckreseller = new System.Windows.Forms.CheckBox();
            this.tbemailaddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tbaddress = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tbpassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tbcommrate = new DevExpress.XtraEditors.TextEdit();
            this.tbfirstname = new DevExpress.XtraEditors.TextEdit();
            this.tbmobilenumber = new DevExpress.XtraEditors.TextEdit();
            this.tblastname = new DevExpress.XtraEditors.TextEdit();
            this.btnconfirm = new DevExpress.XtraEditors.SimpleButton();
            this.ltxtmax = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbemailaddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcommrate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbfirstname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbmobilenumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblastname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ltxtmax.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chckreseller);
            this.groupControl1.Controls.Add(this.tbemailaddress);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.tbaddress);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.tbpassword);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.tbcommrate);
            this.groupControl1.Controls.Add(this.tbfirstname);
            this.groupControl1.Controls.Add(this.tbmobilenumber);
            this.groupControl1.Controls.Add(this.tblastname);
            this.groupControl1.Controls.Add(this.btnconfirm);
            this.groupControl1.Controls.Add(this.ltxtmax);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(460, 387);
            this.groupControl1.TabIndex = 3;
            // 
            // chckreseller
            // 
            this.chckreseller.AutoSize = true;
            this.chckreseller.Location = new System.Drawing.Point(162, 303);
            this.chckreseller.Name = "chckreseller";
            this.chckreseller.Size = new System.Drawing.Size(96, 21);
            this.chckreseller.TabIndex = 1124;
            this.chckreseller.Text = "Is Reseller?";
            this.chckreseller.UseVisualStyleBackColor = true;
            // 
            // tbemailaddress
            // 
            this.tbemailaddress.Location = new System.Drawing.Point(162, 234);
            this.tbemailaddress.Name = "tbemailaddress";
            this.tbemailaddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbemailaddress.Properties.Appearance.Options.UseFont = true;
            this.tbemailaddress.Properties.Mask.EditMask = "((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_" +
    "-])+)+";
            this.tbemailaddress.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tbemailaddress.Size = new System.Drawing.Size(286, 26);
            this.tbemailaddress.TabIndex = 1006;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(12, 238);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(95, 18);
            this.labelControl7.TabIndex = 141;
            this.labelControl7.Text = "Email Address:";
            // 
            // tbaddress
            // 
            this.tbaddress.EditValue = "";
            this.tbaddress.Location = new System.Drawing.Point(162, 166);
            this.tbaddress.Name = "tbaddress";
            this.tbaddress.Size = new System.Drawing.Size(286, 62);
            this.tbaddress.TabIndex = 1005;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 170);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(57, 18);
            this.labelControl6.TabIndex = 138;
            this.labelControl6.Text = "Address:";
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(162, 134);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbpassword.Properties.Appearance.Options.UseFont = true;
            this.tbpassword.Size = new System.Drawing.Size(286, 26);
            this.tbpassword.TabIndex = 1004;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 138);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 18);
            this.labelControl5.TabIndex = 136;
            this.labelControl5.Text = "Password:";
            // 
            // tbcommrate
            // 
            this.tbcommrate.EditValue = "";
            this.tbcommrate.Location = new System.Drawing.Point(162, 266);
            this.tbcommrate.Name = "tbcommrate";
            this.tbcommrate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbcommrate.Properties.Appearance.Options.UseFont = true;
            this.tbcommrate.Properties.Appearance.Options.UseTextOptions = true;
            this.tbcommrate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbcommrate.Properties.Mask.EditMask = "##0.0#";
            this.tbcommrate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbcommrate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.tbcommrate.Size = new System.Drawing.Size(127, 26);
            this.tbcommrate.TabIndex = 1008;
            this.tbcommrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbcommrate_KeyPress);
            // 
            // tbfirstname
            // 
            this.tbfirstname.Location = new System.Drawing.Point(162, 39);
            this.tbfirstname.Name = "tbfirstname";
            this.tbfirstname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbfirstname.Properties.Appearance.Options.UseFont = true;
            this.tbfirstname.Size = new System.Drawing.Size(286, 26);
            this.tbfirstname.TabIndex = 1001;
            // 
            // tbmobilenumber
            // 
            this.tbmobilenumber.Location = new System.Drawing.Point(162, 102);
            this.tbmobilenumber.Name = "tbmobilenumber";
            this.tbmobilenumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbmobilenumber.Properties.Appearance.Options.UseFont = true;
            this.tbmobilenumber.Size = new System.Drawing.Size(286, 26);
            this.tbmobilenumber.TabIndex = 1003;
            // 
            // tblastname
            // 
            this.tblastname.Location = new System.Drawing.Point(162, 70);
            this.tblastname.Name = "tblastname";
            this.tblastname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tblastname.Properties.Appearance.Options.UseFont = true;
            this.tblastname.Size = new System.Drawing.Size(286, 26);
            this.tblastname.TabIndex = 1002;
            // 
            // btnconfirm
            // 
            this.btnconfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnconfirm.Appearance.Options.UseFont = true;
            this.btnconfirm.Location = new System.Drawing.Point(162, 327);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(286, 47);
            this.btnconfirm.TabIndex = 1100;
            this.btnconfirm.Text = "Confirm";
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // ltxtmax
            // 
            this.ltxtmax.EditValue = "(100% max)";
            this.ltxtmax.Enabled = false;
            this.ltxtmax.Location = new System.Drawing.Point(293, 266);
            this.ltxtmax.Name = "ltxtmax";
            this.ltxtmax.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F, System.Drawing.FontStyle.Bold);
            this.ltxtmax.Properties.Appearance.Options.UseFont = true;
            this.ltxtmax.Properties.Appearance.Options.UseTextOptions = true;
            this.ltxtmax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ltxtmax.Properties.ReadOnly = true;
            this.ltxtmax.Size = new System.Drawing.Size(155, 26);
            this.ltxtmax.TabIndex = 1007;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 74);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 18);
            this.labelControl4.TabIndex = 123;
            this.labelControl4.Text = "Lastname:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 270);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(109, 18);
            this.labelControl3.TabIndex = 122;
            this.labelControl3.Text = "Commission(%):";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 106);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 18);
            this.labelControl2.TabIndex = 119;
            this.labelControl2.Text = "Mobile No.:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 43);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 18);
            this.labelControl1.TabIndex = 117;
            this.labelControl1.Text = "Firstname:";
            // 
            // GenCoordEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 387);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenCoordEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Coordinator Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbemailaddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcommrate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbfirstname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbmobilenumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblastname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ltxtmax.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private SimpleButton btnconfirm;
        public TextEdit ltxtmax;
        public TextEdit tbfirstname;
        public TextEdit tbmobilenumber;
        public TextEdit tblastname;
        public TextEdit tbcommrate;
        public TextEdit tbemailaddress;
        private LabelControl labelControl7;
        private MemoEdit tbaddress;
        private LabelControl labelControl6;
        public TextEdit tbpassword;
        private LabelControl labelControl5;
        private System.Windows.Forms.CheckBox chckreseller;
    }
}