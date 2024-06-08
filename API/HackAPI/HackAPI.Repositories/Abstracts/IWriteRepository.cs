using HackAPI.Entities.Entities;
using HackAPI.Entities.Entities.Common;
using System.Linq.Expressions;

namespace HackAPI.Repositories.Abstracts
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        //Create
        Task<int> AddAsync(T entity);
        Task<int> AddAsync(IEnumerable<T> entities);
        //Update
        Task<int> UpdateAsync(T entity);
        int Update(T entity);
        //Delete
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate);
    }

}
