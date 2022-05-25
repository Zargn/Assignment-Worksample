namespace Tiny_Browser.Networking;

public class TinyHttpClient
{
    public string? SendHttpRequest(string hostname, int port)
    {
        TcpConnection tcpConnection = new TcpConnection(hostname, port);
        // tcpConnection.SendMessage(GetRequest(hostname));
        tcpConnection.SendMessage(new Http11Request("GET", "/", hostname).ToString());

        var receive = tcpConnection.WaitForResponse();

        receive.Wait();

        var result = receive.Result;

        return result;
    }
}