using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Mapping
{
    public class EmployeeMappingProfile:Profile
    {
        public EmployeeMappingProfile() 
        {
            CreateMap<Employee, EmployeeDTO>();
                
            
            CreateMap<EmployeeDTO,Employee>()
                .ForMember(d => d.FullName, map => map.Ignore());


        }
    }
}
