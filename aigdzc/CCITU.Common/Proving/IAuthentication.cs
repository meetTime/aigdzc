using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common.Proving
{
    public interface IAuthentication
    {
        Identity TokenStringToIdentity(string value);

        string IdentityToTokenString(Identity identity);

        ActionResponse Verify(string requestUrl, Identity identity);
    }
}
