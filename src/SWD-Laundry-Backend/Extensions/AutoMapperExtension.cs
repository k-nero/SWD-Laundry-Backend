using SWD_Laundry_Backend.Mapper;

namespace SWD_Laundry_Backend.Extensions;


public static class AutoMapperExtension
{
    public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => 
        { 
            cfg.AddProfile<BuildingMapperProfile>();
            cfg.AddProfile<LaundryStoreMapperProfile>();
            cfg.AddProfile<OrderHistoryMapperProfile>();
            cfg.AddProfile<OrderMapperProfile>();
            cfg.AddProfile<StaffTripMapperProfile>();
            cfg.AddProfile<TimeScheduleMapperProfile>();
            cfg.AddProfile<TransactionMapperProfile>();
            cfg.AddProfile<WalletMapperProfile>();
        });
        return services;
    }
}



