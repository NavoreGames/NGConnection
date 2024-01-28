using System;
using System.IO;
using System.Net;
using System.Text;
using NGNotification.Models;
using NGNotification.Enums;
using NGConnection.Models;

namespace NGConnection
{
    public sealed class Ftp : Connection
    {
        public Ftp(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
        public Ftp(string ipAddress, string dataBaseName, string userName, string password, int timeOut)
            : base(ipAddress, dataBaseName, userName, password, timeOut) { }
        public Ftp(string ipAddress, string dataBaseName, string userName, string password)
            : base(ipAddress, dataBaseName, userName, password) { }
        public Ftp(string connectionString)
            : base(connectionString) { }

        public byte[] Select(string filePath)
        {
            //byte[] ret = null;

            //try
            //{
            //	using (FtpWebResponse webResponse = (FtpWebResponse)CreateFtpWebRequest(filePath, WebRequestMethods.Ftp.DownloadFile).GetResponse())
            //	{
            //		using (Stream input = webResponse.GetResponseStream())
            //		{
            //			byte[] buffer = new byte[16 * 1024];
            //			using (MemoryStream ms = new MemoryStream())
            //			{
            //				int read;
            //				while (input.CanRead && (read = input.Read(buffer, 0, buffer.Length)) > 0)
            //				{
            //					ms.Write(buffer, 0, read);
            //				}

            //				ret = ms.ToArray();
            //			}
            //		}

            //		webResponse.Close();
            //	}

            //	return ret;
            //}
            //catch (Exception ex)
            //{
            //	return (byte[])new Response(false, 400, new NGException(Category.Error, ex.Message, ex.ToString(), this.GetType().FullName + "/Select"), null).Data;
            //}

            return default;
        }
        public int Update(string filePath)
        {
            //try
            //{
            //	FtpWebRequest ftpRequest = CreateFtpWebRequest(filePath, WebRequestMethods.Ftp.UploadFile);
            //	byte[] file;

            //	using (StreamReader sr = new StreamReader(filePath))
            //	{
            //		file = Encoding.UTF8.GetBytes(sr.ReadToEnd());
            //	}

            //	using (Stream sw = ftpRequest.GetRequestStream())
            //	{
            //		sw.Write(file, 0, file.Length);
            //	}

            //	ftpRequest.GetResponse();

            //	return 0;
            //}
            //catch (Exception ex)
            //{
            //	return (int)new Response(false, 400, new NGException(Category.Error, ex.Message, ex.ToString(), this.GetType().FullName + "/Update"), -1).Data;
            //}

            return default;
        }
        public bool Delete(string filePath)
        {
            //try
            //{
            //	CreateFtpWebRequest(filePath, WebRequestMethods.Ftp.DeleteFile).GetResponse();
            //	return true;
            //}
            //catch (Exception ex)
            //{
            //	return (bool)new Response(false, 400, new NGException(Category.Error, ex.Message, ex.ToString(), this.GetType().FullName + "/Delete"), false).Data;
            //}

            return default;
        }

        private FtpWebRequest CreateFtpWebRequest(string filePath, string webRequestMethods)
        {
            FtpWebRequest ftpRequest;
            ftpRequest = (FtpWebRequest)WebRequest.Create(IpAddress + filePath);
            ftpRequest.Credentials = new NetworkCredential(UserName, Password);
            ftpRequest.Method = webRequestMethods;

            return ftpRequest;
        }
    }
}
