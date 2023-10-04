using AutoMapper;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Mapper;

public class BuildingMapperProfile : Profile
{
    public BuildingMapperProfile()
    {
        CreateMap<BuildingModel, Building>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
    }
}
