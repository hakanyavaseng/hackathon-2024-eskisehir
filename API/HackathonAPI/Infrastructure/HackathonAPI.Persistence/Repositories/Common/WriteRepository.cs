using HackathonAPI.Application.Interfaces.Repositories.Common;
using HackathonAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace HackathonAPI.Persistence.Repositories.Common
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        public Task<int> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
