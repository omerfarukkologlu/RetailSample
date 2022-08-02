using AutoMapper;
using Customer.Core.Data.Entities;
using Customer.Core.Data.Repository;
using Customer.Core.Dto;
using Customer.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Core.Services
{
    public interface ICustomerService
    {
        public bool CreateCustomer(CreateCustomerDto createCustomerDto);
        public bool UpdateCustomer(UpdateCustomerDto updateCustomerDto);
        public List<CustomerDto> GetCustomers();
        public bool DeleteCustomer(int Id);
        public CustomerDto GetCustomerById(int Id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public bool CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var entity = mapper.Map<CustomerEntity>(createCustomerDto);
            customerRepository.Add(entity);

            return true;
        }

        public List<CustomerDto> GetCustomers()
        {
            return mapper.Map<List<CustomerDto>>(customerRepository.GetAll().ToList());
        }

        public bool UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var entity = customerRepository.GetById(updateCustomerDto.Id);

            if (entity == null)
                throw new CustomerNotFoundException();

            mapper.Map<UpdateCustomerDto, CustomerEntity>(updateCustomerDto, entity);

            customerRepository.Update(entity);

            return true;
        }

        public bool DeleteCustomer(int Id)
        {
            var customer = customerRepository.GetById(Id);

            if (customer == null)
                throw new CustomerNotFoundException();

            customerRepository.Delete(customer);

            return true;
        }

        public CustomerDto GetCustomerById(int Id)
        {
            var customer = customerRepository.GetById(Id);

            if (customer == null)
                throw new CustomerNotFoundException();

            return mapper.Map<CustomerDto>(customer);
        }
    }
}
