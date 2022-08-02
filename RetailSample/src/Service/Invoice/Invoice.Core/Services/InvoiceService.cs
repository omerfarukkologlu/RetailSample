using AutoMapper;
using Invoice.Core.Data.Entities;
using Invoice.Core.Data.Repository;
using Invoice.Core.Dto;
using Invoice.Core.Exceptions;
using Invoice.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Services
{
    public interface IInvoiceService
    {
        public InvoiceDto CreateInvoice(BillDto billDto);
        public InvoiceDto GetInvoiceById(int Id);
        public List<InvoiceDto> GetInvoices();
        public bool DeleteInvoice(int Id);
    }

    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceManager _invoiceManager;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        public InvoiceService(IInvoiceManager invoiceManager, IInvoiceRepository invoiceRepository,
            IMapper mapper)
        {
            _invoiceManager = invoiceManager;
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public InvoiceDto GetInvoiceById(int Id)
        {
            var invoice = _invoiceRepository.GetById(Id);

            if (invoice == null)
                throw new InvoiceNotFoundException();

            return _mapper.Map<InvoiceDto>(invoice);
        }

        public InvoiceDto CreateInvoice(BillDto billDto)
        {
            var createDto = _invoiceManager.CreateInvoiceFromBill(billDto);

            var entity = _mapper.Map<InvoiceEntity>(createDto);

            _invoiceRepository.Add(entity);

            return _mapper.Map<InvoiceDto>(entity);
        }

        public List<InvoiceDto> GetInvoices()
        {
            return _mapper.Map<List<InvoiceDto>>(_invoiceRepository.GetAll());
        }

        public bool DeleteInvoice(int Id)
        {
            var invoice = _invoiceRepository.GetById(Id);

            if (invoice == null)
                throw new InvoiceNotFoundException();

            _invoiceRepository.Delete(invoice);

            return true;
        }
    }
}
