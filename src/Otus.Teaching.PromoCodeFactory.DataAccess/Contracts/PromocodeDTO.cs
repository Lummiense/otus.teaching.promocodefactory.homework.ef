using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Contracts
{
    public class PromoCodeDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }
        public Guid PartnetManagerId { get; set; }

        public Employee PartnerManager { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Guid PreferenceId { get; set; }
        public virtual Preference Preference { get; set; }
    }
}
