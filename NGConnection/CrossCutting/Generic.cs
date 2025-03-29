using NGConnection.Attributes;
using System.Linq.Expressions;
using System.Reflection;

namespace NGConnection.CrossCutting
{
    internal class Generic
    {
        internal static IEnumerable<PropertyInfo> GetPropertyInfo(object entity)
        {
            return entity
                    .GetType()
                    .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                    .Where(w => IsTypeValid(w.PropertyType));
        }
        internal static string GetTableName(object entity)
        {
            return GetTableName(entity.GetType());
        }
        internal static string GetTableName(Type entity)
        {
            return ((entity.GetCustomAttribute<TablePropertiesAttribute>()?.Name?.Trim() ?? "") != "") ?
                        entity.GetCustomAttribute<TablePropertiesAttribute>().Name :
                        entity.Name;
        }
        internal static string GetFieldName(PropertyInfo propertyInfo)
        {
            return ((propertyInfo.GetCustomAttribute<ColumnPropertiesAttribute>()?.Name?.Trim() ?? "") != "") ?
                    propertyInfo.GetCustomAttribute<ColumnPropertiesAttribute>().Name :
                    propertyInfo.Name;
        }
        internal static string[] GetFieldsName(IEnumerable<PropertyInfo> propertyInfos)
        {
            return
                propertyInfos
                    .Select(GetFieldName)
                    .ToArray();
        }
        internal static string[] GetValues(object entity, IEnumerable<PropertyInfo> propertyInfos)
        {
            return
                propertyInfos
                    .Select(s => GetValue(entity, s))
                    .ToArray();
        }
        internal static string GetValue(object entity, PropertyInfo propertyInfos)
        {
            var typeCode = Type.GetTypeCode(GetNullableType(propertyInfos.PropertyType));
            object value = propertyInfos.GetValue(entity);
            return GetValueFormated(typeCode, value);
        }
        internal static string GetValue(FieldInfo fieldInfo, MemberExpression expression)
        {
            var typeCode = Type.GetTypeCode(GetNullableType(fieldInfo.FieldType));
            object value = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();
            return GetValueFormated(typeCode, value);
        }
        internal static string GetValue(MethodCallExpression expression)
        {
            object instance = Expression.Lambda(expression.Object).Compile().DynamicInvoke();

            object[] args =
                expression.Arguments
                    .Select(arg => Expression.Lambda(arg).Compile().DynamicInvoke())
                    .ToArray();

            object value = expression.Method.Invoke(instance, args);
            return GetValueFormated(Type.GetTypeCode(GetNullableType(value.GetType())), value);
        }

        private static string GetValueFormated(TypeCode typeCode, object value)
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
        private static Type GetNullableType(Type typeToCheck)
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
        private static bool IsTypeValid(Type typeToCheck)
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
