using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Interface
{
    public interface IProxy
    {
        #region Public Methods

        Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request);

        #endregion Public Methods
    }
}
