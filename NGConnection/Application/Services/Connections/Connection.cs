using NGConnection.Interfaces;

namespace NGConnection;

public abstract class Connection : IConnection
{
    protected string ConnectionString { get; set; }
    protected string IpAddress { get; set; }
    public string DataBaseName { get; protected set; }
    protected string UserName { get; set; }
    protected string Password { get; set; }
    protected string Port { get; set; }
    protected string TimeOut { get; set; }
    protected Dictionary<string, string> Properties { get; set; }


    protected bool ddlCommandsActivated = false;

    public Connection(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut, Dictionary<string, string> properties)
    {
        IpAddress = ipAddress;
        DataBaseName = dataBaseName;
        UserName = userName;
        Password = password;
        Port = port.ToString();
        TimeOut = timeOut.ToString();
        Properties = properties;
    }
    public Connection(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut) : 
        this(ipAddress, dataBaseName, userName, password, port, timeOut, []) { }
    public Connection(string ipAddress, string dataBaseName, string userName, string password, int port) : 
        this(ipAddress, dataBaseName, userName, password, port, 0) { }
    public Connection(string ipAddress, string dataBaseName, string userName, string password) : 
        this(ipAddress, dataBaseName, userName, password, 0) { }
    public Connection(string connectionString) => SetConnectionString(connectionString);

    protected virtual void SetConnectionString(string ConnectionString) { }
    protected virtual string GetConnectionString() => "";
    protected object GetProperty(string property)
    {
        if (Properties.TryGetValue(property, out string result))
            Properties.Remove(property);

        return result;
    }

    public void SetTimeOut(int timeOut) => TimeOut = timeOut.ToString();
}
