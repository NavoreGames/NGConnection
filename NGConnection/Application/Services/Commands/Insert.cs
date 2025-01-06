using System.Reflection;

namespace NGConnection;

public class Insert : Command
{
    public string[] Fields { get; private set; }
    public string[] Values { get; private set; }

    public Insert() { }
    public Insert(string tableName, string[] fields, string[] values) 
    {
        Name = tableName;
        Fields = fields;
        Values = values;
    }

    public override void SetValues(object entity)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(entity);
        Fields = GetFields(propertyInfos);
        Values = GetValues(entity, propertyInfos);
        Name = GetTableName(entity);
    }
}
