using Common.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{ 
    public abstract class DbConnectionProvider : IDbConnectionProvider
    {
        private IDbConnection dbConnection;
        private IDbTransaction transaction;

        public IDbTransaction dbTransaction
        {
            get
            {
                return transaction;
            }
            set
            {
                transaction = value;
            }
        }

        public IDbTransaction DbTransaction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDbConnection DbConnection
        {
            get
            {
                if (dbConnection == null)
                {
                    dbConnection = CreateDbConnection();
                    TryOpen();
                }
                else if (dbConnection.State == ConnectionState.Closed)
                {
                    TryOpen();
                }
                return dbConnection;
            }
            protected set
            {
                dbConnection = value;
            }
        }

        public List<CommonConnection> Connections { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Schema { get; protected set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected abstract IDbConnection CreateDbConnection();
        private void TryOpen()
        {
            var retryCount = 0;
            while (retryCount <= 5)
            {
                try
                {
                    dbConnection.Open();
                    break;

                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
