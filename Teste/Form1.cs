using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NGConnection;
using NGConnection.Enums;
using NGConnection.Interfaces;
using NGConnection.Models;

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
            ExecutarComandoSelect();

            //ExecutarComandoDdl();
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

        private void ExecutarComandoInsert()
        {
            sqlite = new Sqlite("C:\\Users\\willg\\Meu Drive", "DataBaseTeste", "u758086818_NGTroia", "#Navore2019");
            //sqlite.TestConnection();
            


            //System.Diagnostics.Debug.WriteLine(table.ToString());
        }
        private void ExecutarComandoSelect()
        {
            sqlite = new Sqlite("C:\\Users\\willg\\Meu Drive", "DataBaseTeste", "u758086818_NGTroia", "#Navore2019");
            //sqlite.TestConnection();


            var v = sqlite.ExecuteReader(true, "Select * from Teste where id = @id", [new("@id", 1, DbType.Int32)]).ToList();


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
