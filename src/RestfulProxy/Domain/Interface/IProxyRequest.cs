using OwnApt.RestfulProxy.Domain.Enum;
using System;
using System.Collections.Generic;

namespace OwnApt.RestfulProxy.Domain.Interface
{
    public interface IProxyRequest<TRequestDto, TResponseDto>
    {
        #region Public Fields + Properties

        bool AuthorizationRequired { get; }

        IDictionary<string, IEnumerable<string>> Headers { get; }

        HttpRequestMethod Method { get; }

        TRequestDto RequestDto { get; set; }

        Uri Resource { get; }

        #endregion Public Fields + Properties
    }
}
