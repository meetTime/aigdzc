using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AdminWeb
{
    public class CurrentContext
    {
        #region 配置数据

        public static string WebRoot
        {
            get
            {
                return ConfigurationManager.AppSettings["WebRoot"];
            }
        }

        public static string ApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiUrl"];
            }
        }

        public static string UploadUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadUrl"];
            }
        }

        public static string AuthorizationKey
        {
            get
            {
                return ConfigurationManager.AppSettings["AuthorizationKey"];
            }
        }

        public static string UnAuthorizationPath
        {
            get
            {
                return ConfigurationManager.AppSettings["UnAuthorizationPath"];
            }
        }

        public static string PermissionKey
        {
            get
            {
                return ConfigurationManager.AppSettings["PermissionKey"];
            }
        }

        public static string Version
        {
            get
            {
                return ConfigurationManager.AppSettings["Version"];
            }
        }

        #endregion

        #region 运行时数据   

        public static string RootPath
        {
            get
            {
                return GetRootPath(HttpContext.Current.ApplicationInstance);
            }
        }

        private static string GetRootPath(HttpApplication app)
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

        #endregion
    }
}