using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailSample.Shared.Model
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(string errorMessage) : base(errorMessage) { }
    }
}
