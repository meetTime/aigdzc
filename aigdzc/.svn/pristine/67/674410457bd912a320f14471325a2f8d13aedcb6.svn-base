using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    public class DateTimeUtls
    {
        public static string GetDateTimeFormat(DateTime startTime,DateTime endTime) 
        {
            TimeSpan ts = endTime - startTime;
            int totalMinutes = (int)ts.TotalMinutes;
            if (totalMinutes <= 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            int days = totalMinutes / (60 * 24);
            if (days > 0)
            {
                sb.AppendFormat("{0}天", days);
                totalMinutes -= days * (60 * 24);
            }

            int hours = totalMinutes / (60);
            if (hours > 0)
            {
                sb.AppendFormat("{0}小时", hours);
                totalMinutes -= hours * (60);
            }
            if (totalMinutes > 0)
            {
                sb.AppendFormat("{0}分", totalMinutes);
            }
            
            return sb.ToString();
        }
    }
}
