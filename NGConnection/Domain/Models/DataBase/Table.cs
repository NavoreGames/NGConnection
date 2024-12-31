using System.Collections.Generic;
using NGConnection.Enums;

namespace NGConnection.Models;

public class Table
{
    public string Alias { get; private set; }
    public string Name { get; private set; }
	public DdlCommandType DdlCommandType { get; private set; }
	public List<Column> Columns { get; private set; }
	public string AlterTableName { get; private set; }

	private Table(string alias, string name, DdlCommandType ddlCommandType, List<Column> columns, string alterTableName)
	{
		Name = name;
        DdlCommandType = ddlCommandType;
		Columns = columns ??= [];
		AlterTableName = alterTableName;
	}
    public Table(string alias, string name, DdlCommandType ddlCommandType, List<Column> columns = null) :
        this(alias, name, ddlCommandType, columns, "") { }
    public Table(string name, DdlCommandType ddlCommandType, List<Column> columns = null) : 
		this("", name, ddlCommandType, columns, "") { }
	/// <summary>
	/// SOBRECARGA PARA ALTERAR O NOME DA TABELA.
	/// </summary>
	public Table(string name, string alterTableName) : 
		this("", name, DdlCommandType.Alter, null, alterTableName) { }
}
