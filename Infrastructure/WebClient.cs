using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class WebClient
    {
        public static async Task<string> GetAsync(string url)
        {
            var responseFromServer = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseFromServer = await reader.ReadToEndAsync();
                reader.Dispose();
                stream.Dispose();
                response.Close();
            }

            return responseFromServer;
        }

        public static async Task<string> PostAsync(string url, object body)
        {
            var responseFromServer = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            string postData = JsonConvert.SerializeObject(body);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (dataStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(dataStream))
            {
                responseFromServer = await reader.ReadToEndAsync();
                reader.Dispose();
                response.Close();
            }
            return responseFromServer;
        }
    }
}
