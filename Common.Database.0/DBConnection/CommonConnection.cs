using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database.DBConnection
{
    public class CommonConnection : IDisposable 
    {
        private IDbConnection DbConnection;
        private List<IDbTransaction> TransactionList;

        public CommonConnection(IDbConnectionProvider provider)
        {
            this.DbConnection = provider.DbConnection;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
