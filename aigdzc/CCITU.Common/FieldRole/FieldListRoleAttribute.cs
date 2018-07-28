using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FieldListRoleAttribute : Attribute, IFieldRole
    {
        public FieldListRoleAttribute(int minLength, int maxLength)
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
            var collType = property.PropertyType.GetInterface("System.Collections.ICollection");
            if (collType == null)
            {
                return ActionResponse.CreateFailResponse(-1, "FieldListRoleAttribute特性只能作用ICollection子类");
            }

            var value = (ICollection)property.GetValue(obj);
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
                if (value.Count < this.MinLength)
                {
                    return ActionResponse.CreateFailResponse(-1, "集合项必须大于{0}", this.MinLength);
                }
                if (value.Count > this.MaxLength)
                {
                    return ActionResponse.CreateFailResponse(-1, "集合项必须小于{0}", this.MaxLength);
                }

                return ActionResponse.CreateSuccessResponse(null);
            }
        }
    }
}
