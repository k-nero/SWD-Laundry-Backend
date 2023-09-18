using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Exceptions;
using SWD_Laundry_Backend.Application.Common.Interfaces;

namespace SWD_Laundry_Backend.Application.Building.Commands.UpdateBuilding;
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
        var affectedRow = await _context.Get<Domain.Entities.Building>().Where(x => x.Id == request.Id).ExecuteUpdateAsync(x =>
        x.SetProperty(y => y.Name, request.Name)
       .SetProperty(y => y.Address, request.Address)
       .SetProperty(y => y.Description, request.Description), cancellationToken: cancellationToken);
        return affectedRow;
    }
}

