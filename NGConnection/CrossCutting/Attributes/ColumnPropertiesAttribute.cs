using NGConnection.Enums;

namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnPropertiesAttribute : DataBasePropertiesAttribute
{
    public VariableType Type { get; protected set; }
    public int Length { get; protected set; }
    public bool NotNull { get; protected set; }

    public ColumnPropertiesAttribute(string name, VariableType type, int length, bool notNull)
    {
        Name = name;
        Type = type;
        Length = length;
        NotNull = notNull;
    }
    public ColumnPropertiesAttribute(string name, VariableType type, int length) :
        this(name, type, length, false)
    { }
    public ColumnPropertiesAttribute(string name, VariableType type, bool notNull) :
        this(name, type, 0, notNull)
    { }
    public ColumnPropertiesAttribute(string name, VariableType type) :
        this(name, type, false)
    { }
    public ColumnPropertiesAttribute(string name) :
        this(name, VariableType.None)
    { }
    public ColumnPropertiesAttribute()
    { }
}
