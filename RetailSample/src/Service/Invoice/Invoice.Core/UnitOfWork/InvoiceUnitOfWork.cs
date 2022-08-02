using Invoice.Core.Data;
using RetailSample.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.UnitOfWork
{
    public class InvoiceUnitOfWork : IUnitOfWork
    {
        private readonly InvoiceDbContext invoiceDbContext;

        public InvoiceUnitOfWork(InvoiceDbContext invoiceDbContext)
        {
            this.invoiceDbContext = invoiceDbContext;
        }

        public void SaveChanges()
        {
            invoiceDbContext.SaveChanges();
        }
    }
}
