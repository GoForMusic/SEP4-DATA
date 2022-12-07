namespace WebSocket.Interfaces;

public interface IWebClient
{
    Task WSGetData();
    Task WSSendData();
}