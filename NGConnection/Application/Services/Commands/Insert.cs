using NGConnection.CrossCutting;
using NGConnection.Enums;
using System.Reflection;

namespace NGConnection;

public class Insert : Command
{
    public string[] Fields { get; private set; }
    public string[] Values { get; private set; }

    public Insert(Guid identifier, string tableName, string[] fields, string[] values) 
    {
        Identifier = identifier;
        CommandType = DmlCommandType.Insert;
        Name = tableName;
        Fields = fields;
        Values = values;
        DataParameters = [];
    }
    public Insert(string tableName, string[] fields, string[] values) :
        this(Guid.NewGuid(), tableName, fields, values) { }
    public Insert(Guid identifier) :
        this(identifier, "", [], []) { }
    public Insert() :
        this(Guid.NewGuid(), "", [], []) { }

    public override void SetValues(object source)
    {
        IEnumerable<PropertyInfo> propertyInfos = Generic.GetPropertyInfo(source);
        Name = Generic.GetTableName(source);
        Fields = Generic.GetFieldsName(propertyInfos);
        Values = Generic.GetValues(source, propertyInfos);  
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");

        Query = ((IConnectionDataBases)connection).GetCommandInsert(this);
    }
}
