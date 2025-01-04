using NGEnum;

namespace NGConnection.Enums;
public sealed class DdlActionType : CommandType
{
    public static new readonly CommandType Add = new("Add");
    public static readonly CommandType Remove = new ("Remove");
    public static readonly CommandType Modify = new ("Modify");
}
