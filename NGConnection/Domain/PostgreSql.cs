﻿using System.IO;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NGConnection.Models;
using NGNotification.Models;

namespace NGConnection;

public sealed class Postgresql : ConnectionDataBases
{
    public Postgresql(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut, Dictionary<string, string> properties)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut, properties) { }
    public Postgresql(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
    public Postgresql(string ipAddress, string dataBaseName, string userName, string password, int port)
        : base(ipAddress, dataBaseName, userName, password, port) { }
    public Postgresql(string ipAddress, string dataBaseName, string userName, string password)
        : base(ipAddress, dataBaseName, userName, password) { }
    public Postgresql(string connectionString)
        : base(connectionString) { }

    protected override void SetConnectionString(string ConnectionString) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/SetConnectionString");
    protected override string GetConnectionString() => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/GetConnectionString");
    public override bool OpenConnection(bool openTansaction = false) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/OpenConnection");
}
