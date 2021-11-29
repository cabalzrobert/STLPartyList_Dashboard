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

namespace JLIDashboard.Classes
{
    public class Database
    {
        //static RegistryKey regkey;
        static string constring;
        static string apiURL;
        public Database()
        {

        }
        public static SqlConnection getConnection()
        {
            return Connection;
            ////regkey = Registry.CurrentUser.CreateSubKey(@"Enzo\ConnSettings");
            //regkey = Registry.CurrentUser.CreateSubKey(@"ESAT\ConnSettingsMain");
            ////constring = "Data Source=210.213.236.202\\GLI_TEST,6970;Initial Catalog=STLDB_RDEV; User Id=enduser; Password=Esatpt123456789!;"; // regkey.GetValue("dbconn").ToString();
            ////constring = "Data Source=(local);Initial Catalog=STLDB_RDEV; User Id=test; Password=@test01;";
            //constring = regkey.GetValue("dbconn").ToString();
            //SqlConnection con;
            //try
            //{
            //    con = new SqlConnection(constring);
            //}
            //catch (SqlException sex)
            //{
            //    sex.StackTrace.ToString();
            //    return null;
            //}
            //return con;
        }

        public static RegistryKey RegKey
        {
            get
            {
                var dirPath = $"{Application.StartupPath}\\{'.'}{Application.ProductName}.exe";
                string md5 = Cipher.MD5Hash(dirPath).ToUpper();
                return Registry.CurrentUser.CreateSubKey(@"ESAT\" + md5);
            }
        }
        public static RegistryKey RegKeyAPI
        {
            get
            {
                var dirPath = $"{Application.StartupPath}\\{'.'}{Application.ProductName}.exe";
                string md5 = Cipher.MD5Hash(dirPath).ToUpper();
                return Registry.CurrentUser.CreateSubKey(@"ESAT\" + md5);
            }
        }

        public static SqlConnection Connection
        {
            get
            {
                constring = "Data Source=210.213.236.202\\GLI_TEST,6970;Initial Catalog=STLDB_RDEV; User Id=enduser; Password=Esatpt123456789!;"; // regkey.GetValue("dbconn").ToString();
                constring = "Data Source=(local);Initial Catalog=STLDB_RDEV; User Id=test; Password=@test01;";

                //constring = RegKey.GetValue("dbconn").ToString();
                constring = RegKeyAPI.GetValue("apicon").ToString();
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(constring);
                }
                catch (SqlException sEx)
                {
                    sEx.StackTrace.ToString();
                }
                return con;

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


        public static SqlMapper.GridReader DQueryMultiple(string SqlString, object parameters = null)
        {
            try
            {
                if (parameters != null)
                    return Database.Connection.QueryMultiple(SqlString,
                        param: new DynamicParameters(parameters));
                return Database.Connection.QueryMultiple(SqlString);
            }
            catch { return null; } // 'error to connecting database'/'query error'
        }

        public static IList<T> DSpQuery<T>(string SpName, object parameters = null) where T : class
        {
            try
            {
                if (parameters != null)
                    return Database.Connection.Query<T>(SpName,
                        param: new DynamicParameters(parameters),
                        commandType: CommandType.StoredProcedure).ToList();
                return Database.Connection.Query<T>(SpName,
                    commandType: CommandType.StoredProcedure).ToList();
            } catch { return null; } // 'error to connecting database'/'query error'
        }

        public static IList<T> DAPIQuery<T>(string apiQuery, object parameters=null) where T : class
        {
            try
            {
                //DataTable dt = APITable(apiQuery,parameters);
                ////IList<T> dtList = new List<T>();
                //var json = JsonConvert.SerializeObject(dt);
                //IList<T> dtList = JsonConvert.DeserializeObject<IList<T>>(json);
                //return dtList;

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
                    //json = json.Replace("{", "[{").Replace("}", "}]");
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
        public static IList<T> DAPIQueryResult<T>(string apiQuery, object parameters = null) where T : class
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
                    dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                    //try
                    //{
                    //    json = json.Replace("{", "[{").Replace("}", "}]");
                    //    dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                    //}
                    //catch (Exception)
                    //{
                    //    var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json).ToList();
                    //    string val1 = values[0].Value.ToString();
                    //    string key1 = values[0].Key.ToString();
                    //    dt.Columns.Add(key1, typeof(string));
                    //    DataRow row = dt.NewRow();
                    //    row[key1] = val1;
                    //    dt.Rows.Add(row);
                    //}
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
                    //dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                }


                var jsondt = JsonConvert.SerializeObject(dt);
                return JsonConvert.DeserializeObject<IList<T>>(json);
            }
            catch { return null; }

        }

        public static SqlMapper.GridReader DSpQueryMultiple(string SpName, Dictionary<string, object> parameters = null)
        {
            try
            {
                if (parameters != null)
                    return Database.Connection.QueryMultiple(SpName,
                        param: new DynamicParameters(parameters),
                        commandType: CommandType.StoredProcedure);
                
                return Database.Connection.QueryMultiple(SpName,
                    commandType: CommandType.StoredProcedure);
            }
            catch(Exception e){
                return null;
            } // 'error to connecting database'/'query error'
        }
        public static IDictionary<string,object> DSpQueryAPI(string queryAPI, Dictionary<string,object> parameters = null)
        {
            string json = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
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
            //ds = JsonConvert.DeserializeObject<DataSet>(json);
            var d = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
            return d;
        }
        public static IDictionary<string,object> DAPIQueryMultiple(string queryAPI,string apiToken, Dictionary<string,object> parameters = null)
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
            //ds = JsonConvert.DeserializeObject<DataSet>(json);
            var d = JsonConvert.DeserializeObject<IDictionary<string,object>>(json);
            return d;
        }
        public static DataTable stringDataTable(string parameters = null)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(parameters, typeof(DataTable));
            return dt;
        }
        public static IList<T> DAPIQueryMultiple<T>(string queryAPI, Dictionary<string, object> parameters = null) where T : class
        {

            string json = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
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
            //ds = JsonConvert.DeserializeObject<DataSet>(json);
            var d = JsonConvert.DeserializeObject<IList<T>>(json);
            return d;
        }






        public static void ExecuteQuery(string query)
        {
            SqlConnection con = getConnection();
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public static void ExecuteQuery(string query, string msg)
        {
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.CommandTimeout = 3600;
            com.ExecuteNonQuery();
            XtraMessageBox.Show(msg);
            con.Close();
        }
        public static void ExecuteQuery(string query, string msg, SqlConnection con)
        {
            //SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            XtraMessageBox.Show(msg);
            con.Close();
        }
        public static bool checkifExist(string query)
        {
            bool result = false;
            SqlConnection con = getConnection();
            con.Open();
            //try
            //{
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            reader.Close();
            //}
            //catch(SqlException ex)
            //{
            //    XtraMessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{
            con.Close();
            //}

            return result;
        }
       
        public static DataTable APITable(string apiquery,string apiToken, object parameters=null)
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
        public static void LoginAPI(string apiquery,object parameters = null)
        {
            string json = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string inputbody = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(inputbody, Encoding.UTF8, "application/json");

            HttpResponseMessage res = client.PostAsync(apiquery, content).Result;
            string uri = res.RequestMessage.RequestUri.AbsoluteUri;
            json = res.Content.ReadAsStringAsync().Result;
            //DataTable dt = new DataTable();
            //dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
            //return dt;

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
            catch(Exception) { return result; }
            
        }
        public static String getSingleQueryAPI(string queryAPI, string apiToken, string returnval, object parameters=null)
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
                    //json = json.Replace("{", "[{").Replace("}", "}]");
                    dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                }
                if (dt.Rows.Count > 0)
                {
                    str = dt.Rows[0][returnval].ToString();
                }
            }
            catch(Exception e)
            {
                XtraMessageBox.Show(e.Message.ToString());
            }
            
