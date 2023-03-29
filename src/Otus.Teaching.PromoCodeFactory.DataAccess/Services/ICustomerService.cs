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
        Task<Customer> GetByIdAsync(Guid id);
        Task<ICollection<CustomerDTO>> GetAllAsync();
        Task AddAsync(CustomerDTO customerDTO);
        Task UpdateAsync(CustomerDTO customerDTO);
        Task DeleteAsync(Guid id);
    }
}
