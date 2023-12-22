using System;
using System.Collections.Generic;
using System.Data;
using NGConnection.Enum;
using NGNotification;
using NGNotification.Enum;

namespace NGConnection
{
	public abstract class DataBase : Connection
	{
		protected IDbConnection connection;
		protected IDbCommand command;
		protected IDbTransaction transaction;
		protected IDataReader dataReader;

		public DataBase(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
			: base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
		public DataBase(string ipAddress, string dataBaseName, string userName, string password, int timeOut)
			: base(ipAddress, dataBaseName, userName, password, timeOut) { }
		public DataBase(string ipAddress, string dataBaseName, string userName, string password)
			: base(ipAddress, dataBaseName, userName, password) { }
		public DataBase(string connectionString)
			: base(connectionString) { }

		private void Dispose()
		{
			connection.Dispose();
			command.Dispose();
			transaction.Dispose();
			dataReader.Dispose();
		}
		public override bool OpenConnection(bool openTansaction = false)
		{
			if (connection.State != ConnectionState.Open)
			{
				connection.Open();
				if (connection.State == ConnectionState.Open)
				{
					transaction = null;
					if (openTansaction == true)
						transaction = connection.BeginTransaction();

					if (openTansaction == true && transaction == null)
					{
						CloseConnection();
						return new Response(false, 400, new NGMessage(Category.Warning, "Não foi possível abrir a transação.", "Não foi possível abrir a transação.", this.GetType().FullName + "/OpenConnection")).Success;
					}
				}
				else
					return new Response(false, 400, new NGMessage(Category.Warning, "Não foi possível abrir a conexão.", "Status da conexão: " + connection.State.ToString(), this.GetType().FullName + "/OpenConnection")).Success;

			}
			else
				return new Response(false, 400, new NGMessage(Category.Warning, "A conexão já está aberta", "A conexão não deveria estar aberta, algum processo não está fechando a conexão", this.GetType().FullName + "/OpenConnection")).Success;

			return new Response(true).Success;
		}
		public override bool CloseConnection(bool rollBack = false)
		{
			if (connection.State == ConnectionState.Open)
				connection.Close();

			Dispose();

			return new Response(true).Success;
		}
		public override int ExecuteNonQuery(bool openConnection, bool tansaction, params string[] commands)
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
					CloseConnection(false);
			}
			else
				retorno = (int)new Response(false, 400, new NGMessage(Category.Warning, "A conexão não está aberta", "Abra a conexão, com OpenConnection() ou use outra sobrecarga", this.GetType().FullName + "/OpenConnection"), -1).Data;

			Dispose();

			return retorno;
		}
		public override int ExecuteNonQuery(bool openConnection, params string[] commands) => ExecuteNonQuery(openConnection, false, commands);
		public override int ExecuteNonQuery(params string[] commands) => ExecuteNonQuery(false, false, commands);
		public override object ExecuteScalar(bool openConnection, bool tansaction, params string[] commands)
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
					CloseConnection(false);
			}
			else
				retorno = new Response(false, 400, new NGMessage(Category.Warning, "A conexão não está aberta", "Abra a conexão, com OpenConnection() ou use outra sobrecarga", this.GetType().FullName + "/OpenConnection"), null).Data;

			Dispose();

			return retorno;
		}
		public override object ExecuteScalar(bool openConnection, params string[] commands) => ExecuteScalar(openConnection, false, commands);
		public override object ExecuteScalar(params string[] commands) => ExecuteScalar(false, false, commands);
		public override IEnumerable<object> ExecuteReader(bool openConnection, string commands)
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
				retorno = (IEnumerable<object>)new Response(false, 400, new NGMessage(Category.Warning, "A conexão não está aberta", "Abra a conexão, com OpenConnection() ou use outra sobrecarga", this.GetType().FullName + "/ExecuteReader"), null).Data;

			dataTable.Dispose();
			Dispose();

			return retorno;
		}
		public override IEnumerable<object> ExecuteReader(string commands) => ExecuteReader(false, commands);

	}
}
