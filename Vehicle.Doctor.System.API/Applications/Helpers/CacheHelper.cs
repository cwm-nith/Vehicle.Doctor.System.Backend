﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Vehicle.Doctor.System.API.Applications.Helpers;

public static class CacheHelper
{
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
        await cache.SetStringAsync(key, jsonData, options, token: cancellationToken);
    }

    public static async Task<T?> GetAsync<T>(this IDistributedCache cache,
        string key, CancellationToken cancellationToken = default)
    {
        var jsonData = await cache.GetStringAsync(key, token: cancellationToken);

        return jsonData is null ? default : JsonConvert.DeserializeObject<T>(jsonData);
    }

    public static async Task Invalidate(this IDistributedCache cache, string key,
        CancellationToken cancellationToken = default)
    {
        await cache.RemoveAsync(key, cancellationToken);
    }
}