using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Contracts
{
    public class EmployeeDTO
    {
        public Guid Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    

        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public int AppliedPromocodesCount { get; set; }
        public ICollection<PromoCode> PromoCodes { get; set; }
    }
}
