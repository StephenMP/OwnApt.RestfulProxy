using System;
using System.Net;
using System.Net.Http.Headers;

namespace OwnApt.RestfulProxy.Domain.Interface
{
    public interface IProxyResponse<TResponseDto>
    {
        #region Public Fields + Properties

        bool IsSuccessfulStatusCode { get; }
        string Message { get; set; }
        HttpRequestHeaders RequestHeaders { get; set; }
        Uri Resource { get; set; }
        TResponseDto ResponseDto { get; set; }
        HttpResponseHeaders ResponseHeaders { get; set; }
        HttpStatusCode StatusCode { get; set; }

        #endregion Public Fields + Properties
    }
}
