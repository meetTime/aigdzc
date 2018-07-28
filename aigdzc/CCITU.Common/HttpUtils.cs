using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CCITU.Common
{
    public class HttpUtils
    {
        #region 默认值

        public const string DefaultStringValue="";
        public const int DefaultIntValue = 0;
        public const decimal DefaultDecimalValue = 0;
        public const long DefaultLongValue = 0;
        public const bool DefaultBoolValue = false;
        //public static DateTime DefaultDateTimeValue = DateTime.Now; 调用时生成

        #endregion


        #region Query操作

        /// <summary>
        /// 获得查询字符串变量集合
        /// </summary>        
        /// <returns></returns>
        public static NameValueCollection GetQueryString()
        {
            return HttpContext.Current.Request.QueryString;
        }

        /// <summary>
        /// 获得查询字符串中的值，不存在时返回Null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetQueryNullString(string key)
        {
            var nvc = GetQueryString();
            return nvc[key];
        }
        
        /// <summary>
        /// 获得查询字符串中的值，不存在或转换失败时返回defaultValue
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetQueryString(string key, string defaultValue=DefaultStringValue)
        {
            string value = GetQueryNullString(key);
            return value != null ? value : defaultValue;
        }



        /// <summary>
        /// 获得查询字符串中的值，不存在返回Null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static int? GetQueryNullInt(string key)
        {
            var value = GetQueryString(key);
            int intValue;
            if (int.TryParse(value, out intValue))
            {
                return intValue;
            }
            return null;
        }

        /// <summary>
        /// 获得查询字符串中的值，不存在或转换失败返回defaultValue
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetQueryInt(string key, int defaultValue=DefaultIntValue)
        {
            var value=GetQueryNullInt(key);
            return value.HasValue ? value.Value : defaultValue;
        }

       


        /// <summary>
        /// 获得查询字符串中的值，不存在或转换失败时返回null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static decimal? GetQueryNullDecimal(string key)
        {
            var value = GetQueryString(key);
            decimal decimalValue;
            if (decimal.TryParse(value, out decimalValue))
            {
                return decimalValue;
            }
            return null;
        }

        /// <summary>
        /// 获得查询字符串中的值，不存在或转换失败时返回defaultValue
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal GetQueryDecimal(string key, decimal defaultValue=DefaultDecimalValue)
        {
            var value = GetQueryNullDecimal(key);
            return value.HasValue ? value.Value : defaultValue;
        }
     



        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static bool? GetQueryNullBool(string key)
        {
            var value = GetQueryString(key);
            bool boolValue;
            if (bool.TryParse(value, out boolValue))
            {
                return boolValue;
            }
            return null;
        }
        
        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool GetQueryBool(string key, bool defaultValue=DefaultBoolValue)
        {
            var value = GetQueryNullBool(key);
            return value.HasValue ? value.Value : defaultValue;
        }
       



        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static DateTime? GetQueryNullDateTime(string key)
        {
            var value = GetQueryString(key);
            DateTime dateTimeValue;
            if (DateTime.TryParse(value, out dateTimeValue))
            {
                return dateTimeValue;
            }
            return null;
        }

        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime GetQueryDateTime(string key, DateTime defaultValue)
        {
            var value = GetQueryNullDateTime(key);
            return value.HasValue ? value.Value : defaultValue;
        }

        /// <summary>
        /// 获得Form中的值，找不到时返回当前时间
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static DateTime GetQueryDateTime(string key)
        {
            return GetQueryDateTime(key, DateTime.Now);
        }

        #endregion


        #region Form操作

        /// <summary>
        /// 获得Form变量集合
        /// </summary>        
        /// <returns></returns>
        public static NameValueCollection GetFormString()
        {
            return HttpContext.Current.Request.Form;
        }

        /// <summary>
        /// 获得Form中的值，不存在时返回Null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetFormNullString(string key)
        {
            var nvc = GetFormString();
            return nvc[key];
        }

        /// <summary>
        /// 获得Form中的值，不存在或转换失败时返回defaultValue
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetFormString(string key, string defaultValue = DefaultStringValue)
        {
            string value = GetFormString(key);
            return value != null ? value : defaultValue;
        }



        /// <summary>
        /// 获得Form中的值，不存在返回Null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static int? GetFormNullInt(string key)
        {
            var value = GetFormString(key);
            int intValue;
            if (int.TryParse(value, out intValue))
            {
                return intValue;
            }
            return null;
        }

        /// <summary>
        /// 获得Form中的值，不存在或转换失败返回defaultValue
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetFormInt(string key, int defaultValue = DefaultIntValue)
        {
            var value = GetFormNullInt(key);
            return value.HasValue ? value.Value : defaultValue;
        }




        /// <summary>
        /// 获得Form中的值，不存在或转换失败时返回null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static decimal? GetFormNullDecimal(string key)
        {
            var value = GetFormString(key);
            decimal decimalValue;
            if (decimal.TryParse(value, out decimalValue))
            {
                return decimalValue;
            }
            return null;
        }

        /// <summary>
        /// 获得Form中的值，不存在或转换失败时返回defaultValue
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal GetFormDecimal(string key, decimal defaultValue = DefaultDecimalValue)
        {
            var value = GetFormNullDecimal(key);
            return value.HasValue ? value.Value : defaultValue;
        }




        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static bool? GetFormNullBool(string key)
        {
            var value = GetFormString(key);
            bool boolValue;
            if (bool.TryParse(value, out boolValue))
            {
                return boolValue;
            }
            return null;
        }

        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool GetFormBool(string key, bool defaultValue = DefaultBoolValue)
        {
            var value = GetFormNullBool(key);
            return value.HasValue ? value.Value : defaultValue;
        }




        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static DateTime? GetFormNullDateTime(string key)
        {
            var value = GetFormString(key);
            DateTime dateTimeValue;
            if (DateTime.TryParse(value, out dateTimeValue))
            {
                return dateTimeValue;
            }
            return null;
        }

        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime GetFormDateTime(string key, DateTime defaultValue)
        {
            var value = GetFormNullDateTime(key);
            return value.HasValue ? value.Value : defaultValue;
        }

        /// <summary>
        /// 获得Form中的值，找不到时返回当前时间
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static DateTime GetFormDateTime(string key)
        {
            return GetFormDateTime(key, DateTime.Now);
        }

        #endregion


        #region Request操作

        /// <summary>
        /// 获得Form(优先)和查询字符串变量集合
        /// </summary>        
        /// <returns></returns>
        public static NameValueCollection GetRequestString()
        {
            var nvc1 = GetFormString();
            var nvc2 = GetQueryString();

            for (int i = 0; i < nvc2.Count; i++)
            {
                string key=nvc2.Keys[i];
                string valueInNvc1=nvc1[key];

                if (valueInNvc1==null)
                {
                    nvc1.Add(key, valueInNvc1);
                }
            }
            return nvc1;
        }

        /// <summary>
        /// 获得Form(优先)和查询字符串中的值，不存在时返回Null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetRequestNullString(string key)
        {
            var nvc = GetRequestString();
            return nvc[key];
        }

        /// <summary>
        /// 获得Form(优先)和查询字符串中的值，不存在或转换失败时返回defaultValue
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetRequestString(string key, string defaultValue = DefaultStringValue)
        {
            string value = GetRequestNullString(key);
            return value != null ? value : defaultValue;
        }



        /// <summary>
        /// 获得Form(优先)和查询字符串中的值，不存在返回Null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static int? GetRequestNullInt(string key)
        {
            var value = GetRequestString(key);
            int intValue;
            if (int.TryParse(value, out intValue))
            {
                return intValue;
            }
            return null;
        }

        /// <summary>
        /// 获得Form(优先)和查询字符串中的值，不存在或转换失败返回defaultValue
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetRequestInt(string key, int defaultValue = DefaultIntValue)
        {
            var value = GetRequestNullInt(key);
            return value.HasValue ? value.Value : defaultValue;
        }




        /// <summary>
        /// 获得Form(优先)和查询字符串中的值，不存在或转换失败时返回null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static decimal? GetRequestNullDecimal(string key)
        {
            var value = GetRequestString(key);
            decimal decimalValue;
            if (decimal.TryParse(value, out decimalValue))
            {
                return decimalValue;
            }
            return null;
        }

        /// <summary>
        /// 获得Form(优先)和查询字符串中的值，不存在或转换失败时返回defaultValue
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal GetRequestDecimal(string key, decimal defaultValue = DefaultDecimalValue)
        {
            var value = GetRequestNullDecimal(key);
            return value.HasValue ? value.Value : defaultValue;
        }




        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static bool? GetRequestNullBool(string key)
        {
            var value = GetRequestString(key);
            bool boolValue;
            if (bool.TryParse(value, out boolValue))
            {
                return boolValue;
            }
            return null;
        }

        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool GetRequestBool(string key, bool defaultValue = DefaultBoolValue)
        {
            var value = GetRequestNullBool(key);
            return value.HasValue ? value.Value : defaultValue;
        }




        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static DateTime? GetRequestNullDateTime(string key)
        {
            var value = GetRequestString(key);
            DateTime dateTimeValue;
            if (DateTime.TryParse(value, out dateTimeValue))
            {
                return dateTimeValue;
            }
            return null;
        }

        /// <summary>
        /// 获得Form中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime GetRequestDateTime(string key, DateTime defaultValue)
        {
            var value = GetRequestNullDateTime(key);
            return value.HasValue ? value.Value : defaultValue;
        }

        /// <summary>
        /// 获得Form中的值，找不到时返回当前时间
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static DateTime GetRequestDateTime(string key)
        {
            return GetRequestDateTime(key, DateTime.Now);
        }

        #endregion

        
        #region Cookie

        public static void AddCookie(string key, string value)
        {
            HttpCookie cookie = new HttpCookie(key, value);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void AddCookie(string key, string value, int timeoutMinutes)
        {
            HttpCookie cookie = new HttpCookie(key, value);
            if (timeoutMinutes == 0)
            {
                cookie.Expires = DateTime.MinValue;
            }
            else
            {
                cookie.Expires = DateTime.Now.AddMinutes(timeoutMinutes);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void RemoveCookie(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                HttpCookie cookie = new HttpCookie(key);
                cookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 删除指定名称的Cookie
        /// </summary>
        /// <param name="name">Cookie名称</param>
        public static void DeleteCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }

        /// <summary>
        /// 获得指定名称的Cookie值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <returns></returns>
        public static string GetCookie(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
                return cookie.Value;

            return string.Empty;
        }

        /// <summary>
        /// 获得指定名称的Cookie中特定键的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetCookie(string name, string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null && cookie.HasKeys)
            {
                string v = cookie[key];
                if (v != null)
                    return v;
            }

            return string.Empty;
        }

        /// <summary>
        /// 设置指定名称的Cookie的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">值</param>
        public static void SetCookie(string name, string value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
                cookie.Value = value;
            else
                cookie = new HttpCookie(name, value);

            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 设置指定名称的Cookie的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public static void SetCookie(string name, string value, double expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
                cookie = new HttpCookie(name);

            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 设置指定名称的Cookie特定键的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetCookie(string name, string key, string value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
                cookie = new HttpCookie(name);

            cookie[key] = value;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 设置指定名称的Cookie特定键的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public static void SetCookie(string name, string key, string value, double expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
                cookie = new HttpCookie(name);

            cookie[key] = value;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        #endregion


        public static string GetRootPath(HttpApplication app)
        {
            string currentUrl = app.Request.Url.ToString().ToLower();

            string http = "http://";
            if (currentUrl.StartsWith("https"))
            {
                http = "https://";
            }

            string host = app.Request.Url.Host;

            string port = string.Empty;
            if (app.Request.Url.Port != 80)
            {
                port = ":" + app.Request.Url.Port;
            }

            string applicationPath = string.Empty;
            if (app.Request.ApplicationPath != "/") //使用虚拟路径 
            {
                applicationPath = app.Request.ApplicationPath;
            }

            return http + host + port + applicationPath;
        }

        /// <summary>
        /// 是否是get请求
        /// </summary>
        /// <returns></returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod == "GET";
        }

        /// <summary>
        /// 是否是post请求
        /// </summary>
        /// <returns></returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod == "POST";
        }

        /// <summary>
        /// 是否是Ajax请求
        /// </summary>
        /// <returns></returns>
        public static bool IsAjax()
        {
            return HttpContext.Current.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (!string.IsNullOrEmpty(userHostAddress))
            {
                return userHostAddress;
            }

            userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(userHostAddress))
            {
                return userHostAddress;
            }

            userHostAddress = HttpContext.Current.Request.UserHostAddress;
            return userHostAddress;
        }


        /// <summary>
        ///  对 URL 字符串进行编码，默认使用UTF8。
        /// </summary>
        /// <param name="s">要编码的文本</param>
        /// <returns></returns>
        public static string UrlEncode(string s)
        {
            return HttpUtility.UrlEncode(s, Encoding.UTF8);
        }

        /// <summary>
        /// 对 URL 字符串进行编码。
        /// </summary>
        /// <param name="s">要编码的文本</param>
        /// <param name="encoding">指定编码方案的 System.Text.Encoding 对象。</param>
        /// <returns></returns>
        public static string UrlEncode(string s,Encoding encoding)
        {
            return HttpUtility.UrlEncode(s,encoding);
        }

        /// <summary>
        ///  对 URL 字符串进行解码，默认使用UTF8
        /// </summary>
        /// <param name="s">要解码的文本</param>
        /// <returns></returns>
        public static string UrlDecode(string s)
        {
            return HttpUtility.UrlDecode(s, Encoding.UTF8);
        }

        /// <summary>
        /// 对 URL 字符串进行解码。
        /// </summary>
        /// <param name="s">要解码的文本</param>
        /// <param name="encoding">指定解码方案的 System.Text.Encoding 对象。</param>
        /// <returns></returns>
        public static string UrlDecode(string s, Encoding encoding)
        {
            return HttpUtility.UrlDecode(s, encoding);
        }

        public static string ConvertNameValueCollectionToString(NameValueCollection nv)
        {
            if (nv == null)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            bool first = true;

            for (int i = 0; i < nv.Count; i++)
            {
                string key = nv.GetKey(i);
                string value = nv[i];
                if (first)
                {
                    sb.AppendFormat("{0}={1}", key, value);
                }
                else
                {
                    sb.AppendFormat("&{0}={1}", key, value);
                }
                first = false;
            }
            if (sb.Length > 0)
            {
                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
