using NGConnection.Interfaces;

namespace NGConnection.Models
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

        public void SetTimeOut(int timeOut) => TimeOut = timeOut;
    }
}
