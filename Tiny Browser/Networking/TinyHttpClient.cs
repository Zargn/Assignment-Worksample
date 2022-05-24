namespace Tiny_Browser.Networking;

public class TinyHttpClient
{
    public string? SendHttpRequest(string hostname, int port, string request)
    {
        TcpConnection tcpConnection = new TcpConnection(hostname, port);
        tcpConnection.SendMessage(request);

        var receive = tcpConnection.WaitForResponse();

        receive.Wait();

        var result = receive.Result;

        return result;
    }
}