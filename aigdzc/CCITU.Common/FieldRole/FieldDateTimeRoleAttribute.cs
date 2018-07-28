using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    /// <summary>
    /// 限制该字段为日期类型，默认的最小值为2000.1.1，最大值为2030.12.31
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FieldDateTimeRoleAttribute : Attribute, IFieldRole
    {
        public FieldDateTimeRoleAttribute(bool allowNull = true)
        {
            this.MinValue = new DateTime(2000, 1, 1);
            this.MaxValue = new DateTime(2030, 12, 31);
            this.AllowNull = allowNull;
        }

        public FieldDateTimeRoleAttribute(DateTime minValue, DateTime maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public bool AllowNull
        {
            get;
            set;
        }

        public DateTime MinValue
        {
            get;
            set;
        }

        public DateTime MaxValue
        {
            get;
            set;
        }

        public ActionResponse Validate(PropertyInfo property, object obj)
        {
            if (property.PropertyType != typeof(string))
            {
                return ActionResponse.CreateFailResponse(-1, "FieldStringRoleAttribute特性只能作用于String类型。");
            }

            string value = (string)property.GetValue(obj);

            if (string.IsNullOrEmpty(value))
            {
                if (this.AllowNull)
                {
                    return ActionResponse.CreateSuccessResponse(null);
                }
                else
                {
                    return ActionResponse.CreateFailResponse(-1, "值不能为Null");
                }
            }
            else
            {
                DateTime dtValue;
                if (!DateTime.TryParse(value, out dtValue))
                {
                    return ActionResponse.CreateFailResponse(-1, "不符合要求的DateTime格式");
                }

                if (dtValue < this.MinValue)
                {
                    return ActionResponse.CreateFailResponse(-1, "值不能大于{0}", this.MinValue);
                }
                if (dtValue > this.MaxValue)
                {
                    return ActionResponse.CreateFailResponse(-1, "值不能小于{0}", this.MaxValue);
                }

                return ActionResponse.CreateSuccessResponse(null);
            }
        }


    }
}
