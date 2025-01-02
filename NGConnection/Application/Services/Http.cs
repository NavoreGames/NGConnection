namespace NGConnection;

public sealed class Http : ConnectionTransferProtocol
{
    public Http(string ipAddress, string dataBaseName, string userName, string password, int port, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, port, timeOut) { }
    public Http(string ipAddress, string dataBaseName, string userName, string password, int timeOut)
        : base(ipAddress, dataBaseName, userName, password, timeOut) { }
    public Http(string ipAddress, string dataBaseName, string userName, string password)
        : base(ipAddress, dataBaseName, userName, password) { }
    public Http(string connectionString)
        : base(connectionString) { }

    public byte[] Select(string filePath)
    {
        //byte[] ret = null;
        //Stopwatch timer = new Stopwatch();

        //try
        //{
        //	UnityWebRequest lUnityWebRequest = UnityWebRequest.Get(IpAddress + filePath);
        //	DownloadHandler lDownloadHandler = lUnityWebRequest.downloadHandler;
        //	////// NÃO ESTA SENDO USADO (NÃO PRECISA)
        //	//string authorization = Authenticate();
        //	//www.SetRequestHeader("AUTHORIZATION", authorization);
        //	//////   ENVIA O REQUEST  ////////////////////////
        //	lUnityWebRequest.SendWebRequest();
        //	//////  LOOP ENQUANTO O REQUEST NÃO TERMINA
        //	timer.Restart();
        //	while (!lUnityWebRequest.isDone)
        //	{
        //		if (timer.ElapsedMilliseconds >= (TimeOut * 1000))
        //			return (byte[])new Response(false, 400, new NGMessage(Category.Warning, "Request exceeded the timeout."), null).Data;
        //	};
        //	//////  PEGA O CODIGO DO REQUEST ////////////////////
        //	if (lUnityWebRequest.responseCode.ToString().Substring(0, 1) == "2") //// 2xx: Success
        //	{
        //		///// LOOP EMQUANTO NÃO PEGA TODO O RETORNO  //////
        //		timer.Restart();
        //		while (!lDownloadHandler.isDone)
        //		{
        //			if (timer.ElapsedMilliseconds >= (TimeOut * 1000))
        //				return (byte[])new Response(false, 400, new NGMessage(Category.Warning, "Select exceeded the timeout."), null).Data;
        //		};
        //		/////  ATRIBUI O BYTE[] ////////////////////////
        //		ret = lDownloadHandler.data;
        //	}
        //	else
        //	{
        //		/////// COLOCAR AQUI OS CODIGOS DE ERRO (SE PRECISAR)
        //		/////// 1xx: Informational ,  3xx: Redirection, 4xx: Client Error, 5xx: Server Error
        //		return (byte[])new Response(false, 400, new NGMessage(Category.Warning, lUnityWebRequest.error), null).Data;
        //	}
        //	timer.Stop();

        //	if (ret == null)
        //		return (byte[])new Response(false, 400, new NGMessage(Category.Warning, $"Select error: {IpAddress}/{filePath}"), null).Data;
        //	else
        //		return ret;

        //}
        //catch (Exception ex)
        //{
        //	return (byte[])new Response(false, 400, new NGException(Category.Error, ex.Message, ex.ToString(), this.GetType().FullName + "/Select"), null).Data;
        //}

        return default;
    }
    private string Authenticate(string username, string password)
    {
        string auth = UserName + ":" + Password;
        auth = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }
    public bool CopyTo(string pFilePathFrom, string pFilePathTo)
    {
        //Stopwatch timer = new Stopwatch();

        //try
        //{
        //	UnityWebRequest lUnityWebRequest = UnityWebRequest.Get(pFilePathFrom);
        //	DownloadHandler lDownloadHandler = lUnityWebRequest.downloadHandler;
        //	////// NÃO ESTA SENDO USADO (NÃO PRECISA)
        //	//string authorization = Authenticate();
        //	//www.SetRequestHeader("AUTHORIZATION", authorization);
        //	//////   ENVIA O REQUEST  ////////////////////////
        //	lUnityWebRequest.SendWebRequest();
        //	//////  LOOP ENQUANTO O REQUEST NÃO TERMINA
        //	timer.Restart();
        //	while (!lUnityWebRequest.isDone)
        //	{
        //		if (timer.ElapsedMilliseconds >= (TimeOut * 1000))
        //			return new Response(false, 400, new NGMessage(Category.Warning, "Request exceeded the timeout."), false).Success;
        //	};
        //	//////  PEGA O CODIGO DO REQUEST ////////////////////
        //	if (lUnityWebRequest.responseCode.ToString().Substring(0, 1) == "2") //// 2xx: Success
        //	{
        //		///// LOOP EMQUANTO NÃO PEGA TODO O RETORNO  //////
        //		timer.Restart();
        //		while (!lDownloadHandler.isDone)
        //		{
        //			if (timer.ElapsedMilliseconds >= (TimeOut * 1000))
        //				return new Response(false, 400, new NGMessage(Category.Warning, "Select exceeded the timeout."), false).Success;
        //		};
        //		/////  ATRIBUI O BYTE[] ////////////////////////
        //		System.IO.File.WriteAllBytes(pFilePathTo, lDownloadHandler.data);
        //	}
        //	else
        //	{
        //		/////// COLOCAR AQUI OS CODIGOS DE ERRO (SE PRECISAR)
        //		/////// 1xx: Informational ,  3xx: Redirection, 4xx: Client Error, 5xx: Server Error
        //		return new Response(false, 400, new NGMessage(Category.Warning, lUnityWebRequest.error), false).Success;
        //	}
        //	timer.Stop();

        //	return true;
        //}
        //catch (Exception ex)
        //{
        //	return (bool)new Response(false, 400, new NGException(Category.Error, ex.Message, ex.ToString(), this.GetType().FullName + "/Select"), false).Data;
        //}

        return default;
    }
}
