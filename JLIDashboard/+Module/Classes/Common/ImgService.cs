using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

internal static class ImgService
{
    public static string UrlHost = "http://localhost/upload.php";
    public static async Task<string> SendAsync(byte[] imageBytes)
    {
        WebRequest request = null;
        string responseText = null;
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            request = WebRequest.Create(new Uri(ImgService.UrlHost));
            request.Method = "POST";
            request.ContentType = "application/json-patch+json; application/x-www-form-urlencoded";
            request.ContentLength = imageBytes.Length;
            using (var stream = request.GetRequestStream())
                stream.Write(imageBytes, 0, imageBytes.Length);
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
}
