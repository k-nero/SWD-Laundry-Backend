using FluentValidation;

namespace SWD_Laundry_Backend.Application.Wallets.Commands.UpdateWallet;
public class UpdateWalletCommandValidator : AbstractValidator<UpdateWalletCommand>
{
    public UpdateWalletCommandValidator()
    {
        RuleFor(v => v.Balance).GreaterThan(0);
    }
}
