namespace JLIDashboard.OPERATOR.frm
{
    partial class Print_ID
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrProfilePict = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xlblAccntName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xlblAccntID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.dataSet11 = new JLIDashboard.DataSet1();
            this.xrQRCode = new DevExpress.XtraReports.UI.XRPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrQRCode,
            this.xrProfilePict,
            this.xlblAccntName,
            this.xrLabel5,
            this.xlblAccntID,
            this.xrPictureBox1});
            this.Detail.HeightF = 515.75F;
            this.Detail.MultiColumn.ColumnCount = 3;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            // 
            // xrProfilePict
            // 
            this.xrProfilePict.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "ImageSource", "[PRF_PIC]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "ImageUrl", "[PRF_PIC]")});
            this.xrProfilePict.ImageUrl = "[PRF_PIC]";
            this.xrProfilePict.LocationFloat = new DevExpress.Utils.PointFloat(9.461815F, 83.66668F);
            this.xrProfilePict.Name = "xrProfilePict";
            this.xrProfilePict.SizeF = new System.Drawing.SizeF(96.875F, 99.12498F);
            this.xrProfilePict.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xlblAccntName
            // 
            this.xlblAccntName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FLL_NM]")});
            this.xlblAccntName.ForeColor = System.Drawing.Color.White;
            this.xlblAccntName.LocationFloat = new DevExpress.Utils.PointFloat(10.15625F, 226.0834F);
            this.xlblAccntName.Multiline = true;
            this.xlblAccntName.Name = "xlblAccntName";
            this.xlblAccntName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xlblAccntName.SizeF = new System.Drawing.SizeF(198.4375F, 17.27083F);
            this.xlblAccntName.StylePriority.UseForeColor = false;
            this.xlblAccntName.StylePriority.UseTextAlignment = false;
            this.xlblAccntName.Text = "xlblAccntName";
            this.xlblAccntName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EXPRDATE]")});
            this.xrLabel5.ForeColor = System.Drawing.Color.White;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(10.15625F, 264.8958F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(198.6979F, 15.70831F);
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xlblAccntID
            // 
            this.xlblAccntID.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ACT_ID]")});
            this.xlblAccntID.ForeColor = System.Drawing.Color.White;
            this.xlblAccntID.LocationFloat = new DevExpress.Utils.PointFloat(10.15625F, 188.25F);
            this.xlblAccntID.Multiline = true;
            this.xlblAccntID.Name = "xlblAccntID";
            this.xlblAccntID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xlblAccntID.SizeF = new System.Drawing.SizeF(198.9583F, 16.75F);
            this.xlblAccntID.StylePriority.UseForeColor = false;
            this.xlblAccntID.StylePriority.UseTextAlignment = false;
            this.xlblAccntID.Text = "xlblAccntID";
            this.xlblAccntID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(global::JLIDashboard.Properties.Resources.ID_Layout, true);
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(2.666672F, 8.958371F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(212F, 337F);
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // xrQRCode
            // 
            this.xrQRCode.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "ImageSource", "[QRCODE]")});
            this.xrQRCode.LocationFloat = new DevExpress.Utils.PointFloat(113.1077F, 83.47918F);
            this.xrQRCode.Name = "xrQRCode";
            this.xrQRCode.SizeF = new System.Drawing.SizeF(95.88541F, 97.99999F);
            this.xrQRCode.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // Print_ID
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dataSet11});
            this.DataMember = "dtPrintID";
            this.DataSource = this.dataSet11;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(80, 80, 100, 100);
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DataSet1 dataSet11;
        private DevExpress.XtraReports.UI.XRLabel xlblAccntName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xlblAccntID;
        private DevExpress.XtraReports.UI.XRPictureBox xrProfilePict;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRPictureBox xrQRCode;
    }
}
