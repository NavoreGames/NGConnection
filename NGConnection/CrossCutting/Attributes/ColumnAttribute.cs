using System;
using NGConnection.Enums;

namespace NGConnection.Attributes;

//////// ATRIBUTO PARA USAR NA CRIAÇÃO DAS CLASSES DAS TABELAS DO BANCO    ///
//////////////////////////////////////////////////////////////////////////////
//////// ATRIBUTOS DE PROPRIEDADES DA CLASSE,     ////////////////////////////
//////// PARA GUARDAR INFORMAÇÕES DAS TABELAS     ////////////////////////////
//////// COMO CHAVES, TIPO DO CAMPO, NOT NULL.    ////////////////////////////
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public sealed class ColumnPropertiesAttribute(string name, int length, bool notNull, Key key, bool autoIncrement) : Attribute
	{
    public string Name { get; set; } = name;
    public int Length { get; set; } = length;
    public bool NotNull { get; set; } = notNull;
    public Key Key { get; set; } = key;
    public bool AutoIncrement { get; set; } = autoIncrement;

    public ColumnPropertiesAttribute(Key key, bool autoIncrement) :
        this("", 0, false, key, autoIncrement)
    { }
    public ColumnPropertiesAttribute(Key key) :
        this("", 0, false, key, false)
    { }

    public ColumnPropertiesAttribute(bool notNull, Key key, bool autoIncrement) :
        this("", 0, notNull, key, autoIncrement)
    { }
    public ColumnPropertiesAttribute(bool notNull, Key key) :
        this("", 0, notNull, key, false)
    { }
    public ColumnPropertiesAttribute(bool notNull) :
        this("", 0, notNull, Key.None, false)
    { }

    public ColumnPropertiesAttribute(int length, Key key, bool autoIncrement) :
        this("", length, false, key, autoIncrement)
    { }
    public ColumnPropertiesAttribute(int length, Key key) :
        this("", length, false, key, false)
    { }
    public ColumnPropertiesAttribute(int length, bool notNull, Key key, bool autoIncrement) :
        this("", length, notNull, key, autoIncrement)
    { }
    public ColumnPropertiesAttribute(int length, bool notNull, Key key) :
        this("", length, notNull, key, false)
    { }
    public ColumnPropertiesAttribute(int length, bool notNull) :
        this("", length, notNull, Key.None, false)
    { }
    public ColumnPropertiesAttribute(int length) :
        this("", length, false, Key.None, false)
    { }

    public ColumnPropertiesAttribute(string name, Key key, bool autoIncrement) :
        this(name, 0, false, key, autoIncrement)
    { }
    public ColumnPropertiesAttribute(string name, Key key) :
        this(name, 0, false, key, false)
    { }

    public ColumnPropertiesAttribute(string name, bool notNull, Key key, bool autoIncrement) :
        this(name, 0, notNull, key, autoIncrement)
    { }
    public ColumnPropertiesAttribute(string name, bool notNull, Key key) :
        this(name, 0, notNull, key, false)
    { }
    public ColumnPropertiesAttribute(string name, bool notNull) :
        this(name, 0, notNull, Key.None, false)
    { }

    public ColumnPropertiesAttribute(string name, int length, Key key, bool autoIncrement) :
        this(name, length, false, key, autoIncrement)
    { }
    public ColumnPropertiesAttribute(string name, int length, Key key) :
        this(name, length, false, key, false)
    { }
    public ColumnPropertiesAttribute(string name, int length, bool notNull, Key key) :
        this(name, length, notNull, key, false)
    { }
    public ColumnPropertiesAttribute(string name, int length, bool notNull) :
        this(name, length, notNull, Key.None, false)
    { }
    public ColumnPropertiesAttribute(string name, int length) :
        this(name, length, false, Key.None, false)
    { }
    public ColumnPropertiesAttribute(string name) :
        this(name, 0, false, Key.None, false)
    { }
}
