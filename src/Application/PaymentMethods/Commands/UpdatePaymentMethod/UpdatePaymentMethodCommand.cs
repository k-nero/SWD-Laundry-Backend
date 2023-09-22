using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.PaymentMethods.Commands.UpdatePaymentMethod;
public class UpdatePaymentMethodCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdatePaymentMethodCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        int affectedRows = await _context.Get<PaymentMethod>().Where(x => x.Id == request.Id).ExecuteUpdateAsync(x => 
        x.SetProperty(p => p.Name, p => request.Name ?? p.Name)
         .SetProperty(p => p.Description, p => request.Description ?? p.Name));
        return affectedRows;
    }
}

