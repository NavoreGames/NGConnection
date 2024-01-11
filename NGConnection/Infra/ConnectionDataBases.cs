using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NGConnection.Enum;
using NGConnection.Interface;
using NGNotification;
using NGNotification.Enum;

namespace NGConnection
{
	public abstract class ConnectionDataBases : Connection, IConnectionDataBases
	{
		protected IDbConnection connection;
		protected IDbCommand command;
		protected IDbTransaction transaction;
		protected IDataReader dataReader;

		public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
			: base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
		public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password, int timeOut)
			: base(ipAddress, dataBaseName, userName, password, timeOut) { }
		public ConnectionDataBases(string ipAddress, string dataBaseName, string userName, string password)
			: base(ipAddress, dataBaseName, userName, password) { }
		public ConnectionDataBases(string connectionString)
			: base(connectionString) { }

		public void Dispose()
		{
			connection.Dispose();
			command.Dispose();
			transaction.Dispose();
			dataReader.Dispose();
		}
		public bool TestConnection() => OpenConnection() | CloseConnection();
		public virtual bool OpenConnection(bool openTansaction = false)
		{
			connection.Open();
			if (connection.State != ConnectionState.Open)
				throw new NGException("", $"Unable to open connection, connection is {connection.State}", this.GetType().FullName + "/OpenConnection");

            transaction = null;
			if (openTansaction == true)
			{
				transaction = connection.BeginTransaction();
				if (transaction == null)
				{
					CloseConnection();
					throw new NGException("", $"Unable to open transaction", this.GetType().FullName + "/OpenConnection");
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

            Dispose();

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

            Dispose();

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
                }
                ////// FECHA A CONEXÃO  ///////
                if (openConnection == true)
                    CloseConnection();
            }
            else
                return NGNotifier.AddWarning(Enumerable.Empty<object>(), "Connection is not open", "try open connection with method OpenConnection(), or use other overload");

            dataTable.Dispose();
            Dispose();

            return retorno;
        }
        public virtual IEnumerable<object> ExecuteReader(string commands) => ExecuteReader(false, commands);
    }
}
