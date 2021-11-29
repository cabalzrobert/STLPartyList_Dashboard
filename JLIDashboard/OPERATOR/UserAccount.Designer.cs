namespace JLIDashboard.OPERATOR
{
    partial class UserAccount
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbaddress = new DevExpress.XtraEditors.MemoEdit();
            this.tsdept = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.tbfname = new DevExpress.XtraEditors.TextEdit();
            this.btncancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.tbpassword = new DevExpress.XtraEditors.TextEdit();
            this.tbemail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.tbmobno = new DevExpress.XtraEditors.TextEdit();
            this.tbusername = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.tblname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.btnsubmit = new DevExpress.XtraEditors.SimpleButton();
            this.btnnew = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmsBr = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsBrBtn0b = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBrBtn0c = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBrBtn0d = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBrSep0a = new System.Windows.Forms.ToolStripSeparator();
            this.cmsBrBtn0a = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbaddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsdept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbfname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbemail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbmobno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbusername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmsBr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tbaddress);
            this.groupControl1.Controls.Add(this.tsdept);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.tbfname);
            this.groupControl1.Controls.Add(this.btncancel);
            this.groupControl1.Controls.Add(this.labelControl13);
            this.groupControl1.Controls.Add(this.labelControl18);
            this.groupControl1.Controls.Add(this.tbpassword);
            this.groupControl1.Controls.Add(this.tbemail);
            this.groupControl1.Controls.Add(this.labelControl14);
            this.groupControl1.Controls.Add(this.tbmobno);
            this.groupControl1.Controls.Add(this.tbusername);
            this.groupControl1.Controls.Add(this.labelControl17);
            this.groupControl1.Controls.Add(this.labelControl15);
            this.groupControl1.Controls.Add(this.tblname);
            this.groupControl1.Controls.Add(this.labelControl16);
            this.groupControl1.Controls.Add(this.btnsubmit);
            this.groupControl1.Controls.Add(this.btnnew);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1235, 194);
            this.groupControl1.TabIndex = 11;
            // 
            // tbaddress
            // 
            this.tbaddress.Location = new System.Drawing.Point(527, 35);
            this.tbaddress.Name = "tbaddress";
            this.tbaddress.Size = new System.Drawing.Size(196, 53);
            this.tbaddress.TabIndex = 1006;
            // 
            // tsdept
            // 
            this.tsdept.Location = new System.Drawing.Point(119, 31);
            this.tsdept.Name = "tsdept";
            this.tsdept.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tsdept.Properties.Appearance.Options.UseFont = true;
            this.tsdept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsdept.Properties.NullText = "";
            this.tsdept.Properties.NullValuePrompt = "Select assign department";
            this.tsdept.Properties.PopupView = this.searchLookUpEdit1View;
            this.tsdept.Size = new System.Drawing.Size(165, 26);
            this.tsdept.TabIndex = 1001;
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
            this.labelControl1.Location = new System.Drawing.Point(21, 35);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 18);
            this.labelControl1.TabIndex = 194;
            this.labelControl1.Text = "Department:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(21, 66);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(76, 18);
            this.labelControl8.TabIndex = 177;
            this.labelControl8.Text = "First Name:";
            // 
            // tbfname
            // 
            this.tbfname.Location = new System.Drawing.Point(119, 64);
            this.tbfname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbfname.Name = "tbfname";
            this.tbfname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbfname.Properties.Appearance.Options.UseFont = true;
            this.tbfname.Properties.MaxLength = 100;
            this.tbfname.Size = new System.Drawing.Size(277, 24);
            this.tbfname.TabIndex = 1002;
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(741, 72);
            this.btncancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(111, 32);
            this.btncancel.TabIndex = 1102;
            this.btncancel.Text = "Cancel";
            this.btncancel.Visible = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(35, 163);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(66, 18);
            this.labelControl13.TabIndex = 179;
            this.labelControl13.Text = "Password:";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Location = new System.Drawing.Point(426, 127);
            this.labelControl18.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(95, 18);
            this.labelControl18.TabIndex = 189;
            this.labelControl18.Text = "Email Address:";
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(119, 160);
            this.tbpassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbpassword.Properties.Appearance.Options.UseFont = true;
            this.tbpassword.Properties.MaxLength = 100;
            this.tbpassword.Properties.PasswordChar = '*';
            this.tbpassword.Size = new System.Drawing.Size(277, 24);
            this.tbpassword.TabIndex = 1005;
            // 
            // tbemail
            // 
            this.tbemail.Location = new System.Drawing.Point(527, 124);
            this.tbemail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbemail.Name = "tbemail";
            this.tbemail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbemail.Properties.Appearance.Options.UseFont = true;
            this.tbemail.Properties.MaxLength = 100;
            this.tbemail.Size = new System.Drawing.Size(196, 24);
            this.tbemail.TabIndex = 1008;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(32, 131);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(72, 18);
            this.labelControl14.TabIndex = 181;
            this.labelControl14.Text = "Username:";
            // 
            // tbmobno
            // 
            this.tbmobno.Location = new System.Drawing.Point(527, 95);
            this.tbmobno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbmobno.Name = "tbmobno";
            this.tbmobno.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbmobno.Properties.Appearance.Options.UseFont = true;
            this.tbmobno.Properties.MaxLength = 100;
            this.tbmobno.Size = new System.Drawing.Size(196, 24);
            this.tbmobno.TabIndex = 1006;
            // 
            // tbusername
            // 
            this.tbusername.Location = new System.Drawing.Point(119, 128);
            this.tbusername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbusername.Name = "tbusername";
            this.tbusername.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbusername.Properties.Appearance.Options.UseFont = true;
            this.tbusername.Properties.MaxLength = 100;
            this.tbusername.Size = new System.Drawing.Size(277, 24);
            this.tbusername.TabIndex = 1004;
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Location = new System.Drawing.Point(448, 98);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(73, 18);
            this.labelControl17.TabIndex = 187;
            this.labelControl17.Text = "Mobile No.:";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(464, 39);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(57, 18);
            this.labelControl15.TabIndex = 183;
            this.labelControl15.Text = "Address:";
            // 
            // tblname
            // 
            this.tblname.Location = new System.Drawing.Point(119, 96);
            this.tblname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tblname.Name = "tblname";
            this.tblname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tblname.Properties.Appearance.Options.UseFont = true;
            this.tblname.Properties.MaxLength = 100;
            this.tblname.Size = new System.Drawing.Size(277, 24);
            this.tblname.TabIndex = 1003;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Location = new System.Drawing.Point(21, 98);
            this.labelControl16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(76, 18);
            this.labelControl16.TabIndex = 185;
            this.labelControl16.Text = "Last Name:";
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(741, 34);
            this.btnsubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(111, 32);
            this.btnsubmit.TabIndex = 1100;
            this.btnsubmit.Text = "Save New";
            this.btnsubmit.Visible = false;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(741, 34);
            this.btnnew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(111, 32);
            this.btnnew.TabIndex = 1101;
            this.btnnew.Text = "New";
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmsBr;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 194);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1235, 360);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cmsBr
            // 
            this.cmsBr.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsBrBtn0b,
            this.cmsBrBtn0c,
            this.cmsBrBtn0d,
            this.cmsBrSep0a,
            this.cmsBrBtn0a});
            this.cmsBr.Name = "contextMenuStrip1";
            this.cmsBr.Size = new System.Drawing.Size(180, 106);
            // 
            // cmsBrBtn0b
            // 
            this.cmsBrBtn0b.Name = "cmsBrBtn0b";
            this.cmsBrBtn0b.Size = new System.Drawing.Size(179, 24);
            this.cmsBrBtn0b.Text = "Edit Details";
            this.cmsBrBtn0b.Click += new System.EventHandler(this.cmsBrBtn0b_Click);
            // 
            // cmsBrBtn0c
            // 
            this.cmsBrBtn0c.Name = "cmsBrBtn0c";
            this.cmsBrBtn0c.Size = new System.Drawing.Size(179, 24);
            this.cmsBrBtn0c.Text = "Reset Password";
            this.cmsBrBtn0c.Click += new System.EventHandler(this.cmsBrBtn0c_Click);
            // 
            // cmsBrBtn0d
            // 
            this.cmsBrBtn0d.Name = "cmsBrBtn0d";
            this.cmsBrBtn0d.Size = new System.Drawing.Size(179, 24);
            this.cmsBrBtn0d.Text = "Block User";
            this.cmsBrBtn0d.Click += new System.EventHandler(this.cmsBrBtn0d_Click);
            // 
            // cmsBrSep0a
            // 
            this.cmsBrSep0a.Name = "cmsBrSep0a";
            this.cmsBrSep0a.Size = new System.Drawing.Size(176, 6);
            // 
            // cmsBrBtn0a
            // 
            this.cmsBrBtn0a.Name = "cmsBrBtn0a";
            this.cmsBrBtn0a.Size = new System.Drawing.Size(179, 24);
            this.cmsBrBtn0a.Text = "Refresh";
            this.cmsBrBtn0a.Click += new System.EventHandler(this.cmsBrBtn0a_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // UserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 554);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "UserAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserAccount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbaddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsdept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbfname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbemail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbmobno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbusername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmsBr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cmsBr;
        private System.Windows.Forms.ToolStripMenuItem cmsBrBtn0b;
        private DevExpress.XtraEditors.SearchLookUpEdit tsdept;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnsubmit;
        private DevExpress.XtraEditors.SimpleButton btnnew;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit tbfname;
        private DevExpress.XtraEditors.SimpleButton btncancel;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit tbpassword;
        private DevExpress.XtraEditors.TextEdit tbemail;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit tbmobno;
        private DevExpress.XtraEditors.TextEdit tbusername;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit tblname;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private System.Windows.Forms.ToolStripSeparator cmsBrSep0a;
        private System.Windows.Forms.ToolStripMenuItem cmsBrBtn0a;
        private DevExpress.XtraEditors.MemoEdit tbaddress;
        private System.Windows.Forms.ToolStripMenuItem cmsBrBtn0c;
        private System.Windows.Forms.ToolStripMenuItem cmsBrBtn0d;
    }
}