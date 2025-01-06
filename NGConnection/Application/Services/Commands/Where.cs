using System.Linq.Expressions;
using System.Reflection;
using NGConnection.Models;

namespace NGConnection;

public class Where : Command
{
    public ExpressionData Expression { get; set; }

}
