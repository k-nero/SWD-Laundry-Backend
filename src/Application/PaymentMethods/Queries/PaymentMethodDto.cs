using SWD_Laundry_Backend.Application.Common.Mappings;
using SWD_Laundry_Backend.Domain.Entities;
using SWD_Laundry_Backend.Domain.Enums;

namespace SWD_Laundry_Backend.Application.PaymentMethods.Queries;
public class PaymentMethodDto : IMapFrom<PaymentMethod>
{    
    public PaymentType PaymentType { get; set; }
    public string? Description { get; set; }
}
