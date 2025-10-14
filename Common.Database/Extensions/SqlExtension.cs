using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public static class SqlExtension
    {
        public static Task<int> InsertAsync<T>(this IDbConnection connection, T entity, IDbTransaction transaction = null,
            int? commandTimeout = null, string schema = null, string table = null) where T: class 
        {
            var type = typeof(T);
            bool isList = false;
            if (type.IsArray)
            {
                isList = true;
                type = type.GetElementType();
            }
            else if (type.IsGenericType)
            {
                var typeInfo = type.GetElementType();

            
            }
            return  null ;
        }

        public static Task<int> DeleteAsync()
        {
            return null ;
        }
    }
}
