using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace CCITU.Common.Proving.Web
{
    public class ProvingHttpModule : IHttpModule
    {
        //private string LoginUrl;
        private string CurrentUrl;

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.PostAcquireRequestState += context_PostAcquireRequestState;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            CurrentUrl = app.Request.Url.ToString().ToLower();
        }

        void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            if (app.Context.Handler is IReadOnlySessionState || app.Context.Handler is IRequiresSessionState)
            {
                CookieProving.AcquireLoginState();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
