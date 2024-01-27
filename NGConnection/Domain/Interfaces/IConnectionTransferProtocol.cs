namespace NGConnection.Interfaces
{
    public interface IConnectionTransferProtocol
    {
        byte[] Select(string filePath);
    }
}
