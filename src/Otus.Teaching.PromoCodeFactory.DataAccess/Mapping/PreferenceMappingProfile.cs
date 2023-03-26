using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Mapping
{
    public class PreferenceMappingProfile:Profile
    {
        public PreferenceMappingProfile() 
        {
            CreateMap<Preference, PreferenceDTO>();
            CreateMap<PreferenceDTO, Preference>()
                .ForMember(i => i.Id, map => map.Ignore());

        }
    }
}
