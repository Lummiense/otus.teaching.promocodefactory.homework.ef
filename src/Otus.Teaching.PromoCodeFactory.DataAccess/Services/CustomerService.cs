using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Contracts;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using Otus.Teaching.PromoCodeFactory.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Services
{
    public class CustomerService : EfRepository<Customer>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        public CustomerService(ICustomerService customerService, IMapper mapper,DataContext dbContext):base(dbContext)
        {
            _customerService = customerService;
           _mapper = mapper;
        }

        public async Task AddAsync(CustomerDTO customerDTO)
        {
            var entity = _mapper.Map<CustomerDTO,Customer>(customerDTO);
            await _customerService.AddAsync(entity); 
            await _customerService.SaveChangesAsync();            
        }

        /*public Task<Guid> CreateCustomerAsync(CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }*/

        public async Task DeleteAsync(Guid id)
        {
            await _customerService.DeleteAsync(id);
            await _customerService.SaveChangesAsync();
        }

        /*public Task DeleteCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EditCustomersAsync(Guid id, CustomerDTO customerDTO)
        {
            throw new NotImplementedException();*//*
        }*/

        public async Task<ICollection<CustomerDTO>> GetAllAsync()
        {
            ICollection<Customer> entities = await _customerService.GetAllAsync();
            return _mapper.Map<ICollection<Customer>, ICollection<CustomerDTO>>(entities);
        }

        public async Task<CustomerDTO> GetByIdAsync(Guid id)
        {
            var entity = await _customerService.GetByIdAsync(id);
            return _mapper.Map<Customer,CustomerDTO>(entity);
        }

      /*  public Task<Customer> GetCustomerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Customer>> GetCustomersAsync(CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }*/
              
        public async Task UpdateAsync(CustomerDTO customerDTO)
        {
            var entity = _mapper.Map<CustomerDTO,Customer>(customerDTO);
            await _customerService.UpdateAsync(entity);
            await _customerService.SaveChangesAsync();
        }
    }
}
