using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Data;
using Comm.Common.Extensions;
using System.Data.SqlClient;
using JLIDashboard.Classes;
using DevExpress.XtraEditors;
using System.Net;

namespace JLIDashboard.OPERATOR.frm
{
    public partial class Print_ID : DevExpress.XtraReports.UI.XtraReport
    {
        public Print_ID()
        {
            InitializeComponent();
        }

        public Print_ID setData(DataRow row, bool isEdit = false)
        {
            CultureInfo culture = new System.Globalization.CultureInfo("es-ES");
            this.xlblAccntName.Text = row["FLL_NM"].Str();
            this.xlblAccntID.Text = row["ACT_ID"].Str();
            this.xrLabel5.Text = Convert.ToDateTime(row["EXPRDATE"].Str()).ToString("dd-MMM-yyyy");
            //DataTable dt = Profile_Picture("select * from ESATBDB where USR_ID='" + row["USR_ID"].Str() + "'");
            //var Imge = dt.Rows[0]["PRF_PIC"].Str();
            if (!row["PRF_PIC"].Str().IsEmpty())
            {
                MemoryStream ms = new MemoryStream();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(row["PRF_PIC"].Str());
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream.CanRead)
                {
                    this.xrProfilePict.Image = Image.FromStream(receiveStream);
                }
            }
            else
            {
                Image fileImg;
                OpenFileDialog f = new OpenFileDialog();
                string sPath = AppDomain.CurrentDomain.BaseDirectory;
                string FName = string.Format("{0}Resources\\avatar1.jpg", Path.GetFullPath(Path.Combine(sPath, @"..\..\")));
                fileImg = Image.FromFile(FName);
                string fileName = FName;
                byte[] bytes = File.ReadAllBytes(fileName);
                this.xrProfilePict.Image = Image.FromStream(new MemoryStream(bytes));
            }
            if (!row["FLL_NM"].Str().IsEmpty() && !row["ACT_ID"].Str().IsEmpty())
            {
                var playerInfo = this.xlblAccntID.Text;
                QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                var MyData = QG.CreateQrCode(playerInfo.ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
                var code = new QRCoder.QRCode(MyData);
                this.xrQRCode.Image = code.GetGraphic(50);
            }
            return this;
        }
    }
}
