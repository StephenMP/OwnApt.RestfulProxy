using OwnApt.RestfulProxy.Domain.Interface;
using OwnApt.RestfulProxy.Extensions;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    public class PatchInvoker : RequestInvoker
    {
        #region Public Constructors + Destructors

        public PatchInvoker(IProxyConfiguration proxyConfiguration, ICacheProvider cacheProvider) : base(proxyConfiguration, cacheProvider)
        {
        }

        #endregion Public Constructors + Destructors

        #region Public Methods

        public override IProxyResponse<TResponseDto> Invoke<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request)
        {
            ValidateRequest(request);
            AddHeaders(this.Client, request.Headers);
            using (var response = this.Client.PatchAsJsonAsync(request.Resource, request.RequestDto).Result)
            {
                return BuildResponse<TResponseDto>(response);
            }
        }

        public override async Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request)
        {
            ValidateRequest(request);
            AddHeaders(this.Client, request.Headers);
            using (var response = await this.Client.PatchAsJsonAsync(request.Resource, request.RequestDto))
            {
                return BuildResponse<TResponseDto>(response);
            }
        }

        #endregion Public Methods
    }
}
