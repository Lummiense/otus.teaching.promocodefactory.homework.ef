using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;
using Otus.Teaching.PromoCodeFactory.DataAccess.Services;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController:ControllerBase
        
    {
        //private EfRepository<Customer> _customerRepository;
        private ICustomerService _customerService;
        private IMapper _mapper;
               
        public CustomersController(IMapper mapper, ICustomerService customerService)
        {         
            _mapper = mapper;
            _customerService = customerService;
        }
        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<ActionResult<CustomerShortResponse>> GetCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(_mapper.Map<ICollection<CustomerShortResponse>>(customers));
        }
        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Пользователь с указанным id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
        {
            //TODO: Настроить корректную отдачу Preference
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer==null)
                return NotFound();
            var preferences = customer.CustomerPreferences.Where(c => c.CustomerId == id).Select(p => p.Preference).ToList();            
            var preferenceResponse = _mapper.Map<List<PreferenceResponse>>(preferences);
            var customerResponse = new CustomerResponse()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Preferences= preferenceResponse                
            };
                          
        
            return Ok(_mapper.Map<CustomerResponse>(customer));
        }
        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Ответ с id добавленного пользователя</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CreateOrEditCustomerRequest request)
        {
            var customer = _mapper.Map<CustomerDTO>(request);
            customer.Id = Guid.NewGuid();
            customer.CustomerPreferences = new List<CustomerPreference>();
            foreach(var item in request.PreferenceIds)
            {
                customer.CustomerPreferences.Append(new CustomerPreference
                {
                    PreferenceId = item,
                    CustomerId = customer.Id
                });
            }         

            var result = await _customerService.AddCustomerAsync(customer);
            return Ok($"Пользователь с ID {result} добавлен");
        }
        /// <summary>
        /// Изменить данные пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Ответ с id измененного пользователя</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomersAsync(CreateOrEditCustomerRequest request)
        {
            var customer = _mapper.Map<CustomerDTO>(request);
            var result = await _customerService.UpdateCustomerAsync(customer);
            //TODO: Обновить данные клиента вместе с его предпочтениями
            return Ok($"Данные пользователя с ID {result} обновлены");
        }
        /// <summary>
        /// Удалить пользователя с указанным id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ответ с id удаленного пользователя</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.DeleteCustomerAsync(id);
            //TODO: Удаление клиента вместе с выданными ему промокодами
            return Ok($"Пользователь с ID {id} удален");
        }
    }
}