using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SWD_Laundry_Backend.Contract.Repository.Base_Interface;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Repository.Base;
public class BaseCacheLayer<T> : IBaseCacheLayer<T> where T : BaseEntity, new()
{
    private readonly IDistributedCache distributedCache;
    private readonly IMemoryCache memoryCache;

    public BaseCacheLayer(IMemoryCache memoryCache, IDistributedCache distributedCache)
    {
        this.memoryCache = memoryCache;
        this.distributedCache = distributedCache;
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
}

