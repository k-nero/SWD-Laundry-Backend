using FluentValidation;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core.Validator;
public class TransactionValidator : AbstractValidator<TransactionModel>
{
    public TransactionValidator()
    {
        RuleFor(x => x.PaymentType)
           .IsInEnum().WithMessage("Invalid PaymentType.");

        RuleFor(x => x.TransactionType)
            .IsInEnum().WithMessage("Invalid TransactionType.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0.");

        //RuleFor(x => x.Description)
        //    .NotEmpty().WithMessage("Description is required when applicable.");

        //RuleFor(x => x.WalletID)
        //    .NotEmpty().WithMessage("WalletID is required when applicable.");

        //RuleFor(x => x.PaymentID)
        //    .NotEmpty().WithMessage("PaymentID is required when applicable.");
    }
}
