using AutoMapper;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Mapper;

public class OrderMapperProfile : Profile
{
    public OrderMapperProfile()
    {
        CreateMap<OrderModel, Order>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
    }
}