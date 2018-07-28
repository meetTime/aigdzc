using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common.Proving
{
    public abstract class BaseProving
    {
        public string TokenKeyName
        {
            get;
            set;
        }

        public abstract string TokenValue
        {
            get;
        }

        public IAuthentication Authentication
        {
            get;
            set;
        }


        public BaseProving(string tokenKeyName)
        {
            this.TokenKeyName = tokenKeyName;
            this.Authentication = CreateAuthentication();
        }

        public BaseProving(string tokenKeyName, IAuthentication authentication)
        {
            this.TokenKeyName = tokenKeyName;
            this.Authentication = authentication;
        }

       

        public void AcquireLoginState()
        {
            string tokenString = TokenValue;
            Identity identity = Authentication.TokenStringToIdentity(tokenString);
        }

        public Identity Identity
        {
            get
            {
                string token = TokenValue;
                var identity = Authentication.TokenStringToIdentity(token);
                return identity;
            }
        }

        private static IAuthentication CreateAuthentication()
        {
            var s = ConfigurationManager.AppSettings["CCITU.Common.Proving:AuthenticationModule"];
            if (string.IsNullOrEmpty(s))
            {
                return new CrypoAuthentication();
            }

            string[] arr = s.Split(',');
            ObjectHandle obj = Activator.CreateInstance(arr[1], arr[0]);
            IAuthentication authentication = (IAuthentication)obj.Unwrap();
            return authentication;
        }
    }
}
