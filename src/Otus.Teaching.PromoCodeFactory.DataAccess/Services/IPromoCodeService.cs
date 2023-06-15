using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Services
{
    public interface IPromoCodeService
    {
        Task<List<PromoCodeDTO>> GetAllPromoCodes();
        Task GivePromoCode(PromoCodeDTO promoCodeDTO);
    }
}
