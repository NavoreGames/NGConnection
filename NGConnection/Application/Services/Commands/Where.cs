using System.Linq.Expressions;
using NGConnection.Models;

namespace NGConnection;

public class Where : Command
{
    //public ExpressionData Expression { get; set; }
    public ExpressionData ExpressionData { get; set; }

    public Where() { ExpressionData = new(); }
    public override void SetValues(object source)
    {
        if (source is Expression expression)
            ExpressionData = new(expression);
        else
        {
            ExpressionData = new();
            //IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
            //string[] Fields = GetFields(propertyInfos);
            //string[] Values = GetValues(source, propertyInfos);
        }
    }
    public override void SetCommand(IConnection connection)
    {
        if (connection is not IConnectionDataBases)
            throw new InvalidConnection($"{connection.GetType()} is an invalid connection.");

        Query = ((IConnectionDataBases)connection).GetCommandWhere(this);
    }
}