using Microsoft.EntityFrameworkCore;
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
    public class PromoCodeRepository : EfRepository<PromoCode>, IPromoCodeRepository
    {
        public PromoCodeRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<PromoCode>> GetPromoCodesWithInfo()
        {
            var entities = await _dbContext.Set<PromoCode>().Include(x => x.PartnerManager).AsNoTracking().Include(x => x.Customer).AsNoTracking().Include(x => x.Preference).AsNoTracking().ToListAsync();
            return entities;
        }
    }
}
