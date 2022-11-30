using WebSocket.Clients;
using WebSocket.Interfaces;

namespace WebApplication1.Background;

public class WebClientBackgroundService : BackgroundService
{
    private SensorsClient _webClient;
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _webClient = new SensorsClient();
            while (!stoppingToken.IsCancellationRequested)
            {
                _webClient.WsClientTest();
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }
}