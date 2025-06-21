using NGConnection.Enums;

namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnForeignkeyAttribute : ColumnPropertiesAttribute
{
    public Type Table { get; protected set; }
    public ColumnForeignkeyAttribute(string name, int length, Type table)
    {
        Name = name;
        Length = length;
        NotNull = true;
        Table = table;
    }
    public ColumnForeignkeyAttribute(string name, Type table) :
      this(name, 0, table)
    { }

    public ColumnForeignkeyAttribute(int length, Type table) :
      this(null, 0, table)
    { }
    public ColumnForeignkeyAttribute(Type table) :
      this(0, table)
    { }
}
