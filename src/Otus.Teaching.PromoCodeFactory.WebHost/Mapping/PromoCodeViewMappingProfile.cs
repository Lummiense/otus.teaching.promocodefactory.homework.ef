using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Mapping
{
    public class PromoCodeViewMappingProfile:Profile
    {
        public PromoCodeViewMappingProfile() 
        {
            
            
            //from PromoCodeDTO to PromoCodeShortResponse
            CreateMap<PromoCodeDTO, PromoCodeShortResponse>().            
            ForMember(dest => dest.PartnerName, opt => opt.MapFrom(src => (src.PartnerManager.FirstName + " " + src.PartnerManager.LastName)));           
            
        }
    }
}
