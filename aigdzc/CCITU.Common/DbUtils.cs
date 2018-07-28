using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    //防注入
    public class DbUtils
    {
        /// <summary>
        /// 将指定的值转换为String,转换不成功时返回Null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            return ToString(obj, null);
        }

        /// <summary>
        /// 将指定的值转换为String,转换不成功时返回defaultValue
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ToString(object obj, string defaultValue)
        {
            if (obj == DBNull.Value)
            {
                return defaultValue;
            }
            return (string)obj;
        }


        /// <summary>
        /// 将指定的值转换为DateTime,转换不成功时返回Null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(object obj)
        {
            if (obj == DBNull.Value)
            {
                return null;
            }
            return (DateTime)obj;
        }


        /// <summary>
        /// 将指定的值转换为Int,转换不成功时返回Null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ToInt(object obj)
        {
            if (obj == DBNull.Value || obj==null)
            {
                return null;
            }
            return (int)obj;
        }


        /// <summary>
        /// 将指定的值转换为Int,转换不成功时返回defaultValue
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(object obj, int defaultValue)
        {
            int? a = DbUtils.ToInt(obj);
            if (a == null)
            {
                return defaultValue;
            }
            return a.Value;
        }


        /// <summary>
        /// 将指定的值转换为Decimal,转换不成功时返回Null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(object obj)
        {
            if (obj == DBNull.Value)
            {
                return null;
            }
            return (decimal)obj;
        }


        /// <summary>
        /// 将指定的值转换为Decimal,转换不成功时返回defaultValue
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj, decimal defaultValue)
        {
            decimal? a = DbUtils.ToDecimal(obj);
            if (a == null)
            {
                return defaultValue;
            }
            return a.Value;
        }


        /// <summary>
        /// 将指定的值转换为Bool,转换不成功时返回Null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool? ToBool(object obj)
        {
            if (obj == DBNull.Value)
            {
                return null;
            }
            return (bool)obj;
        }

        /// <summary>
        /// 将指定的值转换为Bool,转换不成功时返回defaultValue
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBool(object obj, bool defaultValue)
        {
            bool? a = DbUtils.ToBool(obj);
            if (a == null)
            {
                return defaultValue;
            }
            return a.Value;
        }

        /// <summary>
        /// 将传入的list转换为Where in 语句中的参数，如: 'a','b','c'，如果list.count=0，返回"null"
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToWhereInParam(IEnumerable<string> list)
        {
            if (list.Count() == 0)
            {
                return "null";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("'");
            sb.Append(string.Join("','", list));
            sb.Append("'");
            return sb.ToString();
        }

        /// <summary>
        /// 将传入的list转换为Where in 语句中的参数，如: 1,2,3，如果list.count=0，返回"null"
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToWhereInParam(IEnumerable<int> list)
        {
            if (list.Count() == 0)
            {
                return "null";
            }

            StringBuilder sb = new StringBuilder();            
            sb.Append(string.Join(",", list));
            return sb.ToString();
        }

        /// <summary>
        /// 将匿名类型List集合 转换成 DataTable
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public static DataTable ListToTable<T>(List<T> entitys)
        {
            DataTable table = new DataTable();
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("空");
            }
            else
            {
                PropertyInfo[] propertys = entitys[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    table.Columns.Add(pi.Name, pi.PropertyType);
                }

                for (int i = 0; i < entitys.Count; i++)
                {
                    ArrayList tenpList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(entitys[i], null);
                        tenpList.Add(obj);
                    }
                    object[] array = tenpList.ToArray();
                    table.LoadDataRow(array, true);
                }
            }
            return table;
        }

        /// <summary>
        /// 将指定类型List集合 转换成 DataTable
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public static DataTable ListToTable(IList entitys)
        {
            DataTable table = new DataTable();
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("空");
            }
            else
            {
                PropertyInfo[] propertys = entitys[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    table.Columns.Add(pi.Name, pi.PropertyType);
                }

                for (int i = 0; i < entitys.Count; i++)
                {
                    ArrayList tenpList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(entitys[i], null);
                        tenpList.Add(obj);
                    }
                    object[] array = tenpList.ToArray();
                    table.LoadDataRow(array, true);
                }
            }
            return table;
        }
    }
}
