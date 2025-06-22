using System.Linq.Expressions;
using System.Reflection;
using NGConnection.Attributes;
using NGConnection.CrossCutting;
using NGConnection.Interfaces;
using NGConnection.Models;

namespace NGConnection;

/*
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
*/

public class Command : ICommand
{
    public Guid Identifier { get; protected set; }
    public Enums.CommandType CommandType { get; protected set; }
    public string Query { get; set; }
    public List<ConnandParameter> DataParameters { get; set; }
    public string Name { get; protected set; }
    public string Alias { get; protected set; }

    private Command(Guid identifier, Enums.CommandType commandType, string query, List<ConnandParameter> dataParameters)
    {
        Identifier = identifier;
        CommandType = commandType;
        Query = query;
        DataParameters = dataParameters;
    }
    public Command(Guid identifier, string query, List<ConnandParameter> dataParameters) : this(identifier, Enums.CommandType.None, query, dataParameters) { }
    public Command(Guid identifier, string query) : this(identifier, Enums.CommandType.None, query, []) { }
    public Command(Guid identifier) : this(identifier, Enums.CommandType.None, "", []) { }
    public Command(string query, List<ConnandParameter> dataParameters) : this(Guid.NewGuid(), Enums.CommandType.None, query, dataParameters) { }
    public Command(string query) : this(Guid.NewGuid(), Enums.CommandType.None, query, []) { }
    public Command() : this(Guid.NewGuid(), Enums.CommandType.None, "", []) { }

    public override string ToString() => Query;

    public virtual void SetValues(object source) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/SetValues");
    public virtual void SetCommand(IConnection connection) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/SetCommand");
    //public virtual object ExecuteCommand(IConnection connection)
    //{
    //    if (connection is not IConnectionDataBases)
    //        throw new InvalidConnection(connection.GetType());

    //    return ((IConnectionDataBases)connection).Execute(this);
    //}

    protected static IEnumerable<PropertyInfo> GetPropertyInfo(object entity)
    {
        return entity
                .GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Where(w => Generic.IsTypeValid(w.PropertyType));
    }
    protected static string GetTableName(object entity)
    {
        return Generic.GetTableName(entity.GetType());
    }
    protected static Dictionary<string, string>  GetFields(object entity, IEnumerable<PropertyInfo> propertyInfos)
    {
        Dictionary<string, string> fields = [];
        foreach (PropertyInfo property in propertyInfos)
        {
            bool autoIncrement = property.GetCustomAttribute<ColumnPrimarykeyAttribute>()?.AutoIncrement ?? false;
            if (autoIncrement)
                continue;

            fields.Add(Generic.GetFieldName(property), Generic.GetValue(entity, property));
        }
        return fields;
    }
}
