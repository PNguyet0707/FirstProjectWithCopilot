using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
namespace Common.Database
{
    public abstract class Repository<TEntity, TKey> : BaseRepository<TEntity>, IRepository<TEntity, TKey> where TEntity : Entity<TKey>, new()
    {
        public Repository(IDbConnectionProvider connectionProvider, IDbTransaction dbTransaction = null) : base(connectionProvider, dbTransaction) { }

        public Task<TEntity> DeleteAsync(TKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
 