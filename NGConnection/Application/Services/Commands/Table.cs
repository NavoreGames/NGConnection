using Mysqlx.Expr;
using NGConnection.Exceptions;
using NGConnection.Interfaces;

namespace NGConnection;

public class Table : Command
{
    public DataBase DataBase { get; private set; }

	public Table(Guid identifier, Enums.CommandType commandType, DataBase dataBase, string name, string alias)
	{
        Identifier = identifier;
        CommandType = commandType;
        DataBase = dataBase;
        Name = name;
		Alias = alias;
    }
    public Table(Guid identifier, Enums.CommandType commandType, DataBase dataBase, string name) :
        this(identifier, commandType, dataBase, name, "") { }
    public Table(Enums.CommandType commandType, DataBase dataBase, string name, string alias) :
        this(Guid.NewGuid(), commandType, dataBase, name, alias) { }
    public Table(Enums.CommandType commandType, DataBase dataBase, string name) :
        this(Guid.NewGuid(), commandType, dataBase, name, "") { }

    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");

        if (CommandType.Equals(Enums.DdlCommandType.Create))
            Query = ((IConnectionDataBases)connection).GetCommandCreateTable(this);
        else if (CommandType.Equals(Enums.DdlCommandType.Alter))
            Query = ((IConnectionDataBases)connection).GetCommandAlterTable(this);
        else if (CommandType.Equals(Enums.DdlCommandType.Drop))
            Query = ((IConnectionDataBases)connection).GetCommandDropTable(this);
    }
}
