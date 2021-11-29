using DevExpress.XtraEditors;

namespace JLIDashboard.SETTINGS
{
    partial class ChangePassword
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
            this.tboldpassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbconfirmpassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tboldpassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbpassword);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.tbconfirmpassword);
            this.groupControl1.Controls.Add(this.btnconfirm);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.tboldpassword);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(460, 203);
            this.groupControl1.TabIndex = 3;
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(162, 69);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbpassword.Properties.Appearance.Options.UseFont = true;
            this.tbpassword.Size = new System.Drawing.Size(286, 26);
            this.tbpassword.TabIndex = 1001;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 73);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(99, 18);
            this.labelControl5.TabIndex = 136;
            this.labelControl5.Text = "New Password:";
            // 
            // tbconfirmpassword
            // 
            this.tbconfirmpassword.Location = new System.Drawing.Point(162, 101);
            this.tbconfirmpassword.Name = "tbconfirmpassword";
            this.tbconfirmpassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbconfirmpassword.Properties.Appearance.Options.UseFont = true;
            this.tbconfirmpassword.Size = new System.Drawing.Size(286, 26);
            this.tbconfirmpassword.TabIndex = 1002;
            // 
            // btnconfirm
            // 
            this.btnconfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnconfirm.Appearance.Options.UseFont = true;
            this.btnconfirm.Location = new System.Drawing.Point(162, 133);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(286, 47);
            this.btnconfirm.TabIndex = 1100;
            this.btnconfirm.Text = "Change Password";
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 105);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(121, 18);
            this.labelControl4.TabIndex = 123;
            this.labelControl4.Text = "Confirm Password:";
            // 
            // tboldpassword
            // 
            this.tboldpassword.Location = new System.Drawing.Point(162, 37);
            this.tboldpassword.Name = "tboldpassword";
            this.tboldpassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tboldpassword.Properties.Appearance.Options.UseFont = true;
            this.tboldpassword.Size = new System.Drawing.Size(286, 26);
            this.tboldpassword.TabIndex = 1102;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 41);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 18);
            this.labelControl1.TabIndex = 1101;
            this.labelControl1.Text = "Old Password:";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 203);
            this.Controls.Add(this.groupControl1);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbconfirmpassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tboldpassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private SimpleButton btnconfirm;
        public TextEdit tbconfirmpassword;
        public TextEdit tbpassword;
        private LabelControl labelControl5;
        public TextEdit tboldpassword;
        private LabelControl labelControl1;
    }
}