
using Mysqlx.Prepare;
using NGConnection.Attributes;
using NGConnection.Domain.Models;
using NGConnection.Interfaces;
using NGConnection.Models;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;

namespace NGConnection;

public abstract class ConnectionDataBases : Connection, IConnectionDataBases
{
    protected IDbConnection dbConnection;
    protected IDbCommand dbCommand;
    protected IDbTransaction dbTransaction;
    protected IDataReader dataReader;

    public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut, Dictionary<string, string> properties)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut, properties) { }
    public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : this(ipAddress, dataBaseName, userName, password, port, timeOut, []) { }
    public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password, int port)
        : this(ipAddress, dataBaseName, userName, password, port, 0) { }
    public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password)
        : this(ipAddress, dataBaseName, userName, password, 0) { }
    public ConnectionDataBases(string connectionString)
        : base(connectionString) { }

    public bool HasTransaction { get; private set; }

    public void Dispose()
    {
        dataReader?.Dispose();
        dataReader = null;
        dbCommand?.Dispose();
        dbCommand = null;
        dbTransaction?.Dispose();
        dbTransaction = null;
    }
    public bool TestConnection() => OpenConnection() | CloseConnection();
    public virtual bool OpenConnection()
    {
        if (dbConnection == null)
            throw new NGException("", $"object dbConnectionction not instantiate", GetType().FullName + "/OpenConnection");

        if (dbConnection.State != ConnectionState.Open)
            dbConnection.Open();
        if (dbConnection.State != ConnectionState.Open)
            throw new NGException("", $"Unable to open connection, connection is {dbConnection.State}", GetType().FullName + "/OpenConnection");

        return true;
    }
    public virtual bool CloseConnection()
    {
        if (!HasTransaction)
        {
            dbConnection?.Close();
            Dispose();
        }

        return true;
    }
    public virtual void BeginTransaction()
    {
        OpenConnection();
        dbTransaction = dbConnection.BeginTransaction();
        HasTransaction = true;
    }
    public virtual void CommitTransaction()
    {
        dbTransaction?.Commit();
        HasTransaction = false;
        CloseConnection();
    }
    public virtual void RollbackTransaction()
    {
        dbTransaction?.Rollback();
        HasTransaction = false;
        CloseConnection();
    }

    public virtual IDataReader ExecuteReader(string command, List<ConnandParameter> dataParameters)
    {
        PrepareExecute(command, dataParameters);
        var observableDataReader = new ObservableDataReader(dbCommand.ExecuteReader());

        observableDataReader.OnCompleted += OnDataDeaderIsCompleted;

        dataReader = observableDataReader;

        return dataReader;
    }
    public virtual IDataReader ExecuteReader(ICommand command) => 
        ExecuteReader(command?.Query ?? "", command?.DataParameters);
    public virtual int ExecuteNonQuery(string command, List<ConnandParameter> dataParameters)
    {
        PrepareExecute(command, dataParameters);
        int retorno = dbCommand.ExecuteNonQuery();

        CloseConnection();

        return retorno;
    }
    public virtual int ExecuteNonQuery(ICommand command) => 
        ExecuteNonQuery(command?.Query ?? "", command?.DataParameters);

    private void PrepareExecute(string command, List<ConnandParameter> dataParameters)
    {
        OpenConnection();
        if (dbConnection?.State != ConnectionState.Open)
            throw new InvalidOperationException("A conexão com o banco não está aberta.");

        if (string.IsNullOrWhiteSpace(command))
            throw new ArgumentException("A consulta SQL está vazia.");

        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = command;

        AddParameters(dbCommand, dataParameters);
    }
    private static void AddParameters(IDbCommand dbCommand, List<ConnandParameter> dataParameters)
    {
        dataParameters
            .ForEach(
                dataParameter =>
                {
                    dbCommand.Parameters
                        .Add(dataParameter
                            .Parse(dbCommand.CreateParameter()));
                }
            );
    }
    private void OnDataDeaderIsCompleted() =>
        CloseConnection();

    public virtual string GetCommandCreateDataBase(DataBase command) =>
        throw new NGException("", "Method not implemented", GetType().FullName + "/GetCommandCreateDataBase");
    public virtual string GetCommandAlterDataBase(DataBase command) =>
        throw new NGException("", "Method not implemented", GetType().FullName + "/GetCommandAlterDataBase");

    public virtual string GetCommandDropDataBase(DataBase command) =>
        throw new NGException("", "Method not implemented", GetType().FullName + "/GetCommandDropDataBase");
    public virtual string GetCommandCreateTable(Table command) =>
        throw new NGException("", "Method not implemented", GetType().FullName + "/GetCommandCreateTable");
    public virtual string GetCommandAlterTable(Table command) =>
        throw new NGException("", "Method not implemented", GetType().FullName + "/GetCommandAlterTable");
    public virtual string GetCommandDropTable(Table command) =>
        throw new NGException("", "Method not implemented", GetType().FullName + "/GetCommandDropTable");
    public virtual string GetCommandAddColumn(Column command) =>
        throw new NGException("", "Method not implemented", GetType().FullName + "/GetCommandAddColumn");
    public virtual string GetCommandModifyColumn(Column command) =>
        throw new NGException("", "Method not implemented", GetType().FullName + "/GetCommandModifyColumn");
    public virtual string GetCommandRemoveColumn(Column command) =>
        throw new NGException("", "Method not implemented", GetType().FullName + "/GetCommandRemoveColumn");

    public virtual string GetCommandInsert(Insert command)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine($"INSERT INTO {command.Name}");
        stringBuilder.AppendLine($"({String.Join(',', command.Fields.Keys)})");
        stringBuilder.AppendLine($"VALUES");
        stringBuilder.AppendLine($"({String.Join(',', command.Fields.Values)})");

        return stringBuilder.ToString();
    }
    public virtual string GetCommandUpdate(Update command)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine($"UPDATE {command.Name} ");
        stringBuilder.AppendLine($"SET {String.Join(',', command.Fields.Keys.Zip(command.Fields.Values, (fields, values) => $"{fields}={values}").ToArray())} ");

        return stringBuilder.ToString();
    }
    public virtual string GetCommandDelete(Delete command)
    {
        return @$"DELETE FROM {command.Name} ";
    }
    public virtual string GetCommandWhere(Where command)
    {
        return $"WHERE {command.ExpressionData.GetQuery()}";
    }
}