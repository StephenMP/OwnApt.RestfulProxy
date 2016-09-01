
namespace OwnApt.RestfulProxy.Interface
{
    public interface IProxyConfiguration
    {
        #region Properties

        string AppId { get; }
        string SecretKey { get; }

        #endregion Properties
    }
}