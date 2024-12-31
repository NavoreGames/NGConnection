using NGEnum;

namespace NGConnection.Enums;
public sealed class DdlCommandType : NGEnums<DdlCommandType>
{
    public static readonly DdlCommandType Alter = new("Alter");
    public static readonly DdlCommandType Create = new ("Create");
    public static readonly DdlCommandType Drop = new ("Drop");
		

	public DdlCommandType() : base(None) { }
	public DdlCommandType(object pObject) : base(pObject) { }
	public DdlCommandType(int pId, object pObject) : base(pId, pObject) { }

}
