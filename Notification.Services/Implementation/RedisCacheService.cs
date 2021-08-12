using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Notification.Services.Contracts;
using Notification.Services.Options;
using System;
using System.Text;

namespace Notification.Services.Implementation
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions cacheOptions;

        public RedisCacheService(IDistributedCache distributedCache, IOptions<RedisOptions> options)
        {
            TimeSpan slidingExpirationTime, absoluteExpirationTime;
            _cache = distributedCache;
            if (!TimeSpan.TryParse(options.Value.AbsoluteExpireTime, out absoluteExpirationTime))
                absoluteExpirationTime = TimeSpan.FromHours(1);
            if (!TimeSpan.TryParse(options.Value.AbsoluteExpireTime, out slidingExpirationTime))
                slidingExpirationTime = TimeSpan.FromMinutes(10);
            cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationTime,
                SlidingExpiration = slidingExpirationTime
            };
        }

        public T Add<T>(string key, T value)
        {
            _cache.SetString(key, JsonConvert.SerializeObject(value), cacheOptions);

            return value;
        }

        public T Get<T>(string key)
        {
            var value = _cache.GetString(key);

            if (value != null)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            return default;
        }
    }
}
