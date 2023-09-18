using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Application.Common.Interfaces;

namespace SWD_Laundry_Backend.Application.Building.Queries;
public class GetAllBuildingQuery : IRequest<List<BuildingViewModel>>
{

}

public class GetAllBuildingQueryHandler : IRequestHandler<GetAllBuildingQuery, List<BuildingViewModel>>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllBuildingQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BuildingViewModel>> Handle(GetAllBuildingQuery request, CancellationToken cancellationToken)
    {
        var buildingList = await _context.Get<Domain.Entities.Building>().AsNoTracking().ToListAsync(cancellationToken);
        return _mapper.Map<List<BuildingViewModel>>(buildingList);
    }

}
