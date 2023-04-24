using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        
        
        public CustomerRepository(DataContext dbContext):base(dbContext) 
        {
        }
        public Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            var customer = _dbContext.Set<Customer>().Include(c => c.CustomerPreferences).Include(p=>p.PromoCodes).FirstOrDefault(x => x.Id == id);
            return Task.FromResult(customer);
        }

      
    }
}
