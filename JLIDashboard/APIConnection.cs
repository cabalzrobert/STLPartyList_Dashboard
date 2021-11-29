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
using JLIDashboard.Classes;
using Comm.Common.Advance;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using AbacosDashboard.Module.Enum;
using Comm.Common.Extensions;
using JLIDashboard.Module;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard
{
    public partial class APIConnection : DevExpress.XtraEditors.XtraForm
    {
        public APIConnection()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (!(ValidateEntries() && XtraMessageBox.Show("Are you sure you want to Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            var res = exec0a(txtURL.Text, txtPort.Text, txtUsername.Text, txtPassword.Text).Result;
            if (res.result == Results.Success)
            {
                var regkey = API.RegKeyAPI;
                string encryptedcode = Cipher.Encrypt($"{txtURL.Text}:{txtPort.Text}", "Esatpt123456789!");
                string strServername = Cipher.Encrypt(res.servername, "Esatpt123456789!");
                regkey.SetValue("apicon", encryptedcode);
                regkey.SetValue("servername", strServername);
                Application.Restart();
            }
            else if (res.result != Results.Null)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
            }
            else
            {
                XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            StaticSettings.hideLoading();
        }

        private bool ValidateEntries()
        {
            if (txtURL.Text.IsEmpty())
            {
                StaticSettings.XtraMessage("URL is required", MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtPort.Text.IsEmpty())
            {
                StaticSettings.XtraMessage("Port is required", MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtUsername.Text.IsEmpty())
            {
                StaticSettings.XtraMessage("Username is required", MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        public static async Task<(Results result, string message, string servername)> exec0a(string apiHost, string apiPort, string username, string password)
        {
            var result = APIHost("app/v1/stl/activator", $"{apiHost}:{apiPort}", new Dictionary<string, object>()
            {
                {"Host", $"{apiHost}:{apiPort}" },
                {"Username", username },
                {"Password",password }
            });
            if (result != null)
            {
                //var row = ((IDictionary<string, object>)result);
                var row = ((IDictionary<string, object>)result);
                string ResultCode = row["Status"].Str();
                if (ResultCode == "2")
                {
                    return (Results.Success, "Successfully Connected",row["SERVERNAME"].Str());
                }
                return (Results.Failed, "Somethings wrong in your data. Please try again",null);
            }
            return (Results.Null, null,null);
        }
        public static IDictionary<string, object> APIHost(string apiquery, string apiHost, Dictionary<string,object> parameters = null) 
        {
            string json = string.Empty;
            //string path = $"/app/v1/stl/{apiquery}";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiHost);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string inputbody = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(inputbody, Encoding.UTF8, "application/json");
            HttpResponseMessage res = client.PostAsync(apiquery, content).Result;
            if (res.IsSuccessStatusCode)
            {
                json = res.Content.ReadAsStringAsync().Result;
                //json = json.Replace("{", "[{").Replace("}", "}]");
            }
            return JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
        }
    }
}