using Google.Protobuf.WellKnownTypes;
using System.Xml.Linq;

namespace NGConnection.Models
{
    public class ConnectionParameter : IDataParameter
    {
        public DbType DbType { get; set; }
        public ParameterDirection Direction { get; set; }
        public bool IsNullable => throw new NotImplementedException();
        public string ParameterName { get; set; }
        public string SourceColumn { get; set; }
        public DataRowVersion SourceVersion { get; set; }
        public object Value { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
        public int Size { get; set; }

        public ConnectionParameter(string parameterName, object value, int size, DbType dbType)
        {
            ParameterName = parameterName;
            Value = value;
            Size = size;
            DbType = dbType;
        }
        public ConnectionParameter(string parameterName, object value, DbType dbType) : 
            this(parameterName, value, 0, dbType) { }
    }
}
