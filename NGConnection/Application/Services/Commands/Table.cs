namespace NGConnection;

public class Table : Command
{
    public DataBase DataBase { get; private set; }

	public Table(DataBase dataBase, string name, string alias)
	{
        DataBase = dataBase;
        Name = name;
		Alias = alias;
    }
    public Table(DataBase dataBase, string name) :
        this(dataBase, name, "") { }
}
