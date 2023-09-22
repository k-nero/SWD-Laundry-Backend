using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.PaymentMethods.Commands.DeletePaymentMethod;
public class DeletePaymentMethodCommand : IRequest<int>
{
    public int Id { get; set; }
}

public class DeletePaymentMethodCommandHandler : IRequestHandler<DeletePaymentMethodCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeletePaymentMethodCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        int affectedRows = await _context.Get<PaymentMethod>().Where(x => x.Id == request.Id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
        return affectedRows;
    }
}
