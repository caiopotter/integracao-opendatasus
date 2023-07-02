using Fiotec.Prova.Domain.Core;
using Fiotec.Prova.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.Data.Base
{
    public class RepositoryBase<T> : IBaseRepository<T> where T : class
    {
        protected SqlContext _context;
        protected DbSet<T> _DbSet;

        protected RepositoryBase(SqlContext context)
        {
            _context = context;
            _DbSet = context.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            await _DbSet.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _DbSet.FindAsync(id);
        }

        public virtual async Task Update(T entity)
        {
            await Task.FromResult(_context.Entry(entity).State = EntityState.Modified);
        }

        public virtual async Task<IEnumerable<T>> GetPage(IQueryable<T> query, int skip, int take)
        {
            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<int> CountAll()
        {
            return await _DbSet.AsNoTracking().CountAsync();
        }

        public virtual async Task<int> CountAll(IQueryable<T> query)
        {
            return await query.AsNoTracking().CountAsync();
        }

        public virtual Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAll(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
