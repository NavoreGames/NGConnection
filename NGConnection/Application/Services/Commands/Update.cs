using NGConnection.Enums;
using NGConnection.Exceptions;
using NGConnection.Interfaces;
using System.Reflection;

namespace NGConnection;

public class Update : Command
{
    public string[] Fields { get; private set; }
    public string[] Values { get; private set; }
    public Where Where { get; set; }

    public Update(Guid identifier, string tableName, string[] fields, string[] values)
    {
        Identifier = identifier;
        CommandType = DmlCommandType.Update;
        Name = tableName;
        Fields = fields;
        Values = values;
    }
    public Update(string tableName, string[] fields, string[] values) :
        this(Guid.NewGuid(), tableName, fields, values) { }
    public Update(Guid identifier) :
        this(identifier, "", [], []) { }
    public Update() :
        this(Guid.NewGuid(), "", [], []) { }

    public override void SetValues(object source)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
        Fields = GetFields(propertyInfos);
        Values = GetValues(source, propertyInfos);
        Name = GetTableName(source);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");

        Query = ((IConnectionDataBases)connection).GetCommandUpdate(this);
    }
}
