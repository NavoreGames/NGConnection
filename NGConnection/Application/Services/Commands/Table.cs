﻿namespace NGConnection;

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
        if (!connection.DataBaseName.Equals(DataBase.Name))
            throw new DataBaseDivergent($"database name {Name} divergent from connection database name {connection.DataBaseName}.");

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"-- {connection.GetType().Name.ToUpper()} COMMAND");

        if (CommandType.Equals(Enums.DdlCommandType.Create))
            sb.AppendLine(((IConnectionDataBases)connection).GetCommandCreateTable(this));
        else if (CommandType.Equals(Enums.DdlCommandType.Alter))
            sb.AppendLine(((IConnectionDataBases)connection).GetCommandAlterTable(this));
        else if (CommandType.Equals(Enums.DdlCommandType.Drop))
            sb.AppendLine(((IConnectionDataBases)connection).GetCommandDropTable(this));

        Query = sb.ToString();
    }
}
