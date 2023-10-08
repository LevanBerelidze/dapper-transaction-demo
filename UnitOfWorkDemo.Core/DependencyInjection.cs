using Microsoft.Extensions.DependencyInjection;

namespace UnitOfWorkDemo.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
        }
    }
}
