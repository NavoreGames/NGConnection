namespace NGConnection.Interfaces;

public interface ICommand
{
    Guid Identifier { get; }
    void SetCommand(IConnection connection);
}
