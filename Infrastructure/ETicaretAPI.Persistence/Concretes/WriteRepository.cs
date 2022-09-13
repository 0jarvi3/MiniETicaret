using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ETicaretAPI.Persistence.Concretes;

public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
{

    readonly private ETicaretAPIDbContext _context;
    public WriteRepository(ETicaretAPIDbContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();
    public async Task<bool> AddAsync(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }
    public async Task<bool> AddRangeAsync(IList<TEntity> entities)
    {
        await Table.AddRangeAsync(entities);
        return true;
    }
    public bool Delete(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }
    public bool DeleteRange(IList<TEntity> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }
    public async Task<bool> DeleteAsync(string id)
    {
        TEntity? entity = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        return Delete(entity);
    }
    public bool Update(TEntity entity)
    {
        EntityEntry entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }
    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();


}
