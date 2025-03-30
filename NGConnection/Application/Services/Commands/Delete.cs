using NGConnection.CrossCutting;
using NGConnection.Enums;

namespace NGConnection;

public class Delete : Command
{
    public Where Where { get; set; }

    public Delete(Guid identifier, string tableName)
    {
        Identifier = identifier;
        CommandType = DmlCommandType.Delete;
        Name = tableName;
        DataParameters = [];
        Where = new Where();
    }
    public Delete(string tableName) :
        this(Guid.NewGuid(), tableName) { }
    public Delete(Guid identifier) :
        this(identifier, "") { }
    public Delete() :
        this(Guid.NewGuid(), "") { }

    public override void SetValues(object source)
    {
        Name = Generic.GetTableName(source);
        Where.SetValues(source);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");

        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine(((IConnectionDataBases)connection).GetCommandDelete(this));
        stringBuilder.AppendLine(((IConnectionDataBases)connection).GetCommandWhere(Where));
        
        Query = stringBuilder.ToString();
    }
}
