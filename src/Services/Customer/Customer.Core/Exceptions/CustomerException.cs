using RetailSample.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Core.Exceptions
{
    public class CustomerException : UserFriendlyException
    {
        public CustomerException(string errorMessage) : base(errorMessage)
        {
        }
    }

    public class CustomerNotFoundException : CustomerException
    {
        public CustomerNotFoundException() : base("Customer couldn't found!")
        {
        }
    }
}
