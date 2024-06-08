using HackathonAPI.Application.Interfaces.Repositories.Common;
using HackathonAPI.Domain.Entities.Common;

namespace HackathonAPI.Persistence.Repositories.Common
{
    public class RepositoryManager : IRepositoryManager
    {
        public IReadRepository<T> GetReadRepository<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
