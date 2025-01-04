using NGConnection.Enums;

namespace NGConnection.Models;

public class Column
{
    #region PROPERTY
    public string TableName { get; private set; }
    public string Name { get; private set; }
    public string Alias { get; private set; }
    public Key Key { get; private set; }
    public VariableType Type { get; private set; }
	public int Length { get; private set; }
	public bool NotNull { get; private set; }
	public bool Autoincrement { get; private set; }
    #endregion

    public Column(string tableName, string name, string alias, Key key, VariableType type, int length, bool notNull, bool autoincrement)
	{
        TableName = tableName;
        Name = name;
        Alias = alias;
		Type = type;
		Length = length;
		NotNull = notNull;
		Autoincrement = autoincrement;
		Key = key;
	}

    public Column(string tableName, string name, string alias, Key key, VariableType type, bool autoincrement) :
        this(tableName, name, alias, key, type, 0, true, autoincrement, "") { }
    public Column(string tableName, string name, string alias, Key key, VariableType type, int length, bool notNul) :
        this(tableName, name, alias, key, type, length, notNul, false, "") { }
    public Column(string tableName, string name, string alias, Key key, VariableType type, int length) :
        this(tableName, name, alias, key, type, length, true, false, "") { }
    public Column(string tableName, string name, string alias, Key key, VariableType type) :
        this(tableName, name, alias, key, type, 0, true, false, "") { }

    public Column(string tableName, string name, string alias, VariableType type, bool autoincrement) :
        this(tableName, name, alias, Key.None, type, 0, true, autoincrement, "") { }
    public Column(string tableName, string name, string alias, VariableType type, int length, bool notNul) :
        this(tableName, name, alias, Key.None, type, length, notNul, false, "") { }
    public Column(string tableName, string name, string alias, VariableType type, int length) :
        this(tableName, name, alias, Key.None, type, length, true, false, "") { }
    public Column(string tableName, string name, string alias, VariableType type) :
        this(tableName, name, alias, Key.None, type, 0, true, false, "") { }

    public Column(string tableName, string name, Key key, VariableType type, bool autoincrement) :
        this(tableName, name, "", key, type, 0, true, autoincrement, "") { }
    public Column(string tableName, string name, Key key, VariableType type, int length, bool notNul) :
        this(tableName, name, "", key, type, length, notNul, false, "") { }
    public Column(string tableName, string name, Key key, VariableType type, int length) :
        this(tableName, name, "",key, type, length, true, false, "") { }
    public Column(string tableName, string name, Key key, VariableType type) :
        this(tableName, name, "", key, type, 0, true, false, "") { }

    public Column(string tableName, string name, VariableType type, bool autoincrement) :
        this(tableName, name, "", Key.None, type, 0, true, autoincrement, "") { }
    public Column(string tableName, string name, VariableType type, int length, bool notNul) :
        this(tableName, name, "", Key.None, type, length, notNul, false, "") { }
    public Column(string tableName, string name, VariableType type, int length) :
        this(tableName, name, "", Key.None, type, length, true, false, "") { }
    public Column(string tableName, string name, VariableType type) :
        this(tableName, name, "", Key.None, type, 0, true, false, "") { }
}
