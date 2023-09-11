using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public class EmployeeRepository :EfRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            var employee = await _dbContext.Set<Employee>().Include(x=>x.Role).AsNoTracking().Include(x=>x.PromoCodes).AsNoTracking().FirstOrDefaultAsync();
            return employee;
        }

        public async Task<Employee> GetEmployeeByName(Expression<Func<Employee, bool>> predicate)
        {
            var employee = await _dbContext.Set<Employee>().FirstOrDefaultAsync(predicate);
            return employee;
        }
    }
}
