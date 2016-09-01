using OwnApt.RestfulProxy.Domain.Enum;
using System;
using System.Collections.Generic;

namespace OwnApt.RestfulProxy.Interface
{
    public interface IProxyRequest<TRequestDto, TResponseDto>
    {
        #region Public Properties

        IDictionary<string, IEnumerable<string>> Headers { get; }

        HttpRequestMethod HttpRequestMethod { get; }

        TRequestDto RequestDto { get; }

        Uri RequestUri { get; }

        #endregion Public Properties
    }
}
