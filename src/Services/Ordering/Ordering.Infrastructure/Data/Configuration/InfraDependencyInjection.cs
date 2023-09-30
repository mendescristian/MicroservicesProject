using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Repositories;
using Ordering.Infrastructure.Repositories.Interfaces;

namespace Ordering.Infrastructure.Data.Configuration
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PostgreDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));

            return services;
        }
    }
}
