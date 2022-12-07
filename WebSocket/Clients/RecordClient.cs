using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using EFCDataBase.DAOImpl;
using Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocket.Interfaces;
using WebSocket.Stream;

namespace WebSocket.Clients;

public class RecordClient : IWebClient
{
    private IRecordDAO _recordDao;
    private ClientWebSocket _clientWebSocket;
    
    
    
    private readonly string _uriAddress = "wss://iotnet.cibicom.dk/app?token=vnoUeAAAABFpb3RuZXQudGVyYWNvbS5kawhxYha6idspsvrlQ4C7KWA=";
    private readonly string _eui = "0004A30B0021B92F";

    public RecordClient()
    {
        _clientWebSocket = new ClientWebSocket();
        ConnectClientAsync();
    }
    
    
    private Record? ReceivedData(string receivedJson)
    {
        //UpLinkStream? receivedPayload = JsonSerializer.Deserialize<UpLinkStream>(receivedJson,new JsonSerializerOptions()
        //{
        //    PropertyNameCaseInsensitive = true,
        //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //});

        //var details = JObject.Parse(receivedJson);
        //Console.WriteLine(JsonConverter(receivedJson,Inte));
        Console.WriteLine(JsonConvert.SerializeObject(receivedJson, Formatting.Indented));
        var details = JObject.Parse(receivedJson);
        Console.WriteLine(details["data"]);
        
        //Console.WriteLine(receivedPayload.data.Substring(0));
        //Record? localRecord = null;
        //if (!String.IsNullOrEmpty(receivedPayload!.data))
        //{
         char[] array = details["data"].Value<String>().ToCharArray();
         
         double humidity = Convert.ToInt16(array[0].ToString()+array[1].ToString(),16);
         humidity += Convert.ToInt16(array[2].ToString()+array[3].ToString(),16)/100f;
         double temperature= Convert.ToInt16(array[4].ToString()+array[5].ToString(),16);
         temperature+= Convert.ToInt16(array[6].ToString()+array[7].ToString(),16)/100f;
         double co2 = Convert.ToInt16(array[8].ToString()+array[9].ToString(),16);
         co2 += Convert.ToInt16(array[10].ToString()+array[11].ToString(),16)/100f;
            //byte status = Convert.ToByte(receivedPayload.data.Substring(i+3*l,2),16);
           // localRecord = new Record((float)temperature, (float)humidity, (float)co2);
            Console.WriteLine(humidity + " " + temperature + " " + co2);
        //}
        
        return null;
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
                data = "001e001807d0"
            };
            string payloadJson = JsonConvert.SerializeObject(upLinkStream);
            Console.WriteLine("---CALL-DownLink---");
            Console.WriteLine(payloadJson);
            Console.WriteLine("---CALL-DownLink---");
            //send
            await _clientWebSocket.SendAsync(Encoding.UTF8.GetBytes(payloadJson), WebSocketMessageType.Text, true, CancellationToken.None);
            
            Byte[] buffer = new byte[500];
            var x = await _clientWebSocket.ReceiveAsync(buffer,CancellationToken.None);
            var strResult = Encoding.UTF8.GetString(buffer);
            
            Console.WriteLine("---Receive-DownLink---");
            //Console.WriteLine(strResult);
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