using AutoMapper;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Mapper;

public class StaffTripMapperProfile : Profile
{
    public StaffTripMapperProfile()
    {
        CreateMap<StaffTripModel, Staff_Trip>().ReverseMap();
    }
}