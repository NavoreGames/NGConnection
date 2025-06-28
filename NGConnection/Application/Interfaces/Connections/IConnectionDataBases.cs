using NGConnection.Domain.Models;
using NGConnection.Models;
using System.Data.Common;

namespace NGConnection.Interfaces;

public interface IConnectionDataBases : IConnection
{
    bool HasTransaction { get; }
    bool TestConnection();
    bool OpenConnection();
    bool CloseConnection();
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();

    IDataReader ExecuteReader(string command, List<ConnandParameter> dataParameters);
    IDataReader ExecuteReader(ICommand command);
    int ExecuteNonQuery(string command, List<ConnandParameter> dataParameters);
    int ExecuteNonQuery(ICommand command);

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
    string GetCommandWhere(Where command);
}
