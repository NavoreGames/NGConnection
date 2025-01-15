using Mysqlx.Expr;
using NGConnection.Enums;
using NGConnection.Exceptions;
using NGConnection.Interfaces;

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
    }
    public Delete(string tableName) :
        this(Guid.NewGuid(), tableName) { }
    public Delete(Guid identifier) :
        this(identifier, "") { }
    public Delete() :
        this(Guid.NewGuid(), "") { }

    public override void SetValues(object source)
    {
        Name = GetTableName(source);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");

        Query = ((IConnectionDataBases)connection).GetCommandDelete(this);
    }
}
