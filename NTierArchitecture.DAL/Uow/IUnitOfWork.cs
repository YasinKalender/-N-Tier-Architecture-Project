using NTierArchitecture.DAL.Repositories;

namespace NTierArchitecture.DAL.Uow
{
    public interface IUnitOfWork
    {
        public IBaseRepository<T> GetBaseRepository<T>() where T : class, new();
        Task CommitAsync();
        void Commit();
    }
}
