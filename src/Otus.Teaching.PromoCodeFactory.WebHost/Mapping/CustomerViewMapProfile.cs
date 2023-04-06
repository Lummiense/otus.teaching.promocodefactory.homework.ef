using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;
using System.Linq;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Mapping
{
    public class CustomerViewMapProfile:Profile
    {
        public CustomerViewMapProfile() 
        {
            CreateMap<CustomerDTO, CustomerResponse>()
                .ForMember(c=>c.Preferences,map=>map.Ignore());
            CreateMap<PromoCodeDTO,PromoCodeShortResponse>().
                ForMember(dest => dest.PartnerName, opt => opt.MapFrom(src => src.PartnerManager.FullName)).
                ForMember(p =>p.Id,map =>map.Ignore());
            /*CreateMap<CustomerResponse, CustomerDTO>().
                  ForMember(c => c.FullName, map => map.Ignore());*/


            CreateMap<CustomerDTO, CustomerShortResponse>();
            /*CreateMap<CustomerShortResponse, CustomerDTO>().
                  ForMember(c => c.FullName, map => map.Ignore()).
                  ForMember(c => c.PromoCodes, map => map.Ignore()).
                  ForMember(c => c.CustomerPreferences, map => map.Ignore());*/

            CreateMap<CreateOrEditCustomerRequest, CustomerDTO>().
                ForMember(c => c.Id, map => map.Ignore()).                
                ForMember(c=>c.PromoCodes,map=>map.Ignore()).
                ForMember(c=>c.CustomerPreferences,map=>map.Ignore());
            
                


        }
    }
}
