using DevExpress.XtraEditors;

namespace JLIDashboard.ACCOUNTS.frm
{
    partial class InvitePlayer
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
            this.tscoord = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tsgencoord = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tbfirstname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tbmobilenumber = new DevExpress.XtraEditors.TextEdit();
            this.tblastname = new DevExpress.XtraEditors.TextEdit();
            this.btnconfirm = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tscoord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgencoord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbfirstname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbmobilenumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblastname.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tscoord);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.tsgencoord);
            this.groupControl1.Controls.Add(this.tbfirstname);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.tbmobilenumber);
            this.groupControl1.Controls.Add(this.tblastname);
            this.groupControl1.Controls.Add(this.btnconfirm);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(460, 260);
            this.groupControl1.TabIndex = 3;
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
            this.tscoord.TabIndex = 1002;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 75);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(79, 18);
            this.labelControl6.TabIndex = 1101;
            this.labelControl6.Text = "Coordinator:";
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
            // tbfirstname
            // 
            this.tbfirstname.Location = new System.Drawing.Point(162, 104);
            this.tbfirstname.Name = "tbfirstname";
            this.tbfirstname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbfirstname.Properties.Appearance.Options.UseFont = true;
            this.tbfirstname.Size = new System.Drawing.Size(286, 26);
            this.tbfirstname.TabIndex = 1003;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 108);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 18);
            this.labelControl5.TabIndex = 136;
            this.labelControl5.Text = "Firstname:";
            // 
            // tbmobilenumber
            // 
            this.tbmobilenumber.Location = new System.Drawing.Point(162, 168);
            this.tbmobilenumber.Name = "tbmobilenumber";
            this.tbmobilenumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbmobilenumber.Properties.Appearance.Options.UseFont = true;
            this.tbmobilenumber.Size = new System.Drawing.Size(286, 26);
            this.tbmobilenumber.TabIndex = 1005;
            // 
            // tblastname
            // 
            this.tblastname.Location = new System.Drawing.Point(162, 136);
            this.tblastname.Name = "tblastname";
            this.tblastname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tblastname.Properties.Appearance.Options.UseFont = true;
            this.tblastname.Size = new System.Drawing.Size(286, 26);
            this.tblastname.TabIndex = 1004;
            // 
            // btnconfirm
            // 
            this.btnconfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnconfirm.Appearance.Options.UseFont = true;
            this.btnconfirm.Location = new System.Drawing.Point(162, 200);
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
            this.labelControl4.Location = new System.Drawing.Point(12, 140);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 18);
            this.labelControl4.TabIndex = 123;
            this.labelControl4.Text = "Lastname:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 172);
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
            this.labelControl1.Size = new System.Drawing.Size(133, 18);
            this.labelControl1.TabIndex = 117;
            this.labelControl1.Text = "General Coordinator:";
            // 
            // InvitePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 260);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvitePlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tscoord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgencoord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
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
        public TextEdit tbmobilenumber;
        public TextEdit tblastname;
        public TextEdit tbfirstname;
        private LabelControl labelControl5;
        private SearchLookUpEdit tsgencoord;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private SearchLookUpEdit tscoord;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private LabelControl labelControl6;
    }
}