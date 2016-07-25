using OwnApt.RestfulProxy.Domain.Invokers;
using OwnApt.RestfulProxy.Interface;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy
{
    public sealed class RestfulProxy : IRestfulProxy
    {
        #region Fields

        private readonly RequestInvoker requestInvoker;

        #endregion Fields

        #region Constructors

        public RestfulProxy(IRestfulProxyConfiguration proxyConfiguration)
        {
            this.requestInvoker = new RequestInvoker(proxyConfiguration);
        }

        #endregion Constructors

        #region Methods

        public async Task<IRestfulProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            return await this.requestInvoker[request.HttpRequestMethod].InvokeAsync(request);
        }

        #endregion Methods
    }
}