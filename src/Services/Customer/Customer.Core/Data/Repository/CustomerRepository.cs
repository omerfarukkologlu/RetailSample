using Customer.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using RetailSample.Shared.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Core.Data.Repository
{
    public interface ICustomerRepository : IRepository<CustomerEntity> { }

    public class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
