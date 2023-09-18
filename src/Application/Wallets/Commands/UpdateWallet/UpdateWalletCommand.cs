using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.Wallets.Commands.UpdateWallet;
public class UpdateWalletCommand : IRequest<int>
{
    public int Id { get; set; }
    public double Balance { get; set; }
}

public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, int>
{
    private readonly IApplicationDbContext _context;
    public UpdateWalletCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
    {
        int affectedRow = await _context.Get<Wallet>().Where(x => x.Id == request.Id).ExecuteUpdateAsync(x =>
        x.SetProperty(y => y.Balance, request.Balance), cancellationToken: cancellationToken);
        return affectedRow;
    }
}