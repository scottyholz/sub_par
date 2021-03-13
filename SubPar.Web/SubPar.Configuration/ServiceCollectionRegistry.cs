using System;
using Microsoft.Extensions.DependencyInjection;
using SubPar.Common;

namespace SubPar.Configuration
{
    public class ServiceCollectionRegistry
    {
        public void RegisterScopedServices(IServiceCollection services, AppSettings appSettings)
        {
           // services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
