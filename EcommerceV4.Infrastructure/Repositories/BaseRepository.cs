using EcommerceV4.Domain.Repositories;
using EcommerceV4.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV4.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected EcommerceDbContext _dbContext;
        protected DbSet<T> _dbSet;

        public BaseRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            return entry.Entity;
        }

        public virtual IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            return entities;
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public virtual T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public virtual int ExecuteUpdate(Expression<Func<T, bool>> predicate, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> updateExpression)
        {
            return _dbSet.Where(predicate).ExecuteUpdate(updateExpression);
        }

        public virtual async Task<int> ExecuteUpdateAsync(Expression<Func<T, bool>> predicate, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> updateExpression)
        {
            return await _dbSet.Where(predicate).ExecuteUpdateAsync(updateExpression);
        }

        public virtual IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            return entities;
        }

        public virtual T Remove(T entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public virtual IEnumerable<T> RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return entities;
        }

        public virtual T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual T? GetOne(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public virtual async Task<T?> GetOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> GetAll(bool tracking = false)
        {
            return tracking ? _dbSet : _dbSet.AsNoTracking();
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate, bool tracking = false)
        {
            return tracking ? _dbSet.Where(predicate) : _dbSet.AsNoTracking().Where(predicate);
        }

        public virtual IQueryable<T> Query(bool tracking = false)
        {
            return tracking ? _dbSet.AsQueryable() : _dbSet.AsNoTracking().AsQueryable();
        }

        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public virtual int Count(Expression<Func<T, bool>>? predicate)
        {
            return predicate != null ? _dbSet.Count(predicate) : _dbSet.Count();
        }

        public virtual Task<int> CountAsync(Expression<Func<T, bool>>? predicate)
        {
            return predicate != null ? _dbSet.CountAsync(predicate) : _dbSet.CountAsync();
        }
    }
}
