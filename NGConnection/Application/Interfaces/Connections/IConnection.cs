namespace NGConnection.Interfaces;

public interface IConnection
{
    string DataBaseName { get; }
    void SetTimeOut(int timeOut);
}
