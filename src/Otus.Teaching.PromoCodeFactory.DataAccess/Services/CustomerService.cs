using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Services
{
    public class CustomerService : EfRepository<Customer>,ICustomerService
    {
        protected CustomerService(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<Guid> CreateCustomerAsync(CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EditCustomersAsync(Guid id, CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Customer>> GetCustomersAsync(CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
