using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common.Proving
{
    public class Identity
    {
        public Identity()
        {
            this.Extentions = new Dictionary<string, object>();
        }

        public int AccountId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }

        public int OwnerId
        {
            get;
            set;
        }

        public DateTime LoginTime
        {
            get;
            set;
        }

        public Dictionary<string, object> Extentions
        {
            get;
            set;
        }
    }
}
