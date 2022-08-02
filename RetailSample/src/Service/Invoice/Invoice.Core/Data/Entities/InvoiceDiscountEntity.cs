using RetailSample.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Data.Entities
{
    [Table("InvoiceDiscount", Schema = "dbo")]
    public class InvoiceDiscountEntity : BaseEntity
    {
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public virtual InvoiceEntity Invoice { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
