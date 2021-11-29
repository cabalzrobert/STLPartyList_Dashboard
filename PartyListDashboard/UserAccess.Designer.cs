namespace JLIDashboard
{
    partial class UserAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccess));
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.tab_HomePage = new DevExpress.XtraTab.XtraTabPage();
            this.homepage_checklist = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnupdate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.tab_HomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homepage_checklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.xtraTabControl2.Appearance.Options.UseFont = true;
            this.xtraTabControl2.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.xtraTabControl2.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 86);
            this.xtraTabControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.tab_HomePage;
            this.xtraTabControl2.Size = new System.Drawing.Size(1074, 527);
            this.xtraTabControl2.TabIndex = 28;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tab_HomePage});
            // 
            // tab_HomePage
            // 
            this.tab_HomePage.Controls.Add(this.homepage_checklist);
            this.tab_HomePage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tab_AdminTools.ImageOptions.Image")));
            this.tab_HomePage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tab_HomePage.Name = "tab_HomePage";
            this.tab_HomePage.Size = new System.Drawing.Size(1072, 495);
            this.tab_HomePage.Text = "Homepage";
            // 
            // homepage_checklist
            // 
            this.homepage_checklist.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.homepage_checklist.Appearance.Options.UseFont = true;
            this.homepage_checklist.CheckOnClick = true;
            this.homepage_checklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homepage_checklist.Location = new System.Drawing.Point(0, 0);
            this.homepage_checklist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.homepage_checklist.Name = "homepage_checklist";
            this.homepage_checklist.Size = new System.Drawing.Size(1072, 495);
            this.homepage_checklist.TabIndex = 62;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.searchLookUpEdit1);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btnupdate);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1074, 86);
            this.groupControl1.TabIndex = 27;
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Location = new System.Drawing.Point(112, 37);
            this.searchLookUpEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.searchLookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.NullText = "";
            this.searchLookUpEdit1.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(330, 24);
            this.searchLookUpEdit1.TabIndex = 62;
            this.searchLookUpEdit1.EditValueChanged += new System.EventHandler(this.searchLookUpEdit1_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 61;
            this.label1.Text = "Select User:";
            // 
            // btnupdate
            // 
            this.btnupdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnupdate.ImageOptions.Image")));
            this.btnupdate.Location = new System.Drawing.Point(449, 36);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(111, 25);
            this.btnupdate.TabIndex = 60;
            this.btnupdate.Text = "Update";
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // UserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 613);
            this.Controls.Add(this.xtraTabControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "UserAccess";
            this.Text = "UserAccess";
            this.Load += new System.EventHandler(this.UserAccess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.tab_HomePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homepage_checklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage tab_HomePage;
        private DevExpress.XtraEditors.CheckedListBoxControl homepage_checklist;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnupdate;
    }
}