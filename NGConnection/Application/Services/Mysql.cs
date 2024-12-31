using System.Data;
using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NGConnection.Models;

namespace NGConnection;

public sealed class Mysql : ConnectionDataBases
{
    public Mysql(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut, Dictionary<string, string> properties)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut, properties) { }
    public Mysql(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
    public Mysql(string ipAddress, string dataBaseName, string userName, string password, int port)
        : base(ipAddress, dataBaseName, userName, password, port) { }
    public Mysql(string ipAddress, string dataBaseName, string userName, string password)
        : base(ipAddress, dataBaseName, userName, password) { }
    public Mysql(string connectionString)
        : base(connectionString) { }

    protected override void SetConnectionString(string ConnectionString)
    {
        Properties = [];
        ConnectionString.Split(';').ToList().Select(s => s.Split('=')).ToList().ForEach(f => { Properties.Add(f[0].Trim(), f[1].Trim()); });

        IpAddress = GetProperty("Server").ToString();
        DataBaseName = GetProperty("Database").ToString();
        UserName = GetProperty("Uid").ToString();
        Password = GetProperty("Pwd").ToString();
        TimeOut = GetProperty("Connection Timeout").ToString() ?? "0";
    }

    protected override string GetConnectionString() => $@"Server = {IpAddress}; Database = {DataBaseName}; Uid = {UserName}; Pwd = {Password}; Connection Timeout = {TimeOut};";

    public override bool OpenConnection(bool openTansaction = false)
    {
        connection = new MySqlConnection(GetConnectionString());
        return base.OpenConnection(openTansaction);
    }

    //private int Max(Type pTypeOf)
    //{
    //	try
    //	{
    //		//this.OpenConnection(true);
    //		////IDataReader lIDataReader = this.ExecuteReader("SET @ret = (SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = \"" + this.DataBase + "\" AND TABLE_NAME =  \"" + pTypeOf.Name + "\");"+
    //		////											  "SET @sql = CONCAT('ALTER TABLE User AUTO_INCREMENT = ', @ret + 1);"+
    //		////											  "PREPARE st FROM @sql;"+
    //		////											  "EXECUTE st;"+
    //		////											  "SELECT @ret;");
    //		//IDataReader lIDataReader = this.ExecuteReader("SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = \"" + this.DataBase + "\" AND TABLE_NAME =  \"" + pTypeOf.Name + "\";");
    //		//while (lIDataReader.Read())
    //		//{
    //		//	ret = Convert.ToInt32(lIDataReader[0]);
    //		//}
    //		//lIDataReader.Dispose();
    //		//this.ExecuteNonQuery("ALTER TABLE " + pTypeOf.Name + " AUTO_INCREMENT =  " + (1 + ret).ToString() + ";", false);

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
