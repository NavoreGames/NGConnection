using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using NGConnection.Enum;
using NGNotification;
using NGNotification.Enum;

namespace NGConnection
{
	public sealed class Mysql : DataBase
	{
		public Mysql(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
			: base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
		public Mysql(string ipAddress, string dataBaseName, string userName, string password, int timeOut)
			: base(ipAddress, dataBaseName, userName, password, timeOut) { }
		public Mysql(string ipAddress, string dataBaseName, string userName, string password)
			: base(ipAddress, dataBaseName, userName, password) { }
		public Mysql(string connectionString)
			: base(connectionString) { }

		protected override void SetConnectionString(string ConnectionString)
		{
			Dictionary<string, string> connectionProperties = new Dictionary<string, string>();
			ConnectionString.Split(';').ToList().Select(s => s.Split('=')).ToList().ForEach(f => { connectionProperties.Add(f[0].Trim(), f[1].Trim()); });
			if (connectionProperties.ContainsKey("Server"))
				IpAddress = connectionProperties["Server"];
			if (connectionProperties.ContainsKey("Database"))
				DataBaseName = connectionProperties["Database"];
			if (connectionProperties.ContainsKey("Uid"))
				UserName = connectionProperties["Uid"];
			if (connectionProperties.ContainsKey("Pwd"))
				Password = connectionProperties["Pwd"];
			if (connectionProperties.ContainsKey("Connection Timeout"))
				TimeOut = Convert.ToInt32(connectionProperties["Connection Timeout"]);
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
}
