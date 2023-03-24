using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PromoCode
        : BaseEntity
    {
        public string Code { get; set; }

        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PartnerName { get; set; }

        public Employee PartnerManager { get; set; }
        public ICollection<Customer> Customers { get; set; }
       
        public Guid PreferenceId { get; set; }
        public Preference Preference { get; set; }
    }
}