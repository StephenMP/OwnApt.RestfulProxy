using OwnApt.Authentication.Client.Handler;
using OwnApt.RestfulProxy.Interface;
using System.Net.Http;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    internal abstract class Invoker
    {
        #region Fields

        private IProxyConfiguration proxyConfiguration;

        #endregion Fields

        #region Properties

        protected HttpClient HttpClient => HttpClientFactory.Create(new HmacDelegatingHandler(this.proxyConfiguration.AppId, this.proxyConfiguration.SecretKey));

        #endregion Properties

        #region Constructors

        protected Invoker(IProxyConfiguration proxyConfiguration)
        {
            this.proxyConfiguration = proxyConfiguration;
        }

        #endregion Constructors

        #region Methods

        public abstract Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request);

        #endregion Methods
    }
}