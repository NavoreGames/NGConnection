using NGConnection.Enums;

namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ColumnUniquekeyAttribute : ColumnPropertiesAttribute
{
    public ColumnUniquekeyAttribute(string name, VariableType type, int length, bool notNull) :
      base(name, type, length, notNull)
    { }
    public ColumnUniquekeyAttribute(string name, VariableType type, int length) :
       this(name, type, length, false)
    { }
    public ColumnUniquekeyAttribute(string name, VariableType type, bool notNull) :
      this(name, type, 0, notNull)
    { }
    public ColumnUniquekeyAttribute(string name, VariableType type) :
      this(name, type, false)
    { }
    public ColumnUniquekeyAttribute(string name) :
          this(name, VariableType.None)
    { }
}



