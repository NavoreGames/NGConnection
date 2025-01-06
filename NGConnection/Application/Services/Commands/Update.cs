using System.Reflection;

namespace NGConnection;

public class Update : Command
{
    public string[] Fields { get; private set; }
    public string[] Values { get; private set; }
    public Where Where { get; set; }
    public Update() { }
    public Update(string tableName, string[] fields, string[] values)
    {
        Name = tableName;
        Fields = fields;
        Values = values;
    }
    public override void SetValues(object source)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
        Fields = GetFields(propertyInfos);
        Values = GetValues(source, propertyInfos);
        Name = GetTableName(source);
    }

    //public override ICommandDml SetCommand(Type connectionType)
    //{
    //           Set = GetFields(propertyInfos).Zip(Values, (fields, values) => $"{fields}={values}" ).ToArray();
    //    Command = @$"UPDATE {Table} SET {String.Join(',', Set)}";

    //    return this;
    //}
}
