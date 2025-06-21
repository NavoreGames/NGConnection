using NGConnection.Enums;

namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnUniquekeyAttribute : ColumnPropertiesAttribute
{
    public ColumnUniquekeyAttribute(string name, int length, bool notNull) :
        base(name, length, notNull)
    { }
    public ColumnUniquekeyAttribute(string name, int length) :
        this(name, length, false)
    { }
    public ColumnUniquekeyAttribute(string name, bool notNull) :
        this(name, 0, notNull)
    { }
    public ColumnUniquekeyAttribute(string name) :
        this(name, false)
    { }

    public ColumnUniquekeyAttribute(int length, bool notNull) :
        this(null, length, notNull)
    { }
    public ColumnUniquekeyAttribute(int length) :
        this(length, false)
    { }
    public ColumnUniquekeyAttribute(bool notNull) :
        this(0, notNull)
    { }
}