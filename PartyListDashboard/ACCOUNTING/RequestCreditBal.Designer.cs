namespace JLIDashboard.ACCOUNTING
{
    partial class RequestCreditBal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestCreditBal));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbamt = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.tbpono = new DevExpress.XtraEditors.TextEdit();
            this.btnsubmit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbamt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpono.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(17, 60);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 18);
            this.labelControl1.TabIndex = 177;
            this.labelControl1.Text = "Amount:";
            // 
            // tbamt
            // 
            this.tbamt.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbamt.Location = new System.Drawing.Point(87, 56);
            this.tbamt.Name = "tbamt";
            this.tbamt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbamt.Properties.Appearance.Options.UseFont = true;
            this.tbamt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbamt.Size = new System.Drawing.Size(128, 26);
            this.tbamt.TabIndex = 1001;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(17, 28);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(35, 18);
            this.labelControl15.TabIndex = 175;
            this.labelControl15.Text = "PO#:";
            // 
            // tbpono
            // 
            this.tbpono.Location = new System.Drawing.Point(87, 25);
            this.tbpono.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpono.Name = "tbpono";
            this.tbpono.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbpono.Properties.Appearance.Options.UseFont = true;
            this.tbpono.Properties.MaxLength = 1;
            this.tbpono.Properties.ReadOnly = true;
            this.tbpono.Size = new System.Drawing.Size(162, 24);
            this.tbpono.TabIndex = 174;
            this.tbpono.TabStop = false;
            // 
            // btnsubmit
            // 
            this.btnsubmit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReqCredit.ImageOptions.Image")));
            this.btnsubmit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnsubmit.Location = new System.Drawing.Point(87, 89);
            this.btnsubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(128, 44);
            this.btnsubmit.TabIndex = 1100;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // RequestCreditBal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 146);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbamt);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.tbpono);
            this.Name = "RequestCreditBal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RequestCreditBal";
            this.Load += new System.EventHandler(this.RequestCreditBal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbamt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpono.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit tbamt;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.SimpleButton btnsubmit;
        public DevExpress.XtraEditors.TextEdit tbpono;
    }
}