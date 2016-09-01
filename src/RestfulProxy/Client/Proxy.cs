using OwnApt.RestfulProxy.Domain.Invokers;
using OwnApt.RestfulProxy.Interface;
using System;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Client
{
    public sealed class Proxy : IProxy
    {
        #region Fields

        private readonly RequestInvoker requestInvoker;

        #endregion Fields

        #region Constructors

        public Proxy(IProxyConfiguration proxyConfiguration)
        {
            this.requestInvoker = new RequestInvoker(proxyConfiguration);
        }

        #endregion Constructors

        #region Methods

        public async Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request)
        {
            try
            {
                return await this.requestInvoker[request.HttpRequestMethod].InvokeAsync(request);
            }

            catch(Exception e)
            {
                return await ProxyResponseFactory.Create<TResponseDto>(e);
            }
        }

        #endregion Methods
    }
}