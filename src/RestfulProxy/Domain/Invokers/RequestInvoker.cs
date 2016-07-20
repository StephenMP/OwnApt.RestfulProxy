using OwnApt.RestfulProxy.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    public abstract class RequestInvoker : IDisposable
    {
        #region Protected Fields + Properties

        protected HttpClient Client { get; set; }

        #endregion Protected Fields + Properties

        #region Private Fields + Properties

        private bool disposedValue = false;

        #endregion Private Fields + Properties

        #region Protected Constructors + Destructors

        protected RequestInvoker(IProxyConfiguration proxyConfiguration, ICacheProvider cacheProvider)
        {
            //this.Client = ClientFactory.CreateClient(proxyConfiguration, cacheProvider);
        }

        #endregion Protected Constructors + Destructors

        #region Public Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract IProxyResponse<TResponseDto> Invoke<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request);

        public abstract Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request);

        #endregion Public Methods

        #region Protected Methods

        protected static void AddHeaders(HttpClient client, IDictionary<string, IEnumerable<string>> headers)
        {
            foreach (var key in headers.Keys)
            {
                client.DefaultRequestHeaders.Add(key, headers[key]);
            }
        }

        protected static void ValidateRequest<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request)
        {
            //IProxyResponse<TResponseDto> proxyResponse = new ProxyResponse<TResponseDto>();
            //if (!ProxyUtility.ValidateRequest(request, proxyResponse)) {
            //	proxyResponse.StatusCode = HttpStatusCode.BadRequest;
            //	throw new RestfulProxyException<TResponseDto>(proxyResponse, "Request/DTO validation failed.");
            //}
        }

        protected IProxyResponse<TResponseDto> BuildResponse<TResponseDto>(HttpResponseMessage response)
        {
            var proxyResponse = new ProxyResponse<TResponseDto>();
            proxyResponse.MapResponse(response);
            this.Client.DefaultRequestHeaders.Clear();
            return proxyResponse;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this.Client != null)
                    {
                        this.Client.Dispose();
                    }
                }
                disposedValue = true;
            }
        }

        #endregion Protected Methods
    }
}
