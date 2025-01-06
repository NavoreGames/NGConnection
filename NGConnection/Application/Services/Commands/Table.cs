using Mysqlx.Expr;

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
}
