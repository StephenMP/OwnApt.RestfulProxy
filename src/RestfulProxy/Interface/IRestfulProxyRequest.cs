using OwnApt.RestfulProxy.Domain.Enum;
using System;
using System.Collections.Generic;

namespace OwnApt.RestfulProxy.Interface
{
    public interface IRestfulProxyRequest<TRequestDto, TResponseDto>
    {
        #region Properties

        IDictionary<string, IEnumerable<string>> Headers { get; }

        HttpRequestMethod HttpRequestMethod { get; }

        TRequestDto RequestDto { get; }

        Uri RequestUri { get; }

        #endregion Properties
    }
}