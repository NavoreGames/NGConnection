using System;

namespace NGConnection.Attributes;

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class TablePropertiesAttribute(string name) : Attribute
	{
    public string Name { get; set; } = name;
}

