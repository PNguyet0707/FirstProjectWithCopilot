using System;
using System.Data;
namespace Common.Database
{
    internal class UnitOfWork : IUnitOfWorks, IDisposable
    {
        //private static readonly ILog  logger = new LogManager(MethodBase.GetCurrentMethod().DeclaringType);
        public IDbConnectionProvider DbConnectionProvider { get; private set; }
        public IDbTransaction DbTransaction { get; private set; }

        public string Schema {  get; private set; }
        public IDbConnection DbConnection => DbConnectionProvider.DbConnection;
        public UnitOfWork(IDbConnectionProvider dbConnectionProvider) 
        {
            DbConnectionProvider = dbConnectionProvider;
            Schema = dbConnectionProvider.Schema;
        }
        public void Commit()
        {
            if (DbTransaction != null)
            {
                // loger.Debug();
                DbTransaction.Commit();
            }
        }
        public void RollBack()
        {
            if (DbTransaction != null)
            {
                //log.Debug();
                DbTransaction.Rollback();
            }
        }
        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            DbTransaction?.Dispose();
            DbConnectionProvider?.Dispose();
        }

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.Unspecified);
        }
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            //log.Debug();
            DbTransaction = DbConnectionProvider.DbConnection.BeginTransaction();
            DbConnectionProvider.DbTransaction = DbTransaction;
        }
    }
}
