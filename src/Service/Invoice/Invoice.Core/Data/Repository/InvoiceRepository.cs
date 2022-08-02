using Invoice.Core.Data.Entities;
using RetailSample.Shared.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Data.Repository
{
    public interface IInvoiceRepository : IRepository<InvoiceEntity> { }

    public class InvoiceRepository : BaseRepository<InvoiceEntity>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
