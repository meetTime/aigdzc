﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;


namespace Victory.Dao
{
    public interface IDataProviderFactory
    {
        DbConnection CreateConnection();
        DbCommand CreateCommand();
        DbParameter CreateParameter();
        DbDataAdapter CreateDataAdapter();
    }
}
