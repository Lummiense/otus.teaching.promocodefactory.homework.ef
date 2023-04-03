using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Mapping
{
    public class PromoCodeMappingProfile:Profile
    {
        public PromoCodeMappingProfile()
        {
            CreateMap<PromoCode,PromoCodeDTO>();
            CreateMap<PromoCodeDTO, PromoCode>()
                .ForMember(i => i.Id, map => map.Ignore())
                .ForMember(pm => pm.PartnetManagerId, map => map.Ignore())
                .ForMember(cm => cm.CustomerId, map => map.Ignore())
                .ForMember(pf => pf.PreferenceId, map => map.Ignore());
        }
    }
}
