using RetailSample.Shared.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Dto
{
    public class CreateInvoiceDto
    {
        public int CustomerId { get; set; }
        public CustomerType CustomerType { get; set; }
        public DateTime? CustomerCreateDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public string Phone { get; set; }
        public string Fax { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal NetAmount { get; set; }

        public List<CreateInvoiceLineDto> InvoiceLines { get; set; }
        public List<CreateInvoiceDiscountDto> InvoiceDiscounts { get; set; }
        public CreateInvoiceAddressDto InvoiceAddress { get; set; }
    }

    public class CreateInvoiceAddressDto
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int PostalCode { get; set; }
        public string AddressDetail { get; set; }
    }

    public class CreateInvoiceLineDto
    {
        public string ItemName { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }

    public class CreateInvoiceDiscountDto
    {
        public string Description { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
