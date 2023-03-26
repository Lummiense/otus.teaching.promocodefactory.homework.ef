using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Mapping
{
    public class RoleMappingProfile:Profile
    {
        public RoleMappingProfile() 
        { 
            CreateMap<Role,RoleDTO>();
            CreateMap<RoleDTO, Role>()
                .ForMember(i => i.Id, map => map.Ignore());
        }
    }
}
