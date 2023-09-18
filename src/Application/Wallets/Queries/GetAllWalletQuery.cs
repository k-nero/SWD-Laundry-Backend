using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.Wallets.Queries;
public class GetAllWalletQuery : IRequest<List<WalletViewModel>>
{

}

public class GetAllWalletQueryHandler : IRequestHandler<GetAllWalletQuery, List<WalletViewModel>>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllWalletQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WalletViewModel>> Handle(GetAllWalletQuery request, CancellationToken cancellationToken)
    {
        var walletList = await _context.Get<Wallet>().AsNoTracking().ToListAsync(cancellationToken);
        return _mapper.Map<List<WalletViewModel>>(walletList);
    }

}
