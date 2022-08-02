using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RetailSample.Shared.Model;
using RetailSample.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailSample.Shared.Middleware
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TransactionMiddleware> _logger;

        public TransactionMiddleware(RequestDelegate next, ILogger<TransactionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext, IUnitOfWork unitOfWork)
        {
            try
            {
                await _next(httpContext);
                unitOfWork.SaveChanges();

                _logger.LogInformation($"Transaction executed successfully");
            }
            catch(Exception ex)
            {
                if(ex is UserFriendlyException userFriendlyException)
                {
                    httpContext.Response.ContentType = "application/json";
                    var response = ResponseModel<string>.Error(ex.Message);
                    var json = JsonConvert.SerializeObject(response);
                    await httpContext.Response.WriteAsync(json);
                }
                else
                {
                    httpContext.Response.ContentType = "application/json";
                    var response = ResponseModel<string>.Error("An error occured.");
                    var json = JsonConvert.SerializeObject(response);
                    await httpContext.Response.WriteAsync(json);
                }

                _logger.LogError(ex, "There is error occured while execution transaction");
            }
        }
    }
}
