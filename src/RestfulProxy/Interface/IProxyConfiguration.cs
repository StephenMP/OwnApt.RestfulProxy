namespace OwnApt.RestfulProxy.Interface
{
    public interface IProxyConfiguration
    {
        #region Public Properties

        string AppId { get; }
        string SecretKey { get; }

        #endregion Public Properties
    }
}
