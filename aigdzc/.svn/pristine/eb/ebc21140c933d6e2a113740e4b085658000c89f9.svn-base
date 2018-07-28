using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Victory.Dao;

namespace Dal
{
    public static class DataSources
    {
        private static IDataMapper _Default;
        private static object Locker = new object();

        static DataSources()
        {

        }

        public static void Init()
        {
            _Default = DataMapperProvider.Build("SqlConfig.xml", Assembly.GetExecutingAssembly(), "ConnectionString");
        }

        public static IDataMapper Default
        {
            get
            {
                lock (Locker)
                {
                    if (_Default == null)
                    {
                        Init();
                    }
                    return _Default;
                }
            }
        }

        public static DateTime CurrentTime
        {
            get
            {
                if (ConfigurationManager.AppSettings["WmsCore_TimeZone"] == "utc")
                {
                    return DateTime.UtcNow;
                }
                else
                {
                    return DateTime.Now;
                }
            }
        }
    }
}
