namespace SWD_Laundry_Backend.Extensions;


public static class AutoMapperExtension
{
    public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => 
        { 

        });
        return services;
    }
}



