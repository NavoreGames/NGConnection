namespace NGConnection;

public class Delete : Command
{
    public Where Where { get; set; }

    public Delete() { }
    public Delete(string tableName)
    {
        Name = tableName;
    }

    public override void SetValues(object source)
    {
        Name = GetTableName(source);
    }

    //public override ICommandDml SetCommand(Type connectionType)
    //{
    //    Command = @$"DELETE FROM {Table}";

    //    return this;
    //}
}
