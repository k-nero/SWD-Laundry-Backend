using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;
public class OrderHistoryValidator : AbstractValidator<OrderHistoryModel>
{
    public OrderHistoryValidator()
    {

        RuleFor(x => x.OrderStatus)
            .IsInEnum().WithMessage("Invalid OrderStatus.");

        RuleFor(x => x.DeliveryStatus)
            .IsInEnum().WithMessage("Invalid DeliveryStatus.");

        RuleFor(x => x.LaundryStatus)
            .IsInEnum().WithMessage("Invalid LaundryStatus.");
    }
}
