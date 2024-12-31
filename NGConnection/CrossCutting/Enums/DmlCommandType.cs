using NGEnum;

namespace NGConnection.Enums;
public sealed class DmlCommandType : NGEnums<DmlCommandType>
{
	public static readonly DmlCommandType Delete = new ("Delete");
    public static readonly DmlCommandType Insert = new("Insert");
    public static readonly DmlCommandType Select = new ("Select");
	public static readonly DmlCommandType Update = new ("Update");
	public static readonly DmlCommandType Where = new ("Where");

	public DmlCommandType() : base(None) { }
	public DmlCommandType(object pObject) : base(pObject) { }
	public DmlCommandType(int pId, object pObject) : base(pId, pObject) { }

}
