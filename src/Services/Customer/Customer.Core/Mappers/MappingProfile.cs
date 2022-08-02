using AutoMapper;
using Customer.Core.Data.Entities;
using Customer.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Core.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>();
            CreateMap<CreateCustomerDto, CustomerEntity>();
            CreateMap<UpdateCustomerDto, CustomerEntity>();
        }
    }
}
