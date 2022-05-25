namespace Tiny_Browser.Networking;

public class TinyHttpClient
{
    private const string DefaultRequest = "GET / HTTP/1.1\r\nHost: www.acme.com\r\n\r\n"; //"{command} {uri} {protocol-version}\r\n{header-key}: {header-value}\r\n{header-key}: {header-value}\r\n\r\n"

    private string GetRequest(string hostname) => $"GET / HTTP/1.1\r\nHost: {hostname}\r\n\r\n";

    public string? SendHttpRequest(string hostname, int port)
    {
        TcpConnection tcpConnection = new TcpConnection(hostname, port);
        tcpConnection.SendMessage(GetRequest(hostname));

        var receive = tcpConnection.WaitForResponse();

        receive.Wait();

        var result = receive.Result;

        return result;
    }
}