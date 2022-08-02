using RetailSample.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Core.Data.Entities
{
    [Table("Customer", Schema = "dbo")]
    public class CustomerEntity : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Surname { get; set; }

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

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }
    }
}
