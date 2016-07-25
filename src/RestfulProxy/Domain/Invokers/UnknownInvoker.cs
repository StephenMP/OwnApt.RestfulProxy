using OwnApt.RestfulProxy.Interface;
using System.Net;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    internal sealed class UnknownInvoker : Invoker
    {
        #region Constructors

        public UnknownInvoker() : base(null)
        {
        }

        #endregion Constructors

        #region Methods

        public override async Task<IRestfulProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            return await Task.FromResult(BuildUnrecognizedRequestType<TResponseDto>());
        }

        private static IRestfulProxyResponse<TResponseDto> BuildUnrecognizedRequestType<TResponseDto>()
        {
            return new RestfulProxyResponse<TResponseDto>()
            {
                StatusCode = HttpStatusCode.MethodNotAllowed,
                ResponseMessage = $"Unrecognized request type. Valid types are DELETE, GET, HEAD, OPTIONS, PATCH, POST, and PUT."
            };
        }

        #endregion Methods
    }
}