using NGConnection.Enums;
using NGConnection.Exceptions;
using NGConnection.Interfaces;
using NGConnection.Models;
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
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
        Fields = GetFields(propertyInfos);
        Values = GetValues(source, propertyInfos);
        Name = GetTableName(source);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");

        Query = ((IConnectionDataBases)connection).GetCommandInsert(this);
    }
}
