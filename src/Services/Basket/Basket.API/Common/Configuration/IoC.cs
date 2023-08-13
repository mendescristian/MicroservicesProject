using Basket.API.GRPCServices;
using Basket.Application.Services;
using Basket.Application.Services.Interfaces;
using Basket.Infrastructure.Repositories;
using Basket.Infrastructure.Repositories.Interface;
using Discount.GRPC.Protos;

namespace Basket.API.Common.Configuration
{
    public static class IoC
    {
        public static void AddDependencyInject(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.InjectRepositories();
            collection.InjectImplementations();
            collection.InjectClients(configuration);
        }

        private static void InjectRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IBasketRepository, BasketRepository>();
        }

        private static void InjectImplementations(this IServiceCollection collection)
        {
            collection.AddScoped<IBasketService, BasketService>();
            collection.AddScoped<DiscountGRPCService>();
        }

        private static void InjectClients(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
                opt => opt.Address = new Uri(configuration.GetSection("GrpcSettings:DiscountUrl").Value));
        }
    }
}
