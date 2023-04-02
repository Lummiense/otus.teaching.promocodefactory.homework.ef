using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Contracts
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }
        public List<CustomerPreference> CustomerPreferences { get; set; }
        public List<PromoCode> PromoCodes { get; set; }
    }
}
