using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public interface IPromoCodeRepository
    {
        Task <List<PromoCode>> GetPromoCodesWithInfo();
    }
}
