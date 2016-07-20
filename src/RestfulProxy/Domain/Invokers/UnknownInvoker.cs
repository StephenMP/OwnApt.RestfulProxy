using OwnApt.RestfulProxy.Domain.Interface;
using System.Net;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    public class UnknownInvoker : RequestInvoker
    {
        #region Public Constructors + Destructors

        public UnknownInvoker() : base(null, null)
        {
        }

        #endregion Public Constructors + Destructors

        #region Public Methods

        public override IProxyResponse<TResponseDto> Invoke<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request)
        {
            ValidateRequest(request);
            return BuildUnrecognizedRequestType<TResponseDto>();
        }

        public override async Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request)
        {
            ValidateRequest(request);
            return await Task.Run(() => BuildUnrecognizedRequestType<TResponseDto>());
        }

        #endregion Public Methods

        #region Private Methods

        private static IProxyResponse<TResponseDto> BuildUnrecognizedRequestType<TResponseDto>()
        {
            return new ProxyResponse<TResponseDto>
            {
                StatusCode = HttpStatusCode.MethodNotAllowed,
                Message = $"Unrecognized request type. Valid types are DELETE, GET, HEAD, OPTIONS, PATCH, POST, and PUT."
            };
        }

        #endregion Private Methods
    }
}
