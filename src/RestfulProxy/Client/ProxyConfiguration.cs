using OwnApt.RestfulProxy.Interface;

namespace OwnApt.RestfulProxy.Client
{
    public class ProxyConfiguration : IProxyConfiguration
    {
        #region Public Constructors

        public ProxyConfiguration(string appId, string secretKey)
        {
            this.AppId = appId;
            this.SecretKey = secretKey;
        }

        #endregion Public Constructors

        #region Public Properties

        public string AppId { get; }

        public string SecretKey { get; }

        #endregion Public Properties
    }
}
