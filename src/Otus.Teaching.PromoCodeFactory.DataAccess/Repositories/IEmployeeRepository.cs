using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(Guid id);
        Task<Employee> GetEmployeeByName(Expression<Func<Employee, bool>> predicate);
    }
}
