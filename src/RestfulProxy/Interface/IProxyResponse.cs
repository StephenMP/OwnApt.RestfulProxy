using System;
using System.Net;
using System.Net.Http.Headers;

namespace OwnApt.RestfulProxy.Interface
{
    public interface IProxyResponse<TResponseDto>
    {
        #region Public Properties

        bool IsSuccessfulStatusCode { get; }
        HttpRequestHeaders RequestHeaders { get; }
        Uri RequestUri { get; }
        TResponseDto ResponseDto { get; }
        HttpResponseHeaders ResponseHeaders { get; }
        string ResponseMessage { get; }
        HttpStatusCode StatusCode { get; }

        #endregion Public Properties
    }
}
