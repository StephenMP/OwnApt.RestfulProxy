using Microsoft.AspNetCore.Hosting;
using OwnApt.RestfulProxy.Domain.Enum;
using RestfulProxy.TestResource.Api;
using System.Threading.Tasks;
using Xunit;

namespace RestfulProxy.Tests.Component
{
    public class RestfulProxyFeatures
    {
        #region Private Fields

        private RestfulProxySteps steps = new RestfulProxySteps();

        #endregion Private Fields

        #region Public Methods

        [Theory]
        [InlineData(HttpRequestMethod.Delete)]
        [InlineData(HttpRequestMethod.Get)]
        [InlineData(HttpRequestMethod.Head)]
        [InlineData(HttpRequestMethod.Options)]
        [InlineData(HttpRequestMethod.Patch)]
        [InlineData(HttpRequestMethod.Post)]
        [InlineData(HttpRequestMethod.Put)]
        public async Task CanInvokeSecuredRequest(HttpRequestMethod requestMethod)
        {
            this.steps.GivenIHaveABaseUri();
            using (var testHost = SpinUpApi())
            {
                if (requestMethod >= HttpRequestMethod.Patch)
                {
                    this.steps.GivenIHaveARequestDto();
                }

                this.steps.GivenIHaveATestRequest(requestMethod);
                this.steps.GivenIHaveAProxyConfiguration();
                this.steps.GIvenIHaveAProxy();
                await this.steps.WhenIInvokeRequest();
                this.steps.ThenICanVerifyIGotResponse();
            }
        }

        [Theory]
        [InlineData(HttpRequestMethod.Delete)]
        [InlineData(HttpRequestMethod.Get)]
        [InlineData(HttpRequestMethod.Head)]
        [InlineData(HttpRequestMethod.Options)]
        [InlineData(HttpRequestMethod.Patch)]
        [InlineData(HttpRequestMethod.Post)]
        [InlineData(HttpRequestMethod.Put)]
        public async Task CanInvokeUnsecuredRequest(HttpRequestMethod requestMethod)
        {
            this.steps.GivenIHaveABaseUri();
            using (var testHost = SpinUpApi())
            {
                if (requestMethod >= HttpRequestMethod.Patch)
                {
                    this.steps.GivenIHaveARequestDto();
                }

                this.steps.GivenIHaveATestRequest(requestMethod, false);
                this.steps.GivenIHaveAProxyConfiguration();
                this.steps.GIvenIHaveAProxy();
                await this.steps.WhenIInvokeRequest();
                this.steps.ThenICanVerifyIGotResponse();
            }
        }

        [Theory]
        [InlineData(HttpRequestMethod.Delete)]
        [InlineData(HttpRequestMethod.Options)]
        [InlineData(HttpRequestMethod.Patch)]
        [InlineData(HttpRequestMethod.Post)]
        [InlineData(HttpRequestMethod.Put)]
        public async Task CannotInvokeRequestDueToBadResource(HttpRequestMethod requestMethod)
        {
            this.steps.GivenIHaveABadBaseUri();
            using (var testHost = SpinUpApi())
            {
                if (requestMethod >= HttpRequestMethod.Patch)
                {
                    this.steps.GivenIHaveARequestDto();
                }

                this.steps.GivenIHaveATestRequest(requestMethod);
                this.steps.GivenIHaveAProxyConfiguration();
                this.steps.GIvenIHaveAProxy();
                await this.steps.WhenIInvokeRequest();
                this.steps.ThenICanVerifyIDidNotInvoke();
            }
        }

        #endregion Public Methods

        #region Private Methods

        private IWebHost SpinUpApi()
        {
            return new WebHostBuilder()
                        .UseKestrel()
                        .UseStartup<Startup>()
                        .Start(this.steps.baseUri.AbsoluteUri);
        }

        #endregion Private Methods
    }
}
