using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult CurrentContextjs()
        {
            JavaScriptResult result = new JavaScriptResult();

            StringBuilder sb = new StringBuilder();
            sb.Append("function currentContext() {");
            sb.AppendFormat(" this.webRoot = '{0}';", CurrentContext.WebRoot);
            sb.AppendFormat(" this.apiUrl = '{0}';", CurrentContext.ApiUrl);
            sb.AppendFormat(" this.uploadUrl = '{0}';", CurrentContext.UploadUrl);
            sb.AppendFormat(" this.rootUrl = '{0}';", CurrentContext.RootPath);
            sb.AppendFormat(" this.authorizationKey = '{0}';", CurrentContext.AuthorizationKey);
            sb.AppendFormat(" this.permissionKey = '{0}';", CurrentContext.PermissionKey);
            sb.AppendFormat(" this.version = '{0}';", CurrentContext.Version);
            sb.Append("} ");
            sb.Append("var currentContext = new currentContext();");
            result.Script = sb.ToString();

            return result;
        }
    }
}