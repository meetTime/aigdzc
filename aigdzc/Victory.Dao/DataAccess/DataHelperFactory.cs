using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Victory.Dao
{
    public class DataHelperFactory
    {
        public static IDataHelper Create(DatabaseType dbType,string connStr)
        {
            switch (dbType)
            {
                case DatabaseType.SqlServer: return new SqlServerHelper(connStr);
                case DatabaseType.Orcale: return new SqlServerHelper(connStr);
                case DatabaseType.Odbc: return new OdbcHelper(connStr);
                case DatabaseType.Oledb: return new OleDbHelper(connStr);

                default: throw new System.Configuration.ConfigurationErrorsException("暂不支持此类型的数据库.");
            }
        }
    }

    public enum DatabaseType
    {
        SqlServer=1,
        Orcale=2,
        Odbc=3,
        Oledb=4

    }
}
