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

    string GetCommandCreateDataBase(DataBase command);
    string GetCommandAlterDataBase(DataBase command);
    string GetCommandDropDataBase(DataBase command);
    string GetCommandCreateTable(Table command);
    string GetCommandAlterTable(Table command);
    string GetCommandDropTable(Table command);
    string GetCommandAddColumn(Column command);
    string GetCommandModifyColumn(Column command);
    string GetCommandRemoveColumn(Column command);
    string GetCommandInsert(Insert command);
    string GetCommandUpdate(Update command);
    string GetCommandDelete(Delete command);
}
