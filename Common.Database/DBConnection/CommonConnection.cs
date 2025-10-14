using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Common.Database
{
    public class CommonConnection : IDisposable 
    {
        private IDbConnection DbConnection;
        private List<IDbTransaction> TransactionList;

        public CommonConnection(IDbConnectionProvider provider)
        {
            this.DbConnection = provider.DbConnection;
            provider.Connections.Add(this);
        }

        public async Task<int> InsertAsync<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null, string schema = null, string table = null, IsolationLevel? isolationLevel = null) where T : class
        {
            return 0;
        }
        public async Task<bool> DeleteAsync<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null, string schema = null, string table = null, IsolationLevel? isolationLevel = null) where T : class
        {
            return false;
        }
        public async Task<T> RetryOnExceptionWithTransactionAsync<T>(Func<IDbTransaction, Task<T>> func, IDbTransaction transaction = null, IsolationLevel? isolationLevel = null)
        {
            if(transaction != null)
            {
                return await func(transaction);
            }
            int retryCount = 5;
            int[] delayTime = { 10000, 20000, 40000, 60000 };
            for(int retry = 0; retry < retryCount; retry++)
            {
                IDbTransaction curentTransaction = null;
                try
                {
                    if (DbConnection.State == ConnectionState.Closed)
                    {
                        // log.Debug("Try to open connection");
                        DbConnection.Open();
                    }
                    if (func.Method.ReturnType.FullName.Contains("System.Data.IDataReader"))
                    {
                        curentTransaction = DbConnection.BeginTransaction(isolationLevel ?? IsolationLevel.Unspecified);
                        TransactionList.Add(curentTransaction);
                        return await func(curentTransaction);
                    }
                    using (curentTransaction = DbConnection.BeginTransaction(isolationLevel ?? IsolationLevel.Unspecified))
                    {
                        var result = await func(curentTransaction);
                        curentTransaction.Commit();
                        return result;
                    }
                }
                catch (Exception ex)                
                when(ex != null) // condition to keep retry 
                {

                    // add logic handle wait and retry
                    try
                    {
                        curentTransaction.Rollback();
                        curentTransaction.Dispose();
                    }
                    catch( Exception exx)
                    {
                        // log.Error($"Rollback failed")
                    }
                }
            }
            throw new Exception($"");
        }
        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbConnection?.Dispose();
                if (TransactionList != null)
                {
                    foreach( var transaction in  TransactionList )
                    {
                        transaction?.Dispose();
                    }
                }
            }
        }


    }
}
