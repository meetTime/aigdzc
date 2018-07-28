using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Api.App_Start
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
        {
            this.ApiContext = new ApiContext();
        }

        public ApiContext ApiContext
        {
            get;
            set;
        }

        public int ApiLogId
        {
            get
            {
                return this.ApiContext.ApiLogId;
            }
            set
            {
                this.ApiContext.ApiLogId = value;
            }
        }
       
        public int ErrorLogId
        {
            get
            {
                return this.ApiContext.ErrorLogId;
            }
            set
            {
                this.ApiContext.ErrorLogId = value;
            }
        }

    }
}