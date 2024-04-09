namespace SocialNetwork.DataAccess.Services
{
    public interface ICacheService
    {
        Task SetKeyAsync(string key, object value, TimeSpan timeOut);
        Task<string> GetValueAsync(string key);
        Task DeleteKeyAsync(string key);
    }
}
