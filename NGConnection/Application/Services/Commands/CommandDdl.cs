using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGConnection;

public class CommandDdl : Command, ICommandDdl
{
    internal CommandDdl() { }
    public CommandDdl(string dataBaseName) { DataBaseName = dataBaseName; }
    public CommandDdl(string dataBaseName, string tableName) { DataBaseName = dataBaseName; TableName = tableName; }
}
