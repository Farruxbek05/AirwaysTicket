using StackExchange.Redis;

namespace Airways.Application.Services.Impl
{
    public class RedisService
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task<string> GetValueAsync(string key)
        {
            var db = _redis.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task SetValueAsync(string key, string value, TimeSpan expiry)
        {
            var db = _redis.GetDatabase();
            await db.StringSetAsync(key, value, expiry);
        }

    }

}
