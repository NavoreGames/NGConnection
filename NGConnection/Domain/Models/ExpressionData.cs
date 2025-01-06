using System.Linq.Expressions;

namespace NGConnection.Models;

public class ExpressionData
{
    public ExpressionData ExpressionLeft { get; set; }
    public ExpressionType ExpressionType { get; set; }
    public ExpressionData ExpressionRight { get; set; }
    public Type Type { get; set; }
    public object Value { get; set; }
}
