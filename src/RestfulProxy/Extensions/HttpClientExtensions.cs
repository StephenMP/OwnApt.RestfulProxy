using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Extensions
{
    public static class HttpClientExtensions
    {
        #region Public Methods

        public static async Task<HttpResponseMessage> HeadAsync(this HttpClient client, Uri requestUri)
        {
            var request = new HttpRequestMessage(new HttpMethod("HEAD"), requestUri);
            return await client.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> OptionsAsync(this HttpClient client, Uri requestUri)
        {
            var request = new HttpRequestMessage(new HttpMethod("OPTIONS"), requestUri);
            return await client.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> PatchAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value)
        {
            var content = new ObjectContent<T>(value, new JsonMediaTypeFormatter());
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = content };
            return await client.SendAsync(request);
        }

        #endregion Public Methods
    }
}
