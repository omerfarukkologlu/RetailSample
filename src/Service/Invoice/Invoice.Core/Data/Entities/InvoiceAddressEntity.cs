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
    [Table("InvoiceAddress", Schema = "dbo")]
    public class InvoiceAddressEntity : BaseEntity
    {
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public virtual InvoiceEntity Invoice { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(200)]
        public string City { get; set; }

        [MaxLength(200)]
        public string Region { get; set; }

        public int PostalCode { get; set; }

        [Required]
        [MaxLength(1000)]
        public string AddressDetail { get; set; }
    }
}
