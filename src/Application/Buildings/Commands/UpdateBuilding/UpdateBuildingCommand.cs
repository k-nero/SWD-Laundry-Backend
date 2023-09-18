using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.Buildings.Commands.UpdateBuilding;
public class UpdateBuildingCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand, int>
{

    private readonly IApplicationDbContext _context;
    public UpdateBuildingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
    {
        var affectedRow = await _context.Get<Building>().Where(x => x.Id == request.Id).ExecuteUpdateAsync(x =>
        x.SetProperty(y => y.Name, y => request.Name ?? y.Name)
       .SetProperty(y => y.Address, y => request.Address ?? y.Address)
       .SetProperty(y => y.Description, y => request.Description ?? y.Description), cancellationToken: cancellationToken);
        return affectedRow;
    }
}

