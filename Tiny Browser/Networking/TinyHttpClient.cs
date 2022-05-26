namespace Tiny_Browser.Networking;

public class TinyHttpClient
{
    public string? SendHttpRequest(string hostname, int port, string http11Request)
    {
        TcpConnection tcpConnection = new TcpConnection(hostname, port);

        tcpConnection.SendMessage(http11Request);

        var receive = tcpConnection.WaitForResponse();

        receive.Wait();

        return receive.Result;
    }
}