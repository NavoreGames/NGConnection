using NGConnection.CrossCutting;
using NGConnection.Enums;
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
        DataParameters = [];
        Where = new Where();
    }
    public Update(string tableName, string[] fields, string[] values) :
        this(Guid.NewGuid(), tableName, fields, values) { }
    public Update(Guid identifier) :
        this(identifier, "", [], []) { }
    public Update() :
        this(Guid.NewGuid(), "", [], []) { }

    public override void SetValues(object source)
    {
        IEnumerable<PropertyInfo> propertyInfos = Generic.GetPropertyInfo(source);
        Name = Generic.GetTableName(source);
        Fields = Generic.GetFieldsName(propertyInfos);
        Values = Generic.GetValues(source, propertyInfos);
        Where.SetValues(source);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");

        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine(((IConnectionDataBases)connection).GetCommandUpdate(this));
        stringBuilder.AppendLine(((IConnectionDataBases)connection).GetCommandWhere(Where));

        Query = stringBuilder.ToString();
    }
}
