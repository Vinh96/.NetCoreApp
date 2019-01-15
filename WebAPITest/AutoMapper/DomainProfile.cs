using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Entities;
using WebAPITest.Models;

namespace WebAPITest.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<Restaurant, Restaurant>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
