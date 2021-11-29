using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Comm.Common.Advance;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Diagnostics;

namespace JLIDashboard._Module.Classes.Common
{
    public class API
    {
        static string apiURL;
        public static RegistryKey RegKeyAPI
        {
            get
            {
                var dirPath = $"{Application.StartupPath}\\{'.'}{Application.ProductName}.exe";
                string md5 = Cipher.MD5Hash(dirPath).ToUpper();
                return Registry.CurrentUser.CreateSubKey(@"ESAT\" + md5);
            }
        }
        public static string APICon
        {
            get
            {
                apiURL = Cipher.Decrypt(RegKeyAPI.GetValue("apicon").ToString(), "Esatpt123456789!");
                return apiURL;
            }
        }
        public static IList<T> DAPIQuery<T>(string apiQuery, object parameters = null) where T : class
        {
            try
            {
                string json = string.Empty;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APICon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string inputbody = JsonConvert.SerializeObject(parameters);
                var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
                DataTable dt = new DataTable();
                HttpResponseMessage res = client.PostAsync(apiQuery, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    json = res.Content.ReadAsStringAsync().Result;
                    dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                }
                var jsondt = JsonConvert.SerializeObject(dt);
                return JsonConvert.DeserializeObject<IList<T>>(jsondt);

            }
            catch { return null; }

        }
        public static IList<T> DataList<T>(DataTable dt) where T : class
        {
            var jsondt = JsonConvert.SerializeObject(dt);
            return JsonConvert.DeserializeObject<IList<T>>(jsondt);
        }
        public static IList<T> DAPIQueryResult<T>(string apiQuery, string apiToken, object parameters = null) where T : class
        {
            try
            {
                string json = string.Empty;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APICon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string inputbody = JsonConvert.SerializeObject(parameters);
                var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
                DataTable dt = new DataTable();
                HttpResponseMessage res = client.PostAsync(apiQuery, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    json = res.Content.ReadAsStringAsync().Result;
                    json = json.Replace("{", "[{").Replace("}", "}]");
                    dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                }


                var jsondt = JsonConvert.SerializeObject(dt);
                return JsonConvert.DeserializeObject<IList<T>>(jsondt);
            }
            catch { return null; }

        }
        public static IList<T> DAPIQueryResultValue<T>(string apiQuery, object parameters = null) where T : class
        {
            try
            {
                string json = string.Empty;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(APICon);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string inputbody = JsonConvert.SerializeObject(parameters);
                var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
                DataTable dt = new DataTable();
                HttpResponseMessage res = client.PostAsync(apiQuery, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    json = res.Content.ReadAsStringAsync().Result;
                    json = json.Replace("{", "[{").Replace("}", "}]");
                }


                var jsondt = JsonConvert.SerializeObject(dt);
                return JsonConvert.DeserializeObject<IList<T>>(json);
            }
            catch { return null; }

        }
        public static IDictionary<string, object> DSpQueryAPI(string queryAPI, string apiToken, Dictionary<string, object> parameters = null)
        {
            string json = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string inputbody = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
            DataSet ds = new DataSet();
            HttpResponseMessage res = client.PostAsync(queryAPI, content).Result;
            if (res.IsSuccessStatusCode)
            {
                string uri = res.RequestMessage.RequestUri.AbsoluteUri;
                json = res.Content.ReadAsStringAsync().Result;
            }
            var d = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
            return d;
        }
        public static IDictionary<string, object> DAPIQueryMultiple(string queryAPI, string apiToken, Dictionary<string, object> parameters = null)
        {

            string json = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string inputbody = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
            DataSet ds = new DataSet();
            HttpResponseMessage res = client.PostAsync(queryAPI, content).Result;
            if (res.IsSuccessStatusCode)
            {
                string uri = res.RequestMessage.RequestUri.AbsoluteUri;
                json = res.Content.ReadAsStringAsync().Result;
            }
            var d = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
            return d;
        }
        public static DataTable stringDataTable(string parameters = null)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(parameters, typeof(DataTable));
            return dt;
        }
        public static IList<T> DAPIQueryMultiple<T>(string queryAPI, string apiToken, Dictionary<string, object> parameters = null) where T : class
        {

            string json = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string inputbody = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
            DataSet ds = new DataSet();
            HttpResponseMessage res = client.PostAsync(queryAPI, content).Result;
            if (res.IsSuccessStatusCode)
            {
                string uri = res.RequestMessage.RequestUri.AbsoluteUri;
                json = res.Content.ReadAsStringAsync().Result;
            }
            var d = JsonConvert.DeserializeObject<IList<T>>(json);
            return d;
        }
        public static DataTable APITable(string apiquery, string apiToken=null, object parameters = null)
        {
            string json = string.Empty;
            Stopwatch stopwatch = Stopwatch.StartNew();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(3600);
            string inputbody = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
            DataTable dt = new DataTable();
            try
            {
                HttpResponseMessage res = client.PostAsync(apiquery, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    string uri = res.RequestMessage.RequestUri.AbsoluteUri;
                    json = res.Content.ReadAsStringAsync().Result;
                    dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                }
                return dt;
            }
            catch (Exception)
            {
                return dt;
            }
        }
        public static void LoginAPI(string apiquery)
        {
            string json = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = client.PostAsync(apiquery, null).Result;
            string uri = res.RequestMessage.RequestUri.AbsoluteUri;
            json = res.Content.ReadAsStringAsync().Result;

        }
        public static bool checkifExistLoginAPIAsync(string apiquery, string param)
        {
            bool result = false;
            DataTable dt = APITable(apiquery);
            DataView dv = dt.DefaultView;
            try
            {
                DataTable dtExist = dt.Select(param).CopyToDataTable();
                if (dtExist != null)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception) { return result; }

        }
        public static bool checkifExistAPIAsync(string apiquery, string apiToken, string param)
        {
            bool result = false;
            DataTable dt = APITable(apiquery, apiToken);
            DataView dv = dt.DefaultView;
            try
            {
                DataTable dtExist = dt.Select(param).CopyToDataTable();
                if (dtExist != null)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception) { return result; }

        }
        public static String getSingleQueryAPI(string queryAPI, string apiToken, string returnval, object parameters = null)
        {
            string json = string.Empty;
            string str = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string inputbody = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
            DataTable dt = new DataTable();
            HttpResponseMessage res = client.PostAsync(queryAPI, content).Result;
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    json = res.Content.ReadAsStringAsync().Result;
                    dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                }
                if (dt.Rows.Count > 0)
                {
                    str = dt.Rows[0][returnval].ToString();
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message.ToString());
            }

