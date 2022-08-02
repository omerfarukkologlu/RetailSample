using Customer.Core.Data;
using RetailSample.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Core.UnitOfWork
{
    public class CustomerUnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext customerDbContext;

        public CustomerUnitOfWork(CustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }

        public void SaveChanges()
        {
            customerDbContext.SaveChanges();
        }
    }
}
