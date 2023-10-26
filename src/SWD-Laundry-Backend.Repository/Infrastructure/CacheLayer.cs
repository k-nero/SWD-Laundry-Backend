using Invedia.DI.Attributes;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using SWD_Laundry_Backend.Contract.Repository.Base_Interface;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Infrastructure;
using SWD_Laundry_Backend.Repository.Base;

namespace SWD_Laundry_Backend.Repository.Infrastructure;
[ScopedDependency(ServiceType = typeof(ICacheLayer<>))]
public class CacheLayer<T> : BaseCacheLayer<T>, IBaseCacheLayer<T>,  ICacheLayer<T> where T : BaseEntity, new()
{
    public CacheLayer(IMemoryCache memoryCache, IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer) : base(memoryCache, distributedCache, connectionMultiplexer)
    {

    }
}
