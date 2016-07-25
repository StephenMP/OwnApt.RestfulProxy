using OwnApt.Authentication.Domain.Interface;
using OwnApt.Authentication.Domain.Service;
using OwnApt.RestfulProxy.Interface;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Domain.Handlers
{
    internal sealed class HmacDelegatingHandler : DelegatingHandler
    {
        #region Fields

        private string cacheKey;
        private IHmacService hmacService;
        private IRestfulProxyConfiguration proxyConfiguration;

        #endregion Fields

        #region Constructors

        public HmacDelegatingHandler(IRestfulProxyConfiguration proxyConfiguration)
        {
            this.hmacService = new HmacService();
            this.proxyConfiguration = proxyConfiguration;
            this.cacheKey = $"token-hmac-{proxyConfiguration.AppId}";
        }

        #endregion Constructors

        #region Methods

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var hmacString = this.RetrieveToken();

            if (string.IsNullOrWhiteSpace(hmacString))
            {
                var appId = this.proxyConfiguration.AppId;
                var secretKey = this.proxyConfiguration.SecretKey;
                var httpMethod = request.Method.Method;
                var requestBody = await request.Content.ReadAsStringAsync();
                hmacString = await hmacService.CreateHmacStringAsync(appId, secretKey, httpMethod, requestBody);
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("amx", hmacString);
            return await base.SendAsync(request, cancellationToken);
        }

        private string RetrieveToken()
        {
            if (this.proxyConfiguration.CacheProvider != null && this.proxyConfiguration.CacheProvider.ContainsToken(this.cacheKey))
            {
                return this.proxyConfiguration.CacheProvider.RetrieveToken<string>(this.cacheKey);
            }

            return null;
        }

        #endregion Methods
    }
}