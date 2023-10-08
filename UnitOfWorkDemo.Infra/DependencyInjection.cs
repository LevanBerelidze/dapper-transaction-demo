using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using UnitOfWorkDemo.Core.Orders;
using UnitOfWorkDemo.Core.Persons;
using UnitOfWorkDemo.Core.Products;
using UnitOfWorkDemo.Infra.Common.Persistence;
using UnitOfWorkDemo.Infra.Orders;
using UnitOfWorkDemo.Infra.Persons;
using UnitOfWorkDemo.Infra.Products;

namespace UnitOfWorkDemo.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // The connection is opened when the service is first requested throughout the scope.
            // This is done because services of type IDisposable will automatically disposed by the DI container.
            // See https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-guidelines#disposal-of-services.
            // SqlConnection implements the IDisposable interface. Close method is automatically called during disposal
            // which, in turn, rolls back any pending transactions. See https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.close.
            services.AddScoped(x => x.GetRequiredService<IDbConnectionFactory>().Create(shouldOpen: true));
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
