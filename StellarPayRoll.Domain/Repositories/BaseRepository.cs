using Microsoft.EntityFrameworkCore;
using StellarPayRoll.Core.Domain.Repositories;
using StellarPayRoll.Core.Models.Entities;
using StellarPayRoll.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StellarPayRoll.Domain.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected AppDBContext DbContext { get; set; }

        public async Task<T> GetAsync(Guid id)
        {
            return await DbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>> GetAsync(IList<Guid> ids)
        {
            return await DbContext.Set<T>().Where(e => ids.Contains(e.Id)).ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await DbContext.Set<T>().AnyAsync(e => e.Id == id);
        }

        public IQueryable<T> Query()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression);
        }

        public async Task<T> AddAsync(T entity)
        {

            await DbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public Task<T> UpdateAsync(T entity)
        {

            DbContext.Entry(entity).State = EntityState.Modified;

            return Task.FromResult(entity);
        }

        public Task DeleteAsync(Guid id)
        {
            var entity = new T
            {
                Id = id
            };

            DbContext.Entry(entity).State = EntityState.Deleted;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Deleted;

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
        {
            await DbContext.AddRangeAsync(entities);
            return entities;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await DbContext.Set<T>().AnyAsync(expression);
        }
    }
}
