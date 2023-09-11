using AutoMapper;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Services
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IRepository<PromoCode> _repository;
        private readonly IPromoCodeRepository _promocodeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public PromoCodeService(IRepository<PromoCode> repository, IPromoCodeRepository promoCodeRepository,IEmployeeRepository employeeRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _repository = repository;
            _promocodeRepository = promoCodeRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<PromoCodeDTO>> GetAllPromoCodes()
        {
            var entities = await _promocodeRepository.GetPromoCodesWithInfo();
            return _mapper.Map<List<PromoCodeDTO>>(entities);
        }

        public async Task GivePromoCode(PromoCodeDTO promoCodeDTO)
        {
            var customers = await _customerRepository.GetCustomersByPreference(x=>x.CustomerPreferences.Any(x=>x.Preference.Name==promoCodeDTO.Preference.Name));            
            var partner = await _employeeRepository.GetEmployeeByName(x => (x.FirstName+" "+x.LastName) == $"{promoCodeDTO.PartnerManager.FirstName} {promoCodeDTO.PartnerManager.LastName}");
            
            var promoCodes = new List<PromoCode>();
            foreach (var customer in customers)
            {
                var promoCode = _mapper.Map<PromoCode>(promoCodeDTO);
                promoCode.Id = Guid.NewGuid();
                promoCode.BeginDate = DateTime.Now;
                promoCode.PartnetManagerId = partner.Id;
                promoCode.PartnerManager.RoleId = partner.RoleId;
                promoCode.CustomerId = customer.Id;
                promoCode.PreferenceId = customer.CustomerPreferences.FirstOrDefault().PreferenceId;
                promoCodes.Add(promoCode);
            }
            
            var result = _repository.AddRange(promoCodes);
            await _repository.SaveChangesAsync();
        }
    }
}
