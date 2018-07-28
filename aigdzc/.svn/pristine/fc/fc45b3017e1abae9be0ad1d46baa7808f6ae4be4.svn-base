using Api.App_Start;
using CCITU.Common;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace Api
{
    public class ApiAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ApiContext context = new ApiContext();
            context.ClientIpAddress = ApiHelper.GetClientIpAddress(actionContext.Request);
            context.UserAgent = actionContext.Request.Headers.UserAgent.ToString();
            context.Session = ApiHelper.GetRequestHeaderValue(actionContext.Request, "Authorization");
            context.RequestUri = actionContext.Request.RequestUri;
            var baseApiController= actionContext.ControllerContext.Controller as BaseApiController;
            if (baseApiController != null)
            {
                baseApiController.ApiContext = context;
            }

            var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = actionContext.ActionDescriptor.ActionName;
            if (controllerName == "Account" && actionName == "GetToken")
            {
                return;
            }

            if (controllerName == "News")
            {
                return;
            }

            //var result = AccountLogic.ValidToken(context);
            //if (result.ResultCode != ActionResponse.SuccessCode)
            //{
            //    actionContext.Response = ApiHelper.CreateHttpResponseMessage(result);
            //}
        }
     
    }

    //public class ApiAuthorizeAttribute : AuthorizeAttribute
    //{


    //    public override void OnAuthorization(HttpActionContext actionContext)
    //    {
    //        var uri = actionContext.Request.RequestUri.AbsoluteUri;

    //        IEnumerable<string> auths;
    //        if (!actionContext.Request.Headers.TryGetValues("Authorization", out auths))
    //        {
    //            throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
    //        }



    //        //var auths=.ToList();
    //        //if (auths.Count == 0 || string.IsNullOrEmpty(auths[0]))
    //        //{
    //        //    throw new HttpResponseException( System.Net.HttpStatusCode.Unauthorized);
    //        //}
    //    }
    //}
}