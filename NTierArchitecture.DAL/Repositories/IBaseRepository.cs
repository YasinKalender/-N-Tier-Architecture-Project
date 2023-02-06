using System.Linq.Expressions;

namespace NTierArchitecture.DAL.Repositories
{
    public interface IBaseRepository<T> where T : class, new()
    {
        Task<T> GetByIdAsync(int Id);
        Task<bool> FindAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T,bool>> expression);
        Task<T> CreateAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
