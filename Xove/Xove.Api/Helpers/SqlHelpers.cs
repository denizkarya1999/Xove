using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xove.Api.Helpers
{
    public static class SqlHelpers
    {
        public static string AddCondition(string clause, string appender, string condition)
        {
            if (clause.Length <= 0)
            {
                return string.Format("WHERE {0}", condition);
            }
            return string.Format("{0} {1} {2}", clause, appender, condition);
        }

        public static DateTime DefaultSqlDateTime = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
    }
}
