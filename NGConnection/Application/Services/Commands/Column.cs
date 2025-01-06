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

    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, string alias, Key key, VariableType type, int length, bool notNull, bool autoincrement)
	{
        Identifier = identifier;
        CommandType = commandType;
        Table = table;
        Name = name;
        Alias = alias;
		Type = type;
		Length = length;
		NotNull = notNull;
		Autoincrement = autoincrement;
		Key = key;
	}

    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, string alias, Key key, VariableType type, bool autoincrement) :
        this(identifier, commandType, table, name, alias, key, type, 0, true, autoincrement) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, string alias, Key key, VariableType type, int length, bool notNul) :
        this(identifier, commandType, table, name, alias, key, type, length, notNul, false) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, string alias, Key key, VariableType type, int length) :
        this(identifier, commandType, table, name, alias, key, type, length, true, false) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, string alias, Key key, VariableType type) :
        this(identifier, commandType, table, name, alias, key, type, 0, true, false) { }

    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, string alias, VariableType type, bool autoincrement) :
        this(identifier, commandType, table, name, alias, Key.None, type, 0, true, autoincrement) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, string alias, VariableType type, int length, bool notNul) :
        this(identifier, commandType, table, name, alias, Key.None, type, length, notNul, false) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, string alias, VariableType type, int length) :
        this(identifier, commandType, table, name, alias, Key.None, type, length, true, false) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, string alias, VariableType type) :
        this(identifier, commandType, table, name, alias, Key.None, type, 0, true, false) { }

    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, Key key, VariableType type, bool autoincrement) :
        this(identifier, commandType, table, name, "", key, type, 0, true, autoincrement) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, Key key, VariableType type, int length, bool notNul) :
        this(identifier, commandType, table, name, "", key, type, length, notNul, false) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, Key key, VariableType type, int length) :
        this(identifier, commandType, table, name, "", key, type, length, true, false) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, Key key, VariableType type) :
        this(identifier, commandType, table, name, "", key, type, 0, true, false) { }

    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, VariableType type, bool autoincrement) :
        this(identifier, commandType, table, name, "", Key.None, type, 0, true, autoincrement) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, VariableType type, int length, bool notNul) :
        this(identifier, commandType, table, name, "", Key.None, type, length, notNul, false) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, VariableType type, int length) :
        this(identifier, commandType, table, name, "", Key.None, type, length, true, false) { }
    public Column(Guid identifier, Enums.CommandType commandType, Table table , string name, VariableType type) :
        this(identifier, commandType, table, name, "", Key.None, type, 0, true, false) { }

    public Column(Enums.CommandType commandType, Table table, string name, string alias, Key key, VariableType type, bool autoincrement) :
        this(Guid.NewGuid(), commandType, table, name, alias, key, type, 0, true, autoincrement)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, string alias, Key key, VariableType type, int length, bool notNul) :
        this(Guid.NewGuid(), commandType, table, name, alias, key, type, length, notNul, false)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, string alias, Key key, VariableType type, int length) :
        this(Guid.NewGuid(), commandType, table, name, alias, key, type, length, true, false)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, string alias, Key key, VariableType type) :
        this(Guid.NewGuid(), commandType, table, name, alias, key, type, 0, true, false)
    { }

    public Column(Enums.CommandType commandType, Table table, string name, string alias, VariableType type, bool autoincrement) :
        this(Guid.NewGuid(), commandType, table, name, alias, Key.None, type, 0, true, autoincrement)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, string alias, VariableType type, int length, bool notNul) :
        this(Guid.NewGuid(), commandType, table, name, alias, Key.None, type, length, notNul, false)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, string alias, VariableType type, int length) :
        this(Guid.NewGuid(), commandType, table, name, alias, Key.None, type, length, true, false)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, string alias, VariableType type) :
        this(Guid.NewGuid(), commandType, table, name, alias, Key.None, type, 0, true, false)
    { }

    public Column(Enums.CommandType commandType, Table table, string name, Key key, VariableType type, bool autoincrement) :
        this(Guid.NewGuid(), commandType, table, name, "", key, type, 0, true, autoincrement)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, Key key, VariableType type, int length, bool notNul) :
        this(Guid.NewGuid(), commandType, table, name, "", key, type, length, notNul, false)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, Key key, VariableType type, int length) :
        this(Guid.NewGuid(), commandType, table, name, "", key, type, length, true, false)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, Key key, VariableType type) :
        this(Guid.NewGuid(), commandType, table, name, "", key, type, 0, true, false)
    { }

    public Column(Enums.CommandType commandType, Table table, string name, VariableType type, bool autoincrement) :
        this(Guid.NewGuid(), commandType, table, name, "", Key.None, type, 0, true, autoincrement)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, VariableType type, int length, bool notNul) :
        this(Guid.NewGuid(), commandType, table, name, "", Key.None, type, length, notNul, false)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, VariableType type, int length) :
        this(Guid.NewGuid(), commandType, table, name, "", Key.None, type, length, true, false)
    { }
    public Column(Enums.CommandType commandType, Table table, string name, VariableType type) :
        this(Guid.NewGuid(), commandType, table, name, "", Key.None, type, 0, true, false)
    { }
}
