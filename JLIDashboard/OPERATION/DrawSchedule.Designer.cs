namespace JLIDashboard.OPERATION
{
    partial class DrawSchedule
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.draw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cutoffbegin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cutoffend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnsubmit = new DevExpress.XtraEditors.SimpleButton();
            this.tsgmtype = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgmtype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(9, 31);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(426, 168);
            this.gridControl1.TabIndex = 10037;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.draw,
            this.cutoffbegin,
            this.cutoffend});
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.InvertSelection = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.AppearanceCell.Options.UseTextOptions = true;
            this.id.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id.AppearanceHeader.Options.UseTextOptions = true;
            this.id.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id.Caption = "Sequence";
            this.id.DisplayFormat.FormatString = "n";
            this.id.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.id.FieldName = "id";
            this.id.MinWidth = 17;
            this.id.Name = "id";
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            this.id.Width = 64;
            // 
            // draw
            // 
            this.draw.AppearanceCell.Options.UseTextOptions = true;
            this.draw.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.draw.AppearanceHeader.Options.UseTextOptions = true;
            this.draw.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.draw.Caption = "Draw Schedule";
            this.draw.MinWidth = 17;
            this.draw.Name = "draw";
            this.draw.Visible = true;
            this.draw.VisibleIndex = 1;
            this.draw.Width = 64;
            // 
            // cutoffbegin
            // 
            this.cutoffbegin.AppearanceCell.Options.UseTextOptions = true;
            this.cutoffbegin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cutoffbegin.AppearanceHeader.Options.UseTextOptions = true;
            this.cutoffbegin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cutoffbegin.Caption = "Begin Cutoff";
            this.cutoffbegin.MinWidth = 17;
            this.cutoffbegin.Name = "cutoffbegin";
            this.cutoffbegin.Visible = true;
            this.cutoffbegin.VisibleIndex = 2;
            this.cutoffbegin.Width = 64;
            // 
            // cutoffend
            // 
            this.cutoffend.AppearanceCell.Options.UseTextOptions = true;
            this.cutoffend.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cutoffend.AppearanceHeader.Options.UseTextOptions = true;
            this.cutoffend.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cutoffend.Caption = "End Cutoff";
            this.cutoffend.MinWidth = 17;
            this.cutoffend.Name = "cutoffend";
            this.cutoffend.Visible = true;
            this.cutoffend.VisibleIndex = 3;
            this.cutoffend.Width = 64;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(27, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(106, 17);
            this.Label1.TabIndex = 10036;
            this.Label1.Text = "Game Type:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(131, 205);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(183, 31);
            this.btnsubmit.TabIndex = 10038;
            this.btnsubmit.Text = "Confirm Update";
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // tsgmtype
            // 
            this.tsgmtype.Location = new System.Drawing.Point(138, 3);
            this.tsgmtype.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsgmtype.Name = "tsgmtype";
            this.tsgmtype.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.8F);
            this.tsgmtype.Properties.Appearance.Options.UseFont = true;
            this.tsgmtype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsgmtype.Properties.NullText = "";
            this.tsgmtype.Properties.PopupView = this.searchLookUpEdit1View;
            this.tsgmtype.Size = new System.Drawing.Size(237, 22);
            this.tsgmtype.TabIndex = 10039;
            this.tsgmtype.EditValueChanged += new System.EventHandler(this.tsactnum_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.DetailHeight = 284;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // DrawSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 243);
            this.Controls.Add(this.tsgmtype);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnsubmit);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DrawSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DrawSchedule";
            this.Load += new System.EventHandler(this.DrawSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsgmtype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn draw;
        private DevExpress.XtraGrid.Columns.GridColumn cutoffbegin;
        private DevExpress.XtraGrid.Columns.GridColumn cutoffend;
        private System.Windows.Forms.Label Label1;
        private DevExpress.XtraEditors.SimpleButton btnsubmit;
        private DevExpress.XtraEditors.SearchLookUpEdit tsgmtype;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}