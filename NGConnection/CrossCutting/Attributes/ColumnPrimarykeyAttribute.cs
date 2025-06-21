using NGConnection.Enums;

namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnPrimarykeyAttribute : ColumnPropertiesAttribute
{
    public bool AutoIncrement { get; protected set; }
    public ColumnPrimarykeyAttribute(string name, int length, bool autoIncrement)
    {
        Name = name;
        Length = length;
        NotNull = true;
        AutoIncrement = autoIncrement;
    }
    public ColumnPrimarykeyAttribute(string name, int length) :
       this(name, length, false)
    { }
    public ColumnPrimarykeyAttribute(string name, bool autoIncrement) :
      this(name, 0, autoIncrement)
    { }
    public ColumnPrimarykeyAttribute(string name) :
      this(name, false)
    { }

    public ColumnPrimarykeyAttribute(int length, bool autoIncrement) :
      this(null, length, autoIncrement)
    { }
    public ColumnPrimarykeyAttribute(int length) :
       this(length, false)
    { }
    public ColumnPrimarykeyAttribute(bool autoIncrement) :
      this(0, autoIncrement)
    { }
    public ColumnPrimarykeyAttribute()
    { }
}