using System.Reflection;
using NGConnection.Attributes;
using NGConnection.Interfaces;

namespace NGConnection;

public abstract class Command : ICommand
{
    public Guid Identifier { get; protected set; }
    public Enums.CommandType CommandType { get; protected set; }
    public string Query { get; protected set; }
    public IDbDataParameter[] DataParameter { get; protected set; }
    public string Name { get; protected set; }
    public string Alias { get; protected set; }

    public override string ToString() => Query;

    public virtual void SetValues(object source) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/SetValues");
    public virtual void SetCommand(IConnection connection) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/SetCommand");

    protected static string GetTableName(object entity)
    {
        return ((entity.GetType().GetCustomAttribute<TablePropertiesAttribute>()?.Name?.Trim() ?? "") != "") ?
                    entity.GetType().GetCustomAttribute<TablePropertiesAttribute>().Name : 
                    entity.GetType().Name;
    }
    protected static IEnumerable<PropertyInfo> GetPropertyInfo(object entity)
    {
        return entity
                .GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Where(w => IsTypeValid(w.PropertyType));
    }
    protected static string[] GetFields(IEnumerable<PropertyInfo> propertyInfos)
    {
        return
            propertyInfos
                .Select
                (
                    s => ((s.GetCustomAttribute<ColumnPropertiesAttribute>()?.Name?.Trim() ?? "") != "") ?
                            s.GetCustomAttribute<ColumnPropertiesAttribute>().Name :
                            s.Name
                )
                .ToArray();
    }
    protected static string[] GetValues(object entity, IEnumerable<PropertyInfo> propertyInfos)
    {
        return 
            propertyInfos
                .Select(s => GetValue(entity, s))
                .ToArray();
    }
    protected static string GetValue(object entity, PropertyInfo propertyInfo)
    {
        var typeCode = Type.GetTypeCode(GetNullableType(propertyInfo.PropertyType));
        object value = propertyInfo.GetValue(entity);

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
    protected static Type GetNullableType(Type typeToCheck)
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
    protected static bool IsTypeValid(Type typeToCheck)
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
