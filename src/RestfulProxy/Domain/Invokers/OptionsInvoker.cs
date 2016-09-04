using OwnApt.RestfulProxy.Client;
using OwnApt.RestfulProxy.Extension;
using OwnApt.RestfulProxy.Interface;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    internal sealed class OptionsInvoker : Invoker
    {
        #region Public Constructors

        public OptionsInvoker(IProxyConfiguration proxyConfiguration) : base(proxyConfiguration)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override async Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request)
        {
            using (var client = HttpClient)
            {
                using (var response = await client.InvokeOptionsAsync(request))
                {
                    return await ProxyResponseFactory.CreateAsync<TResponseDto>(response);
                }
            }
        }

        #endregion Public Methods
    }
}
