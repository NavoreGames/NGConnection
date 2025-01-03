using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGConnection;

public class CommandDdl : Command, ICommandDdl
{
    public DataBase dataBase { get; set; }
    public CommandDdl() { }
}
