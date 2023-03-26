using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Mapping
{
    public class CustomerMappingProfile:Profile
    {
        public CustomerMappingProfile() 
        { 
            CreateMap<Customer,CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(i => i.Id, map => map.Ignore());
        }
    }
}
