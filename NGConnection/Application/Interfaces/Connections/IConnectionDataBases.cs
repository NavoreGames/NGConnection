namespace NGConnection.Interfaces;

public interface IConnectionDataBases : IConnection
{
    bool TestConnection();
    bool OpenConnection(bool openTansaction = false);
    bool CloseConnection();

    int ExecuteNonQuery(bool openConnection, bool tansaction, params string[] commands);
    int ExecuteNonQuery(bool openConnection, params string[] commands);
    int ExecuteNonQuery(params string[] commands);
    object ExecuteScalar(bool openConnection, bool tansaction, params string[] commands);
    object ExecuteScalar(bool openConnection, params string[] commands);
    object ExecuteScalar(params string[] commands);
    IEnumerable<object> ExecuteReader(bool openConnection, string commands);
    IEnumerable<object> ExecuteReader(string commands);

    string GetCommandInsert(Insert command);
    string GetCommandUpdate(Update command);
    string GetCommandDelete(Delete command);
}
