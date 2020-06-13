using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIReactDeepLinking.WebControllers
{
    [AllowAnonymous]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/Test/Identify")]
        public string Identify()
        {
            return Assembly.GetExecutingAssembly().FullName;
        }

        [HttpGet]
        [Route("api/Test/BuildDate")]
        public string GetBuildDate()
        {
            DateTime lastWriteTime = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;

            return lastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Test/GetStatus")]
        public HttpResponseMessage GetStatus()
        {
            string htmlText = "<h1>Hello there</h1>";

            var response = new HttpResponseMessage();
            response.Content = new StringContent(htmlText);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

        [HttpGet]
        [Route("api/Test/MachineName")]
        public string GetMachineName()
        {
            return Environment.MachineName;
        }
    }
}
