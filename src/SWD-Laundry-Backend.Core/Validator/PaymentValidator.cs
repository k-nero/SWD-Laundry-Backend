using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;
public class PaymentValidator : AbstractValidator<PaymentModel>
{
    public PaymentValidator()
    {
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be positive number");
    }
}
