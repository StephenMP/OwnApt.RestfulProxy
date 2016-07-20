using OwnApt.RestfulProxy.Domain.Interface;
using System;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Proxy.Interface
{
    public interface IRestfulProxy : IDisposable
    {
        #region Public Methods

        IProxyResponse<TResponseDto> Invoke<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> proxyRequest);

        Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> proxyRequest);

        #endregion Public Methods
    }
}
