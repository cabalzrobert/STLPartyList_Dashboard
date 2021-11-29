using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JLIDashboard.Classes;

using static JLIDashboard.OPERATOR.frm._x0g1;
using static JLIDashboard.OPERATOR.frm._x0g1.Vyw;
using AbacosDashboard.Module.Enum;
using JLIDashboard.Module;
using Comm.Common.Extensions;
using JLIDashboard.Classes.Common.Extensions;
using JLIDashboard._Module;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using DevExpress.XtraEditors.Camera;
using System.Data.SqlClient;
using System.Net;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.OPERATOR.frm
{
    public partial class UpdateMasterListDetails : DevExpress.XtraEditors.XtraForm
    {
        public bool isEdit;
        public bool ok;
        public Input form = new Input();
        public UpdateMasterListDetails()
        {
            InitializeComponent();
        }
        #region List
        private static List<BloodType> FillBloodTypeList()
        {
            List<BloodType> lstBT = new List<BloodType>();

            lstBT.Add(new BloodType { BTName = "A+" });
            lstBT.Add(new BloodType { BTName = "A-" });
            lstBT.Add(new BloodType { BTName = "B+" });
            lstBT.Add(new BloodType { BTName = "B-" });
            lstBT.Add(new BloodType { BTName = "O+" });
            lstBT.Add(new BloodType { BTName = "O-" });
            lstBT.Add(new BloodType { BTName = "AB+" });
            lstBT.Add(new BloodType { BTName = "AB-" });
            return lstBT;
        }
        private static List<Group_User> GRP_LST()
        {
            List<Group_User> grp = new List<Group_User>();
            grp.Add(new Group_User { GRP_ID = "01", GRP_NM = "STL" });
            grp.Add(new Group_User { GRP_ID = "02", GRP_NM = "Lotto Outlet" });
            grp.Add(new Group_User { GRP_ID = "03", GRP_NM = "Sari-sari Store" });
            grp.Add(new Group_User { GRP_ID = "04", GRP_NM = "Direct Player" });
            return grp;
        }
        #endregion
        #region Json
        private void FillNationalityJson()
        {
            string spath = AppDomain.CurrentDomain.BaseDirectory;
            string sFilename = string.Format("{0}Resources\\json\\Country.json", Path.GetFullPath(Path.Combine(spath, @"..\..\")));
            DataTable dt = new DataTable();
            dt = ConvertJsonToDataTable(sFilename);
            tsNationality.Properties.DataSource = dt;
            tsNationality.Properties.DisplayMember = "nationality";
            tsNationality.Properties.ValueMember = "alpha_3_code";
            tsNationality.Properties.PopulateViewColumns();
            x0e(tsNationality);
        }
        private void fillRegionJson(string regionID)
        {
            string spath = AppDomain.CurrentDomain.BaseDirectory;
            string sFilename = string.Format("{0}Resources\\json\\Regions.json", Path.GetFullPath(Path.Combine(spath, @"..\..\")));
            DataTable dt = new DataTable();
            dt = ConvertJsonToDataTable(sFilename);
            if (dt.Rows.Count == 0) return;
            DataView dv = dt.DefaultView;
            dv.RowFilter = " COUNTRY_CODE='63'";
            DataTable dtNew = dv.ToTable();
            tsregion.Properties.DataSource = dtNew;
            tsregion.Properties.DisplayMember = "REGION_INSTANCE";
            tsregion.Properties.ValueMember = "REGION_CODE";
            tsregion.Properties.PopulateViewColumns();
            x0a(tsregion);
            DataRow drReg = tsregion.GetFocusedDataRow();
            if (regionID.IsEmpty()) return;
            DataRow row = tsregion.Select($"REGION_CODE='{regionID}'").FirstOrDefault();
            if (row == null) return;
            tsregion.EditValue = row["REGION_CODE"].Str();

        }
        private void fillProvinceJson(string regionID)
        {
            if (regionID.IsEmpty())
            {
                tsprovince.Properties.DataSource = null;
                return;
            }
            DataRow rgn = tsregion.GetFocusedDataRow();

            string spath = AppDomain.CurrentDomain.BaseDirectory;
            string sFilename = string.Format("{0}Resources\\json\\Provinces.json", Path.GetFullPath(Path.Combine(spath, @"..\..\")));
            DataTable dt = new DataTable();
            dt = ConvertJsonToDataTable(sFilename);
            if (dt.Rows.Count == 0) return;
            DataView dv = dt.DefaultView;
            dv.RowFilter = " COUNTRY_CODE='63' and REGION_CODE='" + regionID + "'";
            DataTable dtNew = dv.ToTable();
            DataRow drProv = tsprovince.GetFocusedDataRow();
            tsprovince.Properties.DataSource = dtNew;
            tsprovince.Properties.DisplayMember = "PROVINCE";
            tsprovince.Properties.ValueMember = "PROVINCE_CODE";
            tsprovince.Properties.PopulateViewColumns();
            x0b(tsprovince);
            if (regionID.IsEmpty()) return;
            DataRow row = tsprovince.Select($"REGION_CODE='{regionID}'").FirstOrDefault();
            if (row == null) return;
            tsprovince.EditValue = row["PROVINCE_CODE"].Str();

        }
        private void fillMunicipalityJson(string regionID, string provinceID)
        {
            if (regionID.IsEmpty() && provinceID.IsEmpty())
            {
                tsmunicipality.Properties.DataSource = null;
            }
            if (provinceID.IsEmpty()) return;
            string spath = AppDomain.CurrentDomain.BaseDirectory;
            string sFilename = string.Format("{0}Resources\\json\\Municipalities.json", Path.GetFullPath(Path.Combine(spath, @"..\..\")));
            DataTable dt = new DataTable();
            dt = ConvertJsonToDataTable(sFilename);
            if (dt.Rows.Count == 0) return;
            DataView dv = dt.DefaultView;
            dv.RowFilter = " COUNTRY_CODE='63' and REGION_CODE='" + regionID + "' and PROVINCE_CODE='" + Convert.ToInt32(provinceID) + "'";
            DataTable dtNew = dv.ToTable();
            DataRow drMun = tsmunicipality.GetFocusedDataRow();
            tsmunicipality.Properties.DataSource = dtNew;
            tsmunicipality.Properties.DisplayMember = "MUNICIPALITY";
            tsmunicipality.Properties.ValueMember = "MUNICIPALITY_CODE";
            tsmunicipality.Properties.PopulateViewColumns();
            x0c(tsmunicipality);
            if (provinceID.IsEmpty()) return;
            DataRow row = tsmunicipality.Select($"PROVINCE_CODE='{provinceID}'").FirstOrDefault();
            if (row == null) return;
            tsmunicipality.EditValue = row["MUNICIPALITY_CODE"].Str();

        }
        private void fillBarangayJson(string munID)
        {
            if (munID.IsEmpty())
            {
                tsBrgy.Properties.DataSource = null;
            }
            if (munID.IsEmpty()) return;
            string spath = AppDomain.CurrentDomain.BaseDirectory;
            string sFilename = string.Format("{0}Resources\\json\\Barangay.json", Path.GetFullPath(Path.Combine(spath, @"..\..\")));
            DataTable dt = new DataTable();
            dt = ConvertJsonToDataTable(sFilename);
            if (dt.Rows.Count == 0) return;
            DataView dv = dt.DefaultView;
            dv.RowFilter = " COUNTRY_CODE='63' and MUNICIPALITY_CODE='" + munID + "'";
            DataTable dtNew = dv.ToTable();
            DataRow brgy = tsBrgy.GetFocusedDataRow();
            tsBrgy.Properties.DataSource = dtNew;
            tsBrgy.Properties.DisplayMember = "BRGY";
            tsBrgy.Properties.ValueMember = "BRGY_CODE";
            tsBrgy.Properties.PopulateViewColumns();
            x0d(tsBrgy);
        }
        private void FillBloodType()
        {
            tsBloodType.Properties.DataSource = FillBloodTypeList();
            tsBloodType.Properties.DisplayMember = "BTName";
            tsBloodType.Properties.ValueMember = "BTName";
            tsBloodType.Properties.PopulateViewColumns();
        }
        private void FillGroupUser()
        {
            tsGRPUSR.Properties.DataSource = GRP_LST();
            tsGRPUSR.Properties.DisplayMember = "GRP_NM";
            tsGRPUSR.Properties.ValueMember = "GRP_ID";
        }
        #endregion
        #region DataTable
        public static DataTable ConvertJsonToDataTable(string xmlFilePath)
        {
            DataTable dt = new DataTable();
            var json = File.ReadAllText(xmlFilePath);
            dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            return dt;
        }
        public static DataTable Profile_Picture(string query)
        {
            SqlConnection con = Database.getConnection();
            DataTable table = new DataTable();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(table);
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return table;
        }
        #endregion
        #region SearchLookUpEdit_EditValueChanged
        private void tsregion_EditValueChanged(object sender, EventArgs e)
        {
            string val1 = tsregion.EditValue.ToString();
            this.fillProvinceJson(val1.Str());
            this.tsprovince.Text = string.Empty;
        }
        private void tsprovince_EditValueChanged(object sender, EventArgs e)
        {
            string valRegion = tsregion.EditValue.ToString();
            string valProvince = tsprovince.EditValue.ToString();
            this.fillMunicipalityJson(valRegion, valProvince);
            this.tsmunicipality.Text = string.Empty;
        }
        private void tsmunicipality_EditValueChanged(object sender, EventArgs e)
        {
            string valMunicipality = tsmunicipality.EditValue.Str();
            this.fillBarangayJson(tsmunicipality.EditValue.Str());
            this.tsBrgy.Text = string.Empty;
        }
        #endregion
        #region SimpleButton
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) return;
            StaticSettings.showLoading();
            if (!form.ProfilePicture.Str().IsEmpty())
            {
                var resPic = ImgService.SendAsync(form.ProfilePicture).Result;
                var resSig = ImgService.SendAsync(form.SIGNATUREID).Result;
                var data = JsonConvert.DeserializeObject<dynamic>(resPic);
                var dataSig = JsonConvert.DeserializeObject<dynamic>(resSig);
                if (data.status == "success" && dataSig.status == "success")
                {
                    form.ImageUrl = data.url;//
                    form.SignatureURL = dataSig.url;
                    Update_Profiling();
                }
                else if (data.status == "error")
                {
                    XtraMessageBox.Show(data.message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                Update_Profiling();
            }
            StaticSettings.hideLoading();
        }
        private void cmsAttachSignature_Click(object sender, EventArgs e)
        {
            Image FileImg;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image files (*.jpg, *.png, *.gif  | *.jpg; *.png, *.gif )";
            if (f.ShowDialog() == DialogResult.OK)
            {
                FileImg = Image.FromFile(f.FileName);
                picSignature.Image = FileImg;
                string fileName = f.FileName;
                //lblProfilePath.Text = fileName;
                byte[] bytes = File.ReadAllBytes(fileName);
                form.SIGNATUREID = bytes;
            }
        }
        private void cmsUploadbtn_Click(object sender, EventArgs e)
        {
            Image FileImg;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image files (*.jpg, *.png | *.jpg; * *.png)";
            if (f.ShowDialog() == DialogResult.OK)
            {
                FileImg = Image.FromFile(f.FileName);
                profilePicture.Image = FileImg;
                string fileName = f.FileName;
                lblProfilePath.Text = fileName;
                byte[] bytes = File.ReadAllBytes(fileName);
                form.ProfilePicture = bytes;
            }
        }
        private void cmsTakePictureBtn_Click(object sender, EventArgs e)
        {
            TakePictureDialog d = new TakePictureDialog();
            
            d.Caption = "Take Profile Picture";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image i = d.Image;
                using (var stream = new MemoryStream())
                {
                    i.Save(stream, ImageFormat.Jpeg);
                    profilePicture.Image = i;
                    byte[] bytes = stream.ToArray();
                    form.ProfilePicture = bytes;
                }
            }
        }
        #endregion
        #region Forms
        public UpdateMasterListDetails setData(DataRow row, bool isEdit = false)
        {
            CultureInfo culture = new CultureInfo("es-ES");
            string region = row["LOC_REG_NM"].Str();
            string province = row["LOC_PROV_NM"].Str();
            string municipality = row["LOC_MUN_NM"].Str();
            this.isEdit = isEdit;
            this.FillNationalityJson();
            this.FillBloodType();
            this.FillGroupUser();
            form.User_ID = row["USR_ID"].Str();
            form.ExpiryDate = row["EXPRDATE"].Str();
            form.RegionID = row["LOC_REG"].Str();
            form.ProvinceID = row["LOC_PROV"].Str();
            form.MunicipalityID = row["LOC_MUN"].Str();
            form.BrgyID = row["LOC_BRGY"].Str();
            if (!form.RegionID.IsEmpty())
            {
                this.fillProvinceJson(form.RegionID);
            }
            if (!form.ProvinceID.IsEmpty())
            {
                this.fillMunicipalityJson(form.RegionID, form.ProvinceID);
            }
            if (!form.MunicipalityID.IsEmpty())
            {
                this.fillBarangayJson(form.MunicipalityID);
            }
            form.GrpID = row["GRP_CD"].Str().Trim();
            form.GrpNM = row["Group_NM"].Str().Trim();
            form.BRCD = row["BR_CD"].Str().Trim();
            form.ACCTNO = row["ACT_NO"].Str().Trim();
            form.NXTKN_NM = row["NXTKN_NM"].Str().Trim();
            form.NXTKN_NO = row["NXTKN_NO"].Str().Trim();
            this.tbnextkin.Text = form.NXTKN_NM;
            this.tbnextkinno.Text = form.NXTKN_NO;
            this.fillRegionJson(form.Region);
            this.tsregion.EditValue = row["LOC_REG"].Str();
            this.tsprovince.EditValue = row["LOC_PROV"].Str();
            this.tsmunicipality.EditValue = row["LOC_MUN"].Str();
            this.tsBrgy.EditValue = row["LOC_BRGY"].Str();
            this.tsNationality.EditValue = row["CTZNSHP"].Str().Trim();
            //this.tbExpiryDate.Text = (row["EXPRDATE"].Str() == "") ? "" : Convert.ToDateTime(row["EXPRDATE"].Str()).ToString("dd-MMM-yyyy");
            this.tbfirstname.Text = row["FRST_NM"].Str();
            this.tblastname.Text = row["LST_NM"].Str();
            this.tbmobilenumber.Text = row["MOB_NO"].Str();
            this.tbemail.Text = row["EML_ADD"].Str();
            this.tbhomeaddress.Text = row["HM_ADDR"].Str();
            this.tbpresentaddress.Text = row["PRSNT_ADDR"].Str();
            this.tboccptn.Text = row["OCCPTN"].Str().Trim();
            this.tbsklls.Text = row["SKLLS"].Str().Trim();
            this.tsGRPUSR.EditValue = row["GRP_CD"].Str().Trim();
            var strvalfrm = row["VALFRM_DT"].Str().Trim();
            if (row["VALFRM_DT"].Str() != string.Empty)
            {
                this.tbValFrom.Text = Convert.ToDateTime(row["VALFRM_DT"].Str().Trim()).ToString("dd-MMM-yyyy");
            }
            if (row["VALTO_DT"].Str() != string.Empty)
            {
                this.tbValTo.Text = Convert.ToDateTime(row["VALTO_DT"].Str().Trim()).ToString("dd-MMM-yyyy");
            }
            //this.tbValFrom.Text=(row["VALFRM"].Str().Trim().IsEmpty()) ? string.Empty : Convert.ToDateTime(row["VALFRM"].Str().Trim()).ToString("dd-MMM-yyyy");
            //this.tbValTo.Text = (row["VALTO"].Str().Trim().IsEmpty()) ? string.Empty : Convert.ToDateTime(row["VALTO"].Str().Trim()).ToString("dd-MMM-yyyy");
            if (row["BRT_DT"].Str() != string.Empty)
            {
                string strDate = row["BRT_DT_NM"].Str();
                string dtBDate = Convert.ToDateTime(strDate).ToString("dd-MMM-yyyy"); this.tbBDate.Text = dtBDate;
            }
            this.tsBloodType.EditValue = row["BLD_TYP"].Str();
            string strGender = row["GNDR"].Str().Trim();
            this.rdGender.SelectedIndex = (row["GNDR"].Str().Trim() == string.Empty || row["GNDR"].Str().Trim() == null) ? -1 : Convert.ToInt32(row["GNDR"].Str().Trim());
            this.rdmstatus.SelectedIndex = (row["MRTL_STAT"].Str().Trim() == string.Empty || row["MRTL_STAT"].Str().Trim() == null) ? -1 : Convert.ToInt32(row["MRTL_STAT"].Str().Trim());
            form.ImageUrl = row["PRF_PIC"].Str().Trim();
            form.SignatureURL = row["SIGNATUREID"].Str().Trim();
            if (!form.ImageUrl.IsEmpty())
            {
                MemoryStream ms = new MemoryStream();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(form.ImageUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream.CanRead)
                {
                    Image pfImage;
                    byte[] bytes = null;
                    this.profilePicture.Image = Image.FromStream(receiveStream);
                    pfImage = this.profilePicture.Image;
                    using(var stream=new MemoryStream())
                    {
                        pfImage.Save(stream, ImageFormat.Jpeg);
                        bytes = stream.ToArray();
                        form.ProfilePicture = bytes;
                    }
                }
            }
            if (!form.SignatureURL.IsEmpty())
            {
                MemoryStream ms = new MemoryStream();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(form.SignatureURL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream.CanRead)
                {
                    Image pfImage;
                    byte[] bytes = null;
                    this.picSignature.Image = Image.FromStream(receiveStream);
                    pfImage = this.picSignature.Image;
                    using (var stream = new MemoryStream())
                    {
                        pfImage.Save(stream, ImageFormat.Jpeg);
                        bytes = stream.ToArray();
                        form.SIGNATUREID = bytes;
                    }
                }
            }
            this.tbfirstname.ReadOnly = true;
            this.tblastname.ReadOnly = true;
            this.tbmobilenumber.ReadOnly = true;
            this.tbValFrom.AllowDrop = false;
            this.tbValFrom.ReadOnly = true;
            this.tbValTo.AllowDrop = false;
            this.tbValTo.ReadOnly = true;
            //this.tbExpiryDate.ReadOnly = true;
            return this;
        }
        
        public UpdateMasterListDetails retData(DataRow row)
        {
            row["HM_ADDR"] = form.HomeAddress;
            row["PRSNT_ADDR"] = form.PresentAddress;
            row["EML_ADD"] = form.Email;
            row["LOC_REG_NM"] = form.Region;
            row["LOC_REG"] = form.RegionID;
            row["LOC_PROV_NM"] = form.Province;
            row["LOC_PROV"] = form.ProvinceID;
            row["LOC_MUN_NM"] = form.Municipality;
            row["LOC_MUN"] = form.MunicipalityID;
            row["LOC_BRGY_NM"] = form.Brgy;
            row["LOC_BRGY"] = form.BrgyID;
            row["GNDR"] = form.Gender;
            row["MRTL_STAT"] = form.MaritalStatus;
            row["GNDR_NM"] = form.GenderNM;
            row["MRTL_STAT_NM"] = form.MaritalStatusNM;
            row["CTZNSHP"] = form.Citizenship;
            row["CTZNSHP_NM"] = form.Nationality;
            row["BLD_TYP"] = form.BLDTyp;
            row["OCCPTN"] = form.OCCPTN;
            row["SKLLS"] = form.Sklls;
            row["BRT_DT"] = form.BDate;
            row["Group_NM"] = form.GrpNM;
            row["GRP_CD"] = form.GrpID;
            row["NXTKN_NM"] = form.NXTKN_NM;
            row["NXTKN_NO"] = form.NXTKN_NO;
            row["PRF_PIC"] = form.ImageUrl;
            row["SIGNATUREID"] = form.SignatureURL;
            return this;
        }
        #endregion
        #region Function
        private void Update_Profiling()
        {
            var res = (Db.executeUpdate(form)).Result;
            if (res.result == Results.Success)
            {
                this.ok = true;
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else if (res.result != Results.Null)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
            }
            else
            {
                XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private bool ValidEntries()
        {
            string region = tsregion.Text.Str();
            byte[] pfPic = null;
            if (region.IsEmpty())
            {
                StaticSettings.XtraMessage("Region is required", MessageBoxIcon.Exclamation);
                return false;
            }
            string province = tsprovince.Text.Str();
            if (province.IsEmpty())
            {
                StaticSettings.XtraMessage("Province is required", MessageBoxIcon.Exclamation);
                return false;
            }
            string municipality = tsmunicipality.Text.Str();
            if (municipality.IsEmpty())
            {
                StaticSettings.XtraMessage("Municipality is required", MessageBoxIcon.Exclamation);
                return false;
            }
            string barangay = tsBrgy.Text.Str();
            if (barangay.IsEmpty())
            {
                StaticSettings.XtraMessage("Barangay is required", MessageBoxIcon.Exclamation);
                return false;
            }
            string usrID = form.User_ID.Str();
            form.FirstName = tbfirstname.Text.Trim().ToString();
            form.LastName = tblastname.Text.Trim().ToString();
            form.HomeAddress = tbhomeaddress.Text.Trim().ToString();
            form.PresentAddress = tbpresentaddress.Text.Trim().ToString();
            form.RegionID = tsregion.EditValue.ToString();
            form.Region = tsregion.Text.Trim().Str();
            form.ProvinceID = tsprovince.EditValue.ToString();
            form.Province = tsprovince.Text.Trim().Str();
            form.MunicipalityID = tsmunicipality.EditValue.ToString();
            form.Municipality = tsmunicipality.Text.Trim().Str();
            form.BrgyID = tsBrgy.EditValue.Str().Trim();
            form.Brgy = tsBrgy.Text.Trim().Str();
            form.GenderNM = rdGender.Properties.Items[rdGender.SelectedIndex].Description.Str();
            form.Gender = rdGender.EditValue.Str();
            form.MaritalStatusNM = rdmstatus.Properties.Items[rdmstatus.SelectedIndex].Description.Str();
            form.MaritalStatus = rdmstatus.EditValue.Str();
            form.Citizenship = tsNationality.EditValue.Str().Trim();
            form.Nationality = tsNationality.Text.Trim().Str();
            form.BDate = (tbBDate.Text.Trim().Str() == "") ? "" : Convert.ToDateTime(tbBDate.Text.Trim().Str()).ToString("MM/dd/yyyy");
            form.BLDTyp = tsBloodType.EditValue.Str().Trim();
            form.GrpID = tsGRPUSR.EditValue.Str().Trim();
            form.GrpNM = tsGRPUSR.Text.Trim().Str();
            form.NXTKN_NM = tbnextkin.Text.Trim().Str();
            form.NXTKN_NO = tbnextkinno.Text.Trim().Str();
            string gender = rdGender.Text.Trim().ToString();
            string mstatus = rdmstatus.Text.Trim().ToString();
            return true;
        }

        #endregion
    }
    #region ClassObject
    public partial class _x0g1
    {
        public class Vyw
        {
            public static SearchLookUpEdit x0a(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("REGION_INSTANCE", "Region", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0b(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("PROVINCE", "Province", 1, gridview);
                gridview.Columns[0].Visible = false;
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0c(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("MUNICIPALITY", "Municipality", 1, gridview);
                gridview.Columns[0].Visible = false;
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0d(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("BRGY", "Barangay", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0e(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("nationality", "Nationality", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }
            public static SearchLookUpEdit x0f(SearchLookUpEdit control)
            {
                control.Properties.PopulateViewColumns();
                var gridview = control.Properties.View;
                DevXSettings.XgridColsVisible(gridview, false);
                DevXSettings.XtraFormatColumn("GRP_NM", "Group", 1, gridview);
                gridview.BestFitColumns();
                return control;
            }

        }
        public class Db
        {
            public static async Task<(Results result, String message)> executeUpdate(Input input)
            {
                var result = API.DSpQueryAPI("/api/v1/MasterList/UpdateMasterList", Login.authentication, new Dictionary<string, object>()
                    {
                        {"userID",input.User_ID },
                        {"nxtkN_NM",input.NXTKN_NM },
                        {"nxtkN_NO",input.NXTKN_NO },
                        {"homeAddress",input.HomeAddress },
                        {"presentAddress",input.PresentAddress },
                        {"regionID",input.RegionID },
                        {"provinceID",input.ProvinceID },
                        {"brgyID",input.BrgyID},
                        {"municipalityID",input.MunicipalityID },
                        {"gender",input.Gender },
                        {"maritalStatus",input.MaritalStatus },
                        {"citizenship",input.Citizenship },
                        {"profilePicture",input.ImageUrl },
                        {"signatureURL",input.SignatureURL },
                        {"bDate",input.BDate },
                        {"bldTyp",input.BLDTyp },
                        {"occptn",input.OCCPTN },
                        {"sklls",input.Sklls },
                        {"grpID",input.GrpID },
                        {"brcd",input.BRCD },
                        {"acctno",input.ACCTNO },
                        {"updateDescription",Login.userid + " update["+ input.User_ID+"] profiling" }
                    });
                if (result != null)
                {
                    var row = ((IDictionary<string, object>)result);
                    string ResultCode = row["result"].Str();
                    if (ResultCode == "2")
                    {
                        return (Results.Success, row["message"].Str());
                    }
                    return (Results.Failed, row["message"].Str());
                }
                return (Results.Null, null);
            }
        }
        public class Input
        {
            public string User_ID;
            public string ExpiryDate;
            public string FirstName;
            public string LastName;
            //public string mlAlias;
            public string MobileNumber;
            public string Email;
            public string HomeAddress;
            public string PresentAddress;
            public string Region;
            public string RegionID;
            public string Province;
            public string ProvinceID;
            public string Municipality;
            public string MunicipalityID;
            public string Brgy;
            public string BrgyID;
            public string Gender;
            public string GenderNM;
            public string MaritalStatus;
            public string MaritalStatusNM;
            public string Citizenship;
            public string Nationality;
            public byte[] ProfilePicture;
            public string ImageUrl;
            public string BDate;
            public string VALFRM;
            public string VALTO;
            public string BLDTyp;
            public string Sklls;
            public string OCCPTN;
            public string BRCD;
            public string GrpID;
            public string GrpNM;
            public string ACCTNO;
            public string NXTKN_NM;
            public string NXTKN_NO;
            public byte[] SIGNATUREID;
            public string SignatureURL;
        }
        public class BloodType
        {
            public string BTName { get; set; }
        }
        public class Group_User
        {
            public string GRP_ID { get; set; }
            public string GRP_NM { get; set; }
        }

    }
    #endregion
}