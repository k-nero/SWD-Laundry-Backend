using SWD_Laundry_Backend.Application.Common.Mappings;
using SWD_Laundry_Backend.Domain.Entities;
using SWD_Laundry_Backend.Domain.Enums;

namespace SWD_Laundry_Backend.Application.PaymentMethods.Queries;
public class PaymentMethodDto : IMapFrom<PaymentMethod>
{    
    public string Name { get; init; }
    public string? Description { get; set; }
}
