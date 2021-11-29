using DevExpress.XtraEditors;

namespace JLIDashboard.TREASURY
{
    partial class Remittances__
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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsRem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRemBtn0c = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemBtn0b = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemSep0a = new System.Windows.Forms.ToolStripSeparator();
            this.cmsRemBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnnew = new DevExpress.XtraEditors.SimpleButton();
            this.tbtermsurl = new DevExpress.XtraEditors.TextEdit();
            this.tblogourl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tbremname = new DevExpress.XtraEditors.TextEdit();
            this.tbremcode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tsenctype = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btncancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnsubmit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsRem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbtermsurl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblogourl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbremname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbremcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsenctype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsRem;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(336, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(496, 317);
            this.gridControl1.TabIndex = 10037;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsRem
            // 
            this.cmsRem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRemBtn0c,
            this.cmsRemBtn0b,
            this.cmsRemSep0a,
            this.cmsRemBtn0a});
            this.cmsRem.Name = "contextMenuStrip1";
            this.cmsRem.Size = new System.Drawing.Size(184, 82);
            // 
            // cmsRemBtn0c
            // 
            this.cmsRemBtn0c.Name = "cmsRemBtn0c";
            this.cmsRemBtn0c.Size = new System.Drawing.Size(183, 24);
            this.cmsRemBtn0c.Text = "Edit Remittance";
            this.cmsRemBtn0c.Click += new System.EventHandler(this.cmsRemBtn0c_Click);
            // 
            // cmsRemBtn0b
            // 
            this.cmsRemBtn0b.Name = "cmsRemBtn0b";
            this.cmsRemBtn0b.Size = new System.Drawing.Size(183, 24);
            this.cmsRemBtn0b.Text = "Delete";
            this.cmsRemBtn0b.Click += new System.EventHandler(this.cmsRemBtn0b_Click);
            // 
            // cmsRemSep0a
            // 
            this.cmsRemSep0a.Name = "cmsRemSep0a";
            this.cmsRemSep0a.Size = new System.Drawing.Size(180, 6);
            // 
            // cmsRemBtn0a
            // 
            this.cmsRemBtn0a.Name = "cmsRemBtn0a";
            this.cmsRemBtn0a.Size = new System.Drawing.Size(183, 24);
            this.cmsRemBtn0a.Text = "Refresh";
            this.cmsRemBtn0a.Click += new System.EventHandler(this.cmsRemBtn0a_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbtermsurl);
            this.groupControl1.Controls.Add(this.tblogourl);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.tbremname);
            this.groupControl1.Controls.Add(this.tbremcode);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.tsenctype);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btncancel);
            this.groupControl1.Controls.Add(this.btnnew);
            this.groupControl1.Controls.Add(this.btnsubmit);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(336, 317);
            this.groupControl1.TabIndex = 10038;
            this.groupControl1.Text = "Form:";
            // 
            // btnnew
            // 
            this.btnnew.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnnew.Appearance.Options.UseFont = true;
            this.btnnew.Location = new System.Drawing.Point(135, 193);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(114, 34);
            this.btnnew.TabIndex = 1119;
            this.btnnew.Text = "New Form";
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // tbtermsurl
            // 
            this.tbtermsurl.Location = new System.Drawing.Point(136, 161);
            this.tbtermsurl.Name = "tbtermsurl";
            this.tbtermsurl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbtermsurl.Properties.Appearance.Options.UseFont = true;
            this.tbtermsurl.Size = new System.Drawing.Size(185, 26);
            this.tbtermsurl.TabIndex = 1117;
            this.tbtermsurl.TabStop = false;
            // 
            // tblogourl
            // 
            this.tblogourl.Location = new System.Drawing.Point(136, 129);
            this.tblogourl.Name = "tblogourl";
            this.tblogourl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tblogourl.Properties.Appearance.Options.UseFont = true;
            this.tblogourl.Size = new System.Drawing.Size(185, 26);
            this.tblogourl.TabIndex = 1116;
            this.tblogourl.TabStop = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(44, 165);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(86, 18);
            this.labelControl6.TabIndex = 1115;
            this.labelControl6.Text = "Terms(URL):";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(55, 133);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(74, 18);
            this.labelControl7.TabIndex = 1114;
            this.labelControl7.Text = "Logo(URL):";
            // 
            // tbremname
            // 
            this.tbremname.Location = new System.Drawing.Point(136, 65);
            this.tbremname.Name = "tbremname";
            this.tbremname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbremname.Properties.Appearance.Options.UseFont = true;
            this.tbremname.Size = new System.Drawing.Size(185, 26);
            this.tbremname.TabIndex = 1113;
            this.tbremname.TabStop = false;
            // 
            // tbremcode
            // 
            this.tbremcode.Location = new System.Drawing.Point(136, 33);
            this.tbremcode.Name = "tbremcode";
            this.tbremcode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tbremcode.Properties.Appearance.Options.UseFont = true;
            this.tbremcode.Size = new System.Drawing.Size(185, 26);
            this.tbremcode.TabIndex = 1112;
            this.tbremcode.TabStop = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(8, 68);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(122, 18);
            this.labelControl5.TabIndex = 1110;
            this.labelControl5.Text = "Remittance Name:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(6, 101);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(124, 18);
            this.labelControl4.TabIndex = 1108;
            this.labelControl4.Text = "Encashment Type:";
            // 
            // tsenctype
            // 
            this.tsenctype.Location = new System.Drawing.Point(136, 97);
            this.tsenctype.Name = "tsenctype";
            this.tsenctype.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsenctype.Properties.Appearance.Options.UseFont = true;
            this.tsenctype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsenctype.Properties.NullText = "";
            this.tsenctype.Properties.PopupView = this.gridView4;
            this.tsenctype.Size = new System.Drawing.Size(185, 26);
            this.tsenctype.TabIndex = 1109;
            // 
            // gridView4
            // 
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 36);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(116, 18);
            this.labelControl1.TabIndex = 1101;
            this.labelControl1.Text = "Remittance Code:";
            // 
            // btncancel
            // 
            this.btncancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btncancel.Appearance.Options.UseFont = true;
            this.btncancel.Location = new System.Drawing.Point(255, 193);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(66, 34);
            this.btncancel.TabIndex = 1118;
            this.btncancel.Text = "Cancel";
            this.btncancel.Visible = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsubmit
            // 
            this.btnsubmit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.btnsubmit.Appearance.Options.UseFont = true;
            this.btnsubmit.Location = new System.Drawing.Point(135, 193);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(114, 34);
            this.btnsubmit.TabIndex = 1103;
            this.btnsubmit.Text = "Save Changes";
            this.btnsubmit.Visible = false;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // Remittances__
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 317);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "Remittances__";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remittance";
            this.Load += new System.EventHandler(this.ClaimCommission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsRem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbtermsurl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblogourl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbremname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbremcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsenctype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private GroupControl groupControl1;
        private LabelControl labelControl5;
        private LabelControl labelControl4;
        private SearchLookUpEdit tsenctype;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private SimpleButton btnsubmit;
        private LabelControl labelControl1;
        public TextEdit tbremcode;
        public TextEdit tbtermsurl;
        public TextEdit tblogourl;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        public TextEdit tbremname;
        private SimpleButton btncancel;
        private System.Windows.Forms.ContextMenuStrip cmsRem;
        private System.Windows.Forms.ToolStripMenuItem cmsRemBtn0b;
        private System.Windows.Forms.ToolStripSeparator cmsRemSep0a;
        private System.Windows.Forms.ToolStripMenuItem cmsRemBtn0a;
        private SimpleButton btnnew;
        private System.Windows.Forms.ToolStripMenuItem cmsRemBtn0c;
    }
}