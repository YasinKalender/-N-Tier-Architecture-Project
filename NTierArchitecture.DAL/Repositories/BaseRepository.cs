using Microsoft.EntityFrameworkCore;
using NTierArchitecture.DAL.Context;
using System.Linq.Expressions;

namespace NTierArchitecture.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected ProjectContext _projectContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
            _dbSet = _projectContext.Set<T>();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking().Where(expression).AsQueryable();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }
    }
}
