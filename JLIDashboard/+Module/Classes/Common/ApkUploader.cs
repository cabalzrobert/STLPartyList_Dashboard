using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

internal static class ApkUploader
{
    public static string UrlHost = "http://localhost/upload.php";
    public static async Task<string> SendAsync(string type, string version, byte[] fileBytes) //
    {
        WebRequest request = null;
        string responseText = null;
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            request = WebRequest.Create(new Uri(ApkUploader.UrlHost + "=" + type + "&version=" + version));
            request.Method = "POST";
            request.ContentType = "application/json-patch+json; application/x-www-form-urlencoded";
            request.ContentLength = fileBytes.Length;
            using (var stream = request.GetRequestStream())
                stream.Write(fileBytes, 0, fileBytes.Length);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var encoding = Encoding.GetEncoding(response.CharacterSet);
                using (var reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    responseText = reader.ReadToEnd();
                }
                response.Close();
            }
        }
        catch { }
        return responseText;
    }
    /*
    var version = "v21.04110255"; //input textedit

    var res = ApkUploader.SendAsync("app", version, file);

    res.status = ok/error
    res.message = 
    
    res.url(for Update)
    res.url_version (for my Listing)
    //
    if(res.status == ok){
        //ESATBAA.APK_URL = ESATBAA.APK_UPDT_URL = ESATBAA.APK_TRMNL_URL = ESATBAA.APK_TRMNL_UPDT_URL = res.url; //res.url_version  //google.com
        //ESATBAA.APK_VRSN = ESATBAA.APK_TRMNL_VRSN = version   //v21.000000001
        ---
       // UPDATE ESATBDA SET SESSION = NULL
       //

        IS_CURRENT 
        version 
        res.url_version 

        
        Current     Version   URL
                  v21.04110255    google.com
        /            v21.000000001    google.com


         
        IS Force Logout User

    }



    
    */
}
