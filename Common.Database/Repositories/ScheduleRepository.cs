using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database.Repositories
{
    internal class ScheduleRepository : Repository<Schedule, string>
    {
        public ScheduleRepository(IDbConnectionProvider connectionProvider, IDbTransaction dbTransaction = null) : base(connectionProvider, dbTransaction)
        {
        }
    }
}
