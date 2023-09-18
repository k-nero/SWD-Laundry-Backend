using MediatR;
using SWD_Laundry_Backend.Application.Common.Interfaces;

namespace SWD_Laundry_Backend.Application.Building.Commands.CreateBuilding;
public class CreateBuildingCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
}

public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBuildingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Building
        {
            Name = request.Name,
            Address = request.Address,
            Description = request.Description
        };

        _context.Get<Domain.Entities.Building>().Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}