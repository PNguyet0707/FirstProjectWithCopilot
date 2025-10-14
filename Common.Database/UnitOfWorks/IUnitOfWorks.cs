using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    internal interface IUnitOfWorks : IDisposable
    {
        IDbTransaction DbTransaction { get; }
        //IDbConnectionPro
    }
}
