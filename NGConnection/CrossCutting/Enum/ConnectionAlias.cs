using NGEnum;
using NGConnection.Interface;

namespace NGConnection.Enum
{
	public sealed class ConnectionSqlite : IConnectionAlias{ }
	public sealed class ConnectionMysql : IConnectionAlias{}
	public sealed class ConnectionFtp : IConnectionAlias{}
	public sealed class ConnectionHttp : IConnectionAlias{}
}
