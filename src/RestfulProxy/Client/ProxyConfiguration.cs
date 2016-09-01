using OwnApt.RestfulProxy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OwnApt.RestfulProxy.Domain.Interface;

namespace OwnApt.RestfulProxy.Client
{
    public class ProxyConfiguration : IProxyConfiguration
    {
        public ProxyConfiguration(string appId, string secretKey, ICacheProvider cacheProvider)
        {
            this.AppId = appId;
            this.SecretKey = secretKey;
            this.CacheProvider = cacheProvider;
        }

        public ProxyConfiguration(string appId, string secretKey) : this(appId, secretKey, null)
        {
        }

        public string AppId { get; }

        public ICacheProvider CacheProvider { get; }

        public string SecretKey { get; }
    }
}
