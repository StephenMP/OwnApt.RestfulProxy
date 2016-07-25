using OwnApt.RestfulProxy.Domain.Handlers;
using OwnApt.RestfulProxy.Interface;
using System.Net.Http;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    internal abstract class Invoker
    {
        #region Fields

        private IRestfulProxyConfiguration proxyConfiguration;

        #endregion Fields

        #region Properties

        protected HttpClient HttpClient => new HttpClient(new HmacDelegatingHandler(this.proxyConfiguration));

        #endregion Properties

        #region Constructors

        protected Invoker(IRestfulProxyConfiguration proxyConfiguration)
        {
            this.proxyConfiguration = proxyConfiguration;
        }

        #endregion Constructors

        #region Methods

        public abstract Task<IRestfulProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IRestfulProxyRequest<TRequestDto, TResponseDto> request);

        #endregion Methods
    }
}