using Basket.Application.Services;
using Basket.Application.Services.Interfaces;
using Basket.Infrastructure.Repositories.Interface;

namespace Basket.API.Common.Configuration
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
            collection.AddScoped<IBasketRepository, IBasketRepository>();
        }

        private static void InjectImplementations(this IServiceCollection collection)
        {
            collection.AddScoped<IBasketService, BasketService>();
        }
    }
}
