using Common.Database;
using System.Data;
using System.Threading.Tasks;

namespace Common.Database
{
    public abstract class BaseRepository<TEntity> where TEntity : class, new()
    {
        public IDbConnectionProvider connectionProvider { get; private set; }
        private IDbTransaction dbTransaction;
        public IDbTransaction DbTransaction
        {
            get
            {
                if (dbTransaction == null && connectionProvider.DbTransaction != null)
                {
                    dbTransaction = connectionProvider.DbTransaction;
                }
                return dbTransaction;
            }
            set
            {
                dbTransaction = value;
            }
        }
        public string Schema => connectionProvider.Schema;
        private int? commandTimeout;
        public int CommandTimeout
        {
            get
            {
                return commandTimeout ?? 600;
            }
            set 
            { 
                commandTimeout = value; 
            }
        }
        public CommonConnection DbConnection;
        public BaseRepository(IDbConnectionProvider connectionProvider, IDbTransaction dbTransactionn)
        {
            this.connectionProvider = connectionProvider;
            DbTransaction = dbTransaction;
            DbConnection =  new CommonConnection(connectionProvider);
        }

        public Task<bool> DeleteAsync(TEntity entity) 
        {
            return DbConnection.DeleteAsync(entity, DbTransaction, CommandTimeout, schema: Schema);
        }
    }
}
