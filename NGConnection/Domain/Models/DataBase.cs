using NGConnection.Enums;

namespace NGConnection.Models;

public class DataBase
{
    public string Name { get; private set; }
    public DdlCommandType DdlCommandType { get; private set; }
    public List<Table> Tables { get; set; }

    public DataBase() { }
    public DataBase(string name, List<Table> tables)
    {
        Name = name;
        Tables = tables;
    }
}
