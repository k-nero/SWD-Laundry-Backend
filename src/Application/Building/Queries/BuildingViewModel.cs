using SWD_Laundry_Backend.Application.Common.Mappings;

namespace SWD_Laundry_Backend.Application.Building.Queries;
public class BuildingViewModel : IMapFrom<Domain.Entities.Building>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
}
