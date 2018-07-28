using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    public class EnumItem
    {
        public string Name 
        {
            get;
            set;
        }

        public int Value 
        {
            get;
            set;
        }
        
        public string Description
        {
            get;
            set;
        }

        public int Rank
        {
            get;
            set;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Enum)]
    public class EnumProperty : Attribute
    {
        private string description;
        private int rank;

        public EnumProperty(string description, int rank)
        {
            this.description = description;
            this.rank = rank;
        }

        public EnumProperty(string description)
            : this(description, 0)
        {

        }

        public EnumProperty(int rank)
            : this(string.Empty, rank)
        {

        }

        
        public int Rank
        {
            get
            {
                return this.rank;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }
    }

    public enum EnumSortType
    {
        Default=1,
        Name=2,
        Rank=3,
        Description=4
    }

    public class EnumComparer : IComparer<EnumItem>
    {
        EnumSortType sortType;

        public EnumComparer(EnumSortType sortType)
        {
            this.sortType = sortType;
        }

        #region IComparer<NameValueItem> 成员

        public int Compare(EnumItem x, EnumItem y)
        {
            switch (sortType)
            {
                case EnumSortType.Description: return x.Description.CompareTo(y.Description);
                case EnumSortType.Rank: return x.Rank.CompareTo(y.Rank);
                default: return x.Name.CompareTo(y.Name);
            }
        }

        #endregion
    }
        
}
