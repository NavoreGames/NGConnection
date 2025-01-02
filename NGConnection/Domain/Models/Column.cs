using NGConnection.Enums;

namespace NGConnection.Models;

public class Column
{
    #region PROPERTY
    public string Name { get; private set; }
    public string Alias { get; private set; }
	public DdlActionType DdlActionType { get; private set; }
    public Key Key { get; private set; }
    public VariableType Type { get; private set; }
	public int Length { get; private set; }
	public bool NotNull { get; private set; }
	public bool Autoincrement { get; private set; }
	public string AlterColumnalias { get; private set; }
    #endregion

    private Column() { }

    private Column(string name, string alias, DdlActionType ddlActionType, Key key, VariableType type, int length, bool notNull, bool autoincrement, string alterColumnalias)
	{
		Name = name;
        Alias = alias;
        DdlActionType = ddlActionType;
		Type = type;
		Length = length;
		NotNull = notNull;
		Autoincrement = autoincrement;
		Key = key;
		AlterColumnalias = alterColumnalias;
	}

    public Column(string name, string alias, DdlActionType ddlActionType, Key key, VariableType type, bool autoincrement) :
        this(name, alias, ddlActionType, key, type, 0, true, autoincrement, "") { }
    public Column(string name, string alias, DdlActionType ddlActionType, Key key, VariableType type, int length, bool notNul) :
        this(name, alias, ddlActionType, key, type, length, notNul, false, "") { }
    public Column(string name, string alias, DdlActionType ddlActionType, Key key, VariableType type, int length) :
        this(name, alias, ddlActionType, key, type, length, true, false, "") { }
    public Column(string name, string alias, DdlActionType ddlActionType, Key key, VariableType type) :
        this(name, alias, ddlActionType, key, type, 0, true, false, "") { }

    public Column(string name, string alias, DdlActionType ddlActionType, VariableType type, bool autoincrement) :
        this(name, alias, ddlActionType, Key.None, type, 0, true, autoincrement, "") { }
    public Column(string name, string alias, DdlActionType ddlActionType, VariableType type, int length, bool notNul) :
        this(name, alias, ddlActionType, Key.None, type, length, notNul, false, "") { }
    public Column(string name, string alias, DdlActionType ddlActionType, VariableType type, int length) :
        this(name, alias, ddlActionType, Key.None, type, length, true, false, "") { }
    public Column(string name, string alias, DdlActionType ddlActionType, VariableType type) :
        this(name, alias, ddlActionType, Key.None, type, 0, true, false, "") { }

    public Column(string name, DdlActionType ddlActionType, Key key, VariableType type, bool autoincrement) :
        this(name, "", ddlActionType, key, type, 0, true, autoincrement, "") { }
    public Column(string name, DdlActionType ddlActionType, Key key, VariableType type, int length, bool notNul) :
        this(name, "", ddlActionType, key, type, length, notNul, false, "") { }
    public Column(string name, DdlActionType ddlActionType, Key key, VariableType type, int length) :
        this(name, "",ddlActionType, key, type, length, true, false, "") { }
    public Column(string name, DdlActionType ddlActionType, Key key, VariableType type) :
        this(name, "", ddlActionType, key, type, 0, true, false, "") { }

    public Column(string name, DdlActionType ddlActionType, VariableType type, bool autoincrement) :
        this(name, "", ddlActionType, Key.None, type, 0, true, autoincrement, "") { }
    public Column(string name, DdlActionType ddlActionType, VariableType type, int length, bool notNul) :
        this(name, "", ddlActionType, Key.None, type, length, notNul, false, "") { }
    public Column(string name, DdlActionType ddlActionType, VariableType type, int length) :
        this(name, "", ddlActionType, Key.None, type, length, true, false, "") { }
    public Column(string name, DdlActionType ddlActionType, VariableType type) :
        this(name, "", ddlActionType, Key.None, type, 0, true, false, "") { }

    ///// <summary>
    ///// SOBRECARGA PARA ALTERAR O NOME DA COLUNA.
    ///// </summary>
    //public Column(string columnalias, string alterColumnalias) :
    //	this(columnalias, DdlActionType.Alter, VariableType.None, 0, false, false, Key.None, alterColumnalias){ }
}
