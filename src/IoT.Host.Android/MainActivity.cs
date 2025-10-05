using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using IoT.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IoT.Host.Android;

[Activity(Label = "IoT.Host.Android",
          MainLauncher = true,
          Exported = true,
          ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

public class MainActivity : Activity
{

    private IHost? _host;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Log.Debug("IoTWorker", "MainActivity.OnCreate hit");

        var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();
        builder.Logging.ClearProviders();          // optional, start fresh
        builder.Logging.AddProvider(new AndroidLoggerProvider());
        builder.Logging.SetMinimumLevel(LogLevel.Debug);
        builder.AddIotServices();

        _host = builder.Build();
        _host.Start();

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _host?.Dispose();
    }

}
