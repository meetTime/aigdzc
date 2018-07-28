using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FieldEnumRoleAttribute : Attribute, IFieldRole
    {

        public ActionResponse Validate(PropertyInfo property, object obj)
        {
            if (!property.PropertyType.IsEnum)
            {
                return ActionResponse.CreateFailResponse(-1, "FieldEnumRoleAttribute特性只能作用于Enum类型。");
            }

            int value = (int)property.GetValue(obj);
            var isDefined=property.PropertyType.IsEnumDefined(value);
            if (!isDefined)
            {
                return ActionResponse.CreateFailResponse(-1, "无效的枚举项");
            }

            return ActionResponse.CreateSuccessResponse(null);
           
        }
    }
}
