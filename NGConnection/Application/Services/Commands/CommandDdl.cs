using NGConnection.Interfaces;

namespace NGConnection;

public class CommandDdl : Command, ICommandDdl
{
    private CommandDdl() { }
    public CommandDdl(string dataBaseName) { DataBaseName = dataBaseName; }
    public CommandDdl(string dataBaseName, string tableName) { DataBaseName = dataBaseName; TableName = tableName; }
}
