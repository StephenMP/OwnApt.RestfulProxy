using OwnApt.RestfulProxy.Domain.Enum;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RestfulProxy.Tests.Component
{
    public class RestfulProxyFeatures : IDisposable
    {
        #region Private Fields

        private readonly RestfulProxySteps steps;
        private bool disposedValue;

        #endregion Private Fields

        #region Public Constructors

        public RestfulProxyFeatures()
        {
            this.steps = new RestfulProxySteps();
        }

        #endregion Public Constructors

        #region Public Methods

        [Theory]
        [InlineData(HttpRequestMethod.Delete)]
        [InlineData(HttpRequestMethod.Get)]
        [InlineData(HttpRequestMethod.Head)]
        [InlineData(HttpRequestMethod.Options)]
        [InlineData(HttpRequestMethod.Patch)]
        [InlineData(HttpRequestMethod.Post)]
        [InlineData(HttpRequestMethod.Put)]
        public async Task CanInvokeSecuredRequestAsync(HttpRequestMethod requestMethod)
        {
            this.steps.GivenIHaveATestApi();

            if (requestMethod >= HttpRequestMethod.Patch)
            {
                this.steps.GivenIHaveARequestDto();
            }

            this.steps.GivenIHaveATestRequest(requestMethod);
            this.steps.GivenIHaveAProxyConfiguration();
            this.steps.GIvenIHaveAProxy();
            await this.steps.WhenIInvokeRequestAsync();
            this.steps.ThenICanVerifyIGotResponse();
        }

        [Theory]
        [InlineData(HttpRequestMethod.Delete)]
        [InlineData(HttpRequestMethod.Get)]
        [InlineData(HttpRequestMethod.Head)]
        [InlineData(HttpRequestMethod.Options)]
        [InlineData(HttpRequestMethod.Patch)]
        [InlineData(HttpRequestMethod.Post)]
        [InlineData(HttpRequestMethod.Put)]
        public async Task CanInvokeUnsecuredRequestAsync(HttpRequestMethod requestMethod)
        {
            this.steps.GivenIHaveATestApi();

            if (requestMethod >= HttpRequestMethod.Patch)
            {
                this.steps.GivenIHaveARequestDto();
            }

            this.steps.GivenIHaveATestRequest(requestMethod, false);
            this.steps.GivenIHaveAProxyConfiguration();
            this.steps.GIvenIHaveAProxy();
            await this.steps.WhenIInvokeRequestAsync();
            this.steps.ThenICanVerifyIGotResponse();
        }

        [Theory]
        [InlineData(HttpRequestMethod.Delete)]
        [InlineData(HttpRequestMethod.Options)]
        [InlineData(HttpRequestMethod.Patch)]
        [InlineData(HttpRequestMethod.Post)]
        [InlineData(HttpRequestMethod.Put)]
        public async Task CannotInvokeRequestDueToBadResourceAsync(HttpRequestMethod requestMethod)
        {
            this.steps.GivenIHaveATestApi();
            this.steps.GivenIHaveABadBaseUri();

            if (requestMethod >= HttpRequestMethod.Patch)
            {
                this.steps.GivenIHaveARequestDto();
            }

            this.steps.GivenIHaveATestRequest(requestMethod);
            this.steps.GivenIHaveAProxyConfiguration();
            this.steps.GIvenIHaveAProxy();
            await this.steps.WhenIInvokeRequestAsync();
            this.steps.ThenICanVerifyIDidNotInvoke();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.steps?.Dispose();
                }

                disposedValue = true;
            }
        }

        #endregion Protected Methods
    }
}
