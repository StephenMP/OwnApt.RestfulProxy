using OwnApt.RestfulProxy.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Extension
{
    internal static class HttpClientExtension
    {
        #region Methods

        public static async Task<HttpResponseMessage> InvokeDeleteAsync<TRequestDto, TResponseDto>(this HttpClient client, IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            AddHeaders(client, request.Headers);
            return await client.DeleteAsync(request.RequestUri);
        }

        public static async Task<HttpResponseMessage> InvokeGetAsync<TRequestDto, TResponseDto>(this HttpClient client, IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            AddHeaders(client, request.Headers);
            return await client.GetAsync(request.RequestUri);
        }

        public static async Task<HttpResponseMessage> InvokeHeadAsync<TRequestDto, TResponseDto>(this HttpClient client, IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            AddHeaders(client, request.Headers);
            return await client.HeadAsync(request.RequestUri);
        }

        public static async Task<HttpResponseMessage> InvokeOptionsAsync<TRequestDto, TResponseDto>(this HttpClient client, IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            AddHeaders(client, request.Headers);
            return await client.OptionsAsync(request.RequestUri);
        }

        public static async Task<HttpResponseMessage> InvokePatchAsync<TRequestDto, TResponseDto>(this HttpClient client, IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            AddHeaders(client, request.Headers);
            return await client.PatchAsJsonAsync(request.RequestUri, request.RequestDto);
        }

        public static async Task<HttpResponseMessage> InvokePostAsync<TRequestDto, TResponseDto>(this HttpClient client, IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            AddHeaders(client, request.Headers);
            return await client.PostAsJsonAsync(request.RequestUri, request.RequestDto);
        }

        public static async Task<HttpResponseMessage> InvokePutAsync<TRequestDto, TResponseDto>(this HttpClient client, IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            AddHeaders(client, request.Headers);
            return await client.PutAsJsonAsync(request.RequestUri, request.RequestDto);
        }

        private static void AddHeaders(HttpClient client, IDictionary<string, IEnumerable<string>> headers)
        {
            foreach (var key in headers.Keys)
            {
                client.DefaultRequestHeaders.Add(key, headers[key]);
            }
        }

        private static async Task<HttpResponseMessage> HeadAsync(this HttpClient client, Uri requestUri)
        {
            var request = new HttpRequestMessage(new HttpMethod("HEAD"), requestUri);
            return await client.SendAsync(request);
        }

        private static async Task<HttpResponseMessage> OptionsAsync(this HttpClient client, Uri requestUri)
        {
            var request = new HttpRequestMessage(new HttpMethod("OPTIONS"), requestUri);
            return await client.SendAsync(request);
        }

        private static async Task<HttpResponseMessage> PatchAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value)
        {
            var content = new ObjectContent<T>(value, new JsonMediaTypeFormatter());
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = content };
            return await client.SendAsync(request);
        }

        #endregion Methods
    }
}