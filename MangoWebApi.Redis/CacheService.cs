﻿using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MangoWebApi.Redis
{
    public static class CacheService
    {
        public static async Task SetRecordAsync<TEntity>(this IDistributedCache cache,
            string recordId,
            TEntity data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }
        public static async Task<TEntity> GetRecordAsync<TEntity>(
            this IDistributedCache cache,
            string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);
            if (jsonData is null)
            {
                return default(TEntity);
            }
            return JsonSerializer.Deserialize<TEntity>(jsonData);

        }
    }
}
