using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PagerQuery
    {
        public PagerQuery()
        {
            this.StartIndex = 1;
            this.EndIndex = 10;
        }

        public int StartIndex
        {
            get;
            set;
        }

        public int EndIndex
        {
            get;
            set;
        }

        private int _currentPage = 1;
        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                SetPage(_currentPage, PageSize);
            }
        }

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
                SetPage(CurrentPage, _pageSize);
            }
        }

        /// <summary>
        /// 设置页数，页数从1开始计数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public void SetPage(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }

            StartIndex = (pageIndex - 1) * pageSize + 1;
            EndIndex = pageIndex * pageSize;
        }


        public string SortField { get; set; }

        public SortOrder SortOrder { get; set; }
    }

    public enum SortOrder
    {
        Desc,
        Asc
    }
}
