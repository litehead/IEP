using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IEP.BusinessLogic.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindById(int id);
        Task<T> FindByIdAsync(int id);
    }
}
