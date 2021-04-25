using StellarPayRoll.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StellarPayRoll.Core.Domain.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<T> GetAsync(Guid id);

        Task<IEnumerable<T>> GetAsync(IList<Guid> ids);

        Task<bool> ExistsAsync(Guid id);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        IQueryable<T> Query();

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(Guid id);

        Task DeleteAsync(T entity);

        IQueryable<T> Query(Expression<Func<T, bool>> expression);

        Task<int> SaveChangesAsync();
    }
}
