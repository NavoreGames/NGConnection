using System.IO;
using Mono.Data.Sqlite;

namespace NGConnection
{
	public sealed class Sqlite : DataBase
	{
		public Sqlite(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
			: base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
		public Sqlite(string ipAddress, string dataBaseName, string userName, string password, int timeOut)
			: base(ipAddress, dataBaseName, userName, password, timeOut) { }
		public Sqlite(string ipAddress, string dataBaseName, string userName, string password)
			: base(ipAddress, dataBaseName, userName, password) { }
		public Sqlite(string connectionString)
			: base(connectionString) { }

		protected override void SetConnectionString(string ConnectionString)
		{

		}
		protected override string GetConnectionString() => Path.Combine(IpAddress, DataBaseName);

		public override bool OpenConnection(bool openTansaction = false)
		{
			connection = new SqliteConnection(GetConnectionString());
			return base.OpenConnection(openTansaction);
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
}
