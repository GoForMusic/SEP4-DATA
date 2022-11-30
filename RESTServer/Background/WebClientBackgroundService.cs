using WebSocket.Clients;
using WebSocket.Interfaces;

namespace WebApplication1.Background;

public class WebClientBackgroundService : BackgroundService
{
    private RecordClient _webClient;
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _webClient = new RecordClient();
            while (!stoppingToken.IsCancellationRequested)
            {
                _webClient.WsClientTest();
                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }
}