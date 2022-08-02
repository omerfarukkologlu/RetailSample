using Invoice.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Data
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options)
            : base(options)
        { }

        public DbSet<InvoiceEntity> Invoice { get; set; }
        public DbSet<InvoiceLineEntity> InvoiceLine { get; set; }
        public DbSet<InvoiceDiscountEntity> InvoiceDiscount { get; set; }
        public DbSet<InvoiceAddressEntity> InvoiceAddress { get; set; }
    }
}
