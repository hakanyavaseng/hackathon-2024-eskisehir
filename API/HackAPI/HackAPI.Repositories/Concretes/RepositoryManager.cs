using HackAPI.Data.Contexts;
using HackAPI.Repositories.Abstracts;

namespace HackAPI.Repositories.Concretes
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly HackDbContext context;
        public RepositoryManager(HackDbContext context)
        {
            this.context = context;
        }
        public async ValueTask DisposeAsync() => await context.DisposeAsync();
        public int Save() => context.SaveChanges();
        public async Task<int> SaveAsync() => await context.SaveChangesAsync();
        IReadRepository<T> IRepositoryManager.GetReadRepository<T>() => new ReadRepository<T>(context);
        IWriteRepository<T> IRepositoryManager.GetWriteRepository<T>() => new WriteRepository<T>(context);
    }
}
