using RetailSample.Shared.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Dto
{
    public class BillDto
    {
        public BillCustomerDto Customer { get; set; }
        public List<BillItemDto> Items { get; set; }
        public BillAddressDto Address { get; set; }
    }

    public class BillCustomerDto
    {
        public CustomerType CustomerType { get; set; }
        public DateTime? CreateDate { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        
    }

    public class BillAddressDto
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int PostalCode { get; set; }
        public string AddressDetail { get; set; }
    }

    public class BillItemDto
    {
        public string ItemName { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
