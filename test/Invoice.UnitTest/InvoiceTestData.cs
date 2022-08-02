using Invoice.Core.Dto;
using RetailSample.Shared.Data.Enums;

namespace Invoice.UnitTest
{
    public static class InvoiceTestData
    {
        public static BillDto GetBill(
            CustomerType customerType = CustomerType.NotSet,
            DateTime? accountCreateDate = null,
            ItemType billItemType = ItemType.Jewel,
            decimal UnitPrice = 1
            )
        {
            return new BillDto
            {
                Customer = GetTestCustomer(customerType, accountCreateDate),
                Address = GetTestAddress(),
                Items = new List<BillItemDto>
                {
                    new BillItemDto
                    {
                        ItemName = "Test Item",
                        ItemType = billItemType,
                        Quantity = 1,
                        UnitPrice = UnitPrice
                    }
                }
            };
        }

        public static BillDto GetBillForEmployee()
        {
            return new BillDto
            {
                Customer = GetTestCustomer(CustomerType.Employee),
                Address = GetTestAddress(),
                Items = new List<BillItemDto>
                {
                    new BillItemDto
                    {
                        ItemName = "Test Item",
                        ItemType = ItemType.Clothes,
                        Quantity = 1,
                        UnitPrice = 100
                    }
                }
            };
        }

        public static BillDto GetBillForCustomerOver2Years()
        {
            return new BillDto
            {
                Customer = GetTestCustomer(CustomerType.NotSet, DateTime.Today.AddYears(-3)),
                Address = GetTestAddress(),
                Items = new List<BillItemDto>
                {
                    new BillItemDto
                    {
                        ItemName = "Test Item",
                        ItemType = ItemType.Clothes,
                        Quantity = 1,
                        UnitPrice = 100
                    }
                }
            };
        }

        public static BillDto GetBillForCustomer(decimal TotalBillAmount)
        {
            return new BillDto
            {
                Customer = GetTestCustomer(CustomerType.NotSet),
                Address = GetTestAddress(),
                Items = new List<BillItemDto>
                {
                    new BillItemDto
                    {
                        ItemName = "Test Item",
                        ItemType = ItemType.Clothes,
                        Quantity = 1,
                        UnitPrice = 100
                    }
                }
            };
        }

        public static BillDto GetBillForAffiliate()
        {
            return new BillDto
            {
                Customer = GetTestCustomer(CustomerType.Affiliate),
                Address = GetTestAddress(),
                Items = new List<BillItemDto>
                {
                    new BillItemDto
                    {
                        ItemName = "Test Item",
                        ItemType = ItemType.Clothes,
                        Quantity = 1,
                        UnitPrice = 100
                    }
                }
            };
        }

        public static BillCustomerDto GetTestCustomer(CustomerType customerType, DateTime? createDate = null)
        {
            return new BillCustomerDto
            {
                CustomerId = 1,
                CustomerType = customerType,
                Name = "Ömer Faruk",
                Surname = "Koloðlu",
                CreateDate = createDate,
                Fax = "",
                Phone = ""
            };
        }

        public static BillAddressDto GetTestAddress()
        {
            return new BillAddressDto
            {
                Country = "Turkey",
                City = "Ýstanbul",
                AddressDetail = "Nine Hatun Mah.",
                PostalCode = 34220,
                Region = ""
            };
        }
    }
}