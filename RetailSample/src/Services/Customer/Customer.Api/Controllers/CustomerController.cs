using Customer.Core.Dto;
using Customer.Core.Services;
using Microsoft.AspNetCore.Mvc;
using RetailSample.Shared.Model;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            this.customerService = customerService;
            _logger = logger;
        }

        [HttpPost]
        public ResponseModel<bool> Post([FromBody]CreateCustomerDto createCustomerDto)
        {
            customerService.CreateCustomer(createCustomerDto);

            return ResponseModel<bool>.Success(true);
        }

        public ResponseModel<List<CustomerDto>> Get()
        {
            return ResponseModel<List<CustomerDto>>.Success(customerService.GetCustomers());
        }

        [HttpGet("{Id}")]
        public ResponseModel<CustomerDto> Get(int Id)
        {
            return ResponseModel<CustomerDto>.Success(customerService.GetCustomerById(Id));
        }

        [HttpPut]
        public ResponseModel<bool> Put([FromBody]UpdateCustomerDto updateCustomerDto)
        {
            customerService.UpdateCustomer(updateCustomerDto);

            return ResponseModel<bool>.Success(true);
        }

        [HttpDelete("{Id}")]
        public ResponseModel<bool> Delete(int Id)
        {
            customerService.DeleteCustomer(Id);

            return ResponseModel<bool>.Success(true);
        }
    }
}