using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Vehicle.Doctor.System.API.Applications.Configurations;

namespace Vehicle.Doctor.System.API.Applications.Helpers;

public class CacheHelper
{
    public const string CacheKey = "VDS";
    private readonly IDistributedCache _cache;
    private readonly ApplicationSetting _setting;

    public CacheHelper(IDistributedCache cache, ApplicationSetting setting)
    {
        _cache = cache;
        _setting = setting;
    }

    public async Task SetAsync<T>(
        string key,
        T data,
        TimeSpan? absoluteExpireTime = null,
        TimeSpan? slidingExpireTime = null,
        CancellationToken cancellationToken = default)
    {
        if (!_setting.Redis.Enabled) return;
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(86400),
            SlidingExpiration = slidingExpireTime
        };
        var jsonData = JsonConvert.SerializeObject(data);
        await _cache.SetStringAsync(GenKeyCache(key), jsonData, options, token: cancellationToken);
    }

    public async Task<T?> GetAsync<T>(
        string key, CancellationToken cancellationToken = default)
    {
        if (!_setting.Redis.Enabled) return default;
        var jsonData = await _cache.GetStringAsync(GenKeyCache(key), token: cancellationToken);

        return jsonData is null ? default : JsonConvert.DeserializeObject<T>(jsonData);
    }

    private static string GenKeyCache(string key)
    {
        return $"{CacheKey}:{key}";
    }

    public async Task InvalidateAsync(string key,
        CancellationToken cancellationToken = default)
    {
        if (!_setting.Redis.Enabled) return;
        await _cache.RemoveAsync(GenKeyCache(key), cancellationToken);
    }
}