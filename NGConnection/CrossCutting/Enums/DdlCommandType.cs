using NGEnum;

namespace NGConnection.Enums;
public sealed class DdlCommandType : CommandType
{
    public static readonly CommandType Alter = new("Alter");
    public static readonly CommandType Create = new ("Create");
    public static readonly CommandType Drop = new ("Drop");
}
