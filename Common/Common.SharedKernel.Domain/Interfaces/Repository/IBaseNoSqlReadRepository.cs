using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Domain;

public interface IBaseMongoReadRepository<T, TContext> 
    where T : class
    where TContext : DbContext
{
    int GetCount();
    bool Exist(Expression<Func<T, bool>> predicate);
    int GetCount(Expression<Func<T, bool>> predicate);
    IQueryable<T> Queryable();
    Task<T?> FindSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> AllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
}