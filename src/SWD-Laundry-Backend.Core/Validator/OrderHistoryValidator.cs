using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;
public class OrderHistoryValidator : AbstractValidator<OrderHistoryModel>
{
    public OrderHistoryValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required when applicable.");

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Message is required when applicable.");

        RuleFor(x => x.OrderStatus)
            .IsInEnum().WithMessage("Invalid OrderStatus.");

        RuleFor(x => x.DeliveryStatus)
            .IsInEnum().WithMessage("Invalid DeliveryStatus.");

        RuleFor(x => x.LaundryStatus)
            .IsInEnum().WithMessage("Invalid LaundryStatus.");
    }
}
