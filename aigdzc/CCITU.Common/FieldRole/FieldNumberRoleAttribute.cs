using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FieldNumberRoleAttribute : Attribute, IFieldRole
    {
        public FieldNumberRoleAttribute(double minValue,double maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public FieldNumberRoleAttribute()
        {
            this.MinValue = 0;
            this.MaxValue = int.MaxValue;
        }

        public double MinValue
        {
            get;
            set;
        }

        public double MaxValue
        {
            get;
            set;
        }

        public ActionResponse Validate(PropertyInfo property, object obj)
        {
            if (!property.PropertyType.IsValueType)
            {
                return ActionResponse.CreateFailResponse(-1, "FieldNumberRoleAttribute特性只能作用于值类型");
            }

            var value = Convert.ToDouble(property.GetValue(obj));
            if (value < this.MinValue)
            {
                return ActionResponse.CreateFailResponse(-1, "值必须等于或大于{0}", this.MinValue);
            }
            if (value > this.MaxValue)
            {
                return ActionResponse.CreateFailResponse(-1, "值必须等于或小于{0}", this.MaxValue);
            }

            return ActionResponse.CreateSuccessResponse(null);

        }
    }
}
