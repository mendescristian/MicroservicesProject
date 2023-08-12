using MicroservicesProject.Core.Entities.Redis;

namespace Basket.Infrastructure.Repositories.Interface
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasketAsync(string userName);
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);
        Task DeleteBasketAsync(string userName);
    }
}
