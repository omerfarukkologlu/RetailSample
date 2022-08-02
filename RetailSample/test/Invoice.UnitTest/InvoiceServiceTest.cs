using AutoMapper;
using Invoice.Core.Data;
using Invoice.Core.Data.Repository;
using Invoice.Core.Manager;
using Invoice.Core.Mappers;
using Invoice.Core.Services;
using Invoice.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Priority;

namespace Invoice.UnitTest
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class InvoiceServiceTest
    {
        protected InvoiceService InvoiceService;
        protected MapperConfiguration MappingConfig { get; }
        protected IMapper Mapper { get; }
        protected InvoiceRepository InvoiceRepository { get; }
        protected InvoiceManager InvoiceManager { get; }
        protected InvoiceDbContext DbContext;
        protected InvoiceUnitOfWork _unitOfWork;
        public InvoiceServiceTest()
        {
            var dbOption = new DbContextOptionsBuilder<InvoiceDbContext>()
                                .UseInMemoryDatabase("InvoiceDb")
                                .Options;

            DbContext = new InvoiceDbContext(dbOption);
            _unitOfWork = new InvoiceUnitOfWork(DbContext);
            InvoiceRepository = new InvoiceRepository(DbContext);
            MappingConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            Mapper = MappingConfig.CreateMapper();
            InvoiceManager = new InvoiceManager();
            InvoiceService = new InvoiceService(InvoiceManager, InvoiceRepository, Mapper);
        }

        [Fact, Priority(1)]
        public void Should_Create_Invoice_For_Employee_With_30_Percent_Discount()
        {
            var testEmployeeInvoice = InvoiceTestData.GetBill(
                    customerType: RetailSample.Shared.Data.Enums.CustomerType.Employee,
                    accountCreateDate : null,
                    billItemType: RetailSample.Shared.Data.Enums.ItemType.Jewel,
                    UnitPrice: 100m
                );

            var invoice = InvoiceService.CreateInvoice(testEmployeeInvoice);
            _unitOfWork.SaveChanges();

            Assert.Equal(30, invoice.DiscountTotal);
        }

        [Fact, Priority(1)]
        public void Should_Create_Invoice_For_Affiliate_With_10_Percent_Discount()
        {
            var testEmployeeInvoice = InvoiceTestData.GetBill(
                    customerType: RetailSample.Shared.Data.Enums.CustomerType.Affiliate,
                    accountCreateDate: null,
                    billItemType: RetailSample.Shared.Data.Enums.ItemType.Jewel,
                    UnitPrice: 100m
                );

            var invoice = InvoiceService.CreateInvoice(testEmployeeInvoice);
            _unitOfWork.SaveChanges();

            Assert.Equal(10, invoice.DiscountTotal);
        }

        [Fact, Priority(1)]
        public void Should_Create_Invoice_For_Customer_Over_2_Years_With_5_Percent_Discount()
        {
            var testEmployeeInvoice = InvoiceTestData.GetBill(
                    customerType: RetailSample.Shared.Data.Enums.CustomerType.NotSet,
                    accountCreateDate: DateTime.Today.AddYears(-3),
                    billItemType: RetailSample.Shared.Data.Enums.ItemType.Jewel,
                    UnitPrice: 100m
                );

            var invoice = InvoiceService.CreateInvoice(testEmployeeInvoice);
            _unitOfWork.SaveChanges();

            Assert.Equal(5, invoice.DiscountTotal);
        }

        [Fact, Priority(1)]
        public void Should_Create_Invoice_Total_990_Dolar_Amount_With_45_Dolar_Discount()
        {
            var testEmployeeInvoice = InvoiceTestData.GetBill(
                    customerType: RetailSample.Shared.Data.Enums.CustomerType.NotSet,
                    accountCreateDate: null,
                    billItemType: RetailSample.Shared.Data.Enums.ItemType.Jewel,
                    UnitPrice: 990m
                );

            var invoice = InvoiceService.CreateInvoice(testEmployeeInvoice);
            _unitOfWork.SaveChanges();

            Assert.Equal(45, invoice.DiscountTotal);
        }

        [Fact, Priority(1)]
        public void Should_Create_Invoice_For_Customer_For_Item_Groceries_With_0_Discount()
        {
            var testEmployeeInvoice = InvoiceTestData.GetBill(
                    customerType: RetailSample.Shared.Data.Enums.CustomerType.Employee,
                    accountCreateDate: null,
                    billItemType: RetailSample.Shared.Data.Enums.ItemType.Groceries,
                    UnitPrice: 100m
                );

            var invoice = InvoiceService.CreateInvoice(testEmployeeInvoice);
            _unitOfWork.SaveChanges();

            Assert.Equal(0, invoice.DiscountTotal);
        }

        [Fact, Priority(2)]
        public void Should_Get_InvoiceInfo()
        {
            var invoiceId = 1;

            var invoice = InvoiceService.GetInvoiceById(invoiceId);

            Assert.NotNull(invoice);
        }

        [Fact, Priority(4)]
        public void Should_Get_5_Invoices()
        {
            var customers = InvoiceService.GetInvoices();

            Assert.Equal(5, customers.Count);
        }

        [Fact, Priority(5)]
        public void Should_Delete_Invoice()
        {
            int invoiceId = 1;
            InvoiceService.DeleteInvoice(invoiceId);
            _unitOfWork.SaveChanges();
        }
    }
}
