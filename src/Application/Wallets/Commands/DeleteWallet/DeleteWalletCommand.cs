using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.Wallets.Commands.DeleteWallet;
public class DeleteWalletCommand : IRequest<int>
{
    public int Id { get; init; }
}

public class DeleteWalletCommandHandler : IRequestHandler<DeleteWalletCommand, int>
{
    private readonly IApplicationDbContext _context;
    public DeleteWalletCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
    {
        var affectedRow = await _context.Get<Wallet>().Where(x => x.Id == request.Id).ExecuteDeleteAsync(cancellationToken);
        return affectedRow;
    }
}
