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
        DataParameters = [];
    }
    public Table(Guid identifier, Enums.CommandType commandType, DataBase dataBase, string name) :
        this(identifier, commandType, dataBase, name, "") { }
    public Table(Enums.CommandType commandType, DataBase dataBase, string name, string alias) :
        this(Guid.NewGuid(), commandType, dataBase, name, alias) { }
    public Table(Enums.CommandType commandType, DataBase dataBase, string name) :
        this(Guid.NewGuid(), commandType, dataBase, name, "") { }

    public override ICommand Clone()
    {
        return new Table(
            this.Identifier,
            this.CommandType,
            this.DataBase,
            this.Name,
            this.Alias)
        {
            Query = this.Query,
            DataParameters = this.DataParameters,
        };
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection(connection.GetType());
        if (!connection.DataBaseName.Equals(DataBase.Name))
            throw new DataBaseDivergent(this, connection);

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
