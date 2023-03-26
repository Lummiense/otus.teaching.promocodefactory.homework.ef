﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Preference
        :BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PromoCode> PromoCodes { get; set; }
        public ICollection<CustomerPreference> CustomerPreferences { get; set; }
    }
}