﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Services
{
    public class CustomerService : EfRepository<Customer>,ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;        
        public CustomerService(IMapper mapper,ICustomerRepository customerRepository, DataContext dbContext) : base(dbContext)
        {          
            _mapper = mapper;
            _customerRepository = customerRepository;            
        }




        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="customerDTO"></param>
        /// <returns>ID добавленного пользователя</returns>
        public async Task<Guid> AddCustomerAsync(CustomerDTO customerDTO)
        {
            customerDTO.Id = Guid.NewGuid();
            foreach (var item in customerDTO.CustomerPreferences)
            {
               item.CustomerId = customerDTO.Id;
            }
            var entity = _mapper.Map<Customer>(customerDTO);
            var result = await _customerRepository.AddAsync(entity);
            await _customerRepository.SaveChangesAsync();
            return result;
        }



        /// <summary>
        /// Удаление пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCustomerAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
            await _customerRepository.SaveChangesAsync();
        }
        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        public async Task<ICollection<CustomerDTO>> GetAllCustomersAsync()
        {
            ICollection<Customer> entities = await _customerRepository.GetAllAsync();
            return _mapper.Map<ICollection<CustomerDTO>>(entities);
        }
        /// <summary>
        /// Получение пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Пользователь</returns>
        public async Task<CustomerDTO> GetCustomerByIdAsync(Guid id)
        { 
            var entity =await _customerRepository.GetCustomerByIdAsync(id);
            var customer = _mapper.Map<CustomerDTO>(entity);
            return customer;
        }

        

        /// <summary>
        /// Обновить пользователя в базе данных
        /// </summary>
        /// <param name="customerDTO"></param>
        /// <returns>ID обновленного пользователя</returns>
        public async Task <Guid> UpdateCustomerAsync(CustomerDTO customerDTO)
        {
            
            var entity = _mapper.Map<Customer>(customerDTO);
            var result = await _customerRepository.UpdateAsync(entity);
            await _customerRepository.SaveChangesAsync();
            return result;
        }
    }
}
