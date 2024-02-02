using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
            // Tüm Mediator handler'ları dahil etmek için statik sınıf kullandın ve AddApplicationService metodunu ekledik.
            // builder.Services parametresine override yaptık bir nevi
        }
    }
}
