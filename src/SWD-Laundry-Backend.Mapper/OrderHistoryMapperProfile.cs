using AutoMapper;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Mapper;

public class OrderHistoryMapperProfile : Profile
{
    public OrderHistoryMapperProfile()
    {
        CreateMap<OrderHistoryModel, OrderHistory>().ReverseMap();
    }
}