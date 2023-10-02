using Invedia.DI.Attributes;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Repository.Infrastructure;

namespace SWD_Laundry_Backend.Repository.Repository;
[ScopedDependency(ServiceType = typeof(IBuildingCacheLayer))]
public class BuildingCacheLayer : CacheLayer<Building>, IBuildingCacheLayer
{
    public BuildingCacheLayer(IMemoryCache memoryCache, IDistributedCache distributedCache) : base(memoryCache, distributedCache)
    {

    }
}
