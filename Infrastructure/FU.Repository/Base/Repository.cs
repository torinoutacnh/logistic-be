using FU.Domain.Base;
using FU.Infras.Utils;
using FU.Repository.DbStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FU.Repository.Base
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly Store _store;
        protected readonly DbSet<T> _dbSet;

        public Repository(Store store)
        {
            _store = store;
            _dbSet = _store.Set<T>();
        }

        public Task CreateAsync(T entity, CancellationToken token = default)
        {
            return _dbSet.AddAsync(entity, token).AsTask();
        }

        public Task CreateRangeAsync(T[] entity, CancellationToken token = default)
        {
            return _dbSet.AddRangeAsync(entity, token);
        }

        public Task DeleteAsync(Guid id,bool isPhysical = false, CancellationToken token = default)
        {
            var entity = _dbSet.FirstOrDefault(x=>x.Id == id);
            if (entity == null) return Task.CompletedTask;
            if(isPhysical) _dbSet.Remove(entity);
            else
            {
                var tracker = _dbSet.Attach(entity);
                tracker.Property(o => o.IsDeleted).CurrentValue = true;
                tracker.Property(o => o.UpdatedDate).CurrentValue = DateTimeOffset.Now;
                tracker.State = EntityState.Modified;
            }
            return Task.CompletedTask;
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var notIncludeDeleteExpression = expression?.AndAlso<T>((T x) => x.IsDeleted == false);

            includeProperties = includeProperties.Distinct().ToArray();
            var source = isIncludeDeleted ?
                (expression != null ?
                    _dbSet.Where(expression)
                    : _dbSet.AsQueryable())
                : (notIncludeDeleteExpression != null ?
                    _dbSet.Where(notIncludeDeleteExpression)
                    : _dbSet.Where(x => x.IsDeleted == false));
            foreach (Expression<Func<T, object>> navigationPropertyPath in includeProperties)
                source.Include(navigationPropertyPath);

            return source.ToListAsync();
        }

        public Task<List<TResult>> GetAllToAsync<TResult>(Func<T,TResult> f,Expression<Func<T, bool>>? expression = null, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var notIncludeDeleteExpression = expression?.AndAlso<T>((T x) => x.IsDeleted == false);

            includeProperties = includeProperties.Distinct().ToArray();
            var source = isIncludeDeleted ?
                (expression != null ?
                    _dbSet.Where(expression)
                    : _dbSet.AsQueryable())
                : (notIncludeDeleteExpression != null ?
                    _dbSet.Where(notIncludeDeleteExpression)
                    : _dbSet.Where(x => x.IsDeleted == false));
            foreach (Expression<Func<T, object>> navigationPropertyPath in includeProperties)
                source.Include(navigationPropertyPath);

            return source.Select(x=>f(x)).ToListAsync();
        }

        public Task<T?> GetAsync(Guid id, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var source = (isIncludeDeleted ?
                _dbSet.Where(x => x.Id == id)
                : _dbSet.Where(x => x.Id == id && x.IsDeleted == false));

            includeProperties = includeProperties.Distinct().ToArray();
            foreach (Expression<Func<T, object>> navigationPropertyPath in includeProperties)
            {
                source = source.Include(navigationPropertyPath);
            }

            return source.FirstOrDefaultAsync();
        }

        public Task<T?> GetAsync(Expression<Func<T, bool>>? expression, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var notIncludeDeleteExpression = expression?.AndAlso<T>((T x) => x.IsDeleted == false);

            includeProperties = includeProperties.Distinct().ToArray();
            var source = (isIncludeDeleted ?
                (expression != null ?
                    _dbSet.Where(expression)
                    : _dbSet.AsQueryable())
                : (notIncludeDeleteExpression != null ?
                    _dbSet.Where(notIncludeDeleteExpression)
                    : _dbSet.Where(x => x.IsDeleted == false)));

            foreach (Expression<Func<T, object>> navigationPropertyPath in includeProperties)
                source.Include(navigationPropertyPath);

            return source.FirstOrDefaultAsync();
        }

        public Task UpdateAsync(T entity, CancellationToken token = default)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity, CancellationToken token = default, params Expression<Func<T, object>>[] changedProperties)
        {
            var entry = _store.Attach(entity);
            foreach (Expression<Func<T, object>> propertyExpression in changedProperties.Distinct().ToArray())
            {
                entry.Property(propertyExpression).IsModified = true;
            }
            entry.State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
