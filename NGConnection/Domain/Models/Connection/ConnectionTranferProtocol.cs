using NGConnection.Interfaces;
using NGNotification.Models;
using System.Collections.Generic;

namespace NGConnection.Models;

public abstract class ConnectionTransferProtocol : Connection, IConnectionTransferProtocol
{
    public ConnectionTransferProtocol(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut, Dictionary<string, string> properties)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut, properties) { }
    public ConnectionTransferProtocol(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
    public ConnectionTransferProtocol(string ipAddress, string dataBaseName, string userName, string password, int port)
        : base(ipAddress, dataBaseName, userName, password, port) { }
    public ConnectionTransferProtocol(string ipAddress, string dataBaseName, string userName, string password)
        : base(ipAddress, dataBaseName, userName, password) { }
    public ConnectionTransferProtocol(string connectionString)
        : base(connectionString) { }

    public byte[] Select(string filePath) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/Select");
}
