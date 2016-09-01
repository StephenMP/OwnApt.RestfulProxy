using Newtonsoft.Json;
using OwnApt.RestfulProxy.Interface;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Client
{
    internal static class ProxyResponseFactory
    {
        #region Methods

        internal static async Task<IProxyResponse<TResponseDto>> Create<TResponseDto>(HttpResponseMessage httpResponseMessage)
        {
            var restfulProxyResponse = new ProxyResponse<TResponseDto>();

            using (httpResponseMessage)
            {
                restfulProxyResponse.IsSuccessfulStatusCode = httpResponseMessage.IsSuccessStatusCode;
                restfulProxyResponse.StatusCode = httpResponseMessage.StatusCode;
                restfulProxyResponse.RequestHeaders = httpResponseMessage.RequestMessage.Headers;
                restfulProxyResponse.RequestUri = httpResponseMessage.RequestMessage.RequestUri;
                restfulProxyResponse.ResponseHeaders = httpResponseMessage.Headers;

                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                restfulProxyResponse.ResponseDto = JsonConvert.DeserializeObject<TResponseDto>(jsonString);
            }

            return restfulProxyResponse;
        }

        internal static async Task<IProxyResponse<TResponseDto>> Create<TResponseDto>(Exception e)
        {
            var restfulProxyResponse = new ProxyResponse<TResponseDto>
            {
                IsSuccessfulStatusCode = false,
                StatusCode = HttpStatusCode.InternalServerError,
                ResponseMessage = e.Message
            };

            return await Task.FromResult(restfulProxyResponse);
        }

        #endregion Methods
    }
}