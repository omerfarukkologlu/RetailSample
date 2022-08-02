using AutoMapper;
using Customer.Core.Data;
using Customer.Core.Data.Repository;
using Customer.Core.Mappers;
using Customer.Core.Services;
using Customer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Priority;

namespace Customer.UnitTest
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class CustomerServiceTest
    {
        protected CustomerService CustomerService;
        protected MapperConfiguration MappingConfig { get; }
        protected IMapper Mapper { get; }
        protected CustomerRepository CustomerRepository { get; }
        protected CustomerDbContext DbContext;
        protected CustomerUnitOfWork _unitOfWork;
        public CustomerServiceTest()
        {
            var dbOption = new DbContextOptionsBuilder<CustomerDbContext>()
                                .UseInMemoryDatabase("CustomerDb")
                                .Options;

            DbContext = new CustomerDbContext(dbOption);
            _unitOfWork = new CustomerUnitOfWork(DbContext);
            CustomerRepository = new CustomerRepository(DbContext);
            MappingConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            Mapper = MappingConfig.CreateMapper();
            CustomerService = new CustomerService(Mapper, CustomerRepository);
        }

        [Fact, Priority(1)]
        public void Should_Create_Customer()
        {
            var customerForCreate = CustomerTestData.GetCustomerForCreate();

            CustomerService.CreateCustomer(customerForCreate);
            _unitOfWork.SaveChanges();
        }

        [Fact, Priority(2)]
        public void Should_Get_CustomerInfo()
        {
            var customerId = 1;

            var customer = CustomerService.GetCustomerById(customerId);

            Assert.NotNull(customer);
        }

        [Fact, Priority(3)]
        public void Should_Update_Customer()
        {
            var customerForUpdate = CustomerTestData.GetCustomerForUpdate();

            CustomerService.UpdateCustomer(customerForUpdate);
            _unitOfWork.SaveChanges();
        }

        [Fact, Priority(4)]
        public void Should_Get_Only_One_Customer()
        {
            var customers = CustomerService.GetCustomers();

            Assert.Single(customers);
        }

        [Fact, Priority(5)]
        public void Should_Delete_Customer()
        {
            int customerId = 1;
            CustomerService.DeleteCustomer(customerId);
            _unitOfWork.SaveChanges();
        }
    }
}
