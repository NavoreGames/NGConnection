using NGConnection.Interface;
using NGNotification;
using NGNotification.Enum;
using System.Collections.Generic;

namespace NGConnection
{
	public abstract class Connection : IConnection
	{
		public string IpAddress { get; protected set; }
		public string DataBaseName { get; protected set; }
		public string UserName { get; protected set; }
		public string Password { get; protected set; }
		public int Port { get; protected set; }
		public int TimeOut { get; protected set; }

		public Connection(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut = 30)
		{
			this.IpAddress = ipAddress;
			this.DataBaseName = dataBaseName;
			this.UserName = userName;
			this.Password = password;
			this.Port = port;
			this.TimeOut = timeOut;
		}
		public Connection(string ipAddress, string dataBaseName, string userName, string password, int timeOut) : this(ipAddress, dataBaseName, userName, password, 0, timeOut) { }
		public Connection(string ipAddress, string dataBaseName, string userName, string password) : this(ipAddress, dataBaseName, userName, password, 0) { }
		public Connection(string connectionString) => SetConnectionString(connectionString);

		public void SetTimeOut(int timeOut) => this.TimeOut = timeOut;
		protected virtual void SetConnectionString(string ConnectionString) { }
		public virtual string GetConnectionString() { return ""; }
		public virtual bool TestConnection() { return OpenConnection() | CloseConnection(); }
		public virtual bool OpenConnection(bool openTansaction = false) => new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/OpenConnection")).Success;
		public virtual bool CloseConnection(bool rollBack = false) => new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/CloseConnection")).Success;
		public virtual int ExecuteNonQuery(bool openConnection, bool tansaction, params string[] commands) => (int)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/ExecuteNonQuery"), -1).Data;
		public virtual int ExecuteNonQuery(bool openConnection, params string[] commands) => ExecuteNonQuery(openConnection, false, commands);
		public virtual int ExecuteNonQuery(params string[] commands) => ExecuteNonQuery(false, false, commands);
		public virtual object ExecuteScalar(bool openConnection, bool tansaction, params string[] commands) => new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/ExecuteScalar"), null).Data;
		public virtual object ExecuteScalar(bool openConnection, params string[] commands) => ExecuteScalar(openConnection, false, commands);
		public virtual object ExecuteScalar(params string[] commands) => ExecuteScalar(false, false, commands);
		public virtual IEnumerable<object> ExecuteReader(bool openConnection, string commands) => (IEnumerable<object>)new Response(false, 400, new NGMessage(Category.Warning, "Método não implementado", "Método não implementado", this.GetType().FullName + "/ExecuteReader"), null).Data;
		public virtual IEnumerable<object> ExecuteReader(string commands) => ExecuteReader(false, commands);
	}
}
