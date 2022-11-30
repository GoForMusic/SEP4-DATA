using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using EFCDataBase.DAOImpl;
using Entity;
using WebSocket.Interfaces;
using WebSocket.Stream;

namespace WebSocket.Clients;

public class RecordClient : IWebClient
{
    private IRecordDAO _recordDao;
    private ClientWebSocket _clientWebSocket;
    
    
    
    private readonly string _uriAddress = "wss://iotnet.cibicom.dk/app?token=vnoUeAAAABFpb3RuZXQudGVyYWNvbS5kawhxYha6idspsvrlQ4C7KWA=";
    private readonly string _eui = "0004A30B00219CAC";

    public RecordClient()
    {
        _clientWebSocket = new ClientWebSocket();
        ConnectClientAsync();
    }
    
    
    private Record? ReceivedData(string receivedJson)
    {
        UpLinkStream? receivedPayload = JsonSerializer.Deserialize<UpLinkStream>(receivedJson);

        Record? localRecord = null;
        if (!String.IsNullOrEmpty(receivedPayload!.data))
        {
            Console.WriteLine(receivedPayload.data.ToString());
            
            int i = 0;
            int l = 4;
            double temperature = Math.Round(Convert.ToInt16(receivedPayload.data.Substring(i,l),16) / 10.0, 1);
            double humidity = Math.Round(Convert.ToInt16(receivedPayload.data.Substring(i+1*l,l),16) / 10.0, 1);
            double co2 = Convert.ToInt16(receivedPayload.data.Substring(i+2*l,l),16);
            byte status = Convert.ToByte(receivedPayload.data.Substring(i+3*l,2),16);
            localRecord = new Record((float)temperature, (float)humidity, (float)co2);
        }
        
        return localRecord;
    }
    
    private async Task ConnectClientAsync()
    {
        try
        {
            await _clientWebSocket.ConnectAsync(new Uri(_uriAddress), CancellationToken.None);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    
    public async Task WsClientTest()
    {
        try
        {
            Console.WriteLine("WS-CLIENT--------->START");
            DownLinkStream upLinkStream = new()
            {
                cmd = "tx",
                port = 2,
                EUI = _eui,
                data = "E803"
            };
            string payloadJson = JsonSerializer.Serialize(upLinkStream);
            Console.WriteLine("---CALL-DownLink---");
            Console.WriteLine(payloadJson);
            Console.WriteLine("---CALL-DownLink---");
            //send
            await _clientWebSocket.SendAsync(Encoding.UTF8.GetBytes(payloadJson), WebSocketMessageType.Text, true, CancellationToken.None);
            
            Byte[] buffer = new byte[256];
            var x = await _clientWebSocket.ReceiveAsync(buffer,CancellationToken.None);
            var strResult = Encoding.UTF8.GetString(buffer);
            
            Console.WriteLine("---Receive-DownLink---");
            Console.WriteLine(strResult);
            Console.WriteLine("---Receive-DownLink---");
            
            //get data and convert
            Record? getRecord = ReceivedData(strResult);
            
            Console.WriteLine("WS-CLIENT--------->END");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}