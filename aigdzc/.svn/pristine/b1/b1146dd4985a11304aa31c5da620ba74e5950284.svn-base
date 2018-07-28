using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common.Proving
{
    public class CrypoAuthentication : IAuthentication
    {
        public List<string> NoAuthenticationUrls = new List<string>();

        //private string Split = "$$";

        public Identity TokenStringToIdentity(string tokenString)
        {
            try
            {
                string str = CryptoUtils.SymDecrypt(tokenString);
                var identity = JsonConvert.DeserializeObject<Identity>(str);
                return identity;

                //string[] values = str.Split(new string[] { Split }, StringSplitOptions.None);
                //Identity identity = new Identity();
                //identity.AccountId = int.Parse(values[0]);
                //identity.Name = values[1];
                //identity.Type = int.Parse(values[2]);
                //identity.Name = values[3];
                //identity.OwnerId = int.Parse(values[4]);
                //return identity;
            }
            catch
            {
                return null;
            }
        }

        public string IdentityToTokenString(Identity identity)
        {
            var json = JsonConvert.SerializeObject(identity);
            string token = CryptoUtils.SymEncrypt(json);
            return token;

            //StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("{0}{1}", identity.AccountId, Split);
            //sb.AppendFormat("{0}{1}", identity.Name, Split);
            //sb.AppendFormat("{0}{1}", identity.Type, Split);
            //sb.AppendFormat("{0}{1}", identity.OwnerId, Split);
            //sb.AppendFormat("{0}{1}", identity.Extentions, Split);
            //string token = CryptoUtils.SymEncrypt(sb.ToString());
            //return token;
        }

        public ActionResponse Verify(string requestUrl, Identity identity)
        {
            if (identity != null)
            {
                return ActionResponse.CreateSuccessResponse(requestUrl);
            }

            foreach (var item in NoAuthenticationUrls)
            {
                if (requestUrl.Contains(item))
                {
                    return ActionResponse.CreateSuccessResponse(requestUrl);
                }
            }

            return ActionResponse.CreateFailResponse((int)CrypoAuthenticationCode.VerifyFail, "Verify 失败，需要重新授权才能访问:{0}", requestUrl);
        }

    }

    public enum CrypoAuthenticationCode 
    {
        VerifyFail=10001
    }
}
