using NGEnum;

namespace NGConnection.Enums;
public sealed class DdlActionType : NGEnums<DdlActionType>
{
    public static new readonly DdlActionType Add = new("Add");
    public static readonly DdlActionType Remove = new ("Remove");
    public static readonly DdlActionType Modify = new ("Modify");
		

	public DdlActionType() : base(None) { }
	public DdlActionType(object pObject) : base(pObject) { }
	public DdlActionType(int pId, object pObject) : base(pId, pObject) { }

}
