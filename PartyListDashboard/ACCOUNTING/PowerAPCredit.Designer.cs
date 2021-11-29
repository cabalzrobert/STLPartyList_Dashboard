namespace JLIDashboard.ACCOUNTING
{
    partial class PowerAPCredit
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
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.tbcreditbal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.tbacctname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.tbamt = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tsactnum = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnsubmit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbcreditbal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbacctname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbamt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsactnum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(15, 16);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(97, 18);
            this.labelControl8.TabIndex = 167;
            this.labelControl8.Text = "Credit Balance:";
            // 
            // tbcreditbal
            // 
            this.tbcreditbal.EditValue = "";
            this.tbcreditbal.Location = new System.Drawing.Point(122, 13);
            this.tbcreditbal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbcreditbal.Name = "tbcreditbal";
            this.tbcreditbal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbcreditbal.Properties.Appearance.Options.UseFont = true;
            this.tbcreditbal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.tbcreditbal.Properties.MaxLength = 1;
            this.tbcreditbal.Properties.ReadOnly = true;
            this.tbcreditbal.Size = new System.Drawing.Size(277, 24);
            this.tbcreditbal.TabIndex = 166;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(15, 80);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(101, 18);
            this.labelControl15.TabIndex = 169;
            this.labelControl15.Text = "Account Name:";
            // 
            // tbacctname
            // 
            this.tbacctname.Location = new System.Drawing.Point(122, 77);
            this.tbacctname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbacctname.Name = "tbacctname";
            this.tbacctname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbacctname.Properties.Appearance.Options.UseFont = true;
            this.tbacctname.Properties.MaxLength = 1;
            this.tbacctname.Properties.ReadOnly = true;
            this.tbacctname.Size = new System.Drawing.Size(277, 24);
            this.tbacctname.TabIndex = 168;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Location = new System.Drawing.Point(15, 48);
            this.labelControl16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(73, 18);
            this.labelControl16.TabIndex = 171;
            this.labelControl16.Text = "Account #:";
            // 
            // tbamt
            // 
            this.tbamt.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbamt.Location = new System.Drawing.Point(122, 108);
            this.tbamt.Name = "tbamt";
            this.tbamt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbamt.Properties.Appearance.Options.UseFont = true;
            this.tbamt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbamt.Size = new System.Drawing.Size(125, 26);
            this.tbamt.TabIndex = 172;
            this.tbamt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbamt_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(15, 112);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 18);
            this.labelControl1.TabIndex = 173;
            this.labelControl1.Text = "Amount:";
            // 
            // tsactnum
            // 
            this.tsactnum.Location = new System.Drawing.Point(122, 44);
            this.tsactnum.Name = "tsactnum";
            this.tsactnum.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tsactnum.Properties.Appearance.Options.UseFont = true;
            this.tsactnum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsactnum.Properties.NullText = "";
            this.tsactnum.Properties.PopupView = this.searchLookUpEdit1View;
            this.tsactnum.Size = new System.Drawing.Size(277, 26);
            this.tsactnum.TabIndex = 174;
            this.tsactnum.EditValueChanged += new System.EventHandler(this.tsactnum_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // btnsubmit
            // 
            this.btnsubmit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnsubmit.Appearance.Options.UseFont = true;
            this.btnsubmit.Location = new System.Drawing.Point(122, 140);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(286, 47);
            this.btnsubmit.TabIndex = 1101;
            this.btnsubmit.Text = "Load Credits";
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // PowerAPCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 197);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.tsactnum);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbamt);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.tbcreditbal);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.tbacctname);
            this.Controls.Add(this.labelControl16);
            this.Name = "PowerAPCredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PowerAPCredit";
            this.Load += new System.EventHandler(this.PowerAPCredit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbcreditbal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbacctname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbamt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsactnum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit tbcreditbal;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit tbacctname;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.SpinEdit tbamt;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit tsactnum;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton btnsubmit;
    }
}