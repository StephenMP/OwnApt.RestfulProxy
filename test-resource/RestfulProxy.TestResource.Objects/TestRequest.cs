using OwnApt.RestfulProxy.Domain.Enum;
using OwnApt.RestfulProxy.Interface;
using System;
using System.Collections.Generic;

namespace RestfulProxy.TestResource.Objects
{
    public class TestRequest : IProxyRequest<TestRequestDto, TestResponseDto>
    {
        #region Public Constructors

        public TestRequest(Uri baseUri, HttpRequestMethod requestMethod, TestRequestDto requestDto, bool secured)
        {
            var securedROuteAppendix = secured ? "secure" : "unsecure";
            this.RequestUri = new Uri($"{baseUri.AbsoluteUri.TrimEnd('/')}/api/{securedROuteAppendix}");
            this.HttpRequestMethod = requestMethod;
            this.Headers = new Dictionary<string, IEnumerable<string>>
            {
                { "Accept", new string[] { "application/json" } }
            };

            if (requestDto != null)
            {
                this.RequestDto = requestDto;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public IDictionary<string, IEnumerable<string>> Headers { get; }

        public HttpRequestMethod HttpRequestMethod { get; }

        public TestRequestDto RequestDto { get; }

        public Uri RequestUri { get; }

        #endregion Public Properties
    }
}
