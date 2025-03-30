using Google.Protobuf.WellKnownTypes;
using NGConnection.Interfaces;
using NGConnection.Models;
using System.Text;

namespace NGConnection;

public abstract class ConnectionDataBases : Connection, IConnectionDataBases
{
    protected IDbConnection connection;
    protected IDbCommand command;
    protected IDbTransaction transaction;
    protected IDataReader dataReader;

    public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut, Dictionary<string, string> properties)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut, properties) { }
    public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
    public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password, int port)
        : base(ipAddress, dataBaseName, userName, password, port) { }
    public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password)
        : base(ipAddress, dataBaseName, userName, password) { }
    public ConnectionDataBases(string connectionString)
        : base(connectionString) { }

    public void Dispose()
    {
        connection?.Dispose();
        command?.Dispose();
        transaction?.Dispose();
        dataReader?.Dispose();
    }
    public bool TestConnection() => OpenConnection() | CloseConnection();
    public virtual bool OpenConnection(bool openTansaction = false)
    {
        connection.Open();
        if (connection.State != ConnectionState.Open)
            throw new NGException("", $"Unable to open connection, connection is {connection.State}", GetType().FullName + "/OpenConnection");

        transaction = null;
        if (openTansaction == true)
        {
            transaction = connection.BeginTransaction();
            if (transaction == null)
            {
                CloseConnection();
                throw new NGException("", $"Unable to open transaction", GetType().FullName + "/OpenConnection");
            }
        }

        return true;
    }
    public virtual bool CloseConnection()
    {
        connection.Close();
        Dispose();

        return true;
    }

    public virtual int ExecuteNonQuery(bool openConnection, bool tansaction, params string[] commands)
    {
        int retorno = 0;

        ////// ABRE A CONEXÃO SE ESTIVER FECHADA  ///////
        if (openConnection == true)
            OpenConnection(tansaction);
        ////// EXECULTA O COMANDO SE A CONEXÃO FOI ABERTA COM SUCESSO. ////////////
        if (connection.State == ConnectionState.Open)
        {
            command = connection.CreateCommand();
            /////// FOI DIVIDIDO O COMANDO PQ O SQLITE NÃO ACEITA MULTIPLOS COMANDOS SEPARADO POR ; ///////
            foreach (string loopCommand in commands)
            {
                if (loopCommand.Trim() != "")
                {
                    command.CommandText = loopCommand;
                    retorno = command.ExecuteNonQuery();
                }
            }

            ////// FECHA A CONEXÃO  ///////
            if (openConnection == true)
                CloseConnection();
        }
        else
            return NGNotifier.AddWarning(-1, "Connection is not open", "try open connection with method OpenConnection(), or use other overload");

        return retorno;
    }
    public virtual int ExecuteNonQuery(bool openConnection, params string[] commands) => ExecuteNonQuery(openConnection, false, commands);
    public virtual int ExecuteNonQuery(params string[] commands) => ExecuteNonQuery(false, false, commands);
    public virtual object ExecuteScalar(bool openConnection, bool tansaction, params string[] commands)
    {
        object retorno = null;
        ////// ABRE A CONEXÃO SE ESTIVER FECHADA  ///////
        if (openConnection == true)
            OpenConnection(tansaction);
        ////// EXECULTA O COMANDO SE A CONEXÃO FOI ABERTA COM SUCESSO. ////////////
        if (connection.State == ConnectionState.Open)
        {
            command = connection.CreateCommand();
            /////// FOI DIVIDIDO O COMANDO PQ O SQLITE NÃO ACEITA MULTIPLOS COMANDOS SEPARADO POR ; ///////
            foreach (string loopCommand in commands)
            {
                if (loopCommand.Trim() != "")
                {
                    command.CommandText = loopCommand;
                    retorno = command.ExecuteScalar();
                }
            }

            ////// FECHA A CONEXÃO  ///////
            if (openConnection == true)
                CloseConnection();
        }
        else
            return NGNotifier.AddWarning<object>("Connection is not open", "try open connection with method OpenConnection(), or use other overload");

        return retorno;
    }
    public virtual object ExecuteScalar(bool openConnection, params string[] commands) => ExecuteScalar(openConnection, false, commands);
    public virtual object ExecuteScalar(params string[] commands) => ExecuteScalar(false, false, commands);
    public virtual IEnumerable<object> ExecuteReader(bool openConnection, string commands)
    {
        IEnumerable<object> retorno = null;
        DataTable dataTable = new DataTable();
        ////// ABRE A CONEXÃO SE ESTIVER FECHADA  ///////
        if (openConnection == true)
            OpenConnection();
        ////// EXECULTA O COMANDO SE A CONEXÃO FOI ABERTA COM SUCESSO. ////////////
        if (connection.State == ConnectionState.Open)
        {
            if (commands.Trim() != "")
            {
                command = connection.CreateCommand();
                command.CommandText = commands;
                dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);
                retorno = dataTable.AsEnumerable();
                //while (dataReader.Read())
                //{
                //
                //}

                dataTable.Dispose();
            }
            ////// FECHA A CONEXÃO  ///////
            if (openConnection == true)
                CloseConnection();
        }
        else
            return NGNotifier.AddWarning(Enumerable.Empty<object>(), "Connection is not open", "try open connection with method OpenConnection(), or use other overload");

        return retorno;
    }
    public virtual IEnumerable<object> ExecuteReader(string commands) => ExecuteReader(false, commands);


    public virtual IEnumerable<object> ExecuteReader(bool openConnection, string commands, List<ConnectionParameter> dataParameters)
    {
        IEnumerable<object> retorno = null;
        DataTable dataTable = new DataTable();
        ////// ABRE A CONEXÃO SE ESTIVER FECHADA  ///////
        if (openConnection == true)
            OpenConnection();
        ////// EXECULTA O COMANDO SE A CONEXÃO FOI ABERTA COM SUCESSO. ////////////
        if (connection.State == ConnectionState.Open)
        {
            if (commands.Trim() != "")
            {
                command = connection.CreateCommand();
                command.CommandText = commands;
                AddParameters(dataParameters);
                dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);
                retorno = dataTable.AsEnumerable();
                //while (dataReader.Read())
                //{
                //
                //}

                dataTable.Dispose();
            }
            ////// FECHA A CONEXÃO  ///////
            if (openConnection == true)
                CloseConnection();
        }
        else
            return NGNotifier.AddWarning(Enumerable.Empty<object>(), "Connection is not open", "try open connection with method OpenConnection(), or use other overload");

        return retorno;
    }


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
        stringBuilder.AppendLine($"({String.Join(',', command.Fields)})");
        stringBuilder.AppendLine($"VALUES");
        stringBuilder.AppendLine($"({String.Join(',', command.Values)})");

        return stringBuilder.ToString();
    }
    public virtual string GetCommandUpdate(Update command)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine($"UPDATE {command.Name} ");
        stringBuilder.AppendLine($"SET {String.Join(',', command.Fields.Zip(command.Values, (fields, values) => $"{fields}={values}").ToArray())} ");

        return stringBuilder.ToString();
    }
    public virtual string GetCommandDelete(Delete command)
    {
        return @$"DELETE FROM {command.Name} ";
    }
    public virtual string GetCommandWhere(Where command)
    {
        return command.ExpressionData.GetQuery();
    }
    
    private void AddParameters(List<ConnectionParameter> dataParameters)
    {
        dataParameters
            .ForEach(
                dataParameter => 
                {
                    command
                        .Parameters
                            .Add(dataParameter
                                    .Parse(command.CreateParameter())); 
                }
            );
    }
}