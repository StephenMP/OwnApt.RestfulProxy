using OwnApt.RestfulProxy.Domain.Interface;
using OwnApt.RestfulProxy.Proxy.Interface;
using System;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Proxy
{
    public class RestfulProxy : IRestfulProxy
    {
        #region Private Fields + Properties

        private bool disposedValue = false;

        #endregion Private Fields + Properties

        #region Public Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IProxyResponse<TResponseDto> Invoke<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> proxyRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> proxyRequest)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                disposedValue = true;
            }
        }

        #endregion Protected Methods
    }
}
