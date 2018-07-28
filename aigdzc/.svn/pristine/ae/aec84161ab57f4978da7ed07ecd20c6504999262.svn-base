using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    public class FieldRoleValidator
    {
        public static ActionResponse Validate(object obj)
        {
            var objType = obj.GetType();
            var properties = objType.GetProperties();

            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                {
                    return ActionResponse.CreateFailResponse(-1, "字段 {0} 验证失败，原因:不允许出现DateTime或者DateTime?类型。", property.Name);
                }


                ActionResponse result = ValidateProperty(property, obj);
                if (result.ResultCode != ActionResponse.SuccessCode)
                {
                    return result;
                }
            }

            return ActionResponse.CreateSuccessResponse(null);
        }


        public static ActionResponse ValidateProperty(PropertyInfo property,object obj)
        {
            var propertyAttributes = property.GetCustomAttributes(false);
            foreach (var att in propertyAttributes)
            {
                var attType = att.GetType();
                ActionResponse result = null;

                var role = att as IFieldRole;
                if (role != null)
                {
                    result = role.Validate(property, obj);
                }

                if (result != null && result.ResultCode != ActionResponse.SuccessCode)
                {
                    return ActionResponse.CreateFailResponse(-1, "字段 {0} 验证失败，原因:{1}", property.Name, result.Message);
                }
            }

            return ActionResponse.CreateSuccessResponse(null);
        }
        
    }
}
