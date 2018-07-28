using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    [Flags]
    public enum CharsetType
    {
        /// <summary>
        /// 数字
        /// </summary>
        Digit = 1,

        /// <summary>
        /// 字母（即英文A-Z）
        /// </summary>
        Letter = 2,

        /// <summary>
        /// 中文
        /// </summary>
        Chinese = 4,

        /// <summary>
        /// 键盘可输入的字符
        /// </summary>
        KeyboardSupport = 8,

        /// <summary>
        /// 无限制
        /// </summary>
        All = 16
    }
}
