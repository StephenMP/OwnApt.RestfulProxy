﻿using OwnApt.RestfulProxy.Client;
using OwnApt.RestfulProxy.Extension;
using OwnApt.RestfulProxy.Interface;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    internal sealed class PostInvoker : Invoker
    {
        #region Constructors

        public PostInvoker(IProxyConfiguration proxyConfiguration) : base(proxyConfiguration)
        {
        }

        #endregion Constructors

        #region Methods

        public override async Task<IProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IProxyRequest<TRequestDto, TResponseDto> request)
        {
            using (var client = HttpClient)
            {
                using (var response = await client.InvokePostAsync(request))
                {
                    return await ProxyResponseFactory.Create<TResponseDto>(response);
                }
            }
        }

        #endregion Methods
    }
}