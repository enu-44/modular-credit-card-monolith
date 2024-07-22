using System.Linq.Expressions;
using Common.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Infraestructure;

public class BaseMongoReadRepository<T, TContext> : IBaseMongoReadRepository<T, TContext>
    where T : class
    where TContext : DbContext
{
    private readonly TContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public BaseMongoReadRepository(TContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public int GetCount() => _dbSet.Count();

    public int GetCount(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).Count();

    public bool Exist(Expression<Func<T, bool>> predicate) => _dbSet.Any(predicate);

    public async Task<T?> FindSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _dbSet.AsQueryable();
        return await query.FirstOrDefaultAsync(predicate);
    }

    public IQueryable<T> Queryable() => _dbSet.AsQueryable();

    public async Task<IEnumerable<T>> AllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _dbSet.AsQueryable();
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        return await query.AsNoTracking().ToListAsync(cancellationToken);
    }
}