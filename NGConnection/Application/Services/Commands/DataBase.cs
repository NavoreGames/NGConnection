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
        if (!connection.DataBaseName.Equals(Name))
            throw new DataBaseDivergent($"database name {Name} divergent from connection database name {connection.DataBaseName}.");

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"-- {connection.GetType().Name.ToUpper()} COMMAND");
        if (CommandType.Equals(Enums.DdlCommandType.Create))
            sb.AppendLine(((IConnectionDataBases)connection).GetCommandCreateDataBase(this));
        else if (CommandType.Equals(Enums.DdlCommandType.Alter))
            sb.AppendLine(((IConnectionDataBases)connection).GetCommandAlterDataBase(this));
        else if (CommandType.Equals(Enums.DdlCommandType.Drop))
            sb.AppendLine(((IConnectionDataBases)connection).GetCommandDropDataBase(this));

        Query = sb.ToString();
    }
}
