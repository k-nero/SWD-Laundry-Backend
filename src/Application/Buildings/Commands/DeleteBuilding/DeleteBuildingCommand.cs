using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.Buildings.Commands.DeleteBuilding;
public class DeleteBuildingCommand : IRequest<int>
{
    public int Id { get; set; }
}

public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand, int>
{
    private readonly IApplicationDbContext _context;
    public DeleteBuildingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
    {
        var affectedRow = await _context.Get<Building>().Where(x => x.Id == request.Id).ExecuteDeleteAsync(cancellationToken);
        return affectedRow;
    }
}
