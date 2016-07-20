using OwnApt.RestfulProxy.Domain.Interface;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OwnApt.RestfulProxy.Domain
{
    public class ProxyResponse<TResponseDto> : IProxyResponse<TResponseDto>
    {
        #region Public Fields + Properties

        public bool IsSuccessfulStatusCode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Message
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public HttpRequestHeaders RequestHeaders
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Uri Resource
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public TResponseDto ResponseDto
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public HttpResponseHeaders ResponseHeaders
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public HttpStatusCode StatusCode
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion Public Fields + Properties

        #region Internal Methods

        internal void MapResponse(HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }

        #endregion Internal Methods
    }
}
