using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;

namespace SocialNetwork.DataAccess.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public CacheService(IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer)
        {
            _distributedCache = distributedCache;
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task DeleteKeyAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }

        public async Task<string> GetValueAsync(string key)
        {
            var cacheValue = await _distributedCache.GetStringAsync(key);
            return string.IsNullOrEmpty(cacheValue) ? null : cacheValue;
        }

        public async Task SetKeyAsync(string key, object value, TimeSpan timeOut)
        {
            if (value == null) return;

            string serializerObject = JsonConvert.SerializeObject(value, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            await _distributedCache.SetStringAsync(key, serializerObject, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = timeOut
            });
        }
    }
}
