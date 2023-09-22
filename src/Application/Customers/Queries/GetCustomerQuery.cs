using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;

namespace SWD_Laundry_Backend.Application.Customers.Queries;
public class GetCustomerQuery : IRequest<CustomerVm>
{
    public int Id { get; set; } = 0;
    public string? UserName { get; set; }
    public string? UserId { get; set; }

}

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerVm> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customers = await  _context.Get<Domain.Entities.Customer>()
            .Include(x => x.ApplicationUser)
            .AsNoTracking()
            .Where(x => x.Id == request.Id || x.ApplicationUser.UserName == request.UserName || x.ApplicationUser.Id == request.UserId)
            .FirstOrDefaultAsync(cancellationToken);

        return _mapper.Map<CustomerVm>(customers);
    }
    
}