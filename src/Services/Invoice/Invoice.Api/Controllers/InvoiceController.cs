using Invoice.Core.Dto;
using Invoice.Core.Services;
using Microsoft.AspNetCore.Mvc;
using RetailSample.Shared.Model;

namespace Invoice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceService invoiceService, ILogger<InvoiceController> logger)
        {
            this.invoiceService = invoiceService;
            _logger = logger;
        }

        [HttpPost]
        public ResponseModel<InvoiceDto> Post([FromBody] BillDto billDto)
        {
            var invoiceDetail = invoiceService.CreateInvoice(billDto);

            return ResponseModel<InvoiceDto>.Success(invoiceDetail);
        }

        public ResponseModel<List<InvoiceDto>> Get()
        {
            return ResponseModel<List<InvoiceDto>>.Success(invoiceService.GetInvoices());
        }

        [HttpGet("{Id}")]
        public ResponseModel<InvoiceDto> Get(int Id)
        {
            return ResponseModel<InvoiceDto>.Success(invoiceService.GetInvoiceById(Id));
        }

        [HttpDelete("{Id}")]
        public ResponseModel<bool> Delete(int Id)
        {
            return ResponseModel<bool>.Success(invoiceService.DeleteInvoice(Id));
        }
    }
}