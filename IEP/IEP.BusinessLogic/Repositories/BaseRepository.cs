using System;
using IEP.BusinessLogic.Contracts;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IEP.BusinessLogic.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = unitOfWork.Context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            var result = _dbSet.AsQueryable();
            if (filter != null)
            {
                result = result.Where(filter);
            }
            return result;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public Task<T> FindByIdAsync(int id)
        {
            return _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
