using MediatR;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;
using SWD_Laundry_Backend.Domain.Enums;

namespace SWD_Laundry_Backend.Application.PaymentMethods.Commands.CreatePaymentMethod;
public class CreatePaymentMethodCommand : IRequest<int>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePaymentMethodCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = new PaymentMethod
        {
            Name = request.Name,
            Description = request.Description
        };

        _context.Get<PaymentMethod>().Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
