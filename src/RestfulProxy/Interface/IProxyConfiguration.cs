using OwnApt.RestfulProxy.Domain.Interface;

namespace OwnApt.RestfulProxy.Interface
{
    public interface IProxyConfiguration
    {
        #region Properties

        string AppId { get; }
        ICacheProvider CacheProvider { get; }
        string SecretKey { get; }

        #endregion Properties
    }
}