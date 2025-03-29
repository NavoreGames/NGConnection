using System.Reflection;
using NGConnection.Attributes;
using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGConnection;

public abstract class Command : ICommand
{
    public Guid Identifier { get; protected set; }
    public Enums.CommandType CommandType { get; protected set; }
    public string Query { get; protected set; }
    public List<ConnectionParameter> DataParameters { get; protected set; }
    public string Name { get; protected set; }
    public string Alias { get; protected set; }

    public override string ToString() => Query;

    public virtual void SetValues(object source) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/SetValues");
    public virtual void SetCommand(IConnection connection) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/SetCommand");
}
