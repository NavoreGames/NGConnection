using NGConnection.Enums;

namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnPrimarykeyAttribute : ColumnPropertiesAttribute
{
    public bool AutoIncrement { get; protected set; }
    public ColumnPrimarykeyAttribute(string name, VariableType type, int length, bool autoIncrement)
    {
        Name = name;
        Type = type;
        Length = length;
        NotNull = true;
        AutoIncrement = autoIncrement;
    }
    public ColumnPrimarykeyAttribute(string name, VariableType type, int length) :
       this(name, type, length, false)
    { }
    public ColumnPrimarykeyAttribute(string name, VariableType type, bool autoIncrement) :
      this(name, type, 0, autoIncrement)
    { }
    public ColumnPrimarykeyAttribute(string name, VariableType type) :
      this(name, type, false)
    { }
    public ColumnPrimarykeyAttribute(string name) :
          this(name, VariableType.None)
    { }
}