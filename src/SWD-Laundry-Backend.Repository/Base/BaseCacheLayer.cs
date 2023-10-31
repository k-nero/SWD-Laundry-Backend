using System.Collections.Generic;
using Dasync.Collections;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StackExchange.Redis;
using SWD_Laundry_Backend.Contract.Repository.Base_Interface;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Repository.Base;
public class BaseCacheLayer<T> : IBaseCacheLayer<T> where T : BaseEntity, new()
{
    private readonly IDistributedCache _distributedCache;
    private readonly IMemoryCache _memoryCache;
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly IDatabase _cacheDatabase;
    private readonly IServer[] _cacheServer;

    public BaseCacheLayer(IMemoryCache memoryCache, IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer)
    {
        _memoryCache = memoryCache;
        _distributedCache = distributedCache;
        _connectionMultiplexer = connectionMultiplexer;
        _cacheDatabase = _connectionMultiplexer.GetDatabase();
        _cacheServer = _connectionMultiplexer.GetServers();
    }

    public async Task AddSingleAsync(T entity, CancellationToken cancellationToken = default)
    {
        var key = entity.Id;
        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(8))
            .SetAbsoluteExpiration(DateTime.Now.AddHours(24));
        var json = ObjHelper.ToJsonString(entity);
        await _distributedCache.SetStringAsync(key, json, options, cancellationToken);
        return;
    }

    public async Task<T?> GetSingleAsync(string key, CancellationToken cancellationToken = default)
    {
        var json = await _distributedCache.GetStringAsync(key, cancellationToken);
        if (json != null)
        {
            T? entity = JsonConvert.DeserializeObject<T>(json);

            return entity;
        }
        return null;
    }

    public async Task RefreshKeyAsync(string key, CancellationToken cancellationToken = default)
    {
        await  _distributedCache.RefreshAsync(key, cancellationToken);
        return;
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await _distributedCache.RemoveAsync(key, cancellationToken);
        //await _cacheDatabase.KeyDeleteAsync(key, CommandFlags.FireAndForget);
        return;
    }

    public async Task<string[]> GetAvailableKey(CancellationToken cancellationToken = default)
    {
        return await Task.Run(async () =>
            {
                HashSet<string>? keys = new();
                foreach (var server in _cacheServer)
                {
                    var keysTemp = await server.KeysAsync().ToArrayAsync();
                    foreach (string? key in keysTemp)
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

    public async Task AddMultipleAsync(string key, PaginatedList<T> entities, CancellationToken cancellationToken = default)
    {
        key = typeof(T).Name + ":" + key;
        var json = JsonConvert.SerializeObject(entities);
        var options = new DistributedCacheEntryOptions()
       .SetSlidingExpiration(TimeSpan.FromHours(8))
       .SetAbsoluteExpiration(DateTime.Now.AddHours(24));
        await _distributedCache.SetStringAsync(key, json, options, cancellationToken);
        
        return;
    }

    public async Task<PaginatedList<T>?> GetMultipleAsync(string keys, CancellationToken cancellationToken = default)
    {
        keys = typeof(T).Name + ":" + keys;
        var json = await _distributedCache.GetStringAsync(keys, cancellationToken);
        if (json != null)
        {
            PaginatedList<T>? entities = JsonConvert.DeserializeObject<PaginatedList<T>?>(json);
            return entities;
        }
        return null;
    }

    public async Task RemoveMultipleAsync(string[] keyPrefix, CancellationToken cancellationToken = default)
    {
        string prefix = keyPrefix;
        var availableKeys = await GetAvailableKey(cancellationToken);
        foreach (var key in availableKeys)
        {
            foreach(var prefix in keyPrefix)
            {
                if (key.Contains(prefix))
                {
                    await RemoveAsync(key, cancellationToken);
                }
            }
        }
    }
}

