using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IoT.Core;

public static class ServiceRegistration
{
    public static void AddIotServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHostedService<IotWorker>();
    }
}

