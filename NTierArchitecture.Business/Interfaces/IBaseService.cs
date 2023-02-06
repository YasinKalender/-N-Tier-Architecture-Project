using System.Linq.Expressions;

namespace NTierArchitecture.Business.Interfaces
{
    public interface IBaseService<T> where T : class, new()
    {
        Task<T> GetByIdAsync(int Id);
        Task<bool> FindAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
