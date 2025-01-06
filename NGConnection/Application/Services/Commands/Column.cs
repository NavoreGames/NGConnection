using NGConnection.Enums;

namespace NGConnection;

public class Column : Command
{
    #region PROPERTY
    public Table Table { get; private set; }
    public Key Key { get; private set; }
    public VariableType Type { get; private set; }
	public int Length { get; private set; }
	public bool NotNull { get; private set; }
	public bool Autoincrement { get; private set; }
    #endregion

    public Column(Table table , string name, string alias, Key key, VariableType type, int length, bool notNull, bool autoincrement)
	{
        Table = table;
        Name = name;
        Alias = alias;
		Type = type;
		Length = length;
		NotNull = notNull;
		Autoincrement = autoincrement;
		Key = key;
	}

    public Column(Table table , string name, string alias, Key key, VariableType type, bool autoincrement) :
        this(table, name, alias, key, type, 0, true, autoincrement) { }
    public Column(Table table , string name, string alias, Key key, VariableType type, int length, bool notNul) :
        this(table, name, alias, key, type, length, notNul, false) { }
    public Column(Table table , string name, string alias, Key key, VariableType type, int length) :
        this(table, name, alias, key, type, length, true, false) { }
    public Column(Table table , string name, string alias, Key key, VariableType type) :
        this(table, name, alias, key, type, 0, true, false) { }

    public Column(Table table , string name, string alias, VariableType type, bool autoincrement) :
        this(table, name, alias, Key.None, type, 0, true, autoincrement) { }
    public Column(Table table , string name, string alias, VariableType type, int length, bool notNul) :
        this(table, name, alias, Key.None, type, length, notNul, false) { }
    public Column(Table table , string name, string alias, VariableType type, int length) :
        this(table, name, alias, Key.None, type, length, true, false) { }
    public Column(Table table , string name, string alias, VariableType type) :
        this(table, name, alias, Key.None, type, 0, true, false) { }

    public Column(Table table , string name, Key key, VariableType type, bool autoincrement) :
        this(table, name, "", key, type, 0, true, autoincrement) { }
    public Column(Table table , string name, Key key, VariableType type, int length, bool notNul) :
        this(table, name, "", key, type, length, notNul, false) { }
    public Column(Table table , string name, Key key, VariableType type, int length) :
        this(table, name, "",key, type, length, true, false) { }
    public Column(Table table , string name, Key key, VariableType type) :
        this(table, name, "", key, type, 0, true, false) { }

    public Column(Table table , string name, VariableType type, bool autoincrement) :
        this(table, name, "", Key.None, type, 0, true, autoincrement) { }
    public Column(Table table , string name, VariableType type, int length, bool notNul) :
        this(table, name, "", Key.None, type, length, notNul, false) { }
    public Column(Table table , string name, VariableType type, int length) :
        this(table, name, "", Key.None, type, length, true, false) { }
    public Column(Table table , string name, VariableType type) :
        this(table, name, "", Key.None, type, 0, true, false) { }
}
