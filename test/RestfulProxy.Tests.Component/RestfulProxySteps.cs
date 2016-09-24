using OwnApt.RestfulProxy.Client;
using OwnApt.RestfulProxy.Domain.Enum;
using OwnApt.RestfulProxy.Interface;
using OwnApt.TestEnvironment.Environment;
using RestfulProxy.TestResource.Api;
using RestfulProxy.TestResource.Objects;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RestfulProxy.Tests.Component
{
    internal class RestfulProxySteps : IDisposable
    {
        #region Internal Fields

        internal Uri baseUri;

        #endregion Internal Fields

        #region Private Fields

        private readonly string appId = "d63c7a5913dd472481e1d88bbc2bc420";
        private readonly string secretKey = "qlTOlX/p2tyQd1k/0T4nLfwB/Lk=";
        private bool disposedValue;
        private IProxy proxy;
        private IProxyConfiguration proxyConfiguration;
        private TestRequest proxyRequest;
        private IProxyResponse<TestResponseDto> proxyResponse;
        private TestRequestDto requestDto;
        private OwnAptTestEnvironment testEnvironment;

        #endregion Private Fields

        #region Public Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

        #region Internal Methods

        internal void GivenIHaveABadBaseUri()
        {
            this.baseUri = new Uri("http://www.this.does/not/exit");
        }

        internal void GIvenIHaveAProxy()
        {
            this.proxy = new Proxy(this.proxyConfiguration);
        }

        internal void GivenIHaveAProxyConfiguration()
        {
            this.proxyConfiguration = new ProxyConfiguration(this.appId, this.secretKey);
        }

        internal void GivenIHaveARequestDto()
        {
            this.requestDto = new TestRequestDto { Value = "Goodbye" };
        }

        internal void GivenIHaveATestApi()
        {
            this.testEnvironment = new OwnAptTestEnvironmentBuilder()
                                    .AddResourceWebService<Startup>()
                                    .BuildEnvironment();
            
            this.baseUri = this.testEnvironment.GetResourceWebService<Startup>().BaseUri;
        }

        internal void GivenIHaveATestRequest(HttpRequestMethod requestMethod, bool secured = true)
        {
            this.proxyRequest = new TestRequest(this.baseUri, requestMethod, this.requestDto, secured);
        }

        internal void ThenICanVerifyIDidNotInvoke()
        {
            Assert.NotNull(this.proxyResponse);
            Assert.False(this.proxyResponse.IsSuccessfulStatusCode);
        }

        internal void ThenICanVerifyIGotResponse()
        {
            Assert.NotNull(this.proxyResponse);

            Assert.True(this.proxyResponse.IsSuccessfulStatusCode);

            if (this.proxyRequest.HttpRequestMethod == HttpRequestMethod.Head)
            {
                return;
            }

            Assert.NotNull(this.proxyResponse.ResponseDto);
            Assert.NotNull(this.proxyResponse.ResponseDto.Value);

            if (this.proxyRequest.HttpRequestMethod >= HttpRequestMethod.Patch)
            {
                Assert.Equal("Goodbye", this.proxyResponse.ResponseDto.Value);
            }
            else
            {
                Assert.Equal("Hello", this.proxyResponse.ResponseDto.Value);
            }
        }

        internal async Task WhenIInvokeRequestAsync()
        {
            this.proxyResponse = await this.proxy.InvokeAsync(this.proxyRequest);
        }

        #endregion Internal Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.testEnvironment?.Dispose();
                }

                disposedValue = true;
            }
        }

        #endregion Protected Methods
    }
}
