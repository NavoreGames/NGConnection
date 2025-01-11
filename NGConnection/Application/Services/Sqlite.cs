using System.IO;
using Microsoft.Data.Sqlite;

namespace NGConnection;

public sealed class Sqlite : ConnectionDataBases
{
    public Sqlite(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut, Dictionary<string, string> properties)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut, properties) { }
    public Sqlite(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
    public Sqlite(string ipAddress, string dataBaseName, string userName, string password, int port)
        : base(ipAddress, dataBaseName, userName, password, port) { }
    public Sqlite(string ipAddress, string dataBaseName, string userName, string password)
        : base(ipAddress, dataBaseName, userName, password) { }
    public Sqlite(string connectionString)
        : base(connectionString) { }

    protected override void SetConnectionString(string ConnectionString)
    {

    }
    protected override string GetConnectionString() => $@"Data Source={Path.Combine(IpAddress, DataBaseName.Replace(".db", "", StringComparison.OrdinalIgnoreCase))}.db";

    public override bool OpenConnection(bool openTansaction = false)
    {
        string con = GetConnectionString();
        connection = new SqliteConnection(con);
        return base.OpenConnection(openTansaction);
    }

    public override string GetCommandCreateDataBase(DataBase command)
    {
        OpenConnection();
        CloseConnection();
        return @$"-- DATABASE {command.Name} CREATE BY OPEN CONNECTION IN DB NAME";
    }
    public override string GetCommandCreateTable(Table command)
    {
        return @$"CREATE TABLE {command.Name}('')";
    }

    //private int Max(Type pTypeOf)
    //{
    //	try
    //	{
    //		//this.OpenConnection(true);
    //		//this.ExecuteNonQuery("UPDATE SQLITE_SEQUENCE SET seq = seq + 1 WHERE name = \"" + pTypeOf.Name + "\";", false);
    //		//IDataReader lIDataReader = this.ExecuteReader("SELECT seq FROM SQLITE_SEQUENCE WHERE name =  \"" + pTypeOf.Name + "\";");
    //		//while (lIDataReader.Read())
    //		//{
    //		//	ret = Convert.ToInt32(lIDataReader["seq"]);
    //		//}
    //		//this.CloseConnection(true);

    //		return -1;
    //	}
    //	catch (Exception ex)
    //	{
    //		Notification.AddNotification(new NGException(Category.Error, ex.Message, ex.ToString(), ex.StackTrace));
    //		return -1;
    //	}
    //}
}
