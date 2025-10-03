using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Iot.Core;

public static class ServiceRegistration
{
    public static void AddIotServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHostedService<IotWorker>();
    }
}

