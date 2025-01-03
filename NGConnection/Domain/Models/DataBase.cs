using NGConnection.Enums;

namespace NGConnection.Models;

public class DataBase
{
    public string Name { get; private set; }

    public DataBase(string name)
    {
        Name = name;
    }
}
