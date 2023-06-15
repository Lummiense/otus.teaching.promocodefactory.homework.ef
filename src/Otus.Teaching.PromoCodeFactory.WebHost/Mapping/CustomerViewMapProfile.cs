using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;
using System;
using System.Linq;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Mapping
{
    public class CustomerViewMapProfile:Profile
    {
        public CustomerViewMapProfile()
        {
           //from CustomerDTO to CustomerResponse
            CreateMap<CustomerDTO, CustomerResponse>()
                .ForMember(p=>p.Preferences,map =>map.MapFrom(s=>s.CustomerPreferences))
                .ForMember(p=>p.PromoCodes,map=>map.Ignore());
            CreateMap<CustomerPreference,PreferenceResponse>()
                .ForMember(d=>d.Id,map=>map.MapFrom(s=>s.Preference.Id))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.Preference.Name));

           /* CreateMap<PromoCode, PromoCodeShortResponse>().
                ForMember(dest => dest.PartnerName, opt => opt.MapFrom(src => src.PartnerManager.FullName)).
                ForMember(p => p.Id, map => map.Ignore());*/



            /*CreateMap<CustomerResponse, CustomerDTO>().
                  ForMember(c => c.FullName, map => map.Ignore());*/
            //from CustomerDTO to CustomerShortResponse
            CreateMap<CustomerDTO, CustomerShortResponse>();
            /*CreateMap<CustomerShortResponse, CustomerDTO>().
                  ForMember(c => c.FullName, map => map.Ignore()).
                  ForMember(c => c.PromoCodes, map => map.Ignore()).
                  ForMember(c => c.CustomerPreferences, map => map.Ignore());*/

            //from CreateOrEditCustomerReques to CustomerDTO
            CreateMap<CreateOrEditCustomerRequest, CustomerDTO>().
                ForMember(c => c.Id, map => map.Ignore()). 
                ForMember(c=>c.FullName, map => map.MapFrom(src=> $"{src.FirstName} {src.LastName}")).
                ForMember(c => c.CustomerPreferences, map => map.Ignore()).
                ForMember(c => c.PromoCodes, map => map.Ignore());
            
            
                


        }
    }
}
