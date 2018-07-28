using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FieldStringRoleAttribute : Attribute, IFieldRole
    {
        public FieldStringRoleAttribute(int minLength, int maxLength)
        {
            this.MinLength = minLength;
            this.MaxLength = maxLength;
        }

        public int MinLength
        {
            get;
            set;
        }

        public int MaxLength
        {
            get;
            set;
        }

        public ActionResponse Validate(PropertyInfo property, object obj)
        {
            if (property.PropertyType != typeof(string))
            {
                return ActionResponse.CreateFailResponse(-1, "FieldStringRoleAttribute特性只能作用于String类型");
            }

            var value = (string)property.GetValue(obj);
            if (value == null)
            {
                if (this.MinLength == 0)
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
                if (value.Length < this.MinLength)
                {
                    return ActionResponse.CreateFailResponse(-1, "长度必须大于{0}位", this.MinLength);
                }
                if (value.Length > this.MaxLength)
                {
                    return ActionResponse.CreateFailResponse(-1, "长度必须小于{0}位", this.MaxLength);
                }

                return ActionResponse.CreateSuccessResponse(null);
            }
        }
    }
}
