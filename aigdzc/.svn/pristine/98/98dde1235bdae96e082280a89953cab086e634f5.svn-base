using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    /// <summary>
    /// 表示一个操作结果
    /// </summary>
    public class ActionResponse
    {
        public static int SuccessCode = 0;        

        /// <summary>
        /// 1=失败
        /// 0=成功
        /// 其它自定义
        /// </summary>
        public int ResultCode
        {
            get;
            set;
        }

        /// <summary>
        /// 该操作结果所返回的信息，一般在操作失败的情况下返回失败的原因
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// 该操作结果所返回对象，一般在操作成功的情况下需要的数据
        /// </summary>
        public object Tag
        {
            get;
            set;
        }

        /// <summary>
        /// 在分页的时候返回总记录数
        /// </summary>
        public int TotalRecord
        {
            get;
            set;
        }

        public bool Success
        {
            get
            {
                return this.ResultCode == ActionResponse.SuccessCode;
            }
        }

        /// <summary>
        /// 返回该操作的执行结果
        /// </summary>
        //public bool Success
        //{
        //    get
        //    {
        //        return this.ResultCode == ActionResponse.SuccessCode;
        //    }
        //}


        public static ActionResponse CreateSuccessResponse(object tag)
        {
            return CreateActionResponse(ActionResponse.SuccessCode, tag, "Success");
        }

        public static ActionResponse CreateSuccessResponse(object tag,string message)
        {
            return CreateActionResponse(ActionResponse.SuccessCode, tag,message);
        }

        public static ActionResponse CreateSuccessResponse(object tag, int totalRecord)
        {
            return CreateActionResponse(ActionResponse.SuccessCode, tag, null, totalRecord);
        }


        public static ActionResponse CreateFailResponse(int resultCode, string message,params object[] args)
        {
            var s=string.Format(message, args);
            return CreateActionResponse(resultCode, null, s);
        }

        public static ActionResponse CreateActionResponse(int resultCode, object tag, string message, int totalRecord=0)
        {
            ActionResponse ar = new ActionResponse() { ResultCode = resultCode, Tag = tag, Message = message, TotalRecord = totalRecord };
            return ar;
        }

       
    }
}
