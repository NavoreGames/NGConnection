namespace NGConnection;

public sealed class Nosql : ConnectionDataBases
{
    public Nosql(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut, Dictionary<string, string> properties)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut, properties) { }
    public Nosql(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
    public Nosql(string ipAddress, string dataBaseName, string userName, string password, int port)
        : base(ipAddress, dataBaseName, userName, password, port) { }
    public Nosql(string ipAddress, string dataBaseName, string userName, string password)
        : base(ipAddress, dataBaseName, userName, password) { }
    public Nosql(string connectionString)
        : base(connectionString) { }

    protected override void SetConnectionString(string ConnectionString) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/SetConnectionString");
    protected override string GetConnectionString() => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/GetConnectionString");
    public override bool OpenConnection() => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/OpenConnection");
}
