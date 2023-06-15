using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly IRepository<Preference> _preferenceRepository;
        private readonly IMapper _mapper;
        public PreferencesController(IRepository<Preference> preferenceRepository,IMapper mapper)
        {
            _preferenceRepository = preferenceRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Получить список всех предпочтений
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PreferenceResponse>> GetPreferencesAsync()
        {
            var entities = await _preferenceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PreferenceResponse>>(entities);
        }



    }
}
