using MicroservicesProject.Core.Entities.PostgreSQL;
namespace Ordering.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserNameAsync(string userName);
    }
}
