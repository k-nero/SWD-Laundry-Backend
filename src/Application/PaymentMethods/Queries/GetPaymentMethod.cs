using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;
using SWD_Laundry_Backend.Domain.Enums;

namespace SWD_Laundry_Backend.Application.PaymentMethods.Queries;
public class GetPaymentMethod : IRequest<PaymentMethodDto>
{
    public int Id { get; init; }
}

public class GetPaymentMethodHandler : IRequestHandler<GetPaymentMethod, PaymentMethodDto>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetPaymentMethodHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaymentMethodDto> Handle(GetPaymentMethod request, CancellationToken cancellationToken)
    {
        var paymentMethod = await _context.Get<PaymentMethod>().Where(x => x.Id == request.Id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

       var result = _mapper.Map<PaymentMethodDto>(paymentMethod);

        return result;
    }

}