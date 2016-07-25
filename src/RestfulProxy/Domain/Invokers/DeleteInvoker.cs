using OwnApt.RestfulProxy.Extension;
using OwnApt.RestfulProxy.Interface;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    internal sealed class DeleteInvoker : Invoker
    {
        #region Constructors

        public DeleteInvoker(IRestfulProxyConfiguration proxyConfiguration) : base(proxyConfiguration)
        {
        }

        #endregion Constructors

        #region Methods

        public override async Task<IRestfulProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            using (var client = HttpClient)
            {
                using (var response = await client.InvokeDeleteAsync(request))
                {
                    return await RestfulProxyResponseFactory.Create<TResponseDto>(response);
                }
            }
        }

        #endregion Methods
    }
}