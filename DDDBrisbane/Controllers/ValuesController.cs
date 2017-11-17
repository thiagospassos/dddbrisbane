using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DDDBrisbane.Logic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DDDBrisbane.Controllers
{
    [Route("")]
    public class ValuesController : Controller
    {
        private readonly PdfClient _pdfClient;

        public ValuesController(PdfClient pdfClient)
        {
            _pdfClient = pdfClient;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {
                "Hope","You","Guys","Are","Not","Sleeping","At","SSW"
             };
        }

        // GET api/values/5
        [HttpGet("pdf")]
        public async Task<IActionResult> GetPdf()
        {
            var stream = await _pdfClient.FromHtml("<body><p>Hello DDD Brisbane</p><p>Give me feedback for a chance to win an X Box One X One X</p></body>");
            var response = File(stream, "application/octet-stream", "file.pdf");
            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
