using Customer.Core.Data;
using Customer.Core.Data.Entities;
using Customer.Core.Data.Repository;
using Customer.Core.Mappers;
using Customer.Core.Services;
using Customer.Core.UnitOfWork;
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

namespace Customer.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomerApp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options => options.UseInMemoryDatabase(databaseName: "CustomerDb"));
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
            services.AddScoped<IUnitOfWork, CustomerUnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }

        public static void UseCustomerApp(this IApplicationBuilder app)
        {
            app.UseMiddleware<TransactionMiddleware>();
        }
    }
    
}
