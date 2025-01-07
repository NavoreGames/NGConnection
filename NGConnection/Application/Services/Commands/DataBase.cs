using Mysqlx.Expr;
using NGConnection.Exceptions;
using NGConnection.Interfaces;

namespace NGConnection;

public class DataBase : Command
{
    public DataBase(Guid identifier, Enums.CommandType commandType, string name)
    {
        Identifier = identifier;
        CommandType = commandType;
        Name = name;
    }
    public DataBase(Enums.CommandType commandType, string name) :
        this(Guid.NewGuid(), commandType, name) { }

    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");

        if(CommandType.Equals(Enums.DdlCommandType.Create))
            Query = ((IConnectionDataBases)connection).GetCommandCreateDataBase(this);
        else if (CommandType.Equals(Enums.DdlCommandType.Alter))
            Query = ((IConnectionDataBases)connection).GetCommandAlterDataBase(this);
        else if (CommandType.Equals(Enums.DdlCommandType.Drop))
            Query = ((IConnectionDataBases)connection).GetCommandDropDataBase(this);
    }
}
