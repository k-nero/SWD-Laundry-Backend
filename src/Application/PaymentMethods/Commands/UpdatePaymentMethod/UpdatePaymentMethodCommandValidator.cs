using FluentValidation;

namespace SWD_Laundry_Backend.Application.PaymentMethods.Commands.UpdatePaymentMethod;
public class UpdatePaymentMethodCommandValidator : AbstractValidator<UpdatePaymentMethodCommand>
{
    public UpdatePaymentMethodCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Description);
    }
}
