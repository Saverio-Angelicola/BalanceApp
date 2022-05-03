using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceApp.Infrastructure.Http
{
    public interface IHttpClient
    {

        Task<HttpResponseMessage> GetAsync(string? requestUri);
        Task<HttpResponseMessage> GetAsync(string? requestUri, HttpCompletionOption completionOption);
        Task<HttpResponseMessage> GetAsync(string? requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<HttpResponseMessage> GetAsync(string? requestUri, CancellationToken cancellationToken);
        Task<HttpResponseMessage> GetAsync(Uri? requestUri);
        Task<HttpResponseMessage> GetAsync(Uri? requestUri, HttpCompletionOption completionOption);
        Task<HttpResponseMessage> GetAsync(Uri? requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<HttpResponseMessage> GetAsync(Uri? requestUri, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PatchAsync(string? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PatchAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PatchAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PatchAsync(Uri? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PutAsync(string? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PutAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PutAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PutAsync(Uri? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> DeleteAsync(string? requestUri);
        Task<HttpResponseMessage> DeleteAsync(string? requestUri, CancellationToken cancellationToken);
        Task<HttpResponseMessage> DeleteAsync(Uri? requestUri);
        Task<HttpResponseMessage> DeleteAsync(Uri? requestUri, CancellationToken cancellationToken);



    }
}
