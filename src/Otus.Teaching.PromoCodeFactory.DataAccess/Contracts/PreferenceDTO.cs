using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Contracts
{
    public class PreferenceDTO
    {
        public string Name { get; set; }
        public List<PromoCode> PromoCodes { get; set; }
        public List<Preference> CustomerPreferences { get; set; }
    }
}
