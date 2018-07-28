using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Collections.Specialized;
using System.Data;
using Newtonsoft.Json;

namespace CCITU.Common
{
    public class Utils
    {
        #region Enum

        public static List<EnumItem> GetEnumItems(Type enumType)
        {
            return GetEnumItems(enumType, EnumSortType.Default);
        }

        public static List<EnumItem> GetEnumItems(Type enumType, EnumSortType enumSortType)
        {
            List<EnumItem> list = new List<EnumItem>();

            Array array = Enum.GetValues(enumType);

            for (int i = 0; i < array.Length; i++)
            {
                int value = (int)array.GetValue(i);
                string name = Enum.GetName(enumType, value);

                EnumProperty ep = GetEnumProperty(enumType, value);
                if (ep == null)
                {
                    ep = new EnumProperty(string.Empty, 0);
                }

                EnumItem item = new EnumItem() { Name = name, Value = value, Description = ep.Description, Rank = ep.Rank };
                list.Add(item);
            }

            if (enumSortType != EnumSortType.Default)
            {
                list.Sort(new EnumComparer(enumSortType));
            }

            return list;
        }

        public static EnumItem GetEnumItem(Type enumType, int value)
        {
            List<EnumItem> list = GetEnumItems(enumType);
            List<EnumItem> items = list.Where(T => (int)T.Value == value).ToList();
            return items[0];
        }

        public static EnumItem GetEnumItem(Type enumType, string name)
        {
            List<EnumItem> list = GetEnumItems(enumType);
            List<EnumItem> items = list.Where(T => T.Name == name).ToList();
            return items[0];
        }

        public static T GetEnumItem<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        private static EnumProperty GetEnumProperty(Type enumType, object value)
        {
            FieldInfo fi = enumType.GetField(Enum.GetName(enumType, value));
            EnumProperty[] eps = (EnumProperty[])fi.GetCustomAttributes(typeof(EnumProperty), false);

            if (eps.Length > 0)
            {
                return eps[0];
            }
            return null;
        }

        #endregion
        
        #region Other

        public static T DeepCopy<T>(T t)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, t);
            memoryStream.Position = 0;
            T r = (T)formatter.Deserialize(memoryStream);
            return r;
        }

        public static string Join(List<int> list, string split)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int i in list)
            {
                sb.AppendFormat("{0}{1}", i, split);
            }
            if (sb.Length > 0)
            {
                return sb.ToString(0, sb.Length - split.Length);
            }
            return string.Empty;
        }

        public static List<long> StringToLongList(string s, string separate)
        {
            List<long> list = new List<long>();
            if (string.IsNullOrEmpty(s))
            {
                return list;
            }

            var arr = s.Split(new string[] { separate }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in arr)
            {
                list.Add(long.Parse(item));
            }
            return list;
        }

        public static List<int> StringToIntList(string s, string separate)
        {
            List<int> list = new List<int>();
            if(string.IsNullOrEmpty(s))
            {
                return list;
            }

            var arr = s.Split(new string[] { separate }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in arr)
            {
                list.Add(int.Parse(item));
            }
            return list;
        }

        public static List<string> StringToStringList(string s, string separate)
        {
            List<string> list = new List<string>();
            if (string.IsNullOrEmpty(s))
            {
                return list;
            }

            var arr = s.Split(new string[] { separate }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in arr)
            {
                list.Add(item);
            }
            return list;
        }

        public static string NameValueCollectionToString(NameValueCollection nv)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nv.Count; i++)
            {
                sb.AppendFormat("{0}={1};", nv.Keys[i], nv[i]);
            }

            if (sb.Length > 0)
            {
                return sb.ToString(0, sb.Length - 1);
            }

            return string.Empty;
        }

        public static void FillModelValues(object model, DataRow row)
        {
            Type modelType = model.GetType();
            PropertyInfo[] properties = modelType.GetProperties();

            foreach (var item in properties)
            {
                if (row.Table.Columns.Contains(item.Name))
                {
                    object value = row[item.Name];
                    SetPropertyValue(item, model, value);
                }
            }
        }

        private static void SetPropertyValue(PropertyInfo propertyInfo, object model, object value)
        {
            if (value == DBNull.Value)
            {
                value = null;
            }


            if (value != null && propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GenericTypeArguments[0].IsEnum)
            {
                var e = Enum.ToObject(propertyInfo.PropertyType.GenericTypeArguments[0], value);
                propertyInfo.SetValue(model, e, null);
            }
            else
            {
                propertyInfo.SetValue(model, value, null);
            }
        }

        #endregion
        
        #region IpAddress

        public static uint ConvertIpAddressToInt(string ipaddress)
        {
            IPAddress ip = IPAddress.Parse(ipaddress);
            var bytes = ip.GetAddressBytes();
            Array.Reverse(bytes);
            uint n = BitConverter.ToUInt32(bytes, 0);
            return n;
        }

        public static string ConvertIntToIpAddress(uint value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            IPAddress ip = new IPAddress(bytes);
            return ip.ToString();
        }

        public static uint GetNetworkAddress(uint ipaddress, int networkId)
        {
            uint c = (uint)(1 << networkId) - 1;
            uint d = (uint)c << (32 - networkId);
            return ipaddress & d;
        }

        static Regex cidrRegex = new Regex(@"^(\d{1,3}\.){3}\d{1,3}/\d{1,2}$", RegexOptions.IgnoreCase);
        public static bool IsCidr(string ipaddress)
        {
            bool m = cidrRegex.IsMatch(ipaddress);
            if (m) //验证格式
            {
                var arr = ipaddress.Split('/');
                IPAddress ip;
                if (IPAddress.TryParse(arr[0], out ip)) //验证Ip
                {
                    int networkId = int.Parse(arr[1]);
                    if (networkId >= 0 && networkId <= 32) //验证networkId
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region 身份证

        private static int[] IdCardWeight = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };    //十七位数字本体码权重
        private static char[] IdCardCheckCode = { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };    //mod11,对应校验码字符值    

        public static char GetIdCardCheckCode(String id17)
        {
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                var s = id17.Substring(i, 1);
                int c = int.Parse(s);
                int w = IdCardWeight[i];
                sum += c * w;
            }

            int mode = sum % 11;
            return IdCardCheckCode[mode];
        }

        #endregion
        
        #region Json

        /// <summary>
        /// Deserializes the JSON to the specified .NET type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T JsonDeserializeObject<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string JsonSerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        #endregion

    
    }


}
