using SWD_Laundry_Backend.Mapper;

namespace SWD_Laundry_Backend.Extensions;


public static class AutoMapperExtension
{
    public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => 
        { 
            cfg.AddProfile<BuildingMapperProfile>();
        });
        return services;
    }
}



