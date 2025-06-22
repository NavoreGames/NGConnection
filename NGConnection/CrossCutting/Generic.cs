using NGConnection.Attributes;
using System.Linq.Expressions;
using System.Reflection;

namespace NGConnection.CrossCutting
{
    internal class Generic
    {
        internal static string GetTableName(Type entity)
        {
            return ((entity.GetCustomAttribute<TablePropertiesAttribute>()?.Name?.Trim() ?? "") != "") ?
                        entity.GetCustomAttribute<TablePropertiesAttribute>().Name :
                        entity.Name;
        }
        internal static string GetFieldName(PropertyInfo propertyInfo)
        {
            string fieldName = propertyInfo.GetCustomAttribute<ColumnPropertiesAttribute>()?.Name?.Trim() ?? "";
            if (fieldName == "")
                fieldName = propertyInfo.Name;

            return fieldName;
        }
        internal static string GetValue(object entity, PropertyInfo propertyInfo)
        {
            var typeCode = Type.GetTypeCode(GetNullableType(propertyInfo.PropertyType));
            object value = propertyInfo.GetValue(entity);
            return GetValueFormated(typeCode, value);
        }

        internal static string GetValueFormated(TypeCode typeCode, object value)
        {
            if (value == null)
                return "NULL";

            return typeCode switch
            {
                TypeCode.Boolean => ((bool)value == true) ? "1" : "0",
                TypeCode.String or
                TypeCode.Char or
                TypeCode.DateTime => $"'{value}'",
                //case TypeCode.Byte:
                //case TypeCode.Decimal:
                //case TypeCode.Double:
                //case TypeCode.Int16:
                //case TypeCode.Int32:
                //case TypeCode.Int64:
                //case TypeCode.SByte:
                //case TypeCode.Single:
                //case TypeCode.UInt16:
                //case TypeCode.UInt32:
                //case TypeCode.UInt64:
                _ => value.ToString(),
            };
        } 
        internal static Type GetNullableType(Type typeToCheck)
        {
            if (typeToCheck.IsGenericType &&
                typeToCheck.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return Nullable.GetUnderlyingType(typeToCheck);
            }
            else
            {
                return typeToCheck;
            }
        }
        internal static bool IsTypeValid(Type typeToCheck)
        {
            var typeCode = Type.GetTypeCode(GetNullableType(typeToCheck));

            return typeCode switch
            {
                TypeCode.Boolean or
                TypeCode.Byte or
                TypeCode.Char or
                TypeCode.DateTime or
                TypeCode.Decimal or
                TypeCode.Double or
                TypeCode.Int16 or
                TypeCode.Int32 or
                TypeCode.Int64 or
                TypeCode.SByte or
                TypeCode.Single or
                TypeCode.String or
                TypeCode.UInt16 or
                TypeCode.UInt32 or
                TypeCode.UInt64 => true,
                _ => false,
            };
        }
    }
}
