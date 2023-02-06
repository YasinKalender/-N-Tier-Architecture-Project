using NTierArchitecture.DAL.Context;
using NTierArchitecture.DAL.Repositories;

namespace NTierArchitecture.DAL.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _projectContext;

        public UnitOfWork(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public void Commit()
        {
            _projectContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _projectContext.SaveChangesAsync();
        }

        public IBaseRepository<T> GetBaseRepository<T>() where T : class, new()
        {
            return new BaseRepository<T>(_projectContext);
        }
    }
}
