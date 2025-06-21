using NGConnection.Enums;

namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnForeignkeyAttribute : ColumnPropertiesAttribute
{
    public Type Table { get; protected set; }
    public string Property { get; protected set; }
    public ColumnForeignkeyAttribute(string name, int length, bool notNull, Type table, string property)
    {
        Name = name;
        Length = length;
        NotNull = notNull;
        Table = table;
        Property = property;
    }
    public ColumnForeignkeyAttribute(string name, int length, Type table, string property) :
      this(name, length, false, table, property)
    { }
    public ColumnForeignkeyAttribute(string name, bool notNull, Type table, string property) :
      this(name, 0, notNull, table, property)
    { }
    public ColumnForeignkeyAttribute(string name, Type table, string property) :
      this(name, 0, table, property)
    { }

    public ColumnForeignkeyAttribute(int length, bool notNull, Type table, string property) :
     this(null, length, notNull, table, property)
    { }
    public ColumnForeignkeyAttribute(int length, Type table, string property) :
      this(length, false, table, property)
    { }
    public ColumnForeignkeyAttribute(bool notNull, Type table, string property) :
      this(0, notNull, table, property)
    { }
    public ColumnForeignkeyAttribute(Type table, string property) :
      this(0, table, property)
    { }
}
