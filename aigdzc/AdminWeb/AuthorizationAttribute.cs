using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UrlHelper url = new UrlHelper(filterContext.RequestContext);
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.ActionDescriptor.ActionName;

            string[] paths = CurrentContext.UnAuthorizationPath.Split(';');

            if (paths.Length == 0)
            {
                throw new Exception("请配置登陆页");
            }

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            foreach (var item in paths)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                var v = item.Split('.');
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(v[0], v[1]);
                list.Add(kvp);
            }

            foreach (var item in list)
            {
                var m1 = IsMatchPath(item.Key, controllerName);
                var m2 = IsMatchPath(item.Value, actionName);

                if (m1 & m2)
                {
                    return;
                }
            }

            var cs = filterContext.RequestContext.HttpContext.Request.Cookies[CurrentContext.AuthorizationKey];
            if (cs == null)
            {
                filterContext.Result = new RedirectResult(string.Format("{0}/{1}/{2}", CurrentContext.RootPath, list[0].Key, list[0].Value));
            }
        }

        private bool IsMatchPath(string path1, string path2)
        {
            path1 = path1.ToLower();
            path2 = path2.ToLower();

            if (path1 == "*" || path2 == "*")
            {
                return true;
            }

            if (path1 == path2)
            {
                return true;
            }

            return false;
        }
    }
}