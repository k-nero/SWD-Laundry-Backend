using Newtonsoft.Json;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Core.Enum;

//[JsonConverter(typeof(EnumConverter<TripType>))]
public enum TripType
{
    CollectFromCustomer = 0,
    DeliveryToCustomer = 1,
}