using Basket.Application.Services.Interfaces;
using Basket.Infrastructure.Repositories.Interface;
using MicroservicesProject.Core.Entities.Redis;

namespace Basket.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _repository;

        public BasketService(IBasketRepository repository)
            => _repository = repository;

        public async Task<ShoppingCart> GetBasketAsync(string userName)
        {
            var basket = await _repository.GetBasketAsync(userName);

            return basket ?? new ShoppingCart(userName);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket)
        {
            var basketUpdated = await _repository.UpdateBasketAsync(basket);

            return basketUpdated;
        }

        public async Task DeleteBasketAsync(string userName)
            => await _repository.DeleteBasketAsync(userName);
    }
}
