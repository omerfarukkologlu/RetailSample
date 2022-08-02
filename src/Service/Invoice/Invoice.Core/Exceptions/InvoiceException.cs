using RetailSample.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Exceptions
{
    public class InvoiceException : UserFriendlyException
    {
        public InvoiceException(string errorMessage) : base(errorMessage)
        {
        }
    }

    public class InvoiceNotFoundException : InvoiceException
    {
        public InvoiceNotFoundException() : base("Invoice couldn't found!")
        {
        }
    }
}
