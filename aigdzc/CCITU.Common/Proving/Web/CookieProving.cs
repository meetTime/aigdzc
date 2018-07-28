using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CCITU.Common.Proving.Web
{
    public class CookieProving
    {
        static CookieProvingImm CookieProvingImm;

        public static string DefaultProvingKey = "ProvingKey";

        static CookieProving()
        {
            CookieProvingImm = new CookieProvingImm(DefaultProvingKey);
        }

        public static void AcquireLoginState()
        {
            CookieProvingImm.AcquireLoginState();
        }

        public static Identity Identity
        {
            get
            {
                return CookieProvingImm.Identity;
            }
        }

        public static void WriteLoginState(Identity identity)
        {
            CookieProvingImm.WriteLoginState(identity);
        }
    }


    public class CookieProvingImm : BaseProving
    {
        public CookieProvingImm(string tokenKeyName):base(tokenKeyName)
        {
            
        }

        public CookieProvingImm(string tokenKeyName, IAuthentication authentication):base(tokenKeyName, authentication)
        {

        }

        public override string TokenValue
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(TokenKeyName);
                if (cookie == null)
                {
                    return string.Empty;
                }

                return cookie.Value;
            }
        }

        public void WriteLoginState(Identity identity)
        {
            var tokenValue = this.Authentication.IdentityToTokenString(identity);
            HttpUtils.AddCookie(this.TokenKeyName, tokenValue, 60 * 24 * 30);
        }
    }
}
