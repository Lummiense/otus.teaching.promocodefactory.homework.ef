using AutoMapper;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Mapping
{
    public class PromoCodeViewMappingProfile:Profile
    {
        public PromoCodeViewMappingProfile() 
        {
            CreateMap<PromocodeDTO, PromoCodeShortResponse>().
            ForMember(p => p.Id, map => map.Ignore()).
            ForMember(dest => dest.PartnerName, opt => opt.MapFrom(src => src.PartnerManager.FullName));

            /*CreateMap<PromoCodeShortResponse, PromocodeDTO>().  
                ForMember(dest => dest.PartnerManager.FirstName, opt => opt.MapFrom(src=>src.PartnerName)).
                ForMember(p => p.Customer, map => map.Ignore()).                
                ForMember(p => p.Preference, map => map.Ignore());*/
        }
    }
}
