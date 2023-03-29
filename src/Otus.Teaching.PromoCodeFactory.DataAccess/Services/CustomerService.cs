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
    public class CustomerService : EfRepository<Customer>,ICustomerService
    {
        private readonly IMapper _mapper;
        //private readonly ICustomerService _customerService;
        private readonly EfRepository<Customer> _customerRepository;
        /*public CustomerService(ICustomerService customerService, IMapper mapper,EfRepository<Customer> customerRepository, DataContext dbContext):base(dbContext)
         {
            _customerService = customerService;
           _mapper = mapper;
            _customerRepository = customerRepository;
        }*/
        public CustomerService(IMapper mapper, EfRepository<Customer> customerRepository, DataContext dbContext) : base(dbContext)
        {
           // _customerService = customerService;
           _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task AddAsync(CustomerDTO customerDTO)
        {
            var entity = _mapper.Map<CustomerDTO,Customer>(customerDTO);
            await _customerRepository.AddAsync(entity); 
            await _customerRepository.SaveChangesAsync();            
        }

        /*public Task<Guid> CreateCustomerAsync(CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }*/

        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
            await _customerRepository.SaveChangesAsync();
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
            ICollection<Customer> entities = await _customerRepository.GetAllAsync();
            return _mapper.Map<ICollection<Customer>, ICollection<CustomerDTO>>(entities);
        }

        public async Task<CustomerDTO> GetByIdAsync(Guid id)
        {
            var entity = await _customerRepository.GetByIdAsync(id);
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
            await _customerRepository.UpdateAsync(entity);
            await _customerRepository.SaveChangesAsync();
        }
    }
}
