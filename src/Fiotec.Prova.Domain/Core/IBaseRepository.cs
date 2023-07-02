using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Domain.Core
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        abstract Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Add(T entity);
        Task Delete(T entity);
        Task DeleteAll(IEnumerable<T> entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetPage(IQueryable<T> query, int skip, int take);
        Task<int> CountAll();
        Task<int> CountAll(IQueryable<T> query);
    }
}
