using Mysqlx.Expr;
using NGConnection.Enums;
using System.Reflection;

namespace NGConnection;

public class Insert : Command
{
    public Dictionary<string, string> Fields { get; private set; }

    public Insert(Guid identifier, object entity)
    {
        Identifier = identifier;
        CommandType = DmlCommandType.Insert;
        EntityType = entity.GetType();
        Name = "";
        Fields = [];
        DataParameters = [];

        if (entity != null)
            SetValues(entity);
    }
   
    public Insert(Guid identifier) :
         this(identifier, null)
    { }
    public Insert(object entity) :
       this(Guid.NewGuid(), entity)
    { }
    public Insert() :
        this(Guid.NewGuid(), null)
    { }

    public override ICommand Clone()
    {
        return new Insert()
        {
            Identifier = this.Identifier,
            CommandType = this.CommandType,
            Query = this.Query,
            DataParameters = this.DataParameters,
            Name = this.Name,
            Alias = this.Alias,
            Fields = this.Fields
        };
    }

    public override void SetValues(object source)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
        EntityType = source.GetType();
        Name = GetTableName(source);
        Fields = GetFields(source, propertyInfos);
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection(connection.GetType());

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"-- {connection.GetType().Name.ToUpper()} COMMAND");

        sb.AppendLine(((IConnectionDataBases)connection).GetCommandInsert(this));

        Query = sb.ToString();
    }
}
