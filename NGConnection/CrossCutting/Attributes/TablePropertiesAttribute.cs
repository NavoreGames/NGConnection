namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class TablePropertiesAttribute : DataBasePropertiesAttribute
{
    public TablePropertiesAttribute(string name) { Name = name; }
}

