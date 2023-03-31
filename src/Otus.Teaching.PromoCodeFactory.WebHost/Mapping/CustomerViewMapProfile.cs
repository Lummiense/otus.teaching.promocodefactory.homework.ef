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
           // CreateMap<CustomerDTO, CustomerResponse>();
           /* CreateMap<CustomerResponse, CustomerDTO>().
                  ForMember(c => c.FullName, map => map.Ignore());*/

            CreateMap<CustomerDTO, CustomerShortResponse>();
            CreateMap<CustomerShortResponse, CustomerDTO>().
                  ForMember(c => c.FullName, map => map.Ignore()).
                  ForMember(c => c.PromoCodes, map => map.Ignore()).
                  ForMember(c => c.CustomerPreferences, map => map.Ignore());

            //CreateMap<CreateOrEditCustomerRequest, CustomerDTO>();
                


        }
    }
}
