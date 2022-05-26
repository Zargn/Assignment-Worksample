namespace Tiny_Browser.Networking;

public class TinyHttpClient
{
    public string? SendHttpRequest(int port, Http11Request http11Request)
    {
        TcpConnection tcpConnection = new TcpConnection(http11Request.Headers["Host"], port);

        tcpConnection.SendMessage(http11Request.ToString());

        var receive = tcpConnection.WaitForResponse();

        receive.Wait();

        return receive.Result;
    }
}