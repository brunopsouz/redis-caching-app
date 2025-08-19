using App.Domain.Services.Cache;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace App.Infrastructure.Services.Cache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache? _cache;

        public RedisCacheService(IDistributedCache cache) => _cache = cache;

        public async Task<T> GetAsync<T>(string key)
        {
            var data = await _cache!.GetStringAsync(key);

            if(data is null)
                return default(T)!;

            return JsonSerializer.Deserialize<T>(data)!;
        }

        public async Task SetData<T>(string key, T data)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),

                //faltando pouco tempo para expirar se os dados são acessados novamente
                //então SlidingExpiration adiciona tempo adicional no cache.
                SlidingExpiration = TimeSpan.FromMinutes(1)

            };

            await _cache?.SetStringAsync(key, JsonSerializer.Serialize(data), options)!;
        }
    }
}
