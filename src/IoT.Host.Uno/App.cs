using Iot.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Uno.Extensions.Hosting;

namespace Iot.Host.Uno;

public class App : Application
{
    private IHost? _host;

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args)
            .Configure(host =>
            {
                host.AddIotServices();
                host.ConfigureLogging(logging => logging.AddConsole());
            });

        _host = builder.Build();
        _ = _host.RunAsync(); // background loop
    }
}

