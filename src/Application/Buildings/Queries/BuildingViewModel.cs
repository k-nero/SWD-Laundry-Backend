using SWD_Laundry_Backend.Application.Common.Mappings;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.Buildings.Queries;
public class BuildingViewModel : IMapFrom<Building>
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Description { get; set; }
}
