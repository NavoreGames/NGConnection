using NGConnection.Enums;

namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnPropertiesAttribute : DataBasePropertiesAttribute
{
    public int Length { get; protected set; }
    public bool NotNull { get; protected set; }

    public ColumnPropertiesAttribute(string name, int length, bool notNull)
    {
        Name = name;
        Length = length;
        NotNull = notNull;
    }
    public ColumnPropertiesAttribute(string name,int length) :
        this(name, length, false)
    { }
    public ColumnPropertiesAttribute(string name, bool notNull) :
        this(name, 0, notNull)
    { }
    public ColumnPropertiesAttribute(string name) :
        this(name, false)
    { }

    public ColumnPropertiesAttribute(int length, bool notNull) :
        this(null, length, notNull)
    { }
    public ColumnPropertiesAttribute(int length) :
        this(length, false)
    { }
    public ColumnPropertiesAttribute(bool notNull) :
        this(0, notNull)
    { }
    public ColumnPropertiesAttribute()
    { }
}
