using NGConnection.CrossCutting;
using NGConnection.Enums;
using System.Reflection;

namespace NGConnection;

public class Update : Command
{
    public Dictionary<string, string> Fields { get; private set; }
    public Where Where { get; set; }

    public Update(Guid identifier, string tableName, Dictionary<string, string> fields)
    {
        Identifier = identifier;
        CommandType = DmlCommandType.Update;
        Name = tableName;
        Fields = fields;
        DataParameters = [];
        Where = new Where();
    }
    public Update(string tableName, Dictionary<string, string> fields) :
        this(Guid.NewGuid(), tableName, fields) { }
    public Update(Guid identifier) :
        this(identifier, "", []) { }
    public Update() :
        this(Guid.NewGuid(), "", []) { }

    public override ICommand Clone()
    {
        Update clone = (Update)base.Clone();
        clone.Fields = Fields;
        clone.Where = Where;

        return clone;
    }

    public override void SetValues(object source)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
        Name = GetTableName(source);
        Fields = GetFields(source, propertyInfos);
        Where.SetValues(source);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection(connection.GetType());

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"-- {connection.GetType().Name.ToUpper()} COMMAND");

        sb.AppendLine(((IConnectionDataBases)connection).GetCommandUpdate(this));
        sb.AppendLine(((IConnectionDataBases)connection).GetCommandWhere(Where));

        Query = sb.ToString();
    }
}
