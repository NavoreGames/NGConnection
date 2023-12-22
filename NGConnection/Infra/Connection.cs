using NGConnection.Interface;
using NGNotification;
using NGNotification.Enum;
using System.Collections.Generic;

namespace NGConnection
{
	public abstract class Connection : IConnection
	{
		protected string IpAddress { get; set; }
		protected string DataBaseName { get; set; }
		protected string UserName { get; set; }
		protected string Password { get; set; }
		protected int Port { get; set; }
		protected int TimeOut { get; set; }
		protected string ConnectionString { get; set; }

		public Connection(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut = 30)
		{
			IpAddress = ipAddress;
			DataBaseName = dataBaseName;
			UserName = userName;
			Password = password;
			Port = port;
			TimeOut = timeOut;
		}
		public Connection(string ipAddress, string dataBaseName, string userName, string password, int timeOut) : this(ipAddress, dataBaseName, userName, password, 0, timeOut) { }
		public Connection(string ipAddress, string dataBaseName, string userName, string password) : this(ipAddress, dataBaseName, userName, password, 0) { }
		public Connection(string connectionString) => SetConnectionString(connectionString);

		protected virtual void SetConnectionString(string ConnectionString) { }
		protected virtual string GetConnectionString() => "";

		public void SetTimeOut(int timeOut) => this.TimeOut = timeOut;
		public virtual bool TestConnection() { return OpenConnection() | CloseConnection(); }
		public virtual bool OpenConnection(bool openTansaction = false) => throw new NGException("", "Method not implemented in child class", this.GetType().FullName + "/OpenConnection");
		public virtual bool CloseConnection(bool rollBack = false) => throw new NGException("", "Method not implemented in child class", this.GetType().FullName + "/CloseConnection");
		//public virtual int ExecuteNonQuery(bool openConnection, bool tansaction, params string[] commands) => (int)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/ExecuteNonQuery"), -1).Data;
		//public virtual int ExecuteNonQuery(bool openConnection, params string[] commands) => ExecuteNonQuery(openConnection, false, commands);
		//public virtual int ExecuteNonQuery(params string[] commands) => ExecuteNonQuery(false, false, commands);
		//public virtual object ExecuteScalar(bool openConnection, bool tansaction, params string[] commands) => new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/ExecuteScalar"), null).Data;
		//public virtual object ExecuteScalar(bool openConnection, params string[] commands) => ExecuteScalar(openConnection, false, commands);
		//public virtual object ExecuteScalar(params string[] commands) => ExecuteScalar(false, false, commands);
		//public virtual IEnumerable<object> ExecuteReader(bool openConnection, string commands) => (IEnumerable<object>)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/ExecuteReader"), null).Data;
		//public virtual IEnumerable<object> ExecuteReader(string commands) => ExecuteReader(false, commands);
	}
}
