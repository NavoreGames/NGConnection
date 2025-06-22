using NGConnection.Attributes;
using NGConnection.CrossCutting;
using NGConnection.Enums;
using System.Reflection;

namespace NGConnection;

public class Insert : Command
{
    public Dictionary<string, string> Fields { get; private set; }

    public Insert(Guid identifier, string tableName, Dictionary<string, string> fields) 
    {
        Identifier = identifier;
        CommandType = DmlCommandType.Insert;
        Name = tableName;
        Fields = fields;
        DataParameters = [];
    }
    public Insert(string tableName, Dictionary<string, string> fields) :
        this(Guid.NewGuid(), tableName, fields) { }
    public Insert(Guid identifier) :
        this(identifier, "", []) { }
    public Insert() :
        this(Guid.NewGuid(), "", []) { }

    public override void SetValues(object source)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
        Name = GetTableName(source);
        Fields = GetFields(source, propertyInfos);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection(connection.GetType());

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"-- {connection.GetType().Name.ToUpper()} COMMAND");

        sb.AppendLine(((IConnectionDataBases)connection).GetCommandInsert(this));

        Query = sb.ToString();
    }
}
