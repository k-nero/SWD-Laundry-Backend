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

    public Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        var key = entity.Id;
        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
            .SetAbsoluteExpiration(DateTime.Now.AddHours(24));
        var json = ObjHelper.ToJsonString(entity);
        return distributedCache.SetStringAsync(key, json, options, cancellationToken);
    }

    public Task<T?> GetSingleAsync(string key, CancellationToken cancellationToken = default)
    {
        var json = distributedCache.GetString(key);
        if (json != null)
        {
            T? entity = JsonConvert.DeserializeObject<T>(json);
            return Task.FromResult(entity);
        }
        return Task.FromResult<T?>(null);
    }
}

