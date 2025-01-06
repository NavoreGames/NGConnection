using Mysqlx.Expr;

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
}
