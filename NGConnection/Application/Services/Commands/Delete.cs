using Google.Protobuf.WellKnownTypes;
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

    public override ICommand Clone()
    {
        return new Delete()
        {
            Identifier = this.Identifier,
            CommandType = this.CommandType,
            Query = this.Query,
            DataParameters = this.DataParameters,
            Name = this.Name,
            Alias = this.Alias,
            Where = this.Where
        };
    }

    public override void SetValues(object source)
    {
        Name = GetTableName(source);
        Where.SetValues(source);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection(connection.GetType());

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"-- {connection.GetType().Name.ToUpper()} COMMAND");

        sb.AppendLine(((IConnectionDataBases)connection).GetCommandDelete(this));
        sb.AppendLine(((IConnectionDataBases)connection).GetCommandWhere(Where));

        Query = sb.ToString();
    }
}
