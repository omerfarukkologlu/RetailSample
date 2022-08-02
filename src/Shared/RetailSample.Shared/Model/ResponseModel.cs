using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailSample.Shared.Model
{
    public class ResponseModel<TResult>
    {
        public TResult Data { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public static ResponseModel<TResult> Success(TResult data)
        {
            return new ResponseModel<TResult>
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static ResponseModel<TResult> Error(string errorMessage)
        {
            return new ResponseModel<TResult>
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
