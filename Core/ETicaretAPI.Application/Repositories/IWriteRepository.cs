using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories;

public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    Task<bool> AddAsync(TEntity entity);
    Task<bool> AddRangeAsync(IList<TEntity> entities);
    bool Delete(TEntity entity);
    bool DeleteRange(IList<TEntity> entities);
    Task<bool> DeleteAsync(string id);
    bool Update(TEntity entity);
    Task<int> SaveAsync();

}