using System.Net.Sockets;

namespace Tiny_Browser.Networking;

public class TcpConnection
{
    public event Action<string> OnMessageReceive;

    private TcpClient tcpClient;
    private StreamWriter streamWriter;
    private StreamReader streamReader;
    
    public TcpConnection(string hostname, int port)
    {
        tcpClient = new TcpClient(hostname, port);
        streamWriter = new StreamWriter(tcpClient.GetStream());
        streamReader = new StreamReader(tcpClient.GetStream());
    }

    public void SendMessage(string request)
    {
        streamWriter.WriteLine(request);
        streamWriter.Flush();
    }

    public async Task<string?> WaitForResponse()
    {
        var response = await streamReader.ReadLineAsync();
        return response;
    }
}