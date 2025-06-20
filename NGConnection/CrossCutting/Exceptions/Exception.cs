using Google.Protobuf;
using NGNotification.Models;
using System;
using System.Xml.Linq;

namespace NGConnection.Exceptions
{
    public class InvalidConnection: NGException
    {
        public InvalidConnection(string header, string message) : base(header, message, "") { }
        public InvalidConnection(string message) : base("", message) { }
        public InvalidConnection(Type connectionType) : base($"{connectionType} is an invalid connection.") { }
        public InvalidConnection() : base($"connection is an invalid connection.") { }
    }

    public class DataBaseDivergent : NGException
    {
        public DataBaseDivergent(string header, string message) : base(header, message, "") { }
        public DataBaseDivergent(string message) : base("", message) { }
        public DataBaseDivergent(ICommand command, IConnection connection) : base($"command database {command.Name} divergent from connection database {connection.DataBaseName}.") { }
        public DataBaseDivergent() : base($"command database divergent from connection database.") { }
    }
    public class ExpressionNotImplemented : NGException
    {
        public ExpressionNotImplemented(string header, string message) : base(header, message, "") { }
        public ExpressionNotImplemented(string message) : base("", message) { }
    }
}
