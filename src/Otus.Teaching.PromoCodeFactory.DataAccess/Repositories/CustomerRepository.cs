using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        
        
        public CustomerRepository(DataContext dbContext):base(dbContext) 
        {
        }
        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _dbContext.Set<Customer>().Include(c => c.CustomerPreferences).AsNoTracking().Include("CustomerPreferences.Preference").Include(p=>p.PromoCodes).AsNoTracking().FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public async Task<List<Customer>> GetCustomersByPreference(Expression<Func<Customer, bool>> predicate)
        {
            var customers = await _dbContext.Set<Customer>().Include(c => c.PromoCodes).AsNoTracking().Include(c => c.CustomerPreferences).AsNoTracking().Where(predicate).ToListAsync();
            return customers;
        }
    }
}
