using Catalog.Application.Services;
using Catalog.Application.Services.Interfaces;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Data.Interface;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Repositories.Interface;

namespace Catalog.API.Common.Configuration
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
            collection.AddScoped<IMongoDBContext, MongoDBContext>();

            collection.AddScoped<IProductRepository, ProductRepository>();
        }

        private static void InjectImplementations(this IServiceCollection collection)
        {
            collection.AddScoped<IProductService, ProductService>();
        }
    }
}
