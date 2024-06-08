using HackathonAPI.Domain.Entities.Common;

namespace HackathonAPI.Application.Interfaces.Repositories.Common
{
    public interface IRepositoryManager
    {
        IReadRepository<T> GetReadRepository<T>() where T : BaseEntity;
        IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity;
        Task<int> SaveAsync();
        int Save();
    }
}
