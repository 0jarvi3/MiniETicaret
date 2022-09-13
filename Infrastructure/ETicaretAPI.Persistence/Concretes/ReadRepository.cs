using System.Linq.Expressions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Concretes;

public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ETicaretAPIDbContext _context;

    public ReadRepository(ETicaretAPIDbContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();


    public IQueryable<TEntity> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
           query = query.AsNoTracking();
        }
        return query;
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
    {
        var query = Table.Where(predicate);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }

    public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity?> GetByIdAsync(string id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
    }

}