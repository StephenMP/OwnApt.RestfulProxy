using OwnApt.RestfulProxy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnApt.RestfulProxy.Client
{
    public class ProxyConfiguration : IProxyConfiguration
    {
        public ProxyConfiguration(string appId, string secretKey)
        {
            this.AppId = appId;
            this.SecretKey = secretKey;
        }

        public string AppId { get; }

        public string SecretKey { get; }
    }
}
