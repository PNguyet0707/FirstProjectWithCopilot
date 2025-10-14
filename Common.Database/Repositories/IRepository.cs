using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Database
{
    public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TKey id);
        Task<TEntity> DeleteAsync(TEntity entity);
    }
}
