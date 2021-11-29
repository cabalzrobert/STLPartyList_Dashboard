using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace JLIDashboard.SETTINGS
{
    partial class AccountInfo
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
            this.tbemailaddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tbaddress = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tbfirstname = new DevExpress.XtraEditors.TextEdit();
            this.tbmobilenumber = new DevExpress.XtraEditors.TextEdit();
            this.tblastname = new DevExpress.XtraEditors.TextEdit();
            this.btnconfirm = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbemailaddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbfirstname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbmobilenumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblastname.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbemailaddress);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.tbaddress);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.tbfirstname);
            this.groupControl1.Controls.Add(this.tbmobilenumber);
            this.groupControl1.Controls.Add(this.tblastname);
            this.groupControl1.Controls.Add(this.btnconfirm);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(394, 239);
            this.groupControl1.TabIndex = 3;
            // 
            // tbemailaddress
            // 
            this.tbemailaddress.Location = new System.Drawing.Point(139, 164);
            this.tbemailaddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbemailaddress.Name = "tbemailaddress";
            this.tbemailaddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbemailaddress.Properties.Appearance.Options.UseFont = true;
            this.tbemailaddress.Properties.Mask.EditMask = "((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_" +
    "-])+)+";
            this.tbemailaddress.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tbemailaddress.Size = new System.Drawing.Size(245, 22);
            this.tbemailaddress.TabIndex = 1006;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(10, 167);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(78, 14);
            this.labelControl7.TabIndex = 141;
            this.labelControl7.Text = "Email Address:";
            // 
            // tbaddress
            // 
            this.tbaddress.EditValue = "";
            this.tbaddress.Location = new System.Drawing.Point(139, 83);
            this.tbaddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbaddress.Name = "tbaddress";
            this.tbaddress.Size = new System.Drawing.Size(245, 50);
            this.tbaddress.TabIndex = 1005;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(10, 86);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(47, 14);
            this.labelControl6.TabIndex = 138;
            this.labelControl6.Text = "Address:";
            // 
            // tbfirstname
            // 
            this.tbfirstname.Location = new System.Drawing.Point(139, 32);
            this.tbfirstname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbfirstname.Name = "tbfirstname";
            this.tbfirstname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbfirstname.Properties.Appearance.Options.UseFont = true;
            this.tbfirstname.Size = new System.Drawing.Size(245, 22);
            this.tbfirstname.TabIndex = 1001;
            // 
            // tbmobilenumber
            // 
            this.tbmobilenumber.Location = new System.Drawing.Point(139, 138);
            this.tbmobilenumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbmobilenumber.Name = "tbmobilenumber";
            this.tbmobilenumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbmobilenumber.Properties.Appearance.Options.UseFont = true;
            this.tbmobilenumber.Size = new System.Drawing.Size(245, 22);
            this.tbmobilenumber.TabIndex = 1003;
            // 
            // tblastname
            // 
            this.tblastname.Location = new System.Drawing.Point(139, 57);
            this.tblastname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblastname.Name = "tblastname";
            this.tblastname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tblastname.Properties.Appearance.Options.UseFont = true;
            this.tblastname.Size = new System.Drawing.Size(245, 22);
            this.tblastname.TabIndex = 1002;
            // 
            // btnconfirm
            // 
            this.btnconfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnconfirm.Appearance.Options.UseFont = true;
            this.btnconfirm.Location = new System.Drawing.Point(139, 190);
            this.btnconfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(245, 38);
            this.btnconfirm.TabIndex = 1100;
            this.btnconfirm.Text = "Save Information";
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(10, 60);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 14);
            this.labelControl4.TabIndex = 123;
            this.labelControl4.Text = "Lastname:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(10, 141);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 14);
            this.labelControl2.TabIndex = 119;
            this.labelControl2.Text = "Mobile No.:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 14);
            this.labelControl1.TabIndex = 117;
            this.labelControl1.Text = "Firstname:";
            // 
            // AccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 239);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AccountInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbemailaddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbfirstname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbmobilenumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblastname.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private SimpleButton btnconfirm;
        public TextEdit tbfirstname;
        public TextEdit tbmobilenumber;
        public TextEdit tblastname;
        public TextEdit tbemailaddress;
        private LabelControl labelControl7;
        private MemoEdit tbaddress;
        private LabelControl labelControl6;
    }
}