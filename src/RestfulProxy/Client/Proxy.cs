using OwnApt.RestfulProxy.Domain.Invokers;
using OwnApt.RestfulProxy.Interface;
using System;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Client
{
    public sealed class Proxy : IProxy
    {
        #region Private Fields

        private readonly RequestInvoker requestInvoker;

        #endregion Private Fields

        #region Public Constructors

        public Proxy(IProxyConfiguration proxyConfiguration)
        {
            this.requestInvoker = new RequestInvoker(proxyConfiguration);
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request)
        {
            try
            {
                return await this.requestInvoker[request.HttpRequestMethod].InvokeAsync(request);
            }
            catch (Exception e)
            {
                return await ProxyResponseFactory.Create<TResponseDto>(e);
            }
        }

        #endregion Public Methods
    }
}
