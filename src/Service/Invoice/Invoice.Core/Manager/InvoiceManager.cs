using Invoice.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Manager
{
    public interface IInvoiceManager
    {
        public CreateInvoiceDto CreateInvoiceFromBill(BillDto billDto);
     }
    public class InvoiceManager : IInvoiceManager
    {
        public CreateInvoiceDto CreateInvoiceFromBill(BillDto billDto)
        {
            var createInvoiceDto = new CreateInvoiceDto { 
                Surname = billDto.Customer.Surname,
                CustomerCreateDate = billDto.Customer.CreateDate,
                CustomerId = billDto.Customer.CustomerId,
                CustomerType = billDto.Customer.CustomerType,
                Fax = billDto.Customer.Fax,
                Name = billDto.Customer.Name,
                Phone = billDto.Customer.Phone,
                InvoiceAddress = new CreateInvoiceAddressDto
                {
                    AddressDetail = billDto.Address.AddressDetail,
                    City = billDto.Address.City,
                    Country = billDto.Address.Country,
                    PostalCode = billDto.Address.PostalCode,
                    Region = billDto.Address.Region
                }
            };

            createInvoiceDto.InvoiceLines = new List<CreateInvoiceLineDto>();
            createInvoiceDto.InvoiceDiscounts = new List<CreateInvoiceDiscountDto>();
            var invoiceDiscounts = new List<CreateInvoiceDiscountDto>();

            foreach(var item in billDto.Items)
            {
                var lineTotal = item.UnitPrice * item.Quantity;

                createInvoiceDto.InvoiceLines.Add(new CreateInvoiceLineDto
                {
                    ItemName = item.ItemName,
                    ItemType = item.ItemType,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    LineTotal = lineTotal
                });

                if(item.ItemType != RetailSample.Shared.Data.Enums.ItemType.Groceries)
                {
                    if (billDto.Customer.CustomerType == RetailSample.Shared.Data.Enums.CustomerType.Employee)
                    {
                        invoiceDiscounts.Add(new CreateInvoiceDiscountDto
                        {
                            Description = "Employee discount (%30)",
                            DiscountAmount = lineTotal * 0.3m
                        });
                    }
                    else if(billDto.Customer.CustomerType == RetailSample.Shared.Data.Enums.CustomerType.Affiliate)
                    {
                        invoiceDiscounts.Add(new CreateInvoiceDiscountDto
                        {
                            Description = "Affiliate discount (%10)",
                            DiscountAmount = lineTotal * 0.1m
                        });
                    }
                    else if(billDto.Customer.CreateDate != null && billDto.Customer.CreateDate.Value.AddYears(2) <= DateTime.Today)
                    {
                        invoiceDiscounts.Add(new CreateInvoiceDiscountDto
                        {
                            Description = "Over 2 year customer (%5)",
                            DiscountAmount = lineTotal * 0.05m
                        });
                    }
                }
            }

            createInvoiceDto.GrossAmount = createInvoiceDto.InvoiceLines.Sum(o => o.LineTotal);

            if (createInvoiceDto.GrossAmount > 100m)
            {
                invoiceDiscounts.Add(new CreateInvoiceDiscountDto
                {
                    Description = "Discount per 100$ (5$)",
                    DiscountAmount = Math.Floor(createInvoiceDto.GrossAmount / 100m) * 5m
                });
            }

            foreach (var discount in invoiceDiscounts.GroupBy(o => o.Description))
            {
                createInvoiceDto.InvoiceDiscounts.Add(new CreateInvoiceDiscountDto
                {
                    Description = discount.Key,
                    DiscountAmount = discount.Sum(o => o.DiscountAmount)
                });
            }

            createInvoiceDto.DiscountTotal = createInvoiceDto.InvoiceDiscounts.Sum(o => o.DiscountAmount);
            createInvoiceDto.NetAmount = createInvoiceDto.GrossAmount - createInvoiceDto.DiscountTotal;

            return createInvoiceDto;
        }
    }
}
