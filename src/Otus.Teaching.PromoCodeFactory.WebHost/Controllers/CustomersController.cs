using System;
using System.Collections.Generic;
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
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CustomerShortResponse>> GetCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(_mapper.Map<ICollection<CustomerShortResponse>>(customers));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return Ok(_mapper.Map<CustomerResponse>(customer));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CreateOrEditCustomerRequest request)
        {
            var customer = _mapper.Map<CustomerDTO>(request);
            var result = await _customerService.AddCustomerAsync(customer);
            return Ok($"Пользователь с ID {result} добавлен");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomersAsync(CreateOrEditCustomerRequest request)
        {
            var customer = _mapper.Map<CustomerDTO>(request);
            var result = await _customerService.UpdateCustomerAsync(customer);
            //TODO: Обновить данные клиента вместе с его предпочтениями
            return Ok($"Данные пользователя с ID {result} обновлены");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.DeleteCustomerAsync(id);
            //TODO: Удаление клиента вместе с выданными ему промокодами
            return Ok($"Пользователь с ID {id} удален");
        }
    }
}