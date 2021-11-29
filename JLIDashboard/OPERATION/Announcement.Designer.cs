namespace JLIDashboard.OPERATION
{
    partial class Announcement
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
            this.tbttl = new DevExpress.XtraEditors.TextEdit();
            this.tbdescr = new DevExpress.XtraEditors.MemoEdit();
            this.btnsubmit = new DevExpress.XtraEditors.SimpleButton();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tbttl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdescr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbttl
            // 
            this.tbttl.Location = new System.Drawing.Point(12, 25);
            this.tbttl.Name = "tbttl";
            this.tbttl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbttl.Properties.Appearance.Options.UseFont = true;
            this.tbttl.Properties.NullValuePrompt = "Title";
            this.tbttl.Size = new System.Drawing.Size(354, 26);
            this.tbttl.TabIndex = 1001;
            this.tbttl.TabStop = false;
            // 
            // tbdescr
            // 
            this.tbdescr.Location = new System.Drawing.Point(12, 54);
            this.tbdescr.Name = "tbdescr";
            this.tbdescr.Properties.NullValuePrompt = "Description";
            this.tbdescr.Size = new System.Drawing.Size(354, 179);
            this.tbdescr.TabIndex = 1002;
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(99, 240);
            this.btnsubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(183, 38);
            this.btnsubmit.TabIndex = 1100;
            this.btnsubmit.Text = "PUBLISH ANNOUNCEMENT";
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.LinkLabel1.Location = new System.Drawing.Point(11, 5);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(303, 17);
            this.LinkLabel1.TabIndex = 10039;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "See latest annoucement from www.pcso.gov.ph";
            // 
            // Announcement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 291);
            this.Controls.Add(this.LinkLabel1);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.tbdescr);
            this.Controls.Add(this.tbttl);
            this.Name = "Announcement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Post Announcement";
            this.Load += new System.EventHandler(this.Announcement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbttl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdescr.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.TextEdit tbttl;
        private DevExpress.XtraEditors.MemoEdit tbdescr;
        private DevExpress.XtraEditors.SimpleButton btnsubmit;
        private System.Windows.Forms.LinkLabel LinkLabel1;
    }
}