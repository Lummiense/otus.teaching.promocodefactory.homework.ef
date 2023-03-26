using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Services
{
    public interface ICustomerService:IRepository<Customer>
    {
        Task<Customer> GetCustomerAsync(Guid id);
        Task<ICollection<Customer>> GetCustomersAsync(CustomerDTO customerDTO);
        Task<Guid> CreateCustomerAsync(CustomerDTO customerDTO);
        Task EditCustomersAsync(Guid id, CustomerDTO customerDTO);
        Task DeleteCustomer(Guid id);
    }
}
