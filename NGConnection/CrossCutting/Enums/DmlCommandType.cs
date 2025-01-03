using NGEnum;

namespace NGConnection.Enums;
public sealed class DmlCommandType : CommandType
{
	public static readonly CommandType Delete = new ("Delete");
    public static readonly CommandType Insert = new("Insert");
    public static readonly CommandType Select = new ("Select");
	public static readonly CommandType Update = new ("Update");
	public static readonly CommandType Where = new ("Where");
}
