﻿namespace NGConnection;

public sealed class Mongodb : ConnectionDataBases
{
    public Mongodb(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut, Dictionary<string, string> properties)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut, properties) { }
    public Mongodb(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
    public Mongodb(string ipAddress, string dataBaseName, string userName, string password, int port)
        : base(ipAddress, dataBaseName, userName, password, port) { }
    public Mongodb(string ipAddress, string dataBaseName, string userName, string password)
        : base(ipAddress, dataBaseName, userName, password) { }
    public Mongodb(string connectionString)
        : base(connectionString) { }

    protected override void SetConnectionString(string ConnectionString) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/SetConnectionString");
    protected override string GetConnectionString() => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/GetConnectionString");
    public override bool OpenConnection() => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/OpenConnection");
}
