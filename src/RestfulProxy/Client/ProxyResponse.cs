using OwnApt.RestfulProxy.Interface;
using System;
using System.Net;
using System.Net.Http.Headers;

namespace OwnApt.RestfulProxy.Client
{
    public class ProxyResponse<TResponseDto> : IProxyResponse<TResponseDto>
    {
        #region Properties

        public bool IsSuccessfulStatusCode { get; set; }

        public HttpRequestHeaders RequestHeaders { get; set; }
        public Uri RequestUri { get; set; }
        public TResponseDto ResponseDto { get; set; }
        public HttpResponseHeaders ResponseHeaders { get; set; }
        public string ResponseMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        #endregion Properties
    }
}