            return str;

        }
        public static String getSingleQueryAPI(string apiquery, string apiToken, object param)
        {
            DataTable dt = APITable(apiquery, apiToken, param);
            string ret = string.Empty;
            if (dt != null)
            {
                ret = dt.Rows[0][0].ToString();
            }
            return ret;
        }
        public static Dictionary<string, object> GetDictionaryRow(string queryAPI, string apiToken, object parameters = null)
        {
            string json = string.Empty;
            string str = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string inputbody = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
            DataTable dt = new DataTable();
            HttpResponseMessage res = client.PostAsync(queryAPI, content).Result;
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    json = res.Content.ReadAsStringAsync().Result;
                    json = json.Replace("[{", "{").Replace("}]", "}");
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message.ToString());
            }
            return (Dictionary<string, object>)JsonConvert.DeserializeObject(json, typeof(Dictionary<string, object>));
        }
        public static Dictionary<string, object> GetDictionaryStringParameter(string queryAPI, string apiToken)
        {
            string json = string.Empty;
            string str = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DataTable dt = new DataTable();
            HttpResponseMessage res = client.PostAsync(queryAPI, null).Result;
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    json = res.Content.ReadAsStringAsync().Result;
                    json = json.Replace("[{", "{").Replace("}]", "}");
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message.ToString());
            }
            return (Dictionary<string, object>)JsonConvert.DeserializeObject(json, typeof(Dictionary<string, object>));
        }
        public static void displayAPI(string queryAPI, GridControl cont, GridView view, string apiToken, object parameters = null)
        {
            DataTable dt = APITable(queryAPI, apiToken, parameters);
            try
            {
                view.Columns.Clear();
                cont.DataSource = null;
                cont.DataSource = dt;
                view.BestFitColumns();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        public static void displayAPIParam(string queryAPI, GridControl cont, GridView view, string apiToken)
        {
            DataTable dt = APITableParam(queryAPI, apiToken);
            try
            {
                view.Columns.Clear();
                cont.DataSource = null;
                cont.DataSource = dt;
                view.BestFitColumns();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        public static void displaySearchLookupEditAPI(string apiquery, string apiToken, SearchLookUpEdit searchEdit, string displaymember, string valuemember, object parameter = null)
        {
            DataTable dt = APITable(apiquery, apiToken, parameter);
            searchEdit.Properties.View.Columns.Clear();
            searchEdit.Properties.DataSource = null;
            searchEdit.Properties.DataSource = dt;
            searchEdit.Properties.DisplayMember = displaymember;
            searchEdit.Properties.ValueMember = valuemember;
            searchEdit.Properties.PopulateViewColumns();
        }
        public static void displayCheckedcomboboxEditAPI(string apiquery, string apiToken, CheckedComboBoxEdit comboboxEdit, string displaymember, string valuemember, object parameter = null)
        {
            DataTable dt = APITable(apiquery, apiToken, parameter);
            comboboxEdit.Properties.DataSource = null;
            comboboxEdit.Properties.DataSource = dt;
            comboboxEdit.Properties.DisplayMember = displaymember;
            comboboxEdit.Properties.ValueMember = valuemember;
        }
        public static void displayCheckedcomboboxEditAPIParam(string apiquery, string apiToken, CheckedComboBoxEdit comboboxEdit, string displaymember, string valuemember)
        {
            DataTable dt = APITableParam(apiquery, apiToken);
            comboboxEdit.Properties.DataSource = null;
            comboboxEdit.Properties.DataSource = dt;
            comboboxEdit.Properties.DisplayMember = displaymember;
            comboboxEdit.Properties.ValueMember = valuemember;
        }
        public static String getSingleQueryAPIParam(string queryAPI, string apiToken, string returnval)
        {
            string json = string.Empty;
            string str = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            DataTable dt = new DataTable();
            HttpResponseMessage res = client.PostAsync(queryAPI, null).Result;
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    json = res.Content.ReadAsStringAsync().Result;
                    //json = json.Replace("[{", "{").Replace("}]", "}");
                    dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                }
                if (dt.Rows.Count > 0)
                {
                    str = dt.Rows[0][returnval].ToString();
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message.ToString());
            }

            return str;

        }
        public static IDictionary<string, object> DSpQueryAPIParam(string queryAPI, string apiToken)
        {
            string json = string.Empty;
            string strParam = string.Empty;
            string strquery = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = client.PostAsync(queryAPI, null).Result;
            if (res.IsSuccessStatusCode)
            {
                string uri = res.RequestMessage.RequestUri.AbsoluteUri;
                json = res.Content.ReadAsStringAsync().Result;
            }
            var d = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
            return d;
        }
        public static DataTable APITableParam(string queryAPI, string apiToken)
        {
            string json = string.Empty;
            Stopwatch stopwatch = Stopwatch.StartNew();
            string strParam = string.Empty;
            string strquery = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(3600);
            DataTable dt = new DataTable();
            try
            {
                HttpResponseMessage res = client.PostAsync(queryAPI, null).Result;
                if (res.IsSuccessStatusCode)
                {
                    json = res.Content.ReadAsStringAsync().Result;
                    dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                }
                return dt;
            }
            catch (Exception)
            {
                return dt;
            }
        }
        public static void displaySearchLookupEditAPIParam(string apiquery, string apiToken, SearchLookUpEdit searchEdit, string displaymember, string valuemember)
        {
            DataTable dt = APITableParam(apiquery, apiToken);
            searchEdit.Properties.View.Columns.Clear();
            searchEdit.Properties.DataSource = null;
            searchEdit.Properties.DataSource = dt;
            searchEdit.Properties.DisplayMember = displaymember;
            searchEdit.Properties.ValueMember = valuemember;
            searchEdit.Properties.PopulateViewColumns();
        }
    }
}
