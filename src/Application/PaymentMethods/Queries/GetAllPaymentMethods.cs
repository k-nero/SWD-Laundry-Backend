using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;
using SWD_Laundry_Backend.Domain.Enums;

namespace SWD_Laundry_Backend.Application.PaymentMethods.Queries;
public class GetAllPaymentMethods
{
    public class GetAllPaymentMethodsQuery : IRequest<PaymentMethodVm>
    {
    }

    public class GetAllPaymentMethodsQueryHandler : IRequestHandler<GetAllPaymentMethodsQuery, PaymentMethodVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPaymentMethodsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentMethodVm> Handle(GetAllPaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            var paymentMethods = await _context.Get<PaymentMethod>().ProjectTo<PaymentMethodDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var result = new PaymentMethodVm
            {
                PaymentTypes = Enum.GetValues(typeof(PaymentType)).Cast<PaymentType>().Select(p => new PaymentTypeDto { Value = (int)p, Name = p.ToString() }).ToList(),
                PaymentMethods = _mapper.Map<List<PaymentMethodDto>>(paymentMethods)
            };
            return result;
        }
    }
}
