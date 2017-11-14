using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DDDBrisbane.Logic
{
    public class PdfClient
    {
        private readonly string _url;

        public PdfClient(string url)
        {
            _url = url;
        }

        public async Task<Stream> FromHtml(string html)
        {
            var client = new HttpClient();
            var content = new { contents = html.ToBase64() }.ToByteArrayContent();
            var result = await client.PostAsync(_url, content);
            var stream = await result.Content.ReadAsStreamAsync();
            return stream;
        }
    }
}
