using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task <List<Customer>> GetCustomersByPreference(Expression<Func<Customer, bool>> predicate);
    }
}
