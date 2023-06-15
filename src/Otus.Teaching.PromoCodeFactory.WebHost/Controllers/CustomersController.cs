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
        private ICustomerRepository _customerRepository;
        private ICustomerService _customerService;
        private IMapper _mapper;
               
        public CustomersController(IMapper mapper, ICustomerRepository customerRepository, ICustomerService customerService)
        {         
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerService = customerService;
        }
        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<ActionResult<CustomerShortResponse>> GetCustomersAsync()
        {
            var entities = await _customerRepository.GetAllAsync();
            var customersDTO = _mapper.Map<List<CustomerDTO>>(entities);
            return Ok(_mapper.Map<IEnumerable<CustomerShortResponse>>(customersDTO));
        }
        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Пользователь с указанным id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
        {
            
            var customerDTO = await _customerService.GetCustomerByIdAsync(id);
            if (customerDTO == null)
                return NotFound();            
            var result = _mapper.Map<CustomerResponse>(customerDTO);
                                  
        
            return Ok(_mapper.Map<CustomerResponse>(result));
        }
        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Ответ с id добавленного пользователя</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CreateOrEditCustomerRequest request)
        {
            var customerDTO = _mapper.Map<CustomerDTO>(request);
            customerDTO.CustomerPreferences = new List<CustomerPreference>();
            foreach (var item in request.PreferenceIds)
            {
                customerDTO.CustomerPreferences.Add(new CustomerPreference
                {
                    PreferenceId = item,

                } ); 
            }
            var result = await _customerService.AddCustomerAsync(customerDTO);
            return Ok($"Пользователь с ID {result} добавлен");
        }
        /// <summary>
        /// Изменить данные пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Ответ с id измененного пользователя</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomersAsync(Guid id,CreateOrEditCustomerRequest request)
        {
            var customerDTO = _mapper.Map<CustomerDTO>(request);
            customerDTO.Id = id;
            customerDTO.CustomerPreferences = new List<CustomerPreference>();
            foreach (var item in request.PreferenceIds)
            {
                customerDTO.CustomerPreferences.Add(new CustomerPreference
                {
                    PreferenceId = item,
                    CustomerId = id,
                });
            }
            var result = await _customerService.UpdateCustomerAsync(customerDTO);
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
            await _customerRepository.DeleteAsync(id);
            //TODO: Удаление клиента вместе с выданными ему промокодами
            return Ok($"Пользователь с ID {id} удален");
        }
    }
}