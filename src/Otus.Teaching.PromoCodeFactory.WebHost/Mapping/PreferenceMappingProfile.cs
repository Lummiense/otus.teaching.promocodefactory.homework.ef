using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Mapping
{
    public class PreferenceMappingProfile:Profile
    {
        public PreferenceMappingProfile() 
        {
            CreateMap<Preference, PreferenceResponse>();
        }
    }
}
