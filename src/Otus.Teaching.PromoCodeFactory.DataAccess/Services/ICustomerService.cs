﻿using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Services
{
    public interface ICustomerService
    {
        Task <ICollection<CustomerDTO>> GetAllCustomersAsync();
        Task <Guid> AddCustomerAsync (CustomerDTO customerDTO);
        Task<CustomerDTO> GetCustomerByIdAsync(Guid id);
        Task DeleteCustomerAsync(Guid id);
        Task <Guid> UpdateCustomerAsync(CustomerDTO customerDTO);
    }
}
