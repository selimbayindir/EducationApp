using EducationApp.Persistence.Concrete.Repositories;
using EducationApp.Persistence.ConfigurationJson;
using EducationApp.Persistence.Context;
using EducationAPP.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            //services.AddDbContext<EducationAppContext>(option => option.UseSqlServer(Configuration.ConnectionString));
            //AddScoped
            //services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            //services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            //services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            //services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            //services.AddScoped<IProductReadRepository, ProductReadRepository>();
            //services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            //SingleTon
            services.AddDbContext<EducationAppContext>(option => option.UseSqlServer(Configuration.ConnectionString),ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();


        }
    }
}
