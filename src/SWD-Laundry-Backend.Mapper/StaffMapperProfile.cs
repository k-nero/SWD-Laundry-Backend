using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Mapper;
public class StaffMapperProfile : Profile
{
    public StaffMapperProfile()
    {
        CreateMap<StaffModel, Staff>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
    }
}
