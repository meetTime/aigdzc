using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common.Proving.Api
{
    public class ApiProving
    {
        static ApiProvingImm ApiProvingImm;

        public static string DefaultProvingKey = "ProvingKey";

        static ApiProving()
        {
            ApiProvingImm = new ApiProvingImm(DefaultProvingKey);
        }

        public static void AcquireLoginState()
        {
            ApiProvingImm.AcquireLoginState();
        }

        public static Identity Identity
        {
            get
            {
                return ApiProvingImm.Identity;
            }
        }
    }


    public class ApiProvingImm : BaseProving
    {
        private Dictionary<string, Identity> IdentityList = new Dictionary<string, Identity>();

        public ApiProvingImm(string tokenKeyName):base(tokenKeyName)
        {

        }

        public ApiProvingImm(string tokenKeyName, IAuthentication authentication):base(tokenKeyName, authentication)
        {

        }

        public override string TokenValue
        {
            get
            {
                var headers = WebOperationContext.Current.IncomingRequest.Headers;
                string token = headers.Get(TokenKeyName);
                return token;
            }
        }

    }
}
