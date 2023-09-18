using MediatR;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.Wallets.Commands.CreateWallet;
public class CreateWalletCommand : IRequest<int>
{
    public double Balance { get; init; }
}

public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateWalletCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        var entity = new Wallet
        {
            Balance = request.Balance
        };

        _context.Get<Wallet>().Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}