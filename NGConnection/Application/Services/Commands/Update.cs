using NGConnection.Enums;
using System.Reflection;

namespace NGConnection;

public class Update : Command
{
    public Dictionary<string, string> Fields { get; private set; }
    public Where Where { get; set; }

    public Update(Guid identifier, object entity)
    {
        Identifier = identifier;
        CommandType = DmlCommandType.Update;
        Fields = [];
        DataParameters = [];
        Where = new Where();

        if (entity != null)
            SetValues(entity);
    }
    public Update(Guid identifier) :
        this(identifier, "") { }
    public Update(object entity) :
       this(Guid.NewGuid(), entity)
    { }
    public Update() :
        this(Guid.NewGuid(), "") { }

    public override ICommand Clone()
    {
        return new Update()
        {
            Identifier = this.Identifier,
            CommandType = this.CommandType,
            EntityType = this.EntityType,
            Query = this.Query,
            DataParameters = this.DataParameters,
            Name = this.Name,
            Alias = this.Alias,
            Fields = this.Fields,
            Where = this.Where
        };
    }

    public override void SetValues(object source)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
        EntityType = source.GetType();
        Name = GetTableName(source);
        Fields = GetFields(source, propertyInfos);
        Where.SetValues(source);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection(connection.GetType());

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"-- {connection.GetType().Name.ToUpper()} COMMAND");

        sb.AppendLine(((IConnectionDataBases)connection).GetCommandUpdate(this));
        sb.AppendLine(((IConnectionDataBases)connection).GetCommandWhere(Where));

        Query = sb.ToString();
    }
}
