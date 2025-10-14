using Common.Database.DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public interface IDbConnectionProvider : IDisposable
    {
        IDbConnection DbConnection { get;}

         IDbTransaction DbTransaction { get; set; }
         List<CommonConnection> Connections { get; set; }
    }
}
