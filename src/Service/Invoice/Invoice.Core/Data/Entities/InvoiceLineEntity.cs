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
    [Table("InvoiceLine", Schema = "dbo")]
    public class InvoiceLineEntity : BaseEntity
    {
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public virtual InvoiceEntity Invoice { get; set; }

        [Required]
        [MaxLength(200)]
        public string ItemName { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
