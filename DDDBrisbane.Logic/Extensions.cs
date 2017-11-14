using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace DDDBrisbane.Logic
{
    public static class Extensions
    {
        public static ByteArrayContent ToByteArrayContent(this object o)
        {
            var myContent = JsonConvert.SerializeObject(o);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }

        public static string ToBase64(this string html)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(html);
            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }
    }
}
