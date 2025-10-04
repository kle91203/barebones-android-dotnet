using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IoT.Core;

public sealed class IotWorker(ILogger<IotWorker> log) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        log.LogInformation("IoT worker started");
        while (!stoppingToken.IsCancellationRequested)
        {
            log.LogInformation("heartbeat {time}", DateTimeOffset.UtcNow);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}

