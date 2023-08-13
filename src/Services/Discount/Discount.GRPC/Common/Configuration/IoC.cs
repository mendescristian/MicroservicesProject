using Discount.Infrastructure.Repositories.Interfaces;
using Discount.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.GRPC.Common.Configuration
{
    public static class IoC
    {
        public static void AddDependencyInject(this IServiceCollection collection)
        {
            collection.InjectRepositories();
        }

        private static void InjectRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IDiscountRepository, DiscountRepository>();
        }
    }
}
