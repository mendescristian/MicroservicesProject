using MicroservicesProject.Core.Entities.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Interfaces;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(PostgreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Order>> GetOrdersByUserNameAsync(string userName)
        {
            var orders = await _context.Orders
                                       .Where(o => o.UserName == userName)
                                       .ToListAsync();

            return orders;
        }
    }
}
