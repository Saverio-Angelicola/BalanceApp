using System.Net.Http.Headers;

namespace BalanceApp.Infrastructure.Http
{
    public class Client : HttpClient, IHttpClient
    {
        public HttpRequestHeaders getRequestHeader()
        {
            return DefaultRequestHeaders;
        }
    }
}
