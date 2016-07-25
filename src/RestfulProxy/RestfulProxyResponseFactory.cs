using OwnApt.RestfulProxy.Interface;
using System.Net.Http;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy
{
    internal static class RestfulProxyResponseFactory
    {
        #region Methods

        internal static async Task<IRestfulProxyResponse<TResponseDto>> Create<TResponseDto>(HttpResponseMessage httpResponseMessage)
        {
            var restfulProxyResponse = new RestfulProxyResponse<TResponseDto>();

            using (httpResponseMessage)
            {
                restfulProxyResponse.IsSuccessfulStatusCode = httpResponseMessage.IsSuccessStatusCode;
                restfulProxyResponse.RequestHeaders = httpResponseMessage.RequestMessage.Headers;
                restfulProxyResponse.RequestUri = httpResponseMessage.RequestMessage.RequestUri;
                restfulProxyResponse.ResponseDto = await httpResponseMessage.Content.ReadAsAsync<TResponseDto>();
                restfulProxyResponse.ResponseHeaders = httpResponseMessage.Headers;
            }

            return restfulProxyResponse;
        }

        #endregion Methods
    }
}