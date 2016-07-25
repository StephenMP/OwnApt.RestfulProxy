using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Interface
{
    public interface IRestfulProxy
    {
        #region Methods

        Task<IRestfulProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IRestfulProxyRequest<TRequestDto, TResponseDto> request);

        #endregion Methods
    }
}