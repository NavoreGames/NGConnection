using NGConnection.Enums;

namespace NGConnection.Attributes;
public abstract class DataBasePropertiesAttribute() : Attribute
{
    public string Name { get; protected set; }
}



