namespace OwnApt.RestfulProxy.Domain.Interface
{
    public interface ICacheProvider
    {
        #region Methods

        bool ContainsToken(string key);

        void InsertToken<TToken>(string key, TToken token);

        TToken RetrieveToken<TToken>(string key);

        #endregion Methods
    }
}