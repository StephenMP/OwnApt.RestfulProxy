﻿using OwnApt.RestfulProxy.Extension;
using OwnApt.RestfulProxy.Interface;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Invokers
{
    internal sealed class GetInvoker : Invoker
    {
        #region Constructors

        public GetInvoker(IRestfulProxyConfiguration proxyConfiguration) : base(proxyConfiguration)
        {
        }

        #endregion Constructors

        #region Methods

        public override async Task<IRestfulProxyResponse<TResponseDto>> InvokeAsync<TRequestDto, TResponseDto>(IRestfulProxyRequest<TRequestDto, TResponseDto> request)
        {
            using (var client = HttpClient)
            {
                using (var response = await client.InvokeGetAsync(request))
                {
                    return await RestfulProxyResponseFactory.Create<TResponseDto>(response);
                }
            }
        }

        #endregion Methods
    }
}