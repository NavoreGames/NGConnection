using System.Reflection;
using System.Linq.Expressions;
using NGConnection.Attributes;
using NGConnection.CrossCutting;

namespace NGConnection.Models;

public class ExpressionData
{
    public Expression Expression { get; private set; }
    private string Query { get; set; }

    public ExpressionData(Expression expression){ this.Expression = expression; }
    public ExpressionData() { }

    public string GetQuery()
    {
        if (Expression != null)
            SetExpression(Expression);

        return Query;
    }

    private void SetExpression(Expression expression)
    {
        if (expression is LambdaExpression lambdaExpression)
            SetExpression(lambdaExpression);
        else if (expression is BinaryExpression binaryExpression)
            SetExpression(binaryExpression);
        else if (expression is ParameterExpression parameterExpression)
            SetExpression(parameterExpression);
        else if (expression is ConstantExpression constantExpression)
            SetExpression(constantExpression);
        else if (expression is UnaryExpression unaryExpression)
            SetExpression(unaryExpression);
        else if (expression is MethodCallExpression methodCallExpression)
            SetExpression(methodCallExpression);
        else if (expression is MemberExpression memberExpression)
            SetExpression(memberExpression);
        #region tipos de expression (que não foram criados metodos, pois não apareceu ainda)
        else
        {
            string expressionType = "Unknown";

            if (expression is NewExpression)
                expressionType = "NewExpression";
            if (expression is BlockExpression)
                expressionType = "BlockExpression";
            else if (expression is ConditionalExpression)
                expressionType = "ConditionalExpression";
            else if (expression is DebugInfoExpression)
                expressionType = "DebugInfoExpression";
            else if (expression is DefaultExpression)
                expressionType = "DefaultExpression";
            else if (expression is DynamicExpression)
                expressionType = "DynamicExpression";
            else if (expression is GotoExpression)
                expressionType = "GotoExpression";
            //else if (expression is IArgumentProvider)
            //	s = "IArgumentProvider";
            //else if (expression is IDynamicExpression)
            //	s = "IDynamicExpression";
            else if (expression is IndexExpression)
                expressionType = "IndexExpression";
            else if (expression is InvocationExpression)
                expressionType = "InvocationExpression";
            else if (expression is LabelExpression)
                expressionType = "LabelExpression";
            else if (expression is ListInitExpression)
                expressionType = "ListInitExpression";
            else if (expression is LoopExpression)
                expressionType = "LoopExpression";
            else if (expression is MemberInitExpression)
                expressionType = "MemberInitExpression";
            else if (expression is NewArrayExpression)
                expressionType = "NewArrayExpression";
            else if (expression is RuntimeVariablesExpression)
                expressionType = "RuntimeVariablesExpression";
            else if (expression is SwitchExpression)
                expressionType = "SwitchExpression";
            else if (expression is TryExpression)
                expressionType = "TryExpression";
            else if (expression is TypeBinaryExpression)
                expressionType = "TypeBinaryExpression";

            
            throw new ExpressionNotImplemented($"Expression {expressionType} not implemented.");
        }
        #endregion
    }
    private void SetExpression(LambdaExpression expression)
    {
        SetExpression(expression.Body);
    }
    private void SetExpression(UnaryExpression expression)
    {
        SetExpression(expression.Operand);
    }
    private void SetExpression(BinaryExpression expression)
    {
        SetBracket(true, expression.NodeType);
        SetExpression(expression.Left);
        Query += $" {GetOperation(expression.NodeType)} ";
        SetExpression(expression.Right);
        SetBracket(false, expression.NodeType);
    }
    private void SetExpression(ParameterExpression expression)
    {
        Query += $"{Generic.GetTableName(expression.Type)}.";
    }
    private void SetExpression(ConstantExpression expression)
    {
        Query += expression.Value is string ? $"'{expression.Value}'" : expression.Value.ToString();
    }
    private void SetExpression(MemberExpression expression)
    {
        if (expression.Member is FieldInfo fieldInfo)
        {
            Query += GetValue(fieldInfo, expression);
        }
        if (expression.Member is PropertyInfo propertyInfo)
        {
            if (expression.Expression != null)
                SetExpression(expression.Expression);

            Query += Generic.GetFieldName(propertyInfo);
        }
    }
    private void SetExpression(MethodCallExpression expression)
    {
        //if (methodCall.Method.Name == "Contains" && methodCall.Object is MemberExpression memberExp)
        //    return $"{memberExp.Member.Name} LIKE '%{((ConstantExpression)methodCall.Arguments[0]).Value}%'";

        if (expression.Object is ConstantExpression)
        {
            Query += GetValue(expression);
        }
        else if (expression.Object is MemberExpression)
        {
            //Expression += GetMethodValue(expression);
        }
    }
    /*
	
	private string GetExpression(NewExpression expression, List<MemberInfo> members)
	{
		return GetExpression(expression, members);
	}
	*/
   
    private static string GetOperation(ExpressionType value)
    {
        return value switch
        {
            ExpressionType.And or
            ExpressionType.AndAlso => "AND",
            ExpressionType.Or or
            ExpressionType.OrElse => "OR",
            ExpressionType.Equal => "=",
            ExpressionType.NotEqual => "<>",
            ExpressionType.GreaterThan => ">",
            ExpressionType.LessThan => "<",
            ExpressionType.GreaterThanOrEqual => ">=",
            ExpressionType.LessThanOrEqual => "<=",
            _ => value.ToString()
        };
    }
    private void SetBracket(bool open, ExpressionType expressionType)
    {
        if (open == true && expressionType is (ExpressionType.And or ExpressionType.AndAlso or
                                                ExpressionType.Or or ExpressionType.OrElse))
            Query += "(";
        else if (open == false && expressionType is (ExpressionType.And or ExpressionType.AndAlso or
                                                ExpressionType.Or or ExpressionType.OrElse))
            Query += ")";
    }

    private static string GetValue(MethodCallExpression expression)
    {
        object instance = Expression.Lambda(expression.Object).Compile().DynamicInvoke();

        object[] args =
            expression.Arguments
                .Select(arg => Expression.Lambda(arg).Compile().DynamicInvoke())
                .ToArray();

        object value = expression.Method.Invoke(instance, args);
        return Generic.GetValueFormated(Type.GetTypeCode(Generic.GetNullableType(value.GetType())), value);
    }
    private static string GetValue(FieldInfo fieldInfo, MemberExpression expression)
    {
        var typeCode = Type.GetTypeCode(Generic.GetNullableType(fieldInfo.FieldType));
        object value = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();
        value = fieldInfo.GetValue(value);

        return Generic.GetValueFormated(typeCode, value);
    }
}
