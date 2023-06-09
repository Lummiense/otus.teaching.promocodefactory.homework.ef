﻿using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Models
{
    public class CreateOrEditCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Guid> PreferenceIds { get; set; }
    }
}