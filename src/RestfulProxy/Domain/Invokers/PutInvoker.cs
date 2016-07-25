using OwnApt.RestfulProxy.Extension;
using OwnApt.RestfulProxy.Interface;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    internal sealed class PutInvoker : Invoker
    {
        #region Constructors

        public PutInvoker(IRestfulProxyConfiguration proxyConfiguration) : base(proxyConfiguration)
        {
        }

        #endregion Constructors

        #region Methods

        public override async Task<IRestfulProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            using (var client = HttpClient)
            {
                using (var response = await client.InvokePutAsync(request))
                {
                    return await RestfulProxyResponseFactory.Create<TResponseDto>(response);
                }
            }
        }

        #endregion Methods
    }
}