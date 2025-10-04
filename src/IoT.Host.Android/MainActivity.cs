using Android.App;
using Android.Content.PM;
using Android.OS;
using IoT.Core;
using Microsoft.Extensions.Hosting;

namespace IoT.Host.Android;

[Activity(Label = "IoT.Host.Android",
          MainLauncher = true,
          ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class MainActivity : Activity
{

    private IHost? _host;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();

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
