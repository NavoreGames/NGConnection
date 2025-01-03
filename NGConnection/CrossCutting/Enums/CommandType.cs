using NGEnum;

namespace NGConnection.Enums;
public class CommandType : NGEnums<CommandType>
{
	public CommandType() : base(None) { }
	public CommandType(object pObject) : base(pObject) { }
	public CommandType(int pId, object pObject) : base(pId, pObject) { }
}
