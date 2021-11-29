using DevExpress.XtraEditors;

namespace JLIDashboard.ACCOUNTS.frm
{
    partial class PlayerEntry
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
            this.tscoord = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbterminalserial = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.chkterminal = new System.Windows.Forms.CheckBox();
            this.tbemailaddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tbaddress = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tbpassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tbfirstname = new DevExpress.XtraEditors.TextEdit();
            this.tbmobilenumber = new DevExpress.XtraEditors.TextEdit();
            this.tblastname = new DevExpress.XtraEditors.TextEdit();
            this.btnconfirm = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.tsgencoord = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tscoord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbterminalserial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbemailaddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbfirstname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbmobilenumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblastname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgencoord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chckreseller);
            this.groupControl1.Controls.Add(this.tscoord);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.tbterminalserial);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.chkterminal);
            this.groupControl1.Controls.Add(this.tbemailaddress);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.tbaddress);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.tbpassword);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.tbfirstname);
            this.groupControl1.Controls.Add(this.tbmobilenumber);
            this.groupControl1.Controls.Add(this.tblastname);
            this.groupControl1.Controls.Add(this.btnconfirm);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.tsgencoord);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(468, 476);
            this.groupControl1.TabIndex = 3;
            // 
            // chckreseller
            // 
            this.chckreseller.AutoSize = true;
            this.chckreseller.Location = new System.Drawing.Point(162, 332);
            this.chckreseller.Name = "chckreseller";
            this.chckreseller.Size = new System.Drawing.Size(96, 21);
            this.chckreseller.TabIndex = 1123;
            this.chckreseller.Text = "Is Reseller?";
            this.chckreseller.UseVisualStyleBackColor = true;
            // 
            // tscoord
            // 
            this.tscoord.EditValue = "";
            this.tscoord.Location = new System.Drawing.Point(162, 72);
            this.tscoord.Name = "tscoord";
            this.tscoord.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tscoord.Properties.Appearance.Options.UseFont = true;
            this.tscoord.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tscoord.Properties.NullText = "";
            this.tscoord.Properties.PopupView = this.gridView1;
            this.tscoord.Size = new System.Drawing.Size(286, 26);
            this.tscoord.TabIndex = 1122;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 75);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 18);
            this.labelControl3.TabIndex = 1121;
            this.labelControl3.Text = "Coordinator:";
            // 
            // tbterminalserial
            // 
            this.tbterminalserial.Enabled = false;
            this.tbterminalserial.Location = new System.Drawing.Point(162, 378);
            this.tbterminalserial.Name = "tbterminalserial";
            this.tbterminalserial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbterminalserial.Properties.Appearance.Options.UseFont = true;
            this.tbterminalserial.Size = new System.Drawing.Size(286, 26);
            this.tbterminalserial.TabIndex = 1011;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(12, 382);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(99, 18);
            this.labelControl9.TabIndex = 1120;
            this.labelControl9.Text = "Terminal Serial:";
            // 
            // chkterminal
            // 
            this.chkterminal.AutoSize = true;
            this.chkterminal.Location = new System.Drawing.Point(162, 355);
            this.chkterminal.Name = "chkterminal";
            this.chkterminal.Size = new System.Drawing.Size(206, 21);
            this.chkterminal.TabIndex = 1010;
            this.chkterminal.Text = "Tag account as terminal user";
            this.chkterminal.UseVisualStyleBackColor = true;
            this.chkterminal.CheckedChanged += new System.EventHandler(this.chkterminal_CheckedChanged);
            // 
            // tbemailaddress
            // 
            this.tbemailaddress.Location = new System.Drawing.Point(162, 299);
            this.tbemailaddress.Name = "tbemailaddress";
            this.tbemailaddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbemailaddress.Properties.Appearance.Options.UseFont = true;
            this.tbemailaddress.Properties.Mask.EditMask = "((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_" +
    "-])+)+";
            this.tbemailaddress.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tbemailaddress.Size = new System.Drawing.Size(286, 26);
            this.tbemailaddress.TabIndex = 1007;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(12, 303);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(95, 18);
            this.labelControl7.TabIndex = 1108;
            this.labelControl7.Text = "Email Address:";
            // 
            // tbaddress
            // 
            this.tbaddress.EditValue = "";
            this.tbaddress.Location = new System.Drawing.Point(162, 231);
            this.tbaddress.Name = "tbaddress";
            this.tbaddress.Size = new System.Drawing.Size(286, 62);
            this.tbaddress.TabIndex = 1006;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 235);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(57, 18);
            this.labelControl6.TabIndex = 1107;
            this.labelControl6.Text = "Address:";
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(162, 199);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbpassword.Properties.Appearance.Options.UseFont = true;
            this.tbpassword.Size = new System.Drawing.Size(286, 26);
            this.tbpassword.TabIndex = 1005;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 203);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 18);
            this.labelControl5.TabIndex = 1106;
            this.labelControl5.Text = "Password:";
            // 
            // tbfirstname
            // 
            this.tbfirstname.Location = new System.Drawing.Point(162, 104);
            this.tbfirstname.Name = "tbfirstname";
            this.tbfirstname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbfirstname.Properties.Appearance.Options.UseFont = true;
            this.tbfirstname.Size = new System.Drawing.Size(286, 26);
            this.tbfirstname.TabIndex = 1002;
            // 
            // tbmobilenumber
            // 
            this.tbmobilenumber.Location = new System.Drawing.Point(162, 167);
            this.tbmobilenumber.Name = "tbmobilenumber";
            this.tbmobilenumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbmobilenumber.Properties.Appearance.Options.UseFont = true;
            this.tbmobilenumber.Size = new System.Drawing.Size(286, 26);
            this.tbmobilenumber.TabIndex = 1004;
            // 
            // tblastname
            // 
            this.tblastname.Location = new System.Drawing.Point(162, 135);
            this.tblastname.Name = "tblastname";
            this.tblastname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tblastname.Properties.Appearance.Options.UseFont = true;
            this.tblastname.Size = new System.Drawing.Size(286, 26);
            this.tblastname.TabIndex = 1003;
            // 
            // btnconfirm
            // 
            this.btnconfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnconfirm.Appearance.Options.UseFont = true;
            this.btnconfirm.Location = new System.Drawing.Point(162, 410);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(286, 47);
            this.btnconfirm.TabIndex = 1100;
            this.btnconfirm.Text = "Confirm";
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 139);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 18);
            this.labelControl4.TabIndex = 1104;
            this.labelControl4.Text = "Lastname:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 171);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 18);
            this.labelControl2.TabIndex = 1102;
            this.labelControl2.Text = "Mobile No.:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(12, 108);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(69, 18);
            this.labelControl8.TabIndex = 1101;
            this.labelControl8.Text = "Firstname:";
            // 
            // tsgencoord
            // 
            this.tsgencoord.EditValue = "";
            this.tsgencoord.Location = new System.Drawing.Point(162, 40);
            this.tsgencoord.Name = "tsgencoord";
            this.tsgencoord.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tsgencoord.Properties.Appearance.Options.UseFont = true;
            this.tsgencoord.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsgencoord.Properties.NullText = "";
            this.tsgencoord.Properties.PopupView = this.searchLookUpEdit1View;
            this.tsgencoord.Size = new System.Drawing.Size(286, 26);
            this.tsgencoord.TabIndex = 1001;
            this.tsgencoord.EditValueChanged += new System.EventHandler(this.tsgencoord_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 43);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(133, 18);
            this.labelControl1.TabIndex = 117;
            this.labelControl1.Text = "General Coordinator:";
            // 
            // PlayerEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 476);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tscoord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbterminalserial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbemailaddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbfirstname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbmobilenumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblastname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgencoord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private SearchLookUpEdit tsgencoord;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        public TextEdit tbemailaddress;
        private LabelControl labelControl7;
        private MemoEdit tbaddress;
        private LabelControl labelControl6;
        public TextEdit tbpassword;
        private LabelControl labelControl5;
        public TextEdit tbfirstname;
        public TextEdit tbmobilenumber;
        public TextEdit tblastname;
        private SimpleButton btnconfirm;
        private LabelControl labelControl4;
        private LabelControl labelControl2;
        private LabelControl labelControl8;
        public TextEdit tbterminalserial;
        private LabelControl labelControl9;
        private System.Windows.Forms.CheckBox chkterminal;
        private SearchLookUpEdit tscoord;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private LabelControl labelControl3;
        private System.Windows.Forms.CheckBox chckreseller;
    }
}