using NGConnection.Interfaces;
using NGNotification.Models;

namespace NGConnection.Models
{
    public abstract class ConnectionTransferProtocol : Connection, IConnectionTransferProtocol
    {

        public ConnectionTransferProtocol(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
            : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
        public ConnectionTransferProtocol(string ipAddress, string dataBaseName, string userName, string password, int timeOut)
            : base(ipAddress, dataBaseName, userName, password, timeOut) { }
        public ConnectionTransferProtocol(string ipAddress, string dataBaseName, string userName, string password)
            : base(ipAddress, dataBaseName, userName, password) { }
        public ConnectionTransferProtocol(string connectionString)
            : base(connectionString) { }

        public byte[] Select(string filePath) => throw new NGException("", "Method not implemented in child class", GetType().FullName + "/Select");
    }
}
