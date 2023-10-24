using System.Collections.Generic;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StackExchange.Redis;
using SWD_Laundry_Backend.Contract.Repository.Base_Interface;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Repository.Base;
public class BaseCacheLayer<T> : IBaseCacheLayer<T> where T : BaseEntity, new()
{
    private readonly IDistributedCache distributedCache;
    private readonly IMemoryCache memoryCache;
    private readonly IConnectionMultiplexer connectionMultiplexer;
    private readonly IDatabase cacheDatabase;
    private readonly IServer[] cacheServer;

    public BaseCacheLayer(IMemoryCache memoryCache, IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer)
    {
        this.memoryCache = memoryCache;
        this.distributedCache = distributedCache;
        this.connectionMultiplexer = connectionMultiplexer;
        cacheDatabase = this.connectionMultiplexer.GetDatabase();
        cacheServer = this.connectionMultiplexer.GetServers();
    }

    public BaseCacheLayer(IDistributedCache distributedCache)
    {
        this.distributedCache = distributedCache;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        var key = entity.Id;
        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(8))
            .SetAbsoluteExpiration(DateTime.Now.AddHours(24));
        var json = ObjHelper.ToJsonString(entity);
        await distributedCache.SetStringAsync(key, json, options, cancellationToken);
        return;
    }



    public async Task<T?> GetSingleAsync(string key, CancellationToken cancellationToken = default)
    {
        var json = await distributedCache.GetStringAsync(key, cancellationToken);
        if (json != null)
        {
            T? entity = JsonConvert.DeserializeObject<T>(json);

            return entity;
        }
        return null;
    }

    public async Task RefreshKeyAsync(string key, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => distributedCache.Refresh(key), cancellationToken);
        return;
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await distributedCache.RemoveAsync(key, cancellationToken);
        return;
    }

    public async Task<string[]> GetAvailableKey(CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
            {
                ISet<string>? keys = null;
                foreach (var server in cacheServer)
                {
                    foreach (string? key in server.Keys().ToArray())
                    {
                        if (key != null)
                        {
                            keys.Add(key);
                        }
                    }
                }
                return keys.ToArray();
            });
    }
}

