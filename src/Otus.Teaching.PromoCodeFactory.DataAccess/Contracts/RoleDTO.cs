using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Contracts
{
    public class RoleDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
