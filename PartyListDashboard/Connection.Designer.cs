namespace JLIDashboard
{
    partial class Connection
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
            this.txtconnsettingsname = new System.Windows.Forms.ComboBox();
            this.lblservername = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btntest = new System.Windows.Forms.Button();
            this.cbodbname = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtserverpassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtserverid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtservername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtconnsettingsname
            // 
            this.txtconnsettingsname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.txtconnsettingsname.FormattingEnabled = true;
            this.txtconnsettingsname.Items.AddRange(new object[] {
            "AAITCRE\\ConnSettingsCloud",
            "AAITCRE\\ConnSettingsMain",
            "AAITCRE\\ConnSettingsUpdater"});
            this.txtconnsettingsname.Location = new System.Drawing.Point(17, 200);
            this.txtconnsettingsname.Name = "txtconnsettingsname";
            this.txtconnsettingsname.Size = new System.Drawing.Size(343, 33);
            this.txtconnsettingsname.TabIndex = 81;
            this.txtconnsettingsname.Visible = false;
            this.txtconnsettingsname.Click += new System.EventHandler(this.txtconnsettingsname_Click);
            // 
            // lblservername
            // 
            this.lblservername.AutoSize = true;
            this.lblservername.BackColor = System.Drawing.Color.Transparent;
            this.lblservername.Font = new System.Drawing.Font("Tahoma", 12.2F, System.Drawing.FontStyle.Bold);
            this.lblservername.ForeColor = System.Drawing.Color.White;
            this.lblservername.Location = new System.Drawing.Point(13, 9);
            this.lblservername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblservername.Name = "lblservername";
            this.lblservername.Size = new System.Drawing.Size(146, 25);
            this.lblservername.TabIndex = 80;
            this.lblservername.Text = "Server Name";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(409, 244);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 36);
            this.btnCancel.TabIndex = 79;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(272, 244);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(129, 36);
            this.btnsave.TabIndex = 78;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btntest
            // 
            this.btntest.BackColor = System.Drawing.Color.SeaGreen;
            this.btntest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntest.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btntest.ForeColor = System.Drawing.Color.White;
            this.btntest.Location = new System.Drawing.Point(367, 200);
            this.btntest.Margin = new System.Windows.Forms.Padding(4);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(167, 36);
            this.btntest.TabIndex = 77;
            this.btntest.Text = "Test Connection";
            this.btntest.UseVisualStyleBackColor = false;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // cbodbname
            // 
            this.cbodbname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodbname.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.cbodbname.FormattingEnabled = true;
            this.cbodbname.Location = new System.Drawing.Point(165, 163);
            this.cbodbname.Margin = new System.Windows.Forms.Padding(4);
            this.cbodbname.Name = "cbodbname";
            this.cbodbname.Size = new System.Drawing.Size(368, 29);
            this.cbodbname.TabIndex = 76;
            this.cbodbname.Click += new System.EventHandler(this.cbodbname_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 22);
            this.label4.TabIndex = 75;
            this.label4.Text = "Database Name";
            // 
            // txtserverpassword
            // 
            this.txtserverpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtserverpassword.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txtserverpassword.Location = new System.Drawing.Point(165, 127);
            this.txtserverpassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtserverpassword.Name = "txtserverpassword";
            this.txtserverpassword.PasswordChar = '*';
            this.txtserverpassword.Size = new System.Drawing.Size(369, 28);
            this.txtserverpassword.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 22);
            this.label3.TabIndex = 73;
            this.label3.Text = "Server Password";
            // 
            // txtserverid
            // 
            this.txtserverid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtserverid.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txtserverid.Location = new System.Drawing.Point(165, 90);
            this.txtserverid.Margin = new System.Windows.Forms.Padding(4);
            this.txtserverid.Name = "txtserverid";
            this.txtserverid.Size = new System.Drawing.Size(369, 28);
            this.txtserverid.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 71;
            this.label2.Text = "Server Id";
            // 
            // txtservername
            // 
            this.txtservername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtservername.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.txtservername.Location = new System.Drawing.Point(165, 53);
            this.txtservername.Margin = new System.Windows.Forms.Padding(4);
            this.txtservername.Name = "txtservername";
            this.txtservername.Size = new System.Drawing.Size(369, 28);
            this.txtservername.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 22);
            this.label1.TabIndex = 69;
            this.label1.Text = "Server Name";
            // 
            // Connection
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 302);
            this.Controls.Add(this.txtconnsettingsname);
            this.Controls.Add(this.lblservername);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btntest);
            this.Controls.Add(this.cbodbname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtserverpassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtserverid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtservername);
            this.Controls.Add(this.label1);
            this.Name = "Connection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.Connection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox txtconnsettingsname;
        public System.Windows.Forms.Label lblservername;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btntest;
        private System.Windows.Forms.ComboBox cbodbname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtserverpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtserverid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtservername;
        private System.Windows.Forms.Label label1;
    }
}