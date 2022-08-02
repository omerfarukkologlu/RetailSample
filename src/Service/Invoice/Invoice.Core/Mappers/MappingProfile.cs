using AutoMapper;
using Invoice.Core.Data.Entities;
using Invoice.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateInvoiceLineDto, InvoiceLineEntity>();
            CreateMap<CreateInvoiceDiscountDto, InvoiceDiscountEntity>();
            CreateMap<CreateInvoiceAddressDto, InvoiceAddressEntity>();
            CreateMap<CreateInvoiceDto, InvoiceEntity>();
            CreateMap<InvoiceLineEntity, InvoiceLineDto>();
            CreateMap<InvoiceDiscountEntity, InvoiceDiscountDto>();
            CreateMap<InvoiceAddressEntity, InvoiceAddressDto>();
            CreateMap<InvoiceEntity, InvoiceDto>();
        }
    }
}
