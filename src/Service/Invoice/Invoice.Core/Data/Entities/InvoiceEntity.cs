using RetailSample.Shared.Data.Entities;
using RetailSample.Shared.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Data.Entities
{
    [Table("Invoice", Schema = "dbo")]
    public class InvoiceEntity : BaseEntity
    {
        public int CustomerId { get; set; }
        public CustomerType CustomerType { get; set; }
        public DateTime? CustomerCreateDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Surname { get; set; }

        public virtual InvoiceAddressEntity InvoiceAddress { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal NetAmount { get; set; }

        public virtual ICollection<InvoiceLineEntity> InvoiceLines { get; set; }
        public virtual ICollection<InvoiceDiscountEntity> InvoiceDiscounts { get; set; }
    }
}
