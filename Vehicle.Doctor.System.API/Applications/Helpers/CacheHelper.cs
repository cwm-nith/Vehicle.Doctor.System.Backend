using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Vehicle.Doctor.System.API.Applications.Helpers;

public static class CacheHelper
{
    public const string CacheKey = "VDS";
    public static async Task SetAsync<T>(this IDistributedCache cache,
        string key,
        T data,
        TimeSpan? absoluteExpireTime = null,
        TimeSpan? slidingExpireTime = null,
        CancellationToken cancellationToken = default)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(86400),
            SlidingExpiration = slidingExpireTime
        };
        var jsonData = JsonConvert.SerializeObject(data);
        await cache.SetStringAsync(GenKeyCache(key), jsonData, options, token: cancellationToken);
    }

    public static async Task<T?> GetAsync<T>(this IDistributedCache cache,
        string key, CancellationToken cancellationToken = default)
    {
        var jsonData = await cache.GetStringAsync(GenKeyCache(key), token: cancellationToken);

        return jsonData is null ? default : JsonConvert.DeserializeObject<T>(jsonData);
    }

    private static string GenKeyCache(string key)
    {
        return $"{CacheKey}:{key}";
    }

    public static async Task InvalidateAsync(this IDistributedCache cache, string key,
        CancellationToken cancellationToken = default)
    {
        await cache.RemoveAsync(GenKeyCache(key), cancellationToken);
    }
}