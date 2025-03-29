namespace NGConnection.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class Primarykey(string firstField, params string[] otherFields) : Attribute
{
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class Foreignkey(string firstField, params string[] otherFields) : Attribute
{
}