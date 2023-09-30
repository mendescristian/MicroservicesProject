using MicroservicesProject.Core.Entities.PostgreSQL;
using MicroservicesProject.Core.Entities.PostgreSQL.Common;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Infrastructure.Data
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext(DbContextOptions<PostgreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
