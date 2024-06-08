using HackAPI.Entities.Entities.Common;
using HackAPI.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HackAPI.Repositories.Concretes
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly DbContext context;
        public WriteRepository(DbContext context)
        {
            this.context = context;
        }
        protected DbSet<T> Table => context.Set<T>();

        public virtual async Task<int> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<int> AddAsync(IEnumerable<T> entities)
        {
            if (entities is not null && !entities.Any())
                return 0;

            await Table.AddRangeAsync(entities);
            return await context.SaveChangesAsync();
        }
        public virtual int Update(T entity)
        {
            Table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return context.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            Table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return await context.SaveChangesAsync();
        }
        public virtual async Task<int> DeleteAsync(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                Table.Attach(entity);

            Table.Remove(entity);

            return await context.SaveChangesAsync();
        }
        public virtual async Task<int> DeleteAsync(Guid id)
        {
            var entity = await Table.FindAsync(id);
            return await DeleteAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            context.RemoveRange(Table.Where(predicate));
            return await context.SaveChangesAsync() > 0;
        }

        public IQueryable<T> AsQueryable()
        {
            return Table.AsQueryable();
        }
    }

}
