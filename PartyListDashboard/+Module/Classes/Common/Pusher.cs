using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

internal static class Pusher
{
    public static string PublicKey = "0123456789ABCDEF";
    public static string UrlHost = "localhost";

    public static async Task<bool> PushAsync(string topic, object data)
    {
        string body = "";
        if (data != null)
        {
            if (data is String) body = (data as string);
            else body = JsonConvert.SerializeObject(data);
        }
        if (String.IsNullOrEmpty(body)) body = "{}";
        var json = JsonConvert.SerializeObject(new { topic = topic, body = body });
        data = Encoding.ASCII.GetBytes(json);
        //await SendAsync($"http://{UrlHost}/v1/{PublicKey}", data as byte[]);
        Timeout.Set(async () => await SendAsync($"http://{UrlHost}/v1/{PublicKey}", data as byte[]), 5);
        json = null; body = null;
        return true;
    }
    public static async Task<bool> SendAsync(string url, byte[] data, int retry = 2)
    {
        WebRequest request = null;
        try
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            request = WebRequest.Create(new Uri(url));
            request.Method = "POST";
            request.ContentType = "application/json-patch+json; application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
                stream.Write(data, 0, data.Length);
            using (var response = (HttpWebResponse)request.GetResponse())
                response.Close();
            data = new byte[0]; data = null;
            return true;
        }
        catch
        {
            if (retry > 0)
                return await SendAsync(url, data, (retry - 1));
            data = new byte[0]; data = null;
        }
        finally
        {
            request = null;
        }
        return false;
    }
}
