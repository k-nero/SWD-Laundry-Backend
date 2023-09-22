using FluentValidation;

namespace SWD_Laundry_Backend.Application.PaymentMethods.Commands.CreatePaymentMethod;
public class CreatePaymentMethodCommandValdiator : AbstractValidator<CreatePaymentMethodCommand>
{

    public CreatePaymentMethodCommandValdiator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Description);
    }
}
