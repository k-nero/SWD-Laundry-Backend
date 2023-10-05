using AutoMapper;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Mapper;

public class TransactionMapperProfile : Profile
{
    public TransactionMapperProfile()
    {
        CreateMap<TransactionModel, Transaction>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
    }
}