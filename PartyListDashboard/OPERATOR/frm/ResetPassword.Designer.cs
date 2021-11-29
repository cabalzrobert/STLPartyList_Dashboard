using DevExpress.XtraEditors;

namespace JLIDashboard.OPERATOR.frm
{
    partial class ResetPassword
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
            this.tbpassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tbconfirmpassword = new DevExpress.XtraEditors.TextEdit();
            this.btnconfirm = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbconfirmpassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbpassword);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.tbconfirmpassword);
            this.groupControl1.Controls.Add(this.btnconfirm);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(986, 322);
            this.groupControl1.TabIndex = 3;
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(347, 74);
            this.tbpassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbpassword.Properties.Appearance.Options.UseFont = true;
            this.tbpassword.Size = new System.Drawing.Size(613, 56);
            this.tbpassword.TabIndex = 1001;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(26, 82);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(210, 37);
            this.labelControl5.TabIndex = 136;
            this.labelControl5.Text = "New Password:";
            // 
            // tbconfirmpassword
            // 
            this.tbconfirmpassword.Location = new System.Drawing.Point(347, 140);
            this.tbconfirmpassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbconfirmpassword.Name = "tbconfirmpassword";
            this.tbconfirmpassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbconfirmpassword.Properties.Appearance.Options.UseFont = true;
            this.tbconfirmpassword.Size = new System.Drawing.Size(613, 56);
            this.tbconfirmpassword.TabIndex = 1002;
            // 
            // btnconfirm
            // 
            this.btnconfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnconfirm.Appearance.Options.UseFont = true;
            this.btnconfirm.Location = new System.Drawing.Point(347, 206);
            this.btnconfirm.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(613, 97);
            this.btnconfirm.TabIndex = 1100;
            this.btnconfirm.Text = "Confirm";
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(26, 148);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(257, 37);
            this.labelControl4.TabIndex = 123;
            this.labelControl4.Text = "Confirm Password:";
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 322);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Password";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbconfirmpassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private SimpleButton btnconfirm;
        public TextEdit tbconfirmpassword;
        public TextEdit tbpassword;
        private LabelControl labelControl5;
    }
}