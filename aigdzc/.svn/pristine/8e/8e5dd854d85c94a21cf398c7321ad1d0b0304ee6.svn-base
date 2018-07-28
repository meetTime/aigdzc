using CCITU.Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Api.App_Common
{
    public class ErrorResponseFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var actionResponse = new ActionResponse();
            actionResponse.ResultCode = ActionResponse.SuccessCode;
            actionResponse.Message = context.Exception.Message;
            actionResponse.Tag = context.Exception.StackTrace;
            
            context.Response = ApiHelper.CreateHttpResponseMessage(actionResponse);
        }
    }
}