using Discount.Application.Services;
using Discount.Application.Services.Interfaces;
using Discount.Infrastructure.Repositories;
using Discount.Infrastructure.Repositories.Interfaces;

namespace Discount.API.Common.Configuration
{
    public static class IoC
    {
        public static void AddDependencyInject(this IServiceCollection collection)
        {
            collection.InjectRepositories();
            collection.InjectImplementations();
        }

        private static void InjectRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IDiscountRepository, DiscountRepository>();
        }

        private static void InjectImplementations(this IServiceCollection collection)
        {
            collection.AddScoped<IDiscountService, DiscountService>();
        }
    }
}
