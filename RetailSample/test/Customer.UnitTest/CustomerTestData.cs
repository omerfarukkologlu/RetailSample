using Customer.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.UnitTest
{
    public static class CustomerTestData
    {
        public static CreateCustomerDto GetCustomerForCreate()
        {
            return new CreateCustomerDto
            {
                Name = "Ömer Faruk",
                Surname = "Koloğlu",
                City = "İstanbul",
                Country = "Turkey",
                AddressDetail = "Nine Hatun Mah.",
                Phone = "0 (535) 627 50 75",
                PostalCode = 34220,
                Fax = "",
                Region = ""
            };
        }

        public static UpdateCustomerDto GetCustomerForUpdate()
        {
            return new UpdateCustomerDto
            {
                Name = "Ömer Faruk",
                Surname = "Koloğlu",
                City = "İstanbul",
                Country = "Turkey",
                AddressDetail = "Nine Hatun Mah.",
                Phone = "0 (535) 627 50 75",
                PostalCode = 34220,
                Fax = "",
                Region = "",
                Id = 1
            };
        }
    }
}
