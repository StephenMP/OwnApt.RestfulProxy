# RestfulProxy #
## Purpose ##
This package is an abstraction on the communication between OwnApt clients and OwnApt APIs. The goal is to simplify such communication by providing native HMAC authentication ability as well as communication via DTOs.

## Usage Example ##
Assume that there exists an API with the route **http://localhost:5000/api/secure** with a **GET** method that returns a DTO containing a string property named **Value** as such:


```
#!json

{
    "value":"SOME VALUE HERE"
}
```


Below is a simple example of using the RestfulProxy to issue a GET request to such API at the given route:

```
#!c#

using OwnApt.RestfulProxy.Client;
using OwnApt.RestfulProxy.Domain.Enum;
using OwnApt.RestfulProxy.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ApiTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ProxyConfiguration("A_VALID_APPID_HERE", "A_VALID_SECRET_KEY_HERE");
            var proxy = new Proxy(config);
            var request = new ProxyRequest("http://localhost:5000");

            var response = proxy.InvokeAsync(request).Result;
        }

        public class ProxyRequest : IProxyRequest<Missing, ResponseDto>
        {
            public IDictionary<string, IEnumerable<string>> Headers { get; }
            public HttpRequestMethod HttpRequestMethod { get; }
            public Missing RequestDto { get; }
            public Uri RequestUri { get; }

            public ProxyRequest(string baseUri)
            {
                this.HttpRequestMethod = HttpRequestMethod.Get;
                this.RequestUri = new Uri($"{baseUri.TrimEnd('/')}/api/secure");
                this.Headers = new Dictionary<string, IEnumerable<string>>
                {
                    { "Accept", new string [] { "application/json" } }
                };
            }
        }

        public class ResponseDto
        {
            public string Value { get; set; }
        }
    }
}
```

