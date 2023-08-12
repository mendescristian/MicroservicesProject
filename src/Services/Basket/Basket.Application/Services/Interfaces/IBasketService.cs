using MicroservicesProject.Core.Entities.Redis;

namespace Basket.Application.Services.Interfaces
{
    public interface IBasketService
    {
        Task DeleteBasketAsync(string userName);
        Task<ShoppingCart> GetBasketAsync(string userName);
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);
    }
}
