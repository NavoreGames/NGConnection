using NGNotification.Models;
using System;

namespace NGConnection.Exceptions
{
    public class InvalidConnection: NGException
    {
        public InvalidConnection(string header, string message) : base(header, message, "") { }
        public InvalidConnection(string message) : base("", message) { }
    }
    public class DataBaseDivergent : NGException
    {
        public DataBaseDivergent(string header, string message) : base(header, message, "") { }
        public DataBaseDivergent(string message) : base("", message) { }
    }
}
