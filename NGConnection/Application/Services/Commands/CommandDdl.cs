using NGConnection;
using NGConnection.Interfaces;
using NGConnection.Models;
using System.Reflection;

namespace NGConnection;

public class CommandDdl : Command, ICommandDdl
{
    public DataBase dataBase { get; private set; }
    public CommandDdl() { }
}
