using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;

public class OrderValidator : AbstractValidator<OrderModel>
{
    public OrderValidator() 
    {
        RuleFor(x => x.OrderDate)
            .NotNull().WithMessage("OrderDate is required.");

        RuleFor(x => x.DeliveryTimeFrame)
            .IsInEnum().WithMessage("Invalid DeliveryTimeFrame.");

        RuleFor(x => x.ExpectedFinishDate)
            .NotNull().WithMessage("ExpectedFinishDate is required.")
            .GreaterThan(x => x.OrderDate)
            .WithMessage("ExpectedFinishDate must be greater than OrderDate.");



        RuleFor(x => x.PaymentType)
            .IsInEnum().WithMessage("Invalid PaymentType.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required when applicable.");

        RuleFor(x => x.Amount)
            .GreaterThan((short)0).WithMessage("Amount must be greater than 0.");

        RuleFor(x => x.TotalPrice)
            .GreaterThan(0).WithMessage("TotalPrice must be greater than 0.");
    }
}