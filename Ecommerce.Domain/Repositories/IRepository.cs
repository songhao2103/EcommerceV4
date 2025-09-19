using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace EcommerceV4.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add one entity tu current DbSet
        /// </summary>
        /// <param name="entity">Entity object to add</param>
        /// <returns>Entity after being added to DbSet</returns>
        T Add(T entity);

        Task<T> AddAsync(T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entities);
        
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        T Update(T entity);

        /// <summary>
        /// Cập nhật trực tiếp entity thỏa mãn điều kiện trong DbSet bằng lệnh SQL,
        /// Bỏ qua cơ chế tracking của EF Core
        /// </summary>
        /// <param name="predicate">Biếu thức điều kiện lọc Entity (tương ứng với mệnh đề WHERE)</param>
        /// <param name="updateExpression">Biểu thức mô tả các field cần cập nhật</param>
        /// <returns>Số lượng entity đã được cập nhật trong database</returns>
        int ExecuteUpdate(Expression<Func<T, bool>> predicate, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> updateExpression);

        Task<int> ExecuteUpdateAsync(Expression<Func<T, bool>> predicate, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> updateExpresstion);

        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        
        T Remove(T entity);

        IEnumerable<T> RemoveRange(IEnumerable<T> entities);

        T? GetById(int id);

        Task<T?> GetByIdAsync(int id);

        IQueryable<T> GetAll(bool tracking = false);

        T? GetOne(Expression<Func<T, bool>> predicate);

        Task<T> GetOneAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> Query(Expression<Func<T, bool>> predicate, bool tracking = false);

        bool Any(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        int Count(Expression<Func<T, bool>>? predicate);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate);  
    }
}
