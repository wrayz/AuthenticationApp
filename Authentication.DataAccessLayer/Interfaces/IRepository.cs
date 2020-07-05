using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Authentication.DataAccessLayer.Interfaces
{

    public interface IRepository<T>
    {
        Task<int> CreateAsync(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IQueryable<T>> ReadsAsync();

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(T entity);

        Task<int> SaveAsync();
    }
}
