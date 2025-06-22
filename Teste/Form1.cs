using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using NGConnection;
using NGConnection.Enums;
using NGConnection.Interfaces;
using NGConnection.Models;
using NGEntity;

namespace Teste
{
    public partial class Form1 : Form
    {
        private Sqlite sqlite;
        private Mysql mysql;
        private Http http;
        private Ftp ftp;

        private string IpAddress = "0.0.0.0";
        private string DataBaseName = "YourDataBase";
        private string UserName = "UserName";
        private string Password = "********";
        private string TimeOut = "30";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ExecutarComandoInsert();

            //ExecutarComandoUpdate();

            //ExecutarComandoSelect();

            //ExecutarComandoDdl();

            //ExecutarComando();
        }

        private void ExecutarComando()
        {
            sqlite = new Sqlite("C:\\Users\\willg\\Meu Drive", "DataBaseTeste", "u758086818_NGTroia", "#Navore2019");
            //sqlite.TestConnection();
            //sqlite.OpenConnection();

            //sqlite.BeginTransaction();

            ICommand command = new Command("select * from teste");
            using var reader = sqlite.ExecuteReader(command);

            List<object> retorno = [];
            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                reader.GetValues(values);
                retorno.Add(values);
            }

            command = new Command("update teste set text = 'terceiro' where id = 3");
            var v1 = sqlite.ExecuteNonQuery(command);
            
            //sqlite.CommitTransaction();

            //ICommand command = new Command("select * from teste");
            //ICommand command = new Command("update teste set text = 'terceiro' where id = @Id");
            //command.DataParameters = new() { new ConnandParameter("@Id", 3, DbType.Int16) };

            //var v = sqlite.Execute(command);

            //for (int i = 100; i < 10000; i++)
            //{
            //    ICommand command = new Command($"insert into teste select null,'Elemento{i}'");
            //    sqlite.Execute(command);
            //}


            //sqlite.CloseConnection();
            //System.Diagnostics.Debug.WriteLine(table.ToString());


            //using var reader = sqlite.ExecuteReader(command);

            //List<object> retorno = [];
            //while (reader.Read())
            //{
            //    object[] values = new object[reader.FieldCount];
            //    reader.GetValues(values);
            //    retorno.Add(values);
            //}
        }

        private void ExecutarComandoDdl()
        {
            sqlite = new Sqlite("C:\\Users\\willg\\Meu Drive", "DataBaseTeste", "u758086818_NGTroia", "#Navore2019");
            //sqlite.TestConnection();
            
            ICommand dataBase = new DataBase(DdlCommandType.Create, "DataBaseTeste");
            dataBase.SetCommand(sqlite);
            
            ICommand table = new Table(DdlCommandType.Create, (DataBase)dataBase, "Teste");
            table.SetCommand(sqlite);


            System.Diagnostics.Debug.WriteLine(table.ToString());
        }
        private void ExecutarComandoUpdate()
        {
            sqlite = new Sqlite("C:\\Users\\willg\\Meu Drive", "DataBaseTeste", "u758086818_NGTroia", "#Navore2019");
            //sqlite.TestConnection();

            Update update = new Update();
            update.SetValues(new User());
            update.SetCommand(sqlite);
            var v = update.Query;

            int fk = 2;
            Expression<Func<User, bool>> expression = user => (1==1 && user.IdUser == 1 && (user.FkAddress == fk || user.Email.Contains("fdsfsd"))); 
            Where where = new Where();
            //where.SetValues(new User());
            where.SetValues(expression);
            where.SetCommand(sqlite);
            string s = where.ToString();

            //System.Diagnostics.Debug.WriteLine(table.ToString());
        }

        private void ExecutarComandoInsert()
        {
            sqlite = new Sqlite("C:\\Users\\willg\\Meu Drive", "DataBaseTeste", "u758086818_NGTroia", "#Navore2019");
            //sqlite.TestConnection();
            Insert insert = new Insert();
            insert.SetValues(new User());
            insert.SetCommand(sqlite);
            var v1 = insert.Query;
            var v = sqlite.GetCommandInsert(insert);

            //System.Diagnostics.Debug.WriteLine(table.ToString());
        }

        private void ExecutarComandoSelect()
        {
            sqlite = new Sqlite("C:\\Users\\willg\\Meu Drive", "DataBaseTeste", "u758086818_NGTroia", "#Navore2019");
            //sqlite.TestConnection();


            var v = sqlite.ExecuteReader("Select * from Teste where id = @id", [new("@id", 1, DbType.Int32)]);


            //System.Diagnostics.Debug.WriteLine(table.ToString());
        }


        private void Teste()
        {
            Mysql mysql1 = new Mysql("IpAddress", "DataBaseName", "UserName", "Password");
            Mysql mysql2 = new Mysql($@"Server = {IpAddress}; Database = {DataBaseName}; Uid = {UserName}; Pwd = {Password}; Connection Timeout = {TimeOut}");


            http = new Http("http://navoregames.com/", "", "u758086818.ngtroia", "@ftpNgtroia1385@");


            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //sqlite = new Sqlite("", "u758086818_NGTroia.db", "u758086818_NGTroia", "#Navore2019");
            //mysql = new Mysql("sql802.main-hosting.eu", "u758086818_NGTroia", "u758086818_NGTroia", "@NGTroia1385@", 500);
            ////mysql = new Mysql("45.152.46.52", "u758086818_NGTroia", "u758086818_NGTroia", "@NGTroia1385@");
            //http = new Http("http://navoregames.com/", "", "u758086818.ngtroia", "@ftpNgtroia1385@");
            //ftp = new Ftp("ftp://navoregames.com/", "", "u758086818.ngtroia", "@ftpNgtroia1385@");



            //IEnumerable<object> obj = sqlite.ExecuteReader(true, "Select * from Country");


            try
            {


                //bool ret = mysql.TestConnection();

                // byte[] bytes = ftp.Select(sqlite.DataBaseName);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
