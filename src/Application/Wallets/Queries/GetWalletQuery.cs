using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.Wallets.Queries;
public class GetWalletQuery : IRequest<WalletViewModel>
{
    public int Id { get; set; }
}

public class GetWalletQueryHandler : IRequestHandler<GetWalletQuery, WalletViewModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWalletQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<WalletViewModel> Handle(GetWalletQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Get<Wallet>().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return _mapper.Map<WalletViewModel>(entity);
    }
}
