using FluentValidation;
using SWD_Laundry_Backend.Application.Common.Interfaces;

namespace SWD_Laundry_Backend.Application.Wallets.Commands.CreateWallet;
public class CreateWalletCommandValidator : AbstractValidator<CreateWalletCommand>
{
    private readonly IApplicationDbContext _context;
    
    public CreateWalletCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        
        RuleFor(v => v.Balance).GreaterThan(0);
    }
}
