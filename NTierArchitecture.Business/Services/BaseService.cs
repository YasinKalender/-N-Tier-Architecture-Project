using NTierArchitecture.Business.Exceptions;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.DAL.Uow;
using System.Linq.Expressions;

namespace NTierArchitecture.Business.Services
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _unitOfWork.GetBaseRepository<T>().AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _unitOfWork.GetBaseRepository<T>().CreateAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _unitOfWork.GetBaseRepository<T>().Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _unitOfWork.GetBaseRepository<T>().FindAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _unitOfWork.GetBaseRepository<T>().GetAll();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _unitOfWork.GetBaseRepository<T>().GetAll(expression);
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            var existData = await _unitOfWork.GetBaseRepository<T>().GetByIdAsync(Id);

            if (existData == null)
                throw new ClientSideExcepiton($"{typeof(T).Name} not found");

            return await _unitOfWork.GetBaseRepository<T>().GetByIdAsync(Id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _unitOfWork.GetBaseRepository<T>().Update(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }
    }
}
