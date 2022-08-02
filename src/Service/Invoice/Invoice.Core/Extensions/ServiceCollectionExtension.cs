using Invoice.Core.Data;
using Invoice.Core.Data.Repository;
using Invoice.Core.Manager;
using Invoice.Core.Mappers;
using Invoice.Core.Services;
using Invoice.Core.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailSample.Shared.Data.Repository;
using RetailSample.Shared.Middleware;
using RetailSample.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInvoiceApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvoiceDbContext>(options => options.UseInMemoryDatabase(databaseName: "InvoiceDb"));
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
            services.AddScoped<IInvoiceManager, InvoiceManager>();
            services.AddScoped<IUnitOfWork, InvoiceUnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            return services;
        }

        public static void UseCustomerApp(this IApplicationBuilder app)
        {
            app.UseMiddleware<TransactionMiddleware>();
        }
    }
}
