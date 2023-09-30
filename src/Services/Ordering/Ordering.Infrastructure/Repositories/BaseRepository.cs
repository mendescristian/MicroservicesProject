using MicroservicesProject.Core.Entities.PostgreSQL.Common;
using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Ordering.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : EntityBase
    {
        protected readonly PostgreDbContext _context;

        public BaseRepository(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            return await DefineQueryWithOptionsAsync(query, disableTracking, predicate, orderBy, null, includeString);
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            return await DefineQueryWithOptionsAsync(query, disableTracking, predicate, orderBy, includes, null);
        }

        public virtual async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        private async Task<IReadOnlyList<T>> DefineQueryWithOptionsAsync(IQueryable<T> query, bool disableTracking, Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<Expression<Func<T, object>>> includes, string includeString)
        {
            if (disableTracking)
                query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString))
                query = query.Include(includeString);

            if (includes != null)
                query = includes.Aggregate(query, (current, include)
                    => current.Include(include));

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }
    }
}
