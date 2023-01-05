using EducationApp.Persistence.ConfigurationJson;
using EducationApp.Persistence.Context;
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
            ///  services.AddSingleton<IProductServices, ProductServices>();
            ///  services.AddDbContext<EtradeAPIContext>(option => option.UseNpgsql(""));
            services.AddDbContext<EducationAppContext>(option => option.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
