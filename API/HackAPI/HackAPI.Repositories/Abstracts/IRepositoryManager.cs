using HackAPI.Entities.Entities.Common;

namespace HackAPI.Repositories.Abstracts
{
    public interface IRepositoryManager 
    {
        IReadRepository<T> GetReadRepository<T>() where T : BaseEntity;
        IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity;
        Task<int> SaveAsync();
        int Save();
    }
}
