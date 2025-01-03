using NGConnection.Enums;

namespace NGConnection.Models;

public class Table
{
    public string DataBaseName { get; private set; }
    public string Name { get; private set; }
    public string Alias { get; private set; }

	public Table(string dataBaseName, string name, string alias)
	{
        DataBaseName = dataBaseName;
        Name = name;
		Alias = alias;

    }
    public Table(string dataBaseName, string name) :
        this(dataBaseName, name, "") { }
}
