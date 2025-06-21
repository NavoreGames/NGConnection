using NGConnection.Enums;

namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnForeignkeyAttribute : ColumnPropertiesAttribute
{
    public Type Table { get; protected set; }
    public ColumnForeignkeyAttribute(string name, VariableType type, int length, Type table)
    {
        Name = name;
        Type = type;
        Length = length;
        NotNull = true;
        Table = table;
    }
    public ColumnForeignkeyAttribute(string name, VariableType type, Type table) :
      this(name, type, 0, table)
    { }
    public ColumnForeignkeyAttribute(string name, Type table) :
          this(name, VariableType.None, table)
    { }
}
