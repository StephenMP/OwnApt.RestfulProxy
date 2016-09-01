using OwnApt.Authentication.Client.Handler;
using OwnApt.RestfulProxy.Interface;
using System.Net.Http;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    internal abstract class Invoker
    {
        #region Private Fields

        private IProxyConfiguration proxyConfiguration;

        #endregion Private Fields

        #region Protected Constructors

        protected Invoker(IProxyConfiguration proxyConfiguration)
        {
            this.proxyConfiguration = proxyConfiguration;
        }

        #endregion Protected Constructors

        #region Protected Properties

        protected HttpClient HttpClient => HttpClientFactory.Create(new HmacDelegatingHandler(this.proxyConfiguration.AppId, this.proxyConfiguration.SecretKey));

        #endregion Protected Properties

        #region Public Methods

        public abstract Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request);

        #endregion Public Methods
    }
}
