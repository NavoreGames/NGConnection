﻿using System.Linq.Expressions;
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