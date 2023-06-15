using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.DataAccess.Services;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Промокоды
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromocodesController
        : ControllerBase
    {
        
        private readonly IPromoCodeService _promocodeService;
        private readonly IMapper _mapper;
        public PromocodesController(IPromoCodeService promoCodeService,IMapper mapper)
        {
            _promocodeService = promoCodeService;
            _mapper = mapper;            
        }

        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<PromoCodeShortResponse>>> GetPromocodesAsync()
        {
            var enities = await _promocodeService.GetAllPromoCodes();
            return _mapper.Map<List<PromoCodeShortResponse>>(enities);          
        }
        
        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {
            PromoCodeDTO promoCodeDTO = new PromoCodeDTO();
            promoCodeDTO.ServiceInfo = request.ServiceInfo;
            promoCodeDTO.Code = request.PromoCode;
            string[] Names = request.PartnerName.Split(" ");
            promoCodeDTO.PartnerManager = new Employee();
            promoCodeDTO.PartnerManager.FirstName = Names[0];
            promoCodeDTO.PartnerManager.LastName= Names[1];
            promoCodeDTO.Preference = new Preference();
            promoCodeDTO.Preference.Name = request.Preference;
            try
            {
                await _promocodeService.GivePromoCode(promoCodeDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"Создать промокод не удалось. {ex.Message}");
            }

            return Ok("Промокод создан");
        }
    }
}