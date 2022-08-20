using Dapper.Application.Interfaces;
using Dapper.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Infrastructure.Service
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            //services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepositoryStoredProcedure>();
        }
    }
}