            return str;

        }
        public static String getSingleQuery(string query, string returnval)
        {
            string str = "";
            SqlConnection con = getConnection();
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        str = reader[returnval].ToString();
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }

            return str;
        }
        public static String getSingleQuery(string tablename, string condition, string returnval)
        {
            string str = "";
            SqlConnection con = getConnection();
            con.Open();
            try
            {
                string query = "SELECT TOP(1) " + returnval + " FROM " + tablename + " WHERE " + condition + " ";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        str = reader[returnval].ToString();
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
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
        public static Dictionary<string, object> getMultipleQuery(string tablename, string condition, string returnval) // ID, Name
        {
            SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT TOP 1 " + returnval + " FROM " + tablename + " WHERE " + condition + " ";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();

            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    //str = reader[returnval].ToString();
                    dic = ToDictionary(reader);
                }
                reader.Close();
            }
            con.Close();
            return dic;
        }
        public static Dictionary<string,object> GetDictionaryRow(string queryAPI, object parameters = null)
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
                    json = json.Replace("[{", "{").Replace("}]", "}");
                    //dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message.ToString());
            }
            return (Dictionary<string, object>)JsonConvert.DeserializeObject(json, typeof(Dictionary<string, object>));
            //return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }
        public static Dictionary<string,object> GetDictionaryStringParameter(string queryAPI, Dictionary<string,string> parameters=null)
        {
            string json = string.Empty;
            string str = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APICon);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //string inputbody = JsonConvert.SerializeObject(parameters);
            var keyval = new List<KeyValuePair<string, string>>();
            foreach(var item in parameters)
            {
                keyval.Add(new KeyValuePair<string,string>(item.Key, item.Value));
                queryAPI = queryAPI + "?" + item.Key + "=" + item.Value;
            }
            string inputbody = JsonConvert.SerializeObject(keyval);
            var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
            DataTable dt = new DataTable();
            HttpResponseMessage res = client.PostAsync(queryAPI, content).Result;
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    json = res.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message.ToString());
            }
            return (Dictionary<string, object>)JsonConvert.DeserializeObject(json, typeof(Dictionary<string, object>));
        }
        public static Dictionary<string, object> getMultipleQuery(string query) // ID, Name
        {
            SqlConnection con = getConnection();
            con.Open();
            //string query = "SELECT TOP 1 " + returnval + " FROM " + tablename + " WHERE " + condition + " ";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();

            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    //str = reader[returnval].ToString();
                    dic = ToDictionary(reader);
                }
                reader.Close();
            }
            con.Close();
            return dic;
        }

        public static Dictionary<string, object> getMultipleQueryLocal(string query, string returnval, SqlConnection con) // ID, Name
        {
            con.Open();
            //string query = "SELECT TOP 1 " + returnval + " FROM " + tablename + " WHERE " + condition + " ";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();

            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    //str = reader[returnval].ToString();
                    dic = ToDictionary(reader);
                }
                reader.Close();
            }
            con.Close();
            return dic;
        }

        public static Dictionary<string, object> ToDictionary(System.Data.SqlClient.SqlDataReader row)
        {
            string nameStr = "";
            lock (nameStr)
            {
                var dic = new Dictionary<string, object>();
                for (int i = 0; i < row.FieldCount; i++)
                {
                    nameStr = row.GetName(i);
                    dic[nameStr] = (object)row[nameStr];
                }
                return dic;
            }
        }
        public static String getSingleData(string tablename, string col, string value)
        {
            string str = "";
            SqlConnection con = getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM " + tablename + " WHERE " + col + " = '" + value + "' ";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        str = reader[col].ToString();
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
            return str;
        }

        public static String getSingleData(string tablename, string col, string value, string returnval)
        {
            string str = "";
            SqlConnection con = getConnection();
            con.Open();
            try
            {
                string query = "SELECT * FROM " + tablename + " WHERE " + col + " = '" + value + "' ";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        str = reader[returnval].ToString();
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
            return str;
        }
        public static String getSingleResultSet(string query)
        {
            string str = "";
            SqlConnection con = getConnection();
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    str = reader[0].ToString();
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
            return str;
        }

        public static int getCountData(string query, string value)
        {
            int ctr = 0;
            SqlConnection con = getConnection();
            con.Open();
            // string query = "SELECT COUNT(" + id + ") AS Counter FROM " + tablename + " WHERE " + condition + " ";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ctr = Convert.ToInt32(reader[value].ToString());
                }
                reader.Close();
            }
            con.Close();
            return ctr;
        }
        public static int getCountData(string tablename, string condition, string id)
        {
            int ctr = 0;
            SqlConnection con = getConnection();
            con.Open();
            try
            {
                string query = "SELECT COUNT(" + id + ") AS Counter FROM " + tablename + " WHERE " + condition + " ";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        ctr = Convert.ToInt32(reader["Counter"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
            return ctr;
        }

        public static int getCountData(string tablename, string col, string value, string id)
        {
            int ctr = 0;
            SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT COUNT(" + id + ") AS Counter FROM " + tablename + " WHERE " + col + " = '" + value + "' ";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ctr = Convert.ToInt32(reader["Counter"].ToString());
                }
                reader.Close();
            }
            con.Close();
            return ctr;
        }

        public static int getCountData(string tablename, string col, string value, string id, string col2, string val2)
        {
            int ctr = 0;
            SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT COUNT(" + id + ") AS Counter FROM " + tablename + " WHERE " + col + " = '" + value + "' AND " + col2 + " = " + val2 + " ";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ctr = Convert.ToInt32(reader["Counter"].ToString());
                }
                reader.Close();
            }
            con.Close();
            return ctr;
        }

        public static double getTotalSummation(string tablename, string condition, string id)
        {
            double ctr = 0.0;
            SqlConnection con = getConnection();
            con.Open();
            try
            {
                string query = "SELECT ISNULL(" + id + ",0) AS Totals FROM (SELECT SUM(" + id + ") AS Totals FROM " + tablename + " WHERE " + condition + ") ";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                if (!reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ctr = Convert.ToDouble(reader["Totals"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
            return ctr;
        }

        public static double getTotalSummation2(string tablename, string condition, string id)
        {
            double ctr = 0.0;
            SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT  ISNULL(SUM(" + id + "),0) AS Totals FROM " + tablename + " WHERE " + condition + " ";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        ctr = Convert.ToDouble(reader["Totals"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace.ToString());
            }
            finally
            {
                con.Close();
            }

            return ctr;
            // con.Close();
        }
        public static decimal getTotalSummation2Dec(string tablename, string condition, string id)
        {
            decimal ctr = 0;
            SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT  ISNULL(SUM(" + id + "),0) AS Totals FROM " + tablename + " WHERE " + condition + " ";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        ctr = Convert.ToDecimal(reader["Totals"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace.ToString());
            }
            finally
            {
                con.Close();
            }
            return ctr;
            // con.Close();
        }
        public static double getTotalSummation2(string tablename, string condition, string id, SqlConnection con)
        {
            double ctr = 0.0;
            //SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT  ISNULL(SUM(" + id + "),0) AS Totals FROM " + tablename + " WHERE " + condition + " ";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        ctr = Convert.ToDouble(reader["Totals"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace.ToString());
            }
            finally
            {
                con.Close();
            }
            return ctr;
            // con.Close();
        }

        public static double getTotalSummation(string tablename, string col, string value, string id)
        {
            double ctr = 0.0;
            SqlConnection con = getConnection();
            con.Open();
            try
            {
                string query = "SELECT ISNULL(" + id + ",0) AS Summary FROM (SELECT SUM(" + id + ") AS Summary FROM " + tablename + " WHERE " + col + " = '" + value + "') ";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        ctr = Convert.ToDouble(reader["Summary"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
            return ctr;
        }

        public static int getLastID(string tableName, string id)
        {
            int i = 0;
            SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT ISNULL(MAX(CAST(" + id + " as int)),0) AS CC FROM " + tableName;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    i = Convert.ToInt32(reader["CC"].ToString());
                }
                reader.Close();
            }

            con.Close();
            return i;
        }

        public static int getLastID(string tableName, string condition, string id)
        {
            int i = 0;
            SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT isnull(MAX(CAST(" + id + " as int)),0) AS CC FROM " + tableName + " WHERE " + condition + "";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    //i = reader.GetInt32(1);
                    i = Convert.ToInt32(reader["CC"].ToString());
                    // i = int.Parse(reader["CC"].ToString());
                    //  i = reader.GetInt32(reader.GetOrdinal("CC"));
                }
                reader.Close();
            }
            con.Close();
            return i;
        }
        public static int getLastID(string tableName, string condition, string id, SqlConnection con)
        {
            int i = 0;
            con.Open();
            string query = "SELECT isnull(MAX(CAST(" + id + " as int)),0) AS CC FROM " + tableName + " WHERE " + condition + "";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    i = Convert.ToInt32(reader["CC"].ToString());
                }
                reader.Close();
            }
            con.Close();
            return i;
        }

        public static String getLastDate(string tableName, string condition, string id)
        {
            string lastdate = "";
            SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT MAX(" + id + " ) AS CC FROM " + tableName + " WHERE " + condition + "";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    lastdate = reader["CC"].ToString();
                }
                reader.Close();
            }
            con.Close();
            return lastdate;
        }

        public static String getLastRecord(string tableName, string condition, string id)
        {
            string lastdate = "";
            SqlConnection con = getConnection();
            con.Open();
            string query = "SELECT LAST(" + id + " ) AS CC FROM " + tableName + " WHERE " + condition + "";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    lastdate = reader["CC"].ToString();
                }
                reader.Close();
            }
            con.Close();
            return lastdate;
        }

        public static void display(string query, GridControl cont, GridView view)
        {
            SqlConnection con = getConnection();
            con.Open();
            //  cont.BeginUpdate();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            try
            {
                com.CommandTimeout = 180;
                view.Columns.Clear();
                cont.DataSource = null;
                adapter.Fill(table);
                //  table.Columns.Add("OvertimeType");
                cont.DataSource = table;
                view.BestFitColumns();
            }
            catch (SqlException ee)
            {
                XtraMessageBox.Show(ee.ToString());
            }
            finally
            {
                //   cont.EndUpdate();
                con.Close();
            }
        }
        public static void displayAPI(string queryAPI, GridControl cont, GridView view,string apiToken, object parameters=null)
        {
            DataTable dt = APITable(queryAPI, apiToken, parameters);
            try
            {
                view.Columns.Clear();
                cont.DataSource = null;
                cont.DataSource = dt;
                view.BestFitColumns();
            }
            catch(Exception ex) { XtraMessageBox.Show(ex.ToString()); }
        }
        

        public static void display(string query, GridControl cont, GridView view, SqlConnection con)
        {
            //SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
                //  table.Columns.Add("OvertimeType");
                cont.DataSource = table;
                view.BestFitColumns();
            }
            catch (Exception ee)
            {
                XtraMessageBox.Show(ee.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void displayFromSP(string query, GridControl cont, GridView view)
        {
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = query;
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
                //  table.Columns.Add("OvertimeType");
                cont.DataSource = table;
                view.BestFitColumns();
            }
            catch (Exception ee)
            {
                XtraMessageBox.Show(ee.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void displayDevComboBoxItems(string query, string col, ComboBoxEdit box)
        {
            box.Properties.Items.Clear();
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Properties.Items.Add(reader[col].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }

        public static void displayRepositoryComboBoxItems(string query, string col, RepositoryItemComboBox box)
        {
            box.Items.Clear();
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Items.Add(reader[col].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }
        public static void displayDevComboBoxItems(string query, string col, ComboBoxEdit box, SqlConnection con)
        {
            box.Properties.Items.Clear();
            // SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Properties.Items.Add(reader[col].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public static void displayComboBoxItems(string query, string col, System.Windows.Forms.ComboBox box)
        {
            box.Items.Clear();
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Items.Add(reader[col].ToString().Trim());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }
        public static void displayComboBoxItems(string query, string col, System.Windows.Forms.ComboBox box, SqlConnection con)
        {
            box.Items.Clear();
            //SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Items.Add(reader[col].ToString().Trim());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }
        public static void displayListBoxItems(string query, string col, System.Windows.Forms.ListBox box)
        {
            box.Items.Clear();
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Items.Add(reader[col].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }
        public static void displayListBoxItems(string query, string col, System.Windows.Forms.ListBox box, SqlConnection con)
        {
            box.Items.Clear();
            //SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Items.Add(reader[col].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }
        public static void displayCheckedListBoxItems(string query, string col, System.Windows.Forms.CheckedListBox box, SqlConnection con)
        {
            box.Items.Clear();
            //SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Items.Add(reader[col].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }
        public static void displayCheckedListBoxItemsDevEx(string query, string col, CheckedListBoxControl box)
        {
            box.Items.Clear();
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Items.Add(reader[col].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }
        public static void displayCheckedListBoxItemsDevEx(string query, string col, CheckedListBoxControl box, SqlConnection con)
        {
            box.Items.Clear();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        box.Items.Add(reader[col].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }
        public static void displayListViewItems(string query, string col, System.Windows.Forms.ListView view, SqlConnection con)
        {
            view.Items.Clear();
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            SqlDataReader reader = com.ExecuteReader();
            try
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        view.Items.Add(reader[col].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException sex)
            {
                XtraMessageBox.Show(sex.StackTrace.ToString());
            }
            finally
            {

                con.Close();
            }
        }

        public static void displaySearchlookupEdit(string query, SearchLookUpEdit searchEdit)
        {
            SqlConnection con = Database.getConnection();
            con.Open();
            // string query = "SELECT * FROM PrimalCuts";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            searchEdit.Properties.DataSource = table;
            con.Close();
        }
        public static void displaySearchlookupEdit(string query, SearchLookUpEdit searchEdit, string displaymember, string valuemember)
        {
            SqlConnection con = Database.getConnection();
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataTable table = new DataTable();

                searchEdit.Properties.View.Columns.Clear();
                adapter.Fill(table);
                searchEdit.Properties.DataSource = null;
                searchEdit.Properties.DataSource = table;
                searchEdit.Properties.DisplayMember = displaymember;
                searchEdit.Properties.ValueMember = valuemember;
                searchEdit.Properties.PopulateViewColumns();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public static void displaySearchLookupEditAPI(string apiquery, SearchLookUpEdit searchEdit, string displaymember, string valuemember, object parameter = null)
        {
            DataTable dt = APITable(apiquery, Login.authentication, parameter);
            searchEdit.Properties.View.Columns.Clear();
            searchEdit.Properties.DataSource = null;
            searchEdit.Properties.DataSource = dt;
            searchEdit.Properties.DisplayMember = displaymember;
            searchEdit.Properties.ValueMember = valuemember;
            searchEdit.Properties.PopulateViewColumns();
        }
        
        public static void displaySearchlookupEdit(string query, SearchLookUpEdit searchEdit, string displaymember, string valuemember, SqlConnection con)
        {
            // SqlConnection con = Database.getConnection();
            con.Open();
            // string query = "SELECT * FROM PrimalCuts";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            searchEdit.Properties.DataSource = table;
            searchEdit.Properties.DisplayMember = displaymember;
            searchEdit.Properties.ValueMember = valuemember;
            con.Close();
        }

        public static void displayCheckedcomboboxEditAPI(string apiquery, CheckedComboBoxEdit comboboxEdit, string displaymember, string valuemember, object parameter = null)
        {
            DataTable dt = APITable(apiquery, Login.authentication, parameter);
            comboboxEdit.Properties.DataSource = null;
            comboboxEdit.Properties.DataSource = dt;
            comboboxEdit.Properties.DisplayMember = displaymember;
            comboboxEdit.Properties.ValueMember = valuemember;
        }
        public static void displayCheckedcomboboxEdit(string query, CheckedComboBoxEdit comboboxEdit, string displaymember, string valuemember)
        {
            SqlConnection con = Database.getConnection();
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataTable table = new DataTable();

                //comboboxEdit.Properties.View.Columns.Clear();
                adapter.Fill(table);
                comboboxEdit.Properties.DataSource = null;
                comboboxEdit.Properties.DataSource = table;
                comboboxEdit.Properties.DisplayMember = displaymember;
                comboboxEdit.Properties.ValueMember = valuemember;
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public static void displayRepositorySearchlookupEdit(string query, RepositoryItemSearchLookUpEdit searchEdit, string displaymember, string valuemember)
        {
            SqlConnection con = Database.getConnection();
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                adapter.Fill(table);
                searchEdit.DataSource = table;
                searchEdit.DisplayMember = displaymember;
                searchEdit.ValueMember = valuemember;
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public static void displayGridlookupEdit(string query, GridLookUpEdit gridlook, GridView view)
        {
            SqlConnection con = Database.getConnection();
            con.Open();
            // string query = "SELECT * FROM PrimalCuts";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
                gridlook.Properties.DataSource = table;
                view.BestFitColumns();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace.ToString());
            }

            finally
            {
                con.Close();
            }
            //gridLookUpEdit1.Properties.DataSource = table;
        }
        public static DataTable GetDatable(string query)
        {
            SqlConnection con = Database.getConnection();
            con.Open();
            //  cont.BeginUpdate();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            try
            {
                com.CommandTimeout = 180;
                adapter.Fill(table);
            }
            catch (SqlException ee)
            {
                XtraMessageBox.Show(ee.ToString());
            }
            finally
            {
                //   cont.EndUpdate();
                con.Close();
            }
            return table;
        }
        public static void displayCheckListBox(string query, GridLookUpEdit gridlook, GridView view)
        {
            SqlConnection con = Database.getConnection();
            con.Open();
            // string query = "SELECT * FROM PrimalCuts";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
                gridlook.Properties.DataSource = table;
                view.BestFitColumns();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace.ToString());
            }

            finally
            {
                con.Close();
            }
            //gridLookUpEdit1.Properties.DataSource = table;
        }


    }
}
