namespace JLIDashboard.OPERATION
{
    partial class LiveStreaming
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
            this.Label58 = new System.Windows.Forms.Label();
            this.tburl = new DevExpress.XtraEditors.TextEdit();
            this.tbdescr = new DevExpress.XtraEditors.MemoEdit();
            this.btnsubmit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tburl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdescr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Label58
            // 
            this.Label58.AutoSize = true;
            this.Label58.BackColor = System.Drawing.Color.Transparent;
            this.Label58.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label58.Location = new System.Drawing.Point(105, 6);
            this.Label58.Name = "Label58";
            this.Label58.Size = new System.Drawing.Size(213, 28);
            this.Label58.TabIndex = 10028;
            this.Label58.Text = "Live Streaming Video";
            // 
            // tburl
            // 
            this.tburl.Location = new System.Drawing.Point(49, 37);
            this.tburl.Name = "tburl";
            this.tburl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tburl.Properties.Appearance.Options.UseFont = true;
            this.tburl.Properties.NullValuePrompt = "Live Stream Url";
            this.tburl.Size = new System.Drawing.Size(354, 26);
            this.tburl.TabIndex = 1001;
            this.tburl.TabStop = false;
            // 
            // tbdescr
            // 
            this.tbdescr.Location = new System.Drawing.Point(49, 66);
            this.tbdescr.Name = "tbdescr";
            this.tbdescr.Properties.NullValuePrompt = "Live Steam Description";
            this.tbdescr.Size = new System.Drawing.Size(354, 96);
            this.tbdescr.TabIndex = 1002;
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(135, 169);
            this.btnsubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(160, 38);
            this.btnsubmit.TabIndex = 1100;
            this.btnsubmit.Text = "POST VIDEO";
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // LiveStreaming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 220);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.tbdescr);
            this.Controls.Add(this.tburl);
            this.Controls.Add(this.Label58);
            this.Name = "LiveStreaming";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Live Streaming Video";
            this.Load += new System.EventHandler(this.LiveStreaming_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tburl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdescr.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label58;
        public DevExpress.XtraEditors.TextEdit tburl;
        private DevExpress.XtraEditors.MemoEdit tbdescr;
        private DevExpress.XtraEditors.SimpleButton btnsubmit;
    }
}