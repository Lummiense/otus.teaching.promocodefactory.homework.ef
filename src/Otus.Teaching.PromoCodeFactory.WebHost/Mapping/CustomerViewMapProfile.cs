using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Mapping
{
    public class CustomerViewMapProfile:Profile
    {
        public CustomerViewMapProfile() 
        {
            CreateMap<CustomerDTO, CustomerResponse>();
            CreateMap<CustomerDTO, CustomerShortResponse>();
               
        }
    }
}
