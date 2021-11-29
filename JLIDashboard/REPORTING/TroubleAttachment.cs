using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using JLIDashboard._Module;
using static JLIDashboard.REPORTING._x0g3;
using static JLIDashboard.REPORTING._x0g3.Vyw;
using System.Globalization;
using Comm.Common.Extensions;
using JLIDashboard.Classes;
using JLIDashboard.Module;
using System.IO;
using System.Net;
using System.Drawing.Imaging;
using DevExpress.XtraEditors.Controls;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.REPORTING
{
    public partial class TroubleAttachment : DevExpress.XtraEditors.XtraForm
    {
        public bool isEdit;
        public bool ok;
        public Input form = new Input();

        public TroubleAttachment()
        {
            InitializeComponent();
        }
        public void Load_Attachment()
        {
            API.displayAPI("/api/v1/TroubleReport/LoadTroubleAttachment", gridControl1, gridView1, Login.authentication, new Dictionary<string, object>()
            {
                {"transactionNo", form.TRN_NO },
                {"userID", form.USR_ID }
            });

            gridView1.Columns.AddVisible("ViewAttachment");
            x0a(gridView1);
        }
        public TroubleAttachment setData(DataRow row, bool isEdit = false)
        {
            CultureInfo culture = new CultureInfo("es-ES");
            form.COMP_ID = row["COMP_ID"].Str();
            form.BR_CD = row["BR_CD"].Str();
            form.USR_ID = row["USR_ID"].Str();
            form.FLL_NM = row["FLL_NM"].Str();
            form.UPD_TRN_TS = row["UPD_TRN_TS"].Str();
            form.TRN_NO = row["TRN_NO"].Str();
            form.TCKT_NO = row["TCKT_NO"].Str();
            //form.SEQ_NO = row["SEQ_NO"].Str();
            form.SBJCT_CD = row["SBJCT_CD"].Str();
            form.BODY = row["BODY"].Str();
            form.COR_ACTION = row["COR_ACTION"].Str();
            form.STAT = row["STAT"].Str();
            form.STAT_NM = row["STAT_NM"].Str();
            form.FXD_TRN_TS = row["FXD_TRN_TS"].Str();
            //form.ATTCHMNT = row["ATTCHMNT"].Str();
            lblsubject.Text = form.SBJCT_CD;
            lblticketno.Text = form.TCKT_NO;
            lbldate.Text = Convert.ToDateTime(form.UPD_TRN_TS).ToString("dd-MMM-yyyy");
            lblfdate.Text = (form.FXD_TRN_TS == "") ? "Not yet solved" : Convert.ToDateTime(form.FXD_TRN_TS).ToString("dd-MMM-yyyy");
            StaticSettings.showLoading();
            Timeout.Set(() => this.Invoke(new Action(() => this.Load_Attachment())), 250);
            StaticSettings.hideLoading();
            return this;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            string fpath = row["ATTCHMNT"].Str();
            if (!fpath.IsEmpty())
            {
                
                MemoryStream ms = new MemoryStream();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fpath);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream.CanRead)
                {
                    Image pfImage;
                    byte[] bytes = null;
                    this.pctattachment.Image = Image.FromStream(receiveStream);
                    pfImage = this.pctattachment.Image;
                    using (var stream = new MemoryStream())
                    {
                        pfImage.Save(stream, ImageFormat.Jpeg);
                        bytes = stream.ToArray();
                        //form.ATTCHMNT = bytes;
                    }
                }
            }
            pctattachment.Properties.ZoomPercent = 100;
            string zP = pctattachment.Properties.ZoomPercent.Str();
            pctattachment.Properties.SizeMode = PictureSizeMode.Squeeze;
            pctattachment.Properties.ShowScrollBars = true;
        }
        private void Zoom_Attachment(string value)
        {
            lblZoomFactor.Text = " x " + value;
            pctattachment.Properties.SizeMode = PictureSizeMode.Clip;
            //pctattachment.Properties.ZoomPercent = Convert.ToInt32(value) * 100;
            pctattachment.Properties.ZoomPercent = Convert.ToInt32(value);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Zoom_Attachment(trackBar1.Value.Str());
            //lblZoomFactor.Text =" X " + trackBar1.Value.Str();
            //pctattachment.Properties.SizeMode = PictureSizeMode.Clip;
            //pctattachment.Properties.ZoomPercent = trackBar1.Value*100;
        }

        private void pctattachment_Properties_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                this.pctattachment.Properties.ZoomPercent += 5;
            }
            else if (e.Delta < 0)
            {
                this.pctattachment.Properties.ZoomPercent -= 5;
            }
        }

        private void pctattachment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            trackBar1.Visible = true;
            lblZoomFactor.Visible = true;
        }

        private void pctattachment_MouseClick(object sender, MouseEventArgs e)
        {
            //trackBar1.Visible = false;
            //lblZoomFactor.Visible = false;
            Zoom_Attachment(pctattachment.Properties.ZoomPercent.Str());

        }
    }
    public partial class _x0g3
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView)
            {
                if (gridView.RowCount != 0)
                {
                    gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    DevXSettings.XgridColsVisible(gridView, false);
                    DevXSettings.XtraFormatColumn("SEQ_NO", "Attachment", 1, gridView, 100);
                }
                return gridView;
            }
        }
        public class Input
        {
            public string COMP_ID;
            public string BR_CD;
            public string USR_ID;
            public string FLL_NM;
            public string UPD_TRN_TS;
            public string TRN_NO;
            public string TCKT_NO;
            //public string SEQ_NO;
            public string SBJCT_CD;
            public string BODY;
            public string COR_ACTION;
            public string STAT;
            public string STAT_NM;
            public string ATTCHMNT;
            public string FXD_TRN_TS;
        }
    }
}