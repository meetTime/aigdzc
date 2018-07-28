using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace CCITU.Common
{
    /* web.config中的配置
     <connectionStrings>
        <add name="SqlServer" connectionString="data source=XX;uid=XX;pwd=XX;database=XX;Pooling=true;Max Pool Size=100"/>
     </connectionStrings>
     <system.web>
        <caching>
            <sqlCacheDependency enabled="true" pollTime="5000">
            <databases>
                <add connectionStringName="SqlServer" name="SqlDependency"/>
            </databases>
            </sqlCacheDependency>
        </caching>
      </system.web>
     * 数据库执行语句“ALTER DATABASE 【数据库名】 SET ENABLE_BROKER”
     */
    public class SqlDependencyUtils
    {
        private static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        private static Cache Cache = HttpRuntime.Cache;
        private static int Timeout = 3600;//单位秒

        /**
         * 一般该方法会放在Application_Start中初始化
         * **/
        public static void Start()
        {
            SqlDependency.Start(ConnectionString);
        }

        /**
         * 一般该方法会放在Application_End中执行
         * **/
        public static void Stop()
        {
            SqlDependency.Stop(ConnectionString);
        }

        public static void Add(string tableName)
        {
            Add(new string[] { tableName });
        }

        /**
         * 一般该方法会放在Application_Start中初始化
         * **/
        public static void Add(string[] tableNames)
        {
            SqlCacheDependencyAdmin.EnableNotifications(ConnectionString);
            SqlCacheDependencyAdmin.EnableTableForNotifications(ConnectionString, tableNames);
        }

        public static void Insert(string tableName, object data)
        {
            Insert(tableName, data, Timeout);
        }

        /**
         * 该方法放在需要存储缓存的地方
         * **/
        public static void Insert(string tableName, object data, int cacheTime)
        {
            //制定缓存策略,"SqlDependency"是web.config中的名称.
            System.Web.Caching.SqlCacheDependency scd = new System.Web.Caching.SqlCacheDependency("SqlDependency", tableName);
            //插入缓存
            Cache.Insert(tableName, data, scd, DateTime.Now.AddSeconds(cacheTime), Cache.NoSlidingExpiration);
        }

        public static object Get(string tableName)
        {
            return Cache.Get(tableName);
        }

        public static void Remove(string tableName)
        {
            Cache.Remove(tableName);
        }
    }
}
