using System.Linq.Expressions;
using System.Reflection;
using Mysqlx.Expr;
using NGConnection.Models;

namespace NGConnection;

public class Where : Command
{
    public Dictionary<string, string> Fields { get; private set; }
    public ExpressionData ExpressionData { get; set; }

    public Where(Guid identifier) 
    { 
        Identifier = identifier;
        ExpressionData = new();
    }
    public Where() :
         this(Guid.NewGuid())
    { }
    public override void SetValues(object source)
    {
        if (source is Expression expression)
            ExpressionData = new(expression);
        else
        {
            IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
            Fields = GetPrimaryFields(source, propertyInfos);
            ExpressionData = new();
            ExpressionData.SetQuery(Fields);
        }
    }
    public override ICommand Clone()
    {
        return new Where()
        {
            Identifier = this.Identifier,
            CommandType = this.CommandType,
            Query = this.Query,
            DataParameters = this.DataParameters,
            Name = this.Name,
            Alias = this.Alias,
            ExpressionData = this.ExpressionData
        };
    }

    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection(connection.GetType());

        Query = ((IConnectionDataBases)connection).GetCommandWhere(this);
    }
}