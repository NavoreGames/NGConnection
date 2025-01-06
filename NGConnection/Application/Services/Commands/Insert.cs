using System.Reflection;

namespace NGConnection;

public class Insert : Command
{
    public string[] Fields { get; private set; }
    public string[] Values { get; private set; }

    public Insert() { }
    public Insert(string tableName, string[] fields, string[] values) 
    {
        Name = tableName;
        Fields = fields;
        Values = values;
    }

    public override void SetValues(object source)
    {
        IEnumerable<PropertyInfo> propertyInfos = GetPropertyInfo(source);
        Fields = GetFields(propertyInfos);
        Values = GetValues(source, propertyInfos);
        Name = GetTableName(source);
    }

  //  public override ICommandDml SetCommand(Type connectionType)
  //  {
  //      Command =
  //      @$"
		//INSERT INTO {Table}
		//({Fields})
		//VALUES
		//({Values})
  //      ";
  //      return this;
  //  }
}
