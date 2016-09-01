using OwnApt.RestfulProxy.Client;
using OwnApt.RestfulProxy.Domain.Enum;
using OwnApt.RestfulProxy.Interface;
using RestfulProxy.TestResource.Objects;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xunit;

namespace RestfulProxy.Tests.Component
{
    internal class RestfulProxySteps
    {
        #region Internal Fields

        internal Uri baseUri;

        #endregion Internal Fields

        #region Private Fields

        private string appId = "d63c7a5913dd472481e1d88bbc2bc420";
        private IProxy proxy;
        private IProxyConfiguration proxyConfiguration;
        private TestRequest proxyRequest;
        private IProxyResponse<TestResponseDto> proxyResponse;
        private TestRequestDto requestDto;
        private string secretKey = "qlTOlX/p2tyQd1k/0T4nLfwB/Lk=";

        #endregion Private Fields

        #region Internal Methods

        internal void GivenIHaveABadBaseUri()
        {
            this.baseUri = new Uri("http://www.this.does/not/exit");
        }

        internal void GivenIHaveABaseUri()
        {
            this.baseUri = new Uri($"http://localhost:{GetFreeTcpPort()}");
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

            // HEAD is not allowed to return a message body, so we are done testing
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

        internal async Task WhenIInvokeRequest()
        {
            this.proxyResponse = await this.proxy.InvokeAsync(this.proxyRequest);
        }

        #endregion Internal Methods

        #region Private Methods

        private static int GetFreeTcpPort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);

            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();

            return port;
        }

        #endregion Private Methods
    }
}
