﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Victory.Dao
{
    public interface IPagerModelCollection
    {
        int StartIndex
        {
            get;
        }

        int EndIndex
        {
            get;
        }

        int TotalRecord
        {
            get;
        }
    }
}
