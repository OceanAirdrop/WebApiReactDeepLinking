using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIReactDeepLinking.WebHandlers
{
    public class LogHTTPRequestResponse : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine(string.Format("WebReq | {0} | {1} | {2} | {3} | ({4}:{5})", request.RequestUri.Host, request.RequestUri.Scheme, request.Method.Method, request.RequestUri.AbsoluteUri, response.StatusCode, (int)response.StatusCode));
            return response;
        }
    }
}
