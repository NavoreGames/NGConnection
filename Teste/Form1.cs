using System;
using System.Threading;
using System.Windows.Forms;
using MySqlX.XDevAPI;
using NGConnection;
using NGConnection.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Teste
{
    public partial class Form1 : Form
    {
        private Sqlite sqlite;
        private Mysql mysql;
        private Http http;
        private Ftp ftp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Mysql mysql = new Mysql("IpAddress", "DataBaseName", "UserName", "Password");
            Mysql mysql = new Mysql($@"Server = {IpAddress}; Database = {DataBaseName}; Uid = {UserName}; Pwd = {Password}; Connection Timeout = {TimeOut};");

            sqlite = new Sqlite("", "u758086818_NGTroia.db", "u758086818_NGTroia", "#Navore2019");
            sqlite.TestConnection();

            http = new Http("http://navoregames.com/", "", "u758086818.ngtroia", "@ftpNgtroia1385@");


            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //sqlite = new Sqlite("", "u758086818_NGTroia.db", "u758086818_NGTroia", "#Navore2019");
            //mysql = new Mysql("sql802.main-hosting.eu", "u758086818_NGTroia", "u758086818_NGTroia", "@NGTroia1385@", 500);
            ////mysql = new Mysql("45.152.46.52", "u758086818_NGTroia", "u758086818_NGTroia", "@NGTroia1385@");
            //http = new Http("http://navoregames.com/", "", "u758086818.ngtroia", "@ftpNgtroia1385@");
            //ftp = new Ftp("ftp://navoregames.com/", "", "u758086818.ngtroia", "@ftpNgtroia1385@");

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
