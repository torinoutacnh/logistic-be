using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FU.Domain.Base
{
    public interface IRepository<T> where T:Entity
    {
        Task<T?> GetAsync(Guid id, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties);
        Task CreateAsync(T entity, CancellationToken token = default);
        Task CreateRangeAsync(T[] entity, CancellationToken token = default);
        Task UpdateAsync(T entity, CancellationToken token = default);
        Task UpdateAsync(T entity, CancellationToken token = default, params Expression<Func<T, object>>[] changedProperties);
        Task DeleteAsync(Guid id, bool isPhysical = false, CancellationToken token = default);
    }
}